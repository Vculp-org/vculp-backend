using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Vculp.Api.Data.EntityFramework.Common
{
    public static class ValueComparers
    {
        public static ValueComparer<IReadOnlyCollection<string>> StringCollectionValueComparer =
            new ValueComparer<IReadOnlyCollection<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => (IReadOnlyCollection<string>)c.ToList()); // The cast is required here, otherwise EF Core fails when creating the snapshot value expression

        public static ValueComparer<IReadOnlyCollection<Guid>> GuidCollectionValueComparer =
            new ValueComparer<IReadOnlyCollection<Guid>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => (IReadOnlyCollection<Guid>)c.ToList()); // The cast is required here, otherwise EF Core fails when creating the snapshot value expression
    }
}
