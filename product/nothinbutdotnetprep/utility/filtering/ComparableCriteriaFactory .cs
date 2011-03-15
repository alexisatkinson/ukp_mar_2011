using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class ComparableCriteriaFactory<ItemToFilter, ReturnType>  : CriteriaFactory<ItemToFilter,ReturnType>
        where ReturnType : IComparable<ReturnType>
    {
        CriteriaFactory<ItemToFilter, ReturnType> original_factory;

        public ComparableCriteriaFactory(CriteriaFactory<ItemToFilter, ReturnType> original_factory)
        {
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

        public Criteria<ItemToFilter> create_from(MatchingCondition<ItemToFilter> condition)
        {
            return original_factory.create_from(condition);
        }

        public ReturnType get_property_value(ItemToFilter item)
        {
            return original_factory.get_property_value(item);
        }

        public Criteria<ItemToFilter> greater_than(ReturnType value)
        {
            return create_from(item => get_property_value(item).CompareTo(value) > 0);
        }

        public Criteria<ItemToFilter> between(ReturnType start, ReturnType end)
        {
            return create_from(item => get_property_value(item).CompareTo(start) >= 0 &&
                get_property_value(item).CompareTo(end) <= 0);
        }


    }
}