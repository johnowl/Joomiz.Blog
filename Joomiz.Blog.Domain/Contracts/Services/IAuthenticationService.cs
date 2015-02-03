using Joomiz.Blog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joomiz.Blog.Domain.Contracts.Services
{
    public interface IAuthenticationService
    {
        Author Login(string name, string password);
    }
}
