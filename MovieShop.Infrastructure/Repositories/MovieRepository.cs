using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using MovieShop.Infrastructure.Data;

namespace MovieShop.Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Movie> GetTopRatedMovies()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetTopRevenueMovies()
        {
            throw new NotImplementedException();
        }
    }
}
