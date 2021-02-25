using MovieShop.Core.Entities;
using MovieShop.Core.Helper;
using MovieShop.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Core.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<MovieDetailsResponseModel> GetMovieById(int id);
        Task<IEnumerable<MovieCardResponseModel>> GetTop25GrossingMovies();
        Task<PagedResultSet<MovieCardResponseModel>> GetMoviesByPagination(int pageSize = 20, int page = 1, string title = "");
        Task<PaginatedList<MovieCardResponseModel>> GetMoviesByGenre(int genreId, int pageSize = 25, int page = 1);
        Task<List<ReviewResponseModel>> GetReviewsForMovie(int id);

    }
}
