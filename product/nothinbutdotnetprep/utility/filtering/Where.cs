using System;

namespace nothinbutdotnetprep.utility.filtering
{
	public static class Where<ItemToFilter>
	{
		public static DefaultCriteriaFactory<ItemToFilter, ReturnType> has_a<ReturnType>(PropertyAccessor<ItemToFilter, ReturnType> property_accessor)
		{
			return new DefaultCriteriaFactory<ItemToFilter, ReturnType>(property_accessor);
		}

	    public static ComparableCriteriaFactory<ItemToFilter,ReturnType> has_an<ReturnType>(PropertyAccessor<ItemToFilter,ReturnType> property_accessor) where ReturnType : IComparable<ReturnType>
	    {
	        return new ComparableCriteriaFactory<ItemToFilter, ReturnType>(has_a(property_accessor));
	    }
	}

}