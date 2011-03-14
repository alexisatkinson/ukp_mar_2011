using System;
using nothinbutdotnetprep.utility;

namespace nothinbutdotnetprep.collections
{
    public static class Where<ItemToFilter>
    {
        public static object has_a<ReturnType>(PropertyAccessor<ItemToFilter,ReturnType> property_accessor)
        {
            throw new NotImplementedException();
        }
    }
}