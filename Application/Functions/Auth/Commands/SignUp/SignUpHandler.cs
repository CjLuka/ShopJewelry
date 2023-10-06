using Application.Contracts.Persistance;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Commands.SignUp
{
    public class SignUpHandler : IRequestHandler<SignUpCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        public SignUpHandler(IMapper mapper, UserManager<User> userManager, IUserRepository userRepository) 
        {
            _mapper= mapper;
            _userManager= userManager;
            _userRepository= userRepository;
        }

        public async Task<BaseResponse> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var validator = new SignUpValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return new BaseResponse(false, "Error Validation ");
            }

            var userExist = await _userRepository.GetByEmailAsync(request.Email);
            if (userExist != null)
            {
                return new BaseResponse(false, "This Email is already exist in database");
            }

            var newUser = _mapper.Map<User>(request);


            //utworzenie nowego użytkownika
            var createUser = await _userManager.CreateAsync(newUser, request.Password);

            //przypisanie roli nowemu użytkownikowi
            var addRole = await _userManager.AddToRoleAsync(newUser, "User");

            if (!addRole.Succeeded)
            {
                return new BaseResponse(false, "Error with add role to new user");
            }
            

            if (createUser.Succeeded)
            {
                return new BaseResponse(true, "User created");
            }
            return new BaseResponse(false, "Something went wrong");


        }
    }
}
