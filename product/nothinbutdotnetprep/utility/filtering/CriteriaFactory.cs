using System;
using System.Collections.Generic;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.utility.filtering
{
    public class CriteriaFactory<ItemToFilter, ReturnType>
    {
        PropertyAccessor<ItemToFilter, ReturnType> property_accessor;

        public CriteriaFactory(PropertyAccessor<ItemToFilter, ReturnType> propertyAccessor)
        {
            this.property_accessor = propertyAccessor;
        }

        public Criteria<ItemToFilter> equal_to(ReturnType value_to_equal)
        {
            return new ConditionalCriteria<ItemToFilter>(m => property_accessor(m).Equals(value_to_equal));
        }

        public Criteria<ItemToFilter> equal_to_any(params ReturnType[] values)
        {
            return new ConditionalCriteria<ItemToFilter>(item =>
                                                             new List<ReturnType>(values).Contains(
                                                                 property_accessor(item)));
        }

        public Criteria<ItemToFilter> not_equal_to(ReturnType value)
        {
            return new NotCriteria<ItemToFilter>(equal_to(value));
        }
    }
}