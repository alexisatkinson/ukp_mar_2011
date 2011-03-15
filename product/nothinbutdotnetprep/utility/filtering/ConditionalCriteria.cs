namespace nothinbutdotnetprep.utility.filtering
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

        public static ConditionalCriteria<ItemToMatch> Create(MatchingCondition<ItemToMatch> condition)
        {
            return new ConditionalCriteria<ItemToMatch>(condition);
        }
    }
}