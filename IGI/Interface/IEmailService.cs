using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI.Interface
{
    public interface IEmailService
    {
        Task VerificationAsync(string mail, string name, string token, IConfiguration configuration);
    }
}
