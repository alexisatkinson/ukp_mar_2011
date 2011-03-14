using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace nothinbutdotnetprep.collections
{
    public class MovieTitleComparer : IComparer<Movie>
    {
        public System.ComponentModel.ListSortDirection SortDirection { get; private set; }

        public MovieTitleComparer(ListSortDirection sortDirection)
        {
            SortDirection = sortDirection;
        }

        public int Compare(Movie x, Movie y)
        {
            if (SortDirection == ListSortDirection.Ascending)
            {
                return x.title.CompareTo(y.title);
            }
            else
            {
                return y.title.CompareTo(x.title);
            }
        }
   }


    public class MoviePublishDateComparer : IComparer<Movie>
    {
        public System.ComponentModel.ListSortDirection SortDirection { get; private set; }

        public MoviePublishDateComparer(ListSortDirection sortDirection)
        {
            SortDirection = sortDirection;
        }

        public int Compare(Movie x, Movie y)
        {
            if (SortDirection == ListSortDirection.Ascending)
            {
                return x.date_published.CompareTo(y.date_published);
            }
            else
            {
                return y.date_published.CompareTo(x.date_published);
            }
        }
    }
}