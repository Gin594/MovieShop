using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Core.Models.Response;
using AutoMapper;
using MovieShop.Core.Entities;

namespace MovieShop.Infrastructure.Helper
{
    public class MovieShopMappingProfile : Profile
    {
        public MovieShopMappingProfile()
        {
            CreateMap<Movie, MovieCardResponseModel>();
            CreateMap<List<Review>, ReviewResponseModel>();

            //    CreateMap<List<Review>, ReviewResponseModel>()
            //       .ForMember(r => r.ReviewText, opt => opt.MapFrom(src => GetUserReviewedMovies(src)))
            //       .ForMember(r => r.UserId, opt => opt.MapFrom(src => src.FirstOrDefault().UserId));
            //}

            //    private List<ReviewResponseModel> GetUserReviewedMovies(List<Review> reviews)
            //    {
            //        var reviewResponse = new ReviewResponseModel { MovieReviews  = new List<ReviewResponseModel>() };

            //        foreach (var review in reviews)
            //            reviewResponse.MovieReviews.Add(new ReviewResponseModel
            //            {
            //                MovieId = review.MovieId,
            //                Rating = review.Rating,
            //                UserId = review.UserId,
            //                ReviewText = review.ReviewText
            //            });

            //        return reviewResponse.MovieReviews;
        }
    }
    }
