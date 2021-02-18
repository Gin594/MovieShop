using MovieShop.Core.Entities;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        // DI 3 ways 1. Constructor Injection, 2. Method Injection, 3. Property Injection
        
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public MovieDetailsResponseModel GetMovieById(int id)
        {
            var movieDetails = new MovieDetailsResponseModel();
            var movie = _movieRepository.GetByIdAsync(id);
            // map movie entity to MovieDetailsResponseModel
            return movieDetails;
        }

        public IEnumerable<MovieCardResponseModel> GetTop25GrossingMovies()
        {
            var movies = _movieRepository.GetTopRevenueMovies();
            var movieResponseModel = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                var movieCard = new MovieCardResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    Revenue = movie.Revenue,
                    Title = movie.Title
                };
                movieResponseModel.Add(movieCard);
            }
            return movieResponseModel;
        }
    }

    
}
