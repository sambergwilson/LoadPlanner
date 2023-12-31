﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadPlanner.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace LoadPlanner.DataAccess.Context
{
    public class LoadPlannerContext : DbContext
    {
        public LoadPlannerContext(DbContextOptions options) : base(options)
        {
        }

        public LoadPlannerContext()
        {

        }

        // This property is of DbSet < Model > variable you call on
        public DbSet<LoadPlannerModel> LoadModel { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-GMO2ILF\\SQLEXPRESS02;Database=LoadPlanner;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoadPlannerModel>(
                entity =>
                {
                    // This is where you set up the 
                    // Configurations of the Db properites
                    // When you mess up you change the name the table is reading
                    entity.ToTable("LoadInformation");
                    entity.HasKey(e => e.LoadID);
                    entity.Property(e => e.LoadID);
                    entity.Property(e => e.LoadCode);
                    entity.Property(e => e.RouteNumber);
                    entity.Property(e => e.LocationCode);
                    entity.Property(e => e.LocationDescription);
                    entity.Property(e => e.LocationAddress);
                    entity.Property(e => e.DriverName).IsRequired(required:false);
                    entity.Property(e => e.DriverCode);
                    entity.Property(e => e.TruckCode).IsRequired(required: false);
                    entity.Property(e => e.IsAssigned);
                    entity.Property(e => e.IsDeleted);
                    entity.Property(e => e.AssignedDate);
                    entity.Property(e => e.CompletedDate);
                    entity.Property(e => e.IsArchived);
                }

                );
        }
    }
}
