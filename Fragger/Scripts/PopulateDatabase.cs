using Fragger.Models;
using System;
using System.Collections.Generic;

namespace Fragger.Scripts
{
    public class PopulateDatabase
    {

        public static List<Note> Notes = new List<Note>
        {
            new Note { NoteId = 1, Name = "Jasmine" },
            new Note { NoteId = 2, Name = "Chocolate" },
            new Note { NoteId = 3, Name = "Amber" },
            new Note { NoteId = 4, Name = "Honey" },
            new Note { NoteId = 5, Name = "Bulgarian Rose" },
        };

        public static List<Perfume> Perfumes = new List<Perfume>
        {
            new Perfume { PerfumeId = 1, Name = "Alien", Description = "Descriere Alien", ReleaseDate = new DateTime(2002, 12, 23) },
            new Perfume { PerfumeId = 2, Name = "Scandal", Description = "Descriere Scandal", ReleaseDate = new DateTime(2012, 06, 17) },
            new Perfume { PerfumeId = 3, Name = "Chanel No. 5", Description = "Descriere Chanel No.5", ReleaseDate = new DateTime(1998, 04, 13) },
            new Perfume { PerfumeId = 4, Name = "Delina", Description = "Descriere Delina", ReleaseDate = new DateTime(2017, 04, 13) },
            new Perfume { PerfumeId = 5, Name = "Oriana", Description = "Descriere Oriana", ReleaseDate = new DateTime(2020, 07, 09) }
        };

        public static List<Brand> Brands = new List<Brand>
        {
            new Brand { BrandId = 1, Name = "Mugler", EstablishDate = new DateTime(2002, 01, 03) },
            new Brand { BrandId = 2, Name = "Jean Paul Gaultier", EstablishDate = new DateTime(2002, 01, 03) },
            new Brand { BrandId = 3, Name = "Chanel", EstablishDate = new DateTime(2002, 01, 03) },
            new Brand { BrandId = 4, Name = "Parfums de Marly", EstablishDate = new DateTime(2002, 01, 03) }
        };
    }
}
