using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoctorsApi.Data;
using DoctorsApi.Models;

namespace DoctorsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly DataContext _context;

        public DoctorsController(DataContext context)
        {
            _context = context;

            // Seed data if the Doctors table is empty
            if (!_context.Doctors.Any())
            {
                SeedInitialData();
            }
        }

        private void SeedInitialData()
        {
            var initialDoctors = new List<Doctors>
        {
            new Doctors { FirstName = "Vako", LastName = "Janika", Category = "stomatolog", Email = "vako@gmail.com", Place = "Tbilisi" },
            new Doctors { FirstName = "Ana", LastName = "Lastname", Category = "terapist", Email = "ani@gmail.com", Place = "Paris" },
            new Doctors { FirstName = "Nino", LastName = "Lastname", Category = "pediater", Email = "nini@gmail.com", Place = "Rome" },
            new Doctors { FirstName = "Zizi", LastName = "Lastname", Category = "ophtalmo", Email = "vako@gmail.com", Place = "Milan" },

        };

            _context.Doctors.AddRange(initialDoctors);
            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctors>>> GetDoctors()
        {
            return Ok(await _context.Doctors.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Doctors>>> CreateDoctors(Doctors doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return Ok(await _context.Doctors.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Doctors>>> UpdateDoctors(Doctors doctor)
        {
            var dbdoctor = await _context.Doctors.FindAsync(doctor.Id);
            if (dbdoctor == null)
                return BadRequest("doctor not found.");

            dbdoctor.FirstName = doctor.FirstName;
            dbdoctor.LastName = doctor.LastName;
            dbdoctor.Email = doctor.Email;
            dbdoctor.Category =doctor.Category;
            dbdoctor.Place = doctor.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.Doctors.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Doctors>>> DeleteDoctors(int id)
        {
            var dbdoctor = await _context.Doctors.FindAsync(id);
            if (dbdoctor == null)
                return BadRequest("doctor not found.");

            _context.Doctors.Remove(dbdoctor);
            await _context.SaveChangesAsync();

            return Ok(await _context.Doctors.ToListAsync());
        }
    }
}
