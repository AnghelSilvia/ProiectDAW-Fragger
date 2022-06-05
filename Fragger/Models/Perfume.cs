using System;
using System.Collections.Generic;

namespace Fragger.Models
{
    public class Perfume
    {
        public int PerfumeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Brand Brand { get; set; }

        public virtual ICollection<PerfumeNote> PerfumeNotes { get; set; }
    }
}
