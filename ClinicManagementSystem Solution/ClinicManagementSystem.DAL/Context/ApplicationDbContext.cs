using System;
using ClinicManagementSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.DAL.Context
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Patient> Patients { get; set; }
		public DbSet<Appoitment> Appoitments { get; set; }
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Spatialization> Spatializations { get; set; }

    }
}

