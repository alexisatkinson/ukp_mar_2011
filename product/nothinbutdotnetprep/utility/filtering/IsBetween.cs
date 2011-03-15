using System;
using nothinbutdotnetprep.utility.ranges;

namespace nothinbutdotnetprep.utility.filtering
{
    public class IsBetween<ComparableItem> : Criteria<ComparableItem> where ComparableItem : IComparable<ComparableItem>
    {
        Criteria<ComparableItem> criteria;

        public IsBetween(ComparableItem start, ComparableItem end)
        {
            this.criteria = new FallsInRange<ComparableItem>(
                new InclusiveRange<ComparableItem>(start, end));
        }

        public bool matches(ComparableItem item)
        {
            return criteria.matches(item);
        }
    }
}