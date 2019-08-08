using BarnehageAdministrasjon.Interfaces;
using BarnehageAdministrasjon.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BarnehageAdministrasjon.Repositories
{
    public class ApplicationRepository : GenericRepository<Application>, IApplicationRepository
    {
        public ApplicationRepository(KindergartenContext kindergartenContext)
            : base(kindergartenContext)
        {

        }
        public async Task<Application> GetApplication(Guid id)
        {
            return await GetById(id);
        }
    }
}
