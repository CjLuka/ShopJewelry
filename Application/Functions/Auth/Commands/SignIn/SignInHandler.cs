using Application.Contracts.Persistance;
using Application.Functions.Product.Commands.AddProduct;
using Application.Responses;
using Domain.Entites;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Application.Functions.Auth.Commands.SignIn
{
    public class SignInHandler : IRequestHandler<SignInCommand, BaseResponse<string?>>
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public SignInHandler(IConfiguration configuration, UserManager<User> userManager, IUserRepository userRepository) 
        {
            _configuration= configuration;
            _userManager= userManager;
            _userRepository= userRepository;
        }
        public async Task<BaseResponse<string?>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var validator = new SignInValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return new BaseResponse<string?>(false, "Error while validations");
            }

            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user?.UserName ?? ""),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return new BaseResponse<string?>(
                    new JwtSecurityTokenHandler().WriteToken(token).ToString(), true);

            }
            return new BaseResponse<string?>(false, "Incorrect email or password");
            
        }


        private JwtSecurityToken GetToken(List<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? ""));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(1),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
