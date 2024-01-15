using System;
using ClinicManagementSystem.BLL.Interfaces;
using ClinicManagementSystem.DAL.Context;
using ClinicManagementSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.BLL.Repository
{
	public class DoctorRepository : GenericRepository<Doctor> , IDoctorRepository
    {
        private readonly ApplicationDbContext _context;
		public DoctorRepository(ApplicationDbContext contexte):base(contexte)
		{
            _context = contexte;
		}

        public List<Doctor> GetDoctorsBySpecialization(int id)
        {
            var doctors = _context.Doctors
        .Where(d => d.Spatialization.SpatializationID==id)
        .ToList();
            return doctors;
        }
    }
}

