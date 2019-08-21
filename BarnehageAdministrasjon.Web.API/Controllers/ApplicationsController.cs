using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarnehageAdministrasjon.Models;
using BarnehageAdministrasjon.ViewModels;
using AutoMapper;
using Newtonsoft.Json;

namespace BarnehageAdministrasjon.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : Controller
    {
        private readonly KindergartenContext _context;
        private readonly IMapper _mapper;

        public ApplicationsController(KindergartenContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Applications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
        {
            return await _context.Applications.ToListAsync();
        }

        [HttpGet("GetApplicationsByParent/{nationalId}")]
        public async Task<ActionResult<IEnumerable<ApplicationViewModel>>> GetApplicationsByParent(string nationalId)
        {
            // return await _context.Applications.Where(n => n.FatherId == nationalId).ToListAsync();
            var applications = await _context.Applications
              .Include(i => i.ApplicationKindergartenCoverages)
              .Include(x => x.ApplicationSpecRequirements)
              .Include(c => c.Child)
              .Include(f => f.Father)
              .Include(m => m.Mother)
              .Include(m => m.Municipality)
              .Where(x => x.FatherId == nationalId).ToListAsync();

            List<ApplicationViewModel> applicationViewModels = null;
            try
            {

                applicationViewModels = _mapper.Map<List<Application>,List<ApplicationViewModel>>(applications);
                string json = JsonConvert.SerializeObject(applicationViewModels,
                    Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                //write string to file
                // System.IO.File.WriteAllText(@"c:\path123.txt", json);
            }
            catch (Exception ex)
            {

                throw;
            }
            if (applicationViewModels == null)
            {
                return NotFound();
            }

            return applicationViewModels;
        }

        // GET: api/Applications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationViewModel>> GetApplication(Guid id)
        {

            ApplicationViewModel applicationViewModel = null;
            try
            {
                var application = await _context.Applications
                    .Include(i => i.ApplicationKindergartenCoverages)  //.ThenInclude(t => t.WeekDay)
                    .Include(x => x.ApplicationSpecRequirements)  //.ThenInclude(xb => xb.SpecialRequirement)
                    .Include(c => c.Child)
                    .Include(f => f.Father)
                    .Include(m => m.Mother)
                    .Include(m => m.Municipality)
                    .FirstOrDefaultAsync(x => x.ApplicationId == id);
                applicationViewModel = _mapper.Map<ApplicationViewModel>(application);
                string json = JsonConvert.SerializeObject(applicationViewModel,
                    Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                //write string to file
                // System.IO.File.WriteAllText(@"c:\path123.txt", json);
            }
            catch (Exception ex)
            {

                throw;
            }
            

            if (applicationViewModel == null)
            {
                return NotFound();
            }

            return applicationViewModel;
        }

        // PUT: api/Applications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplication(Guid id, Application application)
        {
            if (id != application.ApplicationId)
            {
                return BadRequest();
            }

            _context.Entry(application).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Applications
        [HttpPost]
        public async Task<ActionResult<Application>> PostApplication(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplication", new { id = application.ApplicationId }, application);
        }

        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Application>> DeleteApplication(Guid id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();

            return application;
        }

        private bool ApplicationExists(Guid id)
        {
            return _context.Applications.Any(e => e.ApplicationId == id);
        }
    }
}
