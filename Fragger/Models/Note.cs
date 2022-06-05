using System.Collections.Generic;

namespace Fragger.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PerfumeNote> PerfumeNotes { get; set; }
    }
}
