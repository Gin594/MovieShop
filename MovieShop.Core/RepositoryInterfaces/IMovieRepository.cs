using MovieShop.Core.Entities;
using MovieShop.Core.Helper;
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

        Task<PaginatedList<Movie>> GetMoviesByGenre(int genreId, int pageSize = 25, int page = 1);


    }
}
