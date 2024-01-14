using System;
using ClinicManagementSystem.BLL.Interfaces;
using ClinicManagementSystem.DAL.Context;
using ClinicManagementSystem.DAL.Models;

namespace ClinicManagementSystem.BLL.Repository
{
	public class DoctorRepository : GenericRepository<Doctor> , IDoctorRepository
    {
		public DoctorRepository(ApplicationDbContext contexte):base(contexte)
		{
		}
	}
}

