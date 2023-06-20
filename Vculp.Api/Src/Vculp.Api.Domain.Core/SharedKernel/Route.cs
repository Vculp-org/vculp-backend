using System;

namespace Vculp.Api.Domain.Core.SharedKernel
{
    public class Route : ValueObject<Route>
    {
        #region Constructors
        private Route()
        {
            State = ObjectState.Unchanged;
        }

        public Route(int route)
        {
            if (1 > route || route > 20)
            {
                throw new ArgumentException($"{nameof(route)} must be a value between 1 and 20 (inclusive)", nameof(route));
            }
            RouteValue = route;
        }
        #endregion

        #region Properties
        public int RouteValue { get; private set; }
        #endregion

        #region Methods
        protected override bool EqualsCore(Route other)
        {
            return RouteValue == other.RouteValue;
        }

        protected override int GetHashCodeCore()
        {
            return RouteValue.GetHashCode();
        }
        #endregion
    }
}
