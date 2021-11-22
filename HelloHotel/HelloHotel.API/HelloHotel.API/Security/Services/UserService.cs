using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelloHotel.API.Searching_System.Domain.Repositories;
using HelloHotel.API.Security.Authorization.Handlers.Interfaces;
using HelloHotel.API.Security.Domain.Entities;
using HelloHotel.API.Security.Domain.Repositories;
using HelloHotel.API.Security.Domain.Services;
using HelloHotel.API.Security.Domain.Services.Communication;
using HelloHotel.API.Shared.Exceptions;
using BCryptNet = BCrypt.Net.BCrypt;

namespace HelloHotel.API.Security.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;
        
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IJwtHandler jwtHandler, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {

            var user = await _userRepository.FindByUsernameAsync(request.Username);
            
            // Validate

            if (user == null || !BCryptNet.Verify(request.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect.");
            
            // Authentication is successful

            var response = _mapper.Map<AuthenticateResponse>(user);

            response.Token = _jwtHandler.GenerateToken(user);

            return response;

        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            if (user == null) throw new KeyNotFoundException("User not found.");
            return user;
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            // Validate
            if (_userRepository.ExistsByUsername(request.Username))
                throw new AppException($"Username {request.Username} is already taken.");
            
            // Map request to User model
            var user = _mapper.Map<User>(request);
            
            // Hash Password
            user.PasswordHash = BCryptNet.HashPassword(request.Password);
            
            // Save User
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
            }
            catch(Exception e)
            {
                throw new AppException($"An error occurred while saving the user: {e.Message}");
            }
        }

        public async Task UpdateAsync(int id, UpdateRequest request)
        {
            var user = GetById(id);
            
            // Validate
            if (_userRepository.ExistsByUsername(request.Username))
                throw new AppException($"Username {request.Username} is already taken.");
            
            // If Password is not null, then Hash it
            if (!string.IsNullOrEmpty(request.Password))
                user.PasswordHash = BCryptNet.HashPassword(request.Password);
            
            // Map to User model
            _mapper.Map(request, user);
            try
            {
                _userRepository.Update(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while updating the user: {e.Message}");  
            }
        }

        public async Task DeleteAsync(int id)
        {
            var user = GetById(id);
            
            try
            {
                _userRepository.Remove(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while deleting the user: {e.Message}");  
            }
        }

        // Internal Helpers
        private User GetById(int id)
        {
            var user = _userRepository.FindById(id);
            if (user == null) throw new KeyNotFoundException("User not found.");
            return user;
        }

        
    }
}