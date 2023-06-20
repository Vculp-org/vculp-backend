using System;

namespace Vculp.Api.Common.Common.Models.DocumentGeneration
{
    /// <summary>
    /// This is a marker interface used to mark messages for the document generation commands.
    /// </summary>
    public interface IDocumentGeneratorCommand
    {
        Guid CommandId { get; set; }
    }
}
