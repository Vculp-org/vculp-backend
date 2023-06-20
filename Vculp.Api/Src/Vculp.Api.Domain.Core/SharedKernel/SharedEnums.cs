namespace Vculp.Api.Domain.Core.SharedKernel
{
    public class SharedEnums
    {
        public enum VehicleType
        {
            Artic = 0,
            Rigid = 1,
            SteeringAxle = 2,
            Mounty = 3
        }

        public enum DeliverySlot
        {
            AM = 0,
            PM = 1
        }

        public enum NoteType
        {
            Customer = 0,
            OrderLine = 1,
            DeliverySite = 2,
            Order = 3
        }

        public enum ContactType
        {
            Other = 0,
            Primary = 1,
            Secondary = 2
        }

        public enum VehicleTypeProperty
        {
            IsNonBulkVehicle = 0,
            RequiresTrailer = 1,
            IsBulkVehicle = 2
        }
    }
}
