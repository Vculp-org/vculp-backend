using System.Linq;
using Vculp.Api.Data.EntityFramework.Common;
using Vculp.Api.Domain.Core.FareRecommendation;
using Vculp.Api.Domain.Interfaces.FareRecommendation;

namespace Vculp.Api.Data.EntityFramework.FareRecommendation.Repositories;

public class FareRecommendationDetailsRepository : Repository<FareRecommendationDetails>, IFareRecommendationDetailsRepository
{
    public FareRecommendationDetailsRepository(CoreContext context) : base(context)
    {
    }

    protected override IQueryable<FareRecommendationDetails> IncludeAll()
    {
        return DbSet;
    }
}