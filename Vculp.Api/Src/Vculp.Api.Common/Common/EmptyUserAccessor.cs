using System;

namespace Vculp.Api.Common.Common
{
    public class EmptyUserAccessor : ICurrentUserAccessor
    {
        public Guid? CustomerId => null;

        public int? UserId => null;

        public string Name => null;

        public string HaulierName => null;

        public string DriverCode => null;

        public Guid? VetId => null;

        public Guid? SalesRepId => null;
    }
}
