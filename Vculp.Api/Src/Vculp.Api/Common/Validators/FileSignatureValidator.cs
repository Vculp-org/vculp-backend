using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Vculp.Api.Common.Common;

namespace Vculp.Api.Common.Validators
{
    public class FileSignatureValidator : IFileSignatureValidator
    {
        private readonly Dictionary<string, List<byte[]>> _fileSignature =
            new Dictionary<string, List<byte[]>>(StringComparer.OrdinalIgnoreCase)
        {
            { ".pdf", new List<byte[]>
                {
                    new byte[] { 0x25, 0x50, 0x44, 0x46 },
                }
            },
            { ".jpg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
                }
            },
            { ".jpeg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
                }
            },
            { ".png", new List<byte[]>
                {
                    new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A },
                }
            },
        };

        public bool ValidateSignature(string fileExtension, Stream content)
        {
            if (string.IsNullOrWhiteSpace(fileExtension) ||
                content == null)
            {
                return false;
            }

            // Leave the content stream open so that it can be still be used after signature validation is completed.
            content.Position = 0;
            using (var reader = new BinaryReader(content, Encoding.UTF8, leaveOpen: true))
            {
                var signatures = _fileSignature[fileExtension];
                var headerBytes = reader.ReadBytes(signatures.Max(m => m.Length));

                return signatures.Any(signature =>
                    headerBytes.Take(signature.Length).SequenceEqual(signature));
            }
        }

    }
}
