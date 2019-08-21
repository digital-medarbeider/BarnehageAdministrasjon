using BarnehageAdministrasjon.Interfaces;
using BarnehageAdministrasjon.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarnehageAdministrasjon.Services
{
    public class ApplicationService : IApplicationService
    {
        private KindergartenContext kindergartenContext;
        public ApplicationService(KindergartenContext context)
        {
            this.kindergartenContext = context;
        }
        public async Task<Application> GetApplication(Guid id)
        {
            return await kindergartenContext.Applications
                .FirstOrDefaultAsync(a => a.ApplicationId == id);
        }
    }
}
