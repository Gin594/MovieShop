﻿using MovieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Core.RepositoryInterfaces
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        //IEnumerable<Movie> GetTopRevenueMovie();
        //IEnumerable<Movie> GetHighestRatdMovies();

        Task<IEnumerable<Movie>> GetTopRatedMovies();
        Task<IEnumerable<Movie>> GetTopRevenueMovies();

    }
}
