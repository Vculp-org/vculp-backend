using System.Collections.Generic;

namespace Vculp.Api.Common.Notifications.ResourceParameters
{
    public class DistributeBulkNotificationResourceParameters
    {
        public IEnumerable<string> Species { get; set; }
        public IEnumerable<string> Category { get; set; }
        public IEnumerable<string> County { get; set; }
        public bool? Organic { get; set; }
    }
}
