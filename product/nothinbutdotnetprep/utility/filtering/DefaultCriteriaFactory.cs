using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class DefaultCriteriaFactory<ItemToFilter, ReturnType> : CriteriaFactory<ItemToFilter, ReturnType>
    {
        PropertyAccessor<ItemToFilter, ReturnType> property_accessor;

        public DefaultCriteriaFactory(PropertyAccessor<ItemToFilter, ReturnType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public Criteria<ItemToFilter> equal_to(ReturnType value_to_equal)
        {
            return equal_to_any(value_to_equal);
        }

        public CriteriaFactory<ItemToFilter, ReturnType> not
        {
            get { return new NotCriteriaFactory<ItemToFilter, ReturnType>(this); }
        }

        public Criteria<ItemToFilter> equal_to_any(params ReturnType[] values)
        {
            return create_from(new IsEqualToAny<ReturnType>(values));
        }

        public Criteria<ItemToFilter> create_from(Criteria<ReturnType> property_criteria)
        {
            return new PropertyCriteria<ItemToFilter, ReturnType>(property_accessor,
                                                                  property_criteria);
        }
    }
}