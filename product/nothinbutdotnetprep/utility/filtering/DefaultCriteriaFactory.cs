using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.filtering
{
    public class DefaultCriteriaFactory<ItemToFilter, ReturnType> : CriteriaFactory<ItemToFilter, ReturnType>
    {
        PropertyAccessor<ItemToFilter, ReturnType> property_accessor;

        public DefaultCriteriaFactory(PropertyAccessor<ItemToFilter, ReturnType> propertyAccessor)
        {
            this.property_accessor = propertyAccessor;
        }

        public Criteria<ItemToFilter> equal_to(ReturnType value_to_equal)
        {
            return create_from(m => get_property_value(m).Equals(value_to_equal));
        }

        public Criteria<ItemToFilter> equal_to_any(params ReturnType[] values)
        {
            return create_from(item => new List<ReturnType>(values).Contains(get_property_value(item)));
        }

        public Criteria<ItemToFilter> not_equal_to(ReturnType value)
        {
            return equal_to(value).not();
        }

        public Criteria<ItemToFilter> create_from(MatchingCondition<ItemToFilter> condition)
        {
            return new ConditionalCriteria<ItemToFilter>(condition);
        }

        public ReturnType get_property_value(ItemToFilter item)
        {
            return property_accessor(item);
        }
    }
}