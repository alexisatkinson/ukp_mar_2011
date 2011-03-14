using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.utility
{
    public interface Criteria<ItemToMatch>
    {
        bool matches(ItemToMatch item);
    }


}