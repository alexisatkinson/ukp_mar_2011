using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class ComparableCriteriaFactory<ItemToFilter, ReturnType>  : CriteriaFactory<ItemToFilter,ReturnType>
        where ReturnType : IComparable<ReturnType>
    {
        PropertyAccessor<ItemToFilter, ReturnType> property_accessor;
        CriteriaFactory<ItemToFilter, ReturnType> original_factory;

        public ComparableCriteriaFactory(PropertyAccessor<ItemToFilter, ReturnType> property_accessor, CriteriaFactory<ItemToFilter, ReturnType> original_factory)
        {
            this.property_accessor = property_accessor;
            this.original_factory = original_factory;
        }

        public Criteria<ItemToFilter> equal_to(ReturnType value_to_equal)
        {
            return original_factory.equal_to(value_to_equal);
        }

        public Criteria<ItemToFilter> equal_to_any(params ReturnType[] values)
        {
            return original_factory.equal_to_any(values);
        }

        public Criteria<ItemToFilter> not_equal_to(ReturnType value)
        {
            return original_factory.not_equal_to(value);
        }

        public Criteria<ItemToFilter> greater_than(ReturnType value)
        {
            return ConditionalCriteria<ItemToFilter>.Create(item => property_accessor(item).CompareTo(value) > 0);
        }

        public Criteria<ItemToFilter> between(ReturnType start, ReturnType end)
        {
            return ConditionalCriteria<ItemToFilter>.Create(item => property_accessor(item).CompareTo(start) >= 0 &&
                property_accessor(item).CompareTo(end) <= 0);
        }
    }
}