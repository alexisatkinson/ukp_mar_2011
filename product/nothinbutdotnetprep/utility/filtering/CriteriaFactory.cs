namespace nothinbutdotnetprep.utility.filtering
{
    public interface CriteriaFactory<ItemToFilter, ReturnType>
    {
        Criteria<ItemToFilter> CreateCriteria(MatchingCondition<ItemToFilter> condition);
        Criteria<ItemToFilter> equal_to(ReturnType value_to_equal);
        Criteria<ItemToFilter> equal_to_any(params ReturnType[] values);
        Criteria<ItemToFilter> not_equal_to(ReturnType value);
    }
}