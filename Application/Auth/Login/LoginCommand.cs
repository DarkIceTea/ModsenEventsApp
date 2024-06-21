using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Auth.Login
{
    public class LoginCommand : IRequest<Tokens>
    {
        public string Email {  get; set; }
        public string Name { get; set; }
    }
}
