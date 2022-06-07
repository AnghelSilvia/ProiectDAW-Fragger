using Fragger.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fragger.Controllers
{
    [ApiController]
    [Route("api/perfumes")]
    public class PerfumeController : Controller
    {
        private readonly FraggerContext _context;
        public PerfumeController(FraggerContext context)
        {
            _context = context;
        }

        public static List<Perfume> Perfumes = new List<Perfume>
        {
            new Perfume { PerfumeId = 1, Name = "Alien", Description = "Descriere Alien", ReleaseDate = new DateTime(2002, 12, 23) },
            new Perfume { PerfumeId = 2, Name = "Scandal", Description = "Descriere Scandal", ReleaseDate = new DateTime(2012, 06, 17) },
            new Perfume { PerfumeId = 3, Name = "Chanel No. 5", Description = "Descriere Chanel No.5", ReleaseDate = new DateTime(1998, 04, 13) },
            new Perfume { PerfumeId = 4, Name = "Delina", Description = "Descriere Delina", ReleaseDate = new DateTime(2017, 04, 13) },
            new Perfume { PerfumeId = 5, Name = "Oriana", Description = "Descriere Oriana", ReleaseDate = new DateTime(2020, 07, 09) },
            new Perfume { PerfumeId = 6, Name = "Good Fortune", Description = "Descriere Good Fortune", ReleaseDate = new DateTime(2022, 06, 01) }
        };
        
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            return Ok(Perfumes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadById([FromRoute] int id)
        {
            var perfume = Perfumes.FirstOrDefault(x => x.PerfumeId == id);
            if (perfume == null)
                return NotFound();
            return Ok(perfume);
        }

        [HttpGet("latest")]
        public async Task<IActionResult> ReadLatest()
        {
            DateTime dateLatest = DateTime.Now.AddDays(-30);
            // parfumurile lansate in ultima luna
            var perfumes = Perfumes.Where(x => x.ReleaseDate > dateLatest);

            return Ok(perfumes);
        }


        [HttpPost]
        public async Task <IActionResult> Add([FromBody] Perfume perfume)
        {
            Perfumes.Add(perfume);

            return Ok(Perfumes);
        }

        [HttpPut]
        public async Task <IActionResult> Update([FromBody] Perfume perfume)
        {
            var perfumeToUpdate = Perfumes.FirstOrDefault(x => x.PerfumeId == perfume.PerfumeId);
            perfumeToUpdate.Name = perfume.Name;

            return Ok(Perfumes);
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete([FromRoute] int id)
        {
            var perfumeToRemove = Perfumes.FirstOrDefault(x => x.PerfumeId == id);
            Perfumes.Remove(perfumeToRemove);

            return Ok(Perfumes);
        }
    }
}
