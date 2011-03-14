using System;
using System.Collections.Generic;
using System.Reflection;

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
            foreach (var movie in movies)
            {
                yield return movie;
            }
        }

        public void add(Movie movie)
        {
            if(!movies.Contains(movie))
                movies.Add(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                List<Movie> sortedListByTitle = new List<Movie>(movies);
                sortedListByTitle.Sort((firstMovie, secondMovie) => secondMovie.title.CompareTo(firstMovie.title));
                return sortedListByTitle;
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar) yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar || movie.production_studio == ProductionStudio.Disney)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get {
                List<Movie> sortedListByTitle = new List<Movie>(movies);
                sortedListByTitle.Sort((firstMovie, secondMovie) => firstMovie.title.CompareTo(secondMovie.title));
                return sortedListByTitle;
            }
        }



        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            List<Movie> sortedList = new List<Movie>(movies);
            
            sortedList.Sort(new MovieStudioAndYearPublishedComparer<Movie>());
            return sortedList;
            
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio != ProductionStudio.Pixar) yield return movie;
            };
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            foreach (var movie in movies)
            {
                if (movie.date_published.Year > year) yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            foreach (var movie in movies)
            {
                if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
                    yield return movie;
            }
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            return FindByGenre(Genre.kids);
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return FindByGenre(Genre.action);
        }

        private IEnumerable<Movie> FindByGenre(Genre genre)
        {
            foreach (var movie in movies)
            {
                if (movie.genre == genre) yield return movie;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            List<Movie> sortedList = new List<Movie>(movies);
            sortedList.Sort(
                (firstMovie, secondMovie) =>
                    {
                        if (firstMovie.date_published == secondMovie.date_published) return 0;
                        if (firstMovie.date_published < secondMovie.date_published) return 1;
                        return -1;
                    });
            return sortedList;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            List<Movie> sortedList = new List<Movie>(movies);
            sortedList.Sort(
                (firstMovie, secondMovie) =>
                    {
                        if (firstMovie.date_published == secondMovie.date_published) return 0;
                        if (firstMovie.date_published > secondMovie.date_published) return 1;
                        return -1;
                    });
            return sortedList;
        }

        
    }

    public class MovieStudioAndYearPublishedComparer<T> : IComparer<Movie>
    {
        private static int ProductionStudioRating(ProductionStudio productionStudio)
        {
            //MGM
            //Pixar
            //Dreamworks
            //Universal
            //Disney
            if (productionStudio == ProductionStudio.MGM)
            {
                return 0;
            }
            if(productionStudio == ProductionStudio.Pixar)
            {
                return 1;
            }
            if(productionStudio == ProductionStudio.Dreamworks)
            {
                return 2;
            }
            if(productionStudio == ProductionStudio.Universal)
            {
                return 3;
            }
            if(productionStudio == ProductionStudio.Disney)
            {
                return 4;
            }
            return 5;
        }


        public int Compare(Movie x, Movie y)
        {
            if (ProductionStudioRating(x.production_studio) > ProductionStudioRating(y.production_studio)) return 1;
            if (ProductionStudioRating(x.production_studio) < ProductionStudioRating(y.production_studio)) return -1;
            if(x.date_published > y.date_published) return 1;
            if (x.date_published < y.date_published) return -1;
            return 0;
        }
    }
}