using Fragger.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fragger.Controllers
{
    [ApiController]
    [Route("api/notes")]
    public class NoteController : Controller
    {

        public static List<Note> Notes = new List<Note>
        {
            new Note { NoteId = 1, Name = "Jasmine" },
            new Note { NoteId = 2, Name = "Woodsy Notes" },
            new Note { NoteId = 3, Name = "Amber" },
            new Note { NoteId = 4, Name = "Coffee" },
            new Note { NoteId = 5, Name = "Bulgarian Rose" },
            new Note { NoteId = 6, Name = "Orange" },
            new Note { NoteId = 7, Name = "Honey" },
            new Note { NoteId = 8, Name = "Cinnamon" }
        };

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            return Ok(Notes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadById([FromRoute] int id)
        {
            var note = Notes.FirstOrDefault(x => x.NoteId == id);
            if (note == null)
                return NotFound();
            return Ok(note);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Note note)
        {
            Notes.Add(note);
            return Ok(Notes);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Note note)
        {
            var noteToUpdate = Notes.FirstOrDefault(x => x.NoteId == note.NoteId);
            noteToUpdate.Name = note.Name;

            return Ok(Notes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var noteToRemove = Notes.FirstOrDefault(x => x.NoteId == id);
            Notes.Remove(noteToRemove);

            return Ok(Notes);
        }
    }
}
