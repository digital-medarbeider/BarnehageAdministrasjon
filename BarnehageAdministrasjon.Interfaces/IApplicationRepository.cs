using BarnehageAdministrasjon.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BarnehageAdministrasjon.Interfaces
{
    public interface IApplicationRepository: IGenericRepository<Application>
    {
        Task<Application> GetApplication(Guid id);
    }
}
