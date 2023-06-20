using System;

namespace Vculp.Api.Common.Common.Models.BillingDocumentGeneration
{
    /// <summary>
    /// This is a marker interface used to mark messages for the billing document generation commands.
    /// </summary>
    public interface IBillingDocumentGeneratorCommand
    {
        Guid CommandId { get; set; }
    }
}
