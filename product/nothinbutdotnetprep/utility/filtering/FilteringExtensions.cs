using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public static class FilteringExtensions
    {
        public static Criteria<ItemToFilter> equal_to<ItemToFilter,ReturnType>(this FilteringExtensionPoint<ItemToFilter,ReturnType> default_filtering_extension_point,ReturnType value_to_equal)
        {
            return equal_to_any(default_filtering_extension_point,value_to_equal);
        }


        public static Criteria<ItemToFilter> equal_to_any<ItemToFilter,ReturnType>(this FilteringExtensionPoint<ItemToFilter,ReturnType> extension_point,params ReturnType[] values)
        {
            return create_criteria_using(extension_point, new IsEqualToAny<ReturnType>(values));
        }

        public static Criteria<ItemToFilter> greater_than<ItemToFilter,ReturnType>(this FilteringExtensionPoint<ItemToFilter,ReturnType> default_filtering_extension_point,ReturnType value) where ReturnType : IComparable<ReturnType>
        {
            return create_criteria_using(default_filtering_extension_point, new IsGreaterThan<ReturnType>(value));
        }

        public static Criteria<ItemToFilter> between<ItemToFilter,ReturnType>(this FilteringExtensionPoint<ItemToFilter,ReturnType> default_filtering_extension_point ,ReturnType start, ReturnType end) where ReturnType : IComparable<ReturnType>
        {
            return create_criteria_using(default_filtering_extension_point, new IsBetween<ReturnType>(start, end));
        }

        static Criteria<ItemToFilter> create_criteria_using<ItemToFilter,ReturnType>(this FilteringExtensionPoint<ItemToFilter,ReturnType> extension_point,Criteria<ReturnType> property_criteria)
        {
            return extension_point.create_from(property_criteria);
        }
    }
}