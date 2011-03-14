namespace nothinbutdotnetprep.utility.filtering
{
	public static class Where<ItemToFilter>
	{
		public static CriteriaFactory<ItemToFilter, ReturnType> has_a<ReturnType>(PropertyAccessor<ItemToFilter, ReturnType> property_accessor)
		{
			return new CriteriaFactory<ItemToFilter, ReturnType>(property_accessor);
		}
	}

}