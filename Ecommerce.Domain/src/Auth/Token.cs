using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.src.Auth
{
    public class Token
    {
        public string? AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}