﻿using Microsoft.EntityFrameworkCore;
using PhDSystem.Data.POCOs;

namespace PhDSystem.Data
{
    public class PhdSystemContext : DbContext
    {
        public PhdSystemContext(DbContextOptions<PhdSystemContext> options) : base(options)
        {

        }

        public virtual DbSet<Student> Students { get; set; }
    }
}
