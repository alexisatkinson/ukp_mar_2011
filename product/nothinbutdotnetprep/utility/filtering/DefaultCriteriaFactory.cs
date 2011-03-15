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


        public Criteria<ItemToFilter> not_equal_to(ReturnType value)
        {
            return equal_to(value).not();
        }

        public Criteria<ItemToFilter> create_from(Criteria<ReturnType> property_criteria)
        {
            return new PropertyCriteria<ItemToFilter, ReturnType>(property_accessor,
                                                                  property_criteria);
        }
    }

    public class NotCriteriaFactory<ItemToFilter, ReturnType> : CriteriaFactory<ItemToFilter, ReturnType>
    {
        private DefaultCriteriaFactory<ItemToFilter, ReturnType> criteriaFactory;

        public NotCriteriaFactory(DefaultCriteriaFactory<ItemToFilter, ReturnType> criteriaFactory)
        {
            this.criteriaFactory = criteriaFactory;
        }

        public Criteria<ItemToFilter> create_from(Criteria<ReturnType> property_criteria)
        {
            return new NotCriteria<ItemToFilter>(criteriaFactory.create_from(property_criteria));
        }

        public Criteria<ItemToFilter> equal_to(ReturnType value_to_equal)
        {
            return new NotCriteria<ItemToFilter> ( criteriaFactory.equal_to(value_to_equal));
        }

        public Criteria<ItemToFilter> equal_to_any(params ReturnType[] values)
        {
            return new NotCriteria<ItemToFilter>(criteriaFactory.equal_to_any(values));
        }
    }
}