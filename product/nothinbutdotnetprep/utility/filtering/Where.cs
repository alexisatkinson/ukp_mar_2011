namespace nothinbutdotnetprep.utility.filtering
{
	public static class Where<ItemToFilter>
	{
		public static SpecificationFactory<ItemToFilter, ReturnType> has_a<ReturnType>(PropertyAccessor<ItemToFilter, ReturnType> property_accessor)
		{
			return new SpecificationFactory<ItemToFilter, ReturnType>(property_accessor);
		}
	}

	public class SpecificationFactory<ItemToFilter, ReturnType>
	{
		private readonly PropertyAccessor<ItemToFilter, ReturnType> propertyAccessor;

		public SpecificationFactory(PropertyAccessor<ItemToFilter, ReturnType> propertyAccessor)
		{
			this.propertyAccessor = propertyAccessor;
		}

		public Criteria<ItemToFilter> equal_to(ReturnType valueToEqual)
		{
			return new ConditionalCriteria<ItemToFilter>(m => propertyAccessor(m).Equals(valueToEqual));
		}
	}
}