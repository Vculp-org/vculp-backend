using System;

namespace Vculp.Api.Common.Common.Models.DocumentGeneration
{
    public class GenerateDocketDocumentCommand : IDocumentGeneratorCommand
    {
        public GenerateDocketDocumentCommand()
        {
            CommandId = Guid.NewGuid();
        }

        public Guid CommandId { get; set; }
        public Guid DeliveryDocketId { get; set; }
    }
}
