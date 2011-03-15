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

        public Criteria<ItemToFilter> create_from(Criteria<ReturnType> property_criteria)
        {
            return original_factory.create_from(property_criteria);
        }

        public Criteria<ItemToFilter> greater_than(ReturnType value)
        {
            return create_from(new IsGreaterThan<ReturnType>(value));
        }

        public Criteria<ItemToFilter> between(ReturnType start, ReturnType end)
        {
            return create_from(new IsBetween<ReturnType>(start, end));
        }


    }
}