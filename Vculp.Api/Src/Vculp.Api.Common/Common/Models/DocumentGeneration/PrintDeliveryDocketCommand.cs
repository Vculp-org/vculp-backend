using System;
using System.Collections.Generic;

namespace Vculp.Api.Common.Common.Models.DocumentGeneration
{
    public class PrintDeliveryDocketCommand : IDocumentGeneratorCommand
    {
        public PrintDeliveryDocketCommand()
        {
            CommandId = Guid.NewGuid();
        }

        public Guid CommandId { get; set; }
        public Guid DocketId { get; set; }        
        public IEnumerable<string> CopyTypes { get; set; }
        public string DocketType { get; set; }
        public string DocumentType { get; set; }
    }
}
