using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fragger.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public DateTime EstablishDate { get; set; }

        public virtual ICollection<Perfume> Perfumes { get; set; }

        public Contact Contact { get; set; }
    }
}
