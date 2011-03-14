using System;

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
            throw new NotImplementedException();
        }
    }
}