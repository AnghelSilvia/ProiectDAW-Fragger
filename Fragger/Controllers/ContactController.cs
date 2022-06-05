using Fragger.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fragger.Controllers
{
    public class ContactController : Controller
    {
        public static List<Contact> Contacts = new List<Contact>
        {
            new Contact { ContactId = 1, email = "test1@test.tst", phone = "43413131"},
            new Contact { ContactId = 2, email = "test2@test.tst", phone = "43413156"},
            new Contact { ContactId = 3, email = "test3@test.tst", phone = "43413178"}
        };

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            return Ok(Contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadById([FromRoute] int id)
        {
            var note = Contacts.FirstOrDefault(x => x.ContactId == id);
            if (note == null)
                return NotFound();
            return Ok(note);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Contact contact)
        {
            Contacts.Add(contact);
            return Ok(Contacts);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Contact contact)
        {
            var contactToUpdate = Contacts.FirstOrDefault(x => x.ContactId == contact.ContactId);
            contactToUpdate.email = contact.email;

            return Ok(Contacts);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var noteToRemove = Contacts.FirstOrDefault(x => x.ContactId == id);
            Contacts.Remove(noteToRemove);

            return Ok(Contacts);
        }
    }
}
