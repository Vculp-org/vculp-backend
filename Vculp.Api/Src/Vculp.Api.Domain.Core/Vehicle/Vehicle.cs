using System;
using System.Collections.Generic;
using System.Linq;
using Vculp.Api.Domain.Core.SharedKernel;
using Vculp.Api.Domain.Core.SharedKernel.Interfaces;

namespace Vculp.Api.Domain.Core.Vehicle;

public class Vehicle : AggregateRoot, ICreationAuditable, IUpdateAuditable
{
    private List<FareDetails> _fareDetails;

    #region Constructors

    protected Vehicle()
    {
        _fareDetails = new List<FareDetails>();
        State = ObjectState.Unchanged;
    }

    public Vehicle(string vehicleType, string vehicleBodyType, IEnumerable<FareDetails> fareDetails)
    {
        if (string.IsNullOrWhiteSpace(vehicleType))
        {
            throw new ArgumentException($"{nameof(vehicleType)} cannot be an empty name", nameof(vehicleType));
        }

        if (string.IsNullOrWhiteSpace(vehicleBodyType))
        {
            throw new ArgumentException($"{nameof(vehicleBodyType)} cannot be an empty name", nameof(vehicleBodyType));
        }
        
        //An empty collection is allowed for the nutritional values
        if (fareDetails==null)
        {
            throw new ArgumentNullException(nameof(fareDetails));
        }
        
        if (!fareDetails.Any())
        {
            throw new ArgumentException("The fare details cannot be empty.", nameof(fareDetails));
        }

        _fareDetails = fareDetails.ToList();
        VehicleType = vehicleType;
        VehicleBodyType = vehicleBodyType;
    }
    
    #endregion

    #region Properties

    public string VehicleType { get; set; }
    public string VehicleBodyType { get; set; }
    public IReadOnlyCollection<FareDetails> FareDetails => _fareDetails.AsReadOnly();
    public DateTime CreationTime { get; }
    public int? CreatedByUserId { get; }
    public string CreatedByUserName { get; }
    public DateTime LastUpdated { get; }
    public int? LastUpdatedByUserId { get; }
    public string LastUpdatedByUserName { get; }

    #endregion

    #region Methods

    public void ChangeFareDetails(FareDetails fareDetails)
    {
        if (fareDetails == null)
        {
            throw new ArgumentNullException(nameof(fareDetails), $"{nameof(fareDetails)} is null");
        }

        if (!_fareDetails.Any(c => c.City == fareDetails.City))
        {
            _fareDetails.Add(fareDetails);
            SetStateToUpdated();
        }
    }

    #endregion
}