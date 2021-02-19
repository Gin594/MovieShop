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
            var genreModel = new GenreModel();
            var movie = _movieRepository.GetByIdAsync(id);
            // map movie entity to MovieDetailsResponseModel
            movieDetails.Id = movie.Id;
            movieDetails.Title = movie.Title;
            movieDetails.PosterUrl = movie.PosterUrl;
            movieDetails.Tagline = movie.Tagline;
            var genres = movie.Genres;
            List<GenreModel> list = new List<GenreModel>();
            foreach (var item in genres)
            {
                list.Add(new GenreModel { Id = item.Id, Name = item.Name });
            }
            movieDetails.Genres = new List<GenreModel>(list);
            movieDetails.Overview = movie.Overview;
            movieDetails.Price = movie.Price;
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
