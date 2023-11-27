using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vculp.Api.Domain.Core.SharedKernel.Interfaces;
using Vculp.Api.Domain.Core.SharedKernel;

namespace Vculp.Api.Domain.Core.FavoriteRegion
{
    public class FavoriteRegion : AggregateRoot, ICreationAuditable, IUpdateAuditable
    {
        protected FavoriteRegion()
        {
            State = ObjectState.Unchanged;
        }
        public FavoriteRegion(string name, string areaName, double latitute, double longtitude, double radius, Guid userId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"{nameof(name)} cannot be an empty name", nameof(name));
            }
            Name = name;
            AreaName = areaName;
            Latitude = latitute;
            Longitude = longtitude;
            Radius = radius;
            UserId = userId;
        }

        public string Name { get; private set; }
        public string AreaName { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public double Radius { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreationTime { get; private set; }
        public int? CreatedByUserId { get; }
        public string CreatedByUserName { get; }
        public DateTime LastUpdated { get; private set; }
        public int? LastUpdatedByUserId { get; }
        public string LastUpdatedByUserName { get; }
        public bool IsActive { get; private set; }
        public bool IsDeleted { get; private set; }
        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"{nameof(name)} cannot be an empty name", nameof(name));
            }

            Name = name;
            SetStateToUpdated();
        }

        public void ChangeAreaName(string areaName)
        {
            if (string.IsNullOrWhiteSpace(areaName))
            {
                throw new ArgumentException($"{nameof(areaName)} cannot be an empty name", nameof(areaName));
            }

            AreaName = areaName;
            SetStateToUpdated();
        }

        public void ChangeLatitude(double latitude)
        {
            Latitude = latitude;
            SetStateToUpdated();
        }
        public void ChangeLongitude(double longitude)
        {
            Longitude = longitude;
            SetStateToUpdated();
        }
        public void ChangeRadius(double radius)
        {
            Radius = radius;
            SetStateToUpdated();
        }
        public void Activate()
        {
            if (!IsActive)
            {
                IsActive = true;
                SetStateToUpdated();
            }
        }

        public void Deactivate()
        {
            if (IsActive)
            {
                IsActive = false;
                SetStateToUpdated();
            }
        }

        public void Deleted()
        {
            if (!IsDeleted)
            {
                IsDeleted = true;
                SetStateToUpdated();
            }
        }


    }
}
