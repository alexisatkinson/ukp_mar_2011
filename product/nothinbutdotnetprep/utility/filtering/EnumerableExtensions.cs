using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.filtering
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        public static IEnumerable<ItemToMatch> all_items_matching<ItemToMatch>(this IEnumerable<ItemToMatch> items,
                                                                               Criteria<ItemToMatch> criteria)
        {
            return items.all_items_matching(criteria.matches);
        }

        static IEnumerable<ItemToMatch> all_items_matching<ItemToMatch>(this IEnumerable<ItemToMatch> items,
                                                                               MatchingCondition<ItemToMatch> criteria)
        {
            foreach (var item_to_match in items)
            {
                if (criteria(item_to_match)) yield return item_to_match;
            }
        }
    }
}