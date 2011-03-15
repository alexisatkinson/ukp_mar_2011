namespace nothinbutdotnetprep.utility.filtering
{
    public class IsEqualTo<Item> : Criteria<Item>
    {
        Item value;

        public IsEqualTo(Item value)
        {
            this.value = value;
        }

        public bool matches(Item item)
        {
            return item.Equals(value);
        }
    }
}