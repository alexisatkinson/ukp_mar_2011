namespace nothinbutdotnetprep.utility.filtering
{
    public static class CriteriaExtensions
    {


        public static Criteria<ItemToMatch> or<ItemToMatch>(this Criteria<ItemToMatch> left,
                                                            Criteria<ItemToMatch> right)
        {
            return new OrCriteria<ItemToMatch>(left, right);
        }
        public static Criteria<ItemToMatch> not<ItemToMatch>(this Criteria<ItemToMatch> left)
        {
            return new NotCriteria<ItemToMatch>(left);
        }
    }
}