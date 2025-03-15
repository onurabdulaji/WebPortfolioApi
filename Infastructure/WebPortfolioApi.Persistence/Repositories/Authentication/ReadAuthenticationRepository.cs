using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPortfolioApi.Application.Interfaces.IRepositories.Authentication;
using WebPortfolioApi.Domain.Entities;
using WebPortfolioApi.Persistence.Context;

namespace WebPortfolioApi.Persistence.Repositories.Authentication
{
    public class ReadAuthenticationRepository : ReadRepository<User>, IReadAuthenticationRepository
    {
        public ReadAuthenticationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
