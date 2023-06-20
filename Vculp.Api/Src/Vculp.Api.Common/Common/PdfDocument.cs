using System;
using System.Linq;

namespace Vculp.Api.Common.Common
{
    public class PdfDocument
    {
        #region Constructors

        public PdfDocument
        (
            string title,
            byte[] content
        )
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException($"{nameof(title)} is null, empty or contains only whitespace", nameof(title));
            }
            if (content == null || !content.Any())
            {
                throw new ArgumentException($"{nameof(content)} cannot null or empty", nameof(content));
            }

            Title = title;
            Content = content;
        }

        #endregion

        #region Properties

        public string Title { get; private set; }
        public byte[] Content { get; private set; }

        #endregion
    }
}
