using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatingApp_FullSD.Server.Data;
using DatingApp_FullSD.Shared.Domain;
using DatingApp_FullSD.Server.IRepository;
using DatingApp_FullSD.Server.Repository;
using Microsoft.CodeAnalysis.CSharp;

namespace DatingApp_FullSD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfilesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Profiles
        [HttpGet]

        public async Task<IActionResult> GetProfiles()
        {
            var profiles = await _unitOfWork.Profiles.GetAll();
            return Ok(profiles);
        }

        // GET: api/Profiles/5
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetProfile(int id)
        {
            var profile = await _unitOfWork.Profiles.Get(q => q.Id == id);

            if (profile ==null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        // PUT: api/Profiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(int id, Profile profile)
        {
            if (id != profile.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Profiles.Update(profile);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!await ProfileExists(id))
                {
                    return NotFound();
                }
            
            }

            return NoContent();
 
        }

        // POST: api/Profiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profile>> PostProfile(Profile profile)
        {
            await _unitOfWork.Profiles.Insert(profile);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetProfile", new { id = profile.Id }, profile);
        }

        // DELETE: api/Profiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var profile = await _unitOfWork.Profiles.Get(q => q.Id == id);
            if (profile == null)
            {
                return NotFound();
            }

            await _unitOfWork.Profiles.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        

        private async Task<bool> ProfileExists(int id)
        {
            var profile = await _unitOfWork.Profiles.Get(q => q.Id == id);
            return profile != null;
        }
    }
}
