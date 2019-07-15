using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Models.Repositories.EF
{
    public class DVDContext : DbContext
    {
        public DVDContext() : base("DVDLibraryEF")
        {
        }

        public DbSet<DVD> DVDs { get; set; }
    }
}