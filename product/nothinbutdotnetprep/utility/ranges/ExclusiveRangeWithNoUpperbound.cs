using System;

namespace nothinbutdotnetprep.utility.ranges
{
    public class ExclusiveRangeWithNoUpperbound<T> : Range<T> where T : IComparable<T>
    {
        T start;

        public ExclusiveRangeWithNoUpperbound(T start)
        {
            this.start = start;
        }

        public bool contains(T value)
        {
            return value.CompareTo(start) > 0;
        }
    }
}