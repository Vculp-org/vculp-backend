using System;
using Microsoft.EntityFrameworkCore;

namespace Vculp.Api.Data.EntityFramework.Common
{
    public abstract class QueryHandler
    {
        public QueryHandler(CoreContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected CoreContext Context { get; }
    }
}
