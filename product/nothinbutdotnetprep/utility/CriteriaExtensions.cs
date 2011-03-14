namespace nothinbutdotnetprep.utility
{
    public static class CriteriaExtensions
    {
        public static Criteria<ItemToMatch> as_criteria<ItemToMatch>(this MatchingCondition<ItemToMatch> condition)
        {
            return new ConditionalCriteria<ItemToMatch>(condition);
        }

        public static Criteria<ItemToMatch> or<ItemToMatch>(this Criteria<ItemToMatch> left,
                                                            Criteria<ItemToMatch> right)
        {
            return new OrCriteria<ItemToMatch>(left, right);
        }
    }
}