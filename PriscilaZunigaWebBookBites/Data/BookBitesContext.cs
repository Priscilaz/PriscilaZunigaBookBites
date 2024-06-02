using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PriscilaZunigaWebBookBites.Models;

namespace PZ.Data
{
    public class BookBitesContext : DbContext
    {
        public BookBitesContext (DbContextOptions<BookBitesContext> options)
            : base(options)
        {
        }

        public DbSet<PriscilaZunigaWebBookBites.Models.PZLibro> PZLibro { get; set; } = default!;
        public DbSet<PriscilaZunigaWebBookBites.Models.PZCopia> PZCopia { get; set; } = default!;

    }
}
