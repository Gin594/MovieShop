using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using MovieShop.Infrastructure.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            return _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(20);
        }

        public override Movie GetByIdAsync(int id)
        {
            return _dbContext.Movies.Include(m => m.MovieCasts).ThenInclude(m => m.Cast).Include(m => m.Genres)
                .FirstOrDefault(m => m.Id == id);
        }
    }
}
