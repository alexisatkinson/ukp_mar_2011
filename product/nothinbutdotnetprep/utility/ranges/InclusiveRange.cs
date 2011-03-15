using System;

namespace nothinbutdotnetprep.utility.ranges
{
    public class InclusiveRange<Item> : Range<Item> where Item : IComparable<Item>
    {
        Item start;
        Item end;

        public InclusiveRange(Item start, Item end)
        {
            this.start = start;
            this.end = end;
        }

        public bool contains(Item value)
        {
            return value.CompareTo(start) >= 0 && value.CompareTo(end) <= 0;
        }
    }
}