﻿using BlogDemo.core.Entities;
using BlogDemo.Infrastructure.Database.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDemo.Infrastructure.Database
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PostConfiguration());
        }

        public DbSet<Post> Posts { get; set; }
    }
}
