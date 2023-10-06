using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Auth.Commands.SignUp
{
    public class SignUpCommand : IRequest<BaseResponse>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassowrd { get; set; }
        public string PhoneNumber { get; set; }
    }
}
