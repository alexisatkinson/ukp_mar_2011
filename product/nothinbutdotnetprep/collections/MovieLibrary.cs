using System.Collections.Generic;
using System.ComponentModel;
using nothinbutdotnetprep.utility.filtering;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;

            movies.Add((movie));
        }

        bool already_contains(Movie movie)
        {
            return movies.Contains(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                var result = new List<Movie>(movies);
                result.Sort(new MovieTitleComparer(ListSortDirection.Descending));
                return result;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get
            {
                var result = new List<Movie>(movies);
                result.Sort(new MovieTitleComparer(ListSortDirection.Ascending));
                return result;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            var result = new List<Movie>(movies);
            result.Sort(new MovieStudioRankingAndYearPublishedComparer());
            return result;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            var result = new List<Movie>(movies);
            result.Sort(new MoviePublishDateComparer(ListSortDirection.Descending));
            return result;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            var result = new List<Movie>(movies);
            result.Sort(new MoviePublishDateComparer(ListSortDirection.Ascending));
            return result;
        }
    }
}