using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class IsGreaterThan<ComparableItem> : Criteria<ComparableItem>
        where ComparableItem : IComparable<ComparableItem>
    {
        ComparableItem start;

        public IsGreaterThan(ComparableItem start)
        {
            this.start = start;
        }

        public bool matches(ComparableItem item)
        {
            return item.CompareTo(start) > 0;
        }
    }
}