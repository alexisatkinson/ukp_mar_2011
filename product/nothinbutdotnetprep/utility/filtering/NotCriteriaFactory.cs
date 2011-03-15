namespace nothinbutdotnetprep.utility.filtering
{
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