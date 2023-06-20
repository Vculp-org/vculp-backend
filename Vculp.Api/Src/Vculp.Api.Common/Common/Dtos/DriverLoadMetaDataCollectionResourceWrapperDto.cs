using System.Collections.Generic;

namespace Vculp.Api.Common.Common.Dtos
{
    public class DriverLoadMetaDataCollectionResourceWrapperDto<T> : LinkedCollectionResourceWrapperDto<T>
        where T : LinkedResourceDto
    {
        public DriverLoadMetaDataCollectionResourceWrapperDto(IEnumerable<T> value, string driverName, int loadsReady, int loadsAccepted)
            : base(value)
        {
            DriverName = driverName;
            LoadsReady = loadsReady;
            LoadsAccepted = loadsAccepted;
        }

        public string DriverName { get; set; }

        public int LoadsReady { get; set; }

        public int LoadsAccepted { get; set; }
    }
}
