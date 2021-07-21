﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirBnbWebApi.Models
{
    public class AirBnbDbContext:DbContext
    {
        public AirBnbDbContext()
        {
        }

        public AirBnbDbContext(DbContextOptions<AirBnbDbContext> options):base(options)
        {

        }
        public DbSet<Host> hosts { get; set; }
    }
}