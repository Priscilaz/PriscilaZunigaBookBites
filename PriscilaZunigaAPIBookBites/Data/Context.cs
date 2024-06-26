﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PriscilaZunigaAPIBookBites.Data.Models;

namespace PriscilaZunigaAPIBookBites.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<PriscilaZunigaAPIBookBites.Data.Models.Pzlibro> Pzlibro { get; set; } = default!;
    }
}
