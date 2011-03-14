using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class MovieStudioRankingAndYearPublishedComparer : IComparer<Movie>
    {
        //Studio Ratings (highest to lowest)
        //MGM
        //Pixar
        //Dreamworks
        //Universal
        //Disney

        private List<ProductionStudio> rankedStudios = new List<ProductionStudio>(new ProductionStudio[] { ProductionStudio.MGM, ProductionStudio.Pixar, ProductionStudio.Dreamworks, ProductionStudio.Universal, ProductionStudio.Disney });
        

        public int Compare(Movie x, Movie y)
        {
            int xProductionRank = rankedStudios.IndexOf(x.production_studio);
            int yProductionRank = rankedStudios.IndexOf(y.production_studio);
            int compareResult = xProductionRank.CompareTo(yProductionRank);
            if (compareResult == 0)
                compareResult = x.date_published.CompareTo(y.date_published);

            return compareResult;
        }
    }
}