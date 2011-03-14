namespace nothinbutdotnetprep.utility
{
    public class ConditionalCriteria<ItemToMatch> : Criteria<ItemToMatch>
    {
        MatchingCondition<ItemToMatch> condition;

        public ConditionalCriteria(MatchingCondition<ItemToMatch> condition)
        {
            this.condition = condition;
        }

        public bool matches(ItemToMatch item)
        {
            return condition(item);
        }
    }
}