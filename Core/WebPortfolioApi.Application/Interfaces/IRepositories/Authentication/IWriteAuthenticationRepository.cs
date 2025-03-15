using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPortfolioApi.Domain.Entities;

namespace WebPortfolioApi.Application.Interfaces.IRepositories.Authentication
{
    public interface IWriteAuthenticationRepository : IWriteRepository<User>
    {
    }
}
