using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.src.Auth;

namespace Ecommerce.Service.src.AuthService
{
    public interface IAuthManagement
    {
        Task<string> LoginAsync(UserCredentials userCredentials);
    }
}