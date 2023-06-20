using System;

namespace Vculp.Api.Common.Common.Models.BillingDocumentGeneration
{
    public class GenerateBillingDocumentForDocketCommand : IBillingDocumentGeneratorCommand
    {
        public GenerateBillingDocumentForDocketCommand()
        {
            CommandId = Guid.NewGuid();
        }

        public Guid CommandId { get; set; }
        public Guid DeliveryDocketId { get; set; }
    }
}
