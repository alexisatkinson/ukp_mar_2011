namespace nothinbutdotnetprep.utility.filtering
{
    public class NegatingFilteringExtensionPoint<ItemToFilter, PropertyType> : FilteringExtensionPoint<ItemToFilter,PropertyType>
    {
        readonly FilteringExtensionPoint<ItemToFilter, PropertyType> original;

        public NegatingFilteringExtensionPoint(FilteringExtensionPoint<ItemToFilter, PropertyType> original)
        {
            this.original = original;
        }

        public Criteria<ItemToFilter> create_from(Criteria<PropertyType> property_criteria)
        {
            return original.create_from(property_criteria).not();
        }
    }
}