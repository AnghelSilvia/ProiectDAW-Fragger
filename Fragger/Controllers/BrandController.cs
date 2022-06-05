using Fragger.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fragger.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : Controller
    {
        private readonly FraggerContext _context;
        public BrandController(FraggerContext context)
        {
            _context = context;
        }

        public static List<Brand> Brands = new List<Brand>
        {
            new Brand { 
                BrandId = 1, 
                Name = "Mugler", 
                EstablishDate = new DateTime(2002, 01, 03),
                Contact = new Contact
                {
                    ContactId = 1, 
                    email = "test1@test.tst", 
                    phone = "43413131"
                }
            },
            new Brand { 
                BrandId = 2,
                Name = "Jean Paul Gaultier", 
                EstablishDate = new DateTime(2002, 01, 03),
                Contact = new Contact
                {
                    ContactId = 2,
                    email = "test2@test.tst",
                    phone = "43413132"
                }
            },
            new Brand { 
                BrandId = 3, 
                Name = "Chanel", 
                EstablishDate = new DateTime(2002, 01, 03),
                Contact = new Contact
                {
                    ContactId = 3,
                    email = "test3@test.tst",
                    phone = "43413132"
                }
            },
            new Brand { 
                BrandId = 4, 
                Name = "Parfums de Marly",
                EstablishDate = new DateTime(2002, 01, 03) ,
                Contact = new Contact
                {
                    ContactId = 4, 
                    email = "test2@test.tst", 
                    phone = "43413132" 
                }
            }
        };

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            return Ok(Brands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadById([FromRoute] int id)
        {
            var brand = Brands.FirstOrDefault(x => x.BrandId == id);
            if (brand == null)
                return NotFound();
            return Ok(brand);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Brand brand)
        {
            Brands.Add(brand);

            return Ok(Brands);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Brand brand)
        {
            var BrandToUpdate = Brands.FirstOrDefault(x => x.BrandId == brand.BrandId);
            BrandToUpdate.Name = brand.Name;

            return Ok(Brands);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var brandToRemove = Brands.FirstOrDefault(x => x.BrandId == id);
            Brands.Remove(brandToRemove);

            return Ok(Brands);
        }
    }
}
