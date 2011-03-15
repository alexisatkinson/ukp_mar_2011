using System;

namespace nothinbutdotnetprep.utility.ranges
{
    public interface Range<Item> where Item : IComparable<Item>
    {
        bool contains(Item value);
    }
}