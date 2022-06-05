using System.ComponentModel.DataAnnotations;

namespace Fragger.Models
{
    public class PerfumeNote
    {
        [Key]
        public int PerfumeId { get; set; }
        public Perfume Perfume { get; set; }

        [Key]
        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}
