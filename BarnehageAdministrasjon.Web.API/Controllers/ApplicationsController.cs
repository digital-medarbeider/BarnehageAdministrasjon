using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BarnehageAdministrasjon.Interfaces;
using BarnehageAdministrasjon.Models;
using BarnehageAdministrasjon.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarnehageAdministrasjon.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationService applicationService;
        private readonly IMapper _mapper;
        public ApplicationsController(IApplicationService service, IMapper mapper)
        {
            applicationService = service;
            _mapper = mapper;
        }
        // GET: api/Applications
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Applications/5
        [HttpGet("{id}")]
        public async Task<ApplicationViewModel> Get(Guid id)
        {
            var application= await applicationService.GetApplication(id);
             var applicationViewModel = _mapper.Map<ApplicationViewModel>(application);
            return applicationViewModel;
        }

        // POST: api/Applications
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Applications/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
