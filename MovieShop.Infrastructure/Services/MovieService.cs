using MovieShop.Core.Entities;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<MovieDetailsResponseModel> GetMovieById(int id)
        {
            var movieDetails = new MovieDetailsResponseModel();
            var movie =  await _movieRepository.GetByIdAsync(id);
            // map movie entity to MovieDetailsResponseModel
            movieDetails.Id = movie.Id;
            movieDetails.Title = movie.Title;
            movieDetails.PosterUrl = movie.PosterUrl;
            movieDetails.Tagline = movie.Tagline;
            movieDetails.Overview = movie.Overview;
            movieDetails.Price = movie.Price;
            movieDetails.RunTime = movie.RunTime;
            movieDetails.BackdropUrl = movie.BackdropUrl;
            movieDetails.ReleaseDate = movie.ReleaseDate;
            movieDetails.Revenue = movie.Revenue;
            movieDetails.Budget = movie.Budget;
            movieDetails.ImdbUrl = movie.ImdbUrl;

            movieDetails.Genres = new List<GenreModel>();
            movieDetails.Casts = new List<CastResponseModel>();
            movieDetails.Reviews = new List<ReviewResponseModel>();
            foreach (var item in movie.Genres)
            {
                movieDetails.Genres.Add(new GenreModel { Id = item.Id, Name = item.Name });
            }

            foreach (var cast in movie.MovieCasts)
            {
                movieDetails.Casts.Add(new CastResponseModel
                {
                    Id = cast.CastId,
                    Character = cast.Character,
                    Name = cast.Cast.Name,
                    ProfilePath = cast.Cast.ProfilePath
                });
            }
            decimal? rating = 0.0m;
            if (movie.Reviews != null)
            {
                foreach (var review in movie.Reviews)
                {
                    movieDetails.Reviews.Add(new ReviewResponseModel
                    {
                        MovieId = review.MovieId,
                        UserId = review.UserId,
                        Rating = review.Rating,
                        ReviewText = review.ReviewText,
                        CreatedDate = review.CreatedDate
                    });

                }
                foreach (var rate in movieDetails.Reviews)
                {
                    rating += rate.Rating;
                }
                rating = rating / movieDetails.Reviews.Count;

            }
           
            movieDetails.Rating = rating;
            return movieDetails;
        }
           
           
           

        public async Task<IEnumerable<MovieCardResponseModel>> GetTop25GrossingMovies()
        {
            var movies = await _movieRepository.GetTopRevenueMovies();
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
