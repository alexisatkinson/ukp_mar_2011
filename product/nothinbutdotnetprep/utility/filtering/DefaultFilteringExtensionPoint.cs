using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class DefaultFilteringExtensionPoint<ItemToFilter, ReturnType> : FilteringExtensionPoint<ItemToFilter, ReturnType>
    {
        PropertyAccessor<ItemToFilter, ReturnType> property_accessor;

        public DefaultFilteringExtensionPoint(PropertyAccessor<ItemToFilter, ReturnType> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public FilteringExtensionPoint<ItemToFilter, ReturnType> not
        {
            get
            {
                return new NegatingFilteringExtensionPoint<ItemToFilter, ReturnType>(this);
            }
        }
        public Criteria<ItemToFilter> create_from(Criteria<ReturnType> property_criteria)
        {
            return new PropertyCriteria<ItemToFilter, ReturnType>(property_accessor,
                                                                          property_criteria);
        }
    }
}