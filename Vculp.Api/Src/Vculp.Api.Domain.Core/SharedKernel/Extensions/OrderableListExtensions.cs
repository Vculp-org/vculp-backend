using System;
using System.Collections.Generic;
using System.Linq;
using Vculp.Api.Domain.Core.SharedKernel.Interfaces;

namespace Vculp.Api.Domain.Core.SharedKernel.Extensions
{
    public static class OrderableListExtensions
    {
        public static void AddOrderableItem<T>(this List<T> list, T item) where T : IOrderable
        {
            if (item == null) { throw new ArgumentNullException(nameof(item)); }

            var order = list.Any() ? list.Max(s => s.PrintOrder) : 0;
            item.SetPrintOrder(order + 1);
            list.Add(item);
        }

        public static void RemoveOrderableItem<T>(this List<T> list, T itemToRemove) where T : IOrderable
        {
            if (itemToRemove == null) { throw new ArgumentNullException(nameof(itemToRemove)); }

            if (list.Contains(itemToRemove))
            {
                var order = itemToRemove.PrintOrder;
                list.Remove(itemToRemove);
                foreach (var item in list)
                {
                    if (item.PrintOrder > order)
                        item.SetPrintOrder(item.PrintOrder - 1);
                }
            }
        }

        public static void ChangePrintOrder<T>(this List<T> list, Dictionary<Guid, int> printOrders) where T : IOrderable
        {
            if (printOrders == null) { throw new ArgumentNullException(nameof(printOrders)); }
            if (list.Count != printOrders.Count())
            {
                throw new ArgumentException("Print orders must have same number of item as existing list", nameof(printOrders));
            }
            if (printOrders.Count() != printOrders.Select(i => i.Value).Distinct().Count())
            {
                throw new ArgumentException("Print orders should not contain duplicate print order", nameof(printOrders));
            }
            if (printOrders.Min(s => s.Value) != 1)
            {
                throw new ArgumentException("Print order must start with 1", nameof(printOrders));
            }
            if (printOrders.Max(s => s.Value) != printOrders.Count())
            {
                throw new ArgumentException("Print orders should not have any gaps", nameof(printOrders));
            }

            foreach (var newItem in printOrders)
            {
                var item = list.Find(i => i.Id == newItem.Key);
                if (item == null)
                {
                    throw new ArgumentException($"Item {newItem.Key} not exists in the current list", nameof(printOrders));
                }

                item.SetPrintOrder(newItem.Value);
            }
        }
    }
}
