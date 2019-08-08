using BarnehageAdministrasjon.Interfaces;
using BarnehageAdministrasjon.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BarnehageAdministrasjon.Services
{
    public class ApplicationService : IApplicationService
    {
        private IApplicationRepository repository;
        public ApplicationService(IApplicationRepository applicationRepository)
        {
            repository = applicationRepository;
        }
        public Task<Application> GetApplication(Guid id)
        {
            return repository.GetApplication(id);
        }
    }
}
