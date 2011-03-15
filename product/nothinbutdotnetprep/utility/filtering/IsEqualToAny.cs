using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.filtering
{
    public class IsEqualToAny<Item> : Criteria<Item>
    {
        IList<Item> items;

        public IsEqualToAny(params Item[] values)
        {
            this.items = new List<Item>(values);
        }

        public bool matches(Item item)
        {
            return items.Contains(item);
        }
    }
}