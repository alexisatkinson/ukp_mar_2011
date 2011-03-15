namespace nothinbutdotnetprep.utility.filtering
{
    public static class Where<ItemToFilter>
    {
        public static DefaultFilteringExtensionPoint<ItemToFilter, ReturnType> has_a<ReturnType>(
            PropertyAccessor<ItemToFilter, ReturnType> property_accessor)
        {
            return new DefaultFilteringExtensionPoint<ItemToFilter, ReturnType>(property_accessor);
        }
    }
}