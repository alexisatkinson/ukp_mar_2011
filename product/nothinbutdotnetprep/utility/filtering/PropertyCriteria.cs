namespace nothinbutdotnetprep.utility.filtering
{
    public class PropertyCriteria<ItemToFilter, ReturnType> : Criteria<ItemToFilter>
    {
        PropertyAccessor<ItemToFilter, ReturnType> property_accessor;
        Criteria<ReturnType> value_criteria;

        public PropertyCriteria(PropertyAccessor<ItemToFilter, ReturnType> property_accessor, Criteria<ReturnType> value_criteria)
        {
            this.property_accessor = property_accessor;
            this.value_criteria = value_criteria;
        }

        public bool matches(ItemToFilter item)
        {
            return value_criteria.matches(property_accessor(item));
        }
    }
}