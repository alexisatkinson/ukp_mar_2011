namespace nothinbutdotnetprep.utility.filtering
{
    public interface CriteriaFactory<ItemToFilter, ReturnType>
    {
        Criteria<ItemToFilter> create_from(Criteria<ReturnType> property_criteria);
        Criteria<ItemToFilter> equal_to(ReturnType value_to_equal);
        Criteria<ItemToFilter> equal_to_any(params ReturnType[] values);
    }
}