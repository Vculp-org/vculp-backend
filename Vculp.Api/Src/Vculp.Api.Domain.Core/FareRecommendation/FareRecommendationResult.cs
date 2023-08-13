// using System;
// using Vculp.Api.Domain.Core.SharedKernel;
// using Vculp.Api.Domain.Core.Vehicle;
//
// namespace Vculp.Api.Domain.Core.FareRecommendation;
//
// public class FareRecommendationResult: ValueObject<FareRecommendationResult>
// {
//     #region Constructors
//
//     private FareRecommendationResult()
//     {
//         State = ObjectState.Unchanged;
//     }
//
//     public FareRecommendationResult(FareDetails price)
//     {
//         Price = price ?? throw new ArgumentNullException(nameof(price));
//
//         if(string.IsNullOrWhiteSpace(priceSource))
//         {
//             throw new ArgumentException($"{nameof(priceSource)} is null, empty or contains only whitespace", nameof(priceSource));
//         }
//
//         PriceSource = priceSource;
//     }
//
//     #endregion
//
//     #region Properties
//
//     public FareDetailsy Price { get; private set; }
//     public string PriceSource { get; private set; }
//
//     #endregion
//
//     #region Methods
//
//     protected override bool EqualsCore(FareRecommendationResult other)
//     {
//         return other.Price == Price &&
//                other.PriceSource == PriceSource;
//     }
//
//     protected override int GetHashCodeCore()
//     {
//         return Price.GetHashCode() ^ PriceSource.GetHashCode();
//     }
//
//     #endregion
// }