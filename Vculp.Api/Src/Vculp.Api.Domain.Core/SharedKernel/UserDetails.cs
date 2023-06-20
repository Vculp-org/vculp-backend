using System;

namespace Vculp.Api.Domain.Core.SharedKernel
{
    public class UserDetails : ValueObject<UserDetails>
    {
        #region Constructors

        private UserDetails()
        {
            State = ObjectState.Unchanged;
        }

        public UserDetails(int id, string name)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"{nameof(id)} must be greater than zero", nameof(id));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"{nameof(name)} is empty or contains only whitespace", nameof(name));
            }

            Id = id;
            Name = name;
        }

        #endregion

        #region Properties

        public int Id { get; private set; }

        public string Name { get; private set; }

        #endregion

        public static UserDetails Empty
        {
            get { return new UserDetails(0, null); }
        }

        protected override bool EqualsCore(UserDetails other)
        {
            return other.Id == Id
                && other.Name == Name;
        }

        protected override int GetHashCodeCore()
        {
            return Id.GetHashCode()
                ^ Name.GetHashCode();
        }
    }
}