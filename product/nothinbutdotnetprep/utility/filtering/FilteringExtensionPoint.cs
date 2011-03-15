namespace nothinbutdotnetprep.utility.filtering
{
    public interface FilteringExtensionPoint<ItemToFilter, ReturnType>
    {
        Criteria<ItemToFilter> create_from(Criteria<ReturnType> property_criteria);
    }
}