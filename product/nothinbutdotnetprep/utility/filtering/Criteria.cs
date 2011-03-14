namespace nothinbutdotnetprep.utility.filtering
{
    public interface Criteria<ItemToMatch>
    {
        bool matches(ItemToMatch item);
    }


}