using System;

namespace nothinbutdotnetprep.collections
{
    public class Movie : IEquatable<Movie>
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        public bool Equals(Movie other)
        {
            if (title == other.title) return true;
            return false;
        }

        public override string ToString()
        {
            return string.Format("Title {0}, Publisher {1}, Date Published {2}", title, production_studio,
                                 date_published.ToLongDateString());
        }
    }
}