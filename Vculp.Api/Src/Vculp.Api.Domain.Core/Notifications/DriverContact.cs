using System;

namespace Vculp.Api.Domain.Core.Notifications
{
    public class DriverContact : Contact
    {
        #region Constructors
        private DriverContact() : base()
        {

        }

        public DriverContact(Guid contactId, string firstName, string lastName, Guid haulierId)
            : base(contactId, firstName, lastName)
        {
            if (haulierId == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(haulierId)} cannot be an empty guid.", nameof(haulierId));
            }

            HaulierId = haulierId;
        }

        #endregion

        #region Properties
        public Guid HaulierId { get; private set; }
        #endregion
    }
}
