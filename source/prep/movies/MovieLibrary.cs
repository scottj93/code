using System;
using System.Collections.Generic;
using System.EnterpriseServices;

namespace code.prep.movies
{
  public class MovieLibrary
  {
    readonly IList<Movie> movies;

    public MovieLibrary(IList<Movie> list_of_movies)
    {
      this.movies = list_of_movies;
    }

    public IEnumerable<Movie> all_movies()
    {
      return movies;
    }

    public void add(Movie movie)
    {
      movies.Add(movie);
    }

    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
        IList<Movie> resp = new List<Movie>();
        foreach (var movie in movies)
        {
            if (movie.production_studio == ProductionStudio.Pixar)
            {
                resp.Add(movie);
            }
        }
        return resp;
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
            IList<Movie> resp = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar || 
                    movie.production_studio == ProductionStudio.Disney)
                {
                    resp.Add(movie);
                }
            }
            return resp;
        }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
            IList<Movie> resp = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.production_studio != ProductionStudio.Pixar)
                {
                    resp.Add(movie);
                }
            }
            return resp;
        }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
            IList<Movie> resp = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.date_published.Year > year)
                {
                    resp.Add(movie);
                }
            }
            return resp;
        }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
            IList<Movie> resp = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.date_published.Year >= startingYear &&
                    movie.date_published.Year <= endingYear)
                {
                    resp.Add(movie);
                }
            }
            return resp;
        }

    public IEnumerable<Movie> all_kid_movies()
    {
            IList<Movie> resp = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.genre == Genre.kids)
                {
                    resp.Add(movie);
                }
            }
            return resp;
        }

    public IEnumerable<Movie> all_action_movies()
    {
            IList<Movie> resp = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.genre == Genre.action)
                {
                    resp.Add(movie);
                }
            }
            return resp;
        }

    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_title_ascending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
      throw new NotImplementedException();
    }
  }
}
