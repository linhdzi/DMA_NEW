using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD_GIT.Models;

namespace CRUD_GIT.Data
{
    public class CRUD_GITContext : DbContext
    {
        public CRUD_GITContext (DbContextOptions<CRUD_GITContext> options)
            : base(options)
        {
        }

        public DbSet<CRUD_GIT.Models.Ward> Ward { get; set; } = default!;

        public DbSet<CRUD_GIT.Models.Nurse>? Nurse { get; set; } = default!;
    }
}
