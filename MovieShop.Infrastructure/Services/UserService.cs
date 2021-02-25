using MovieShop.Core.Entities;
using MovieShop.Core.Exceptions;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _cryptoService;
        private readonly ICurrentLogedInUser _currentLogedInUser;
        private readonly IAsyncRepository<Review> _reviewRepository;
        public UserService(IUserRepository userRepository, ICryptoService cryptoService, ICurrentLogedInUser currentLogedInUser, IAsyncRepository<Review> reviewRepository)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
            _currentLogedInUser = currentLogedInUser;
            _reviewRepository = reviewRepository;

        }

        public async Task AddMovieReview(ReviewRequestModel reviewRequestModel)
        {
            if (_currentLogedInUser.UserId != reviewRequestModel.UserId)
                throw new ConfilictException("You are not Authorized to Review");
            var review = new Review
            {
                MovieId = reviewRequestModel.MovieId,
                UserId = reviewRequestModel.UserId,
                Rating = reviewRequestModel.Rating,
                ReviewText = reviewRequestModel.ReviewText,
            };
            await _reviewRepository.AddAsync(review);
        }

        public async Task<bool> RegisterUser(UserRegisterRequestModel userRegisterRequestModel)
        {
            // we need to check whether that email exists or not
            var dbUser = await _userRepository.GetUserByEmail(userRegisterRequestModel.Email);

            if (dbUser != null)
            {
                throw new ConfilictException("Email already exists");
            }

            // first generate salt
            var salt = _cryptoService.GenerateRandomSalt();
            // hash the password with salt and save the salt and hased password to the database
            var hashedPassword = _cryptoService.HashPassword(userRegisterRequestModel.Password, salt);
            var user = new User {
                Email = userRegisterRequestModel.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                FirstName = userRegisterRequestModel.FirtName,
                LastName = userRegisterRequestModel.LastName,
                DateOfBirth = userRegisterRequestModel.DateOfBirth
            };
            var createdUser = await _userRepository.AddAsync(user);
            // if the limitation exceed the max length in the database then 
            // id will be set to negative
            if (createdUser != null && createdUser.Id > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<LoginResponseModel> ValidateUser(LoginRequestModel loginRequestModel)
        {
            var dbUser = await _userRepository.GetUserByEmail(loginRequestModel.Email);

            if (dbUser == null)
            {
                return null;
            }

            var hashedPassword = _cryptoService.HashPassword(loginRequestModel.Password, dbUser.Salt);

            List<RoleModel> roleList = new List<RoleModel>();
            RoleModel roleModel = new RoleModel();
            foreach (var role in dbUser.Roles)
            {
                roleList.Add(new RoleModel { Id = role.Id, Name = role.Name });
            }

            if (hashedPassword == dbUser.HashedPassword)
            {
                // user has entered correct password
                var loginResponse = new LoginResponseModel
                {
                    Id = dbUser.Id,
                    Email = dbUser.Email,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    DateOfBirth = dbUser.DateOfBirth,
                    Roles = roleList
                };

                return loginResponse;
            }

            return null;
        }
    }
}
