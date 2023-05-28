using E.ApplicationCore.Domain;
using E.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.ApplicationCore.Services
{
    public class ServiceCompte : Service<Compte>, IServiceCompte
    {
        public ServiceCompte(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


    }
}
