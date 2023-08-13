using System;
using Vculp.Api.Domain.Core.SharedKernel;
using Vculp.Api.Domain.Core.SharedKernel.Interfaces;

namespace Vculp.Api.Domain.Core.FareRecommendation;

public class FareRecommendationDetails: AggregateRoot, ICreationAuditable, IUpdateAuditable
{
    
      #region Constructors

        protected FareRecommendationDetails()
        {
            State = ObjectState.Unchanged;
        }

        // public FareRecommendationDetails
        // (
        // )
        // { 
        //     
        // }

        #endregion
        
        #region Properties

        public DateTime CreationTime { get; }
        public int? CreatedByUserId { get; }
        public string CreatedByUserName { get; }
        public DateTime LastUpdated { get; }
        public int? LastUpdatedByUserId { get; }
        public string LastUpdatedByUserName { get; }

        #endregion
        
        #region Methods

        
        #endregion
        
    
}