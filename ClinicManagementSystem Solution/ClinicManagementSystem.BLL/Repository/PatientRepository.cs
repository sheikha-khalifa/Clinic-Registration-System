using System;
using ClinicManagementSystem.BLL.Interfaces;
using ClinicManagementSystem.DAL.Context;
using ClinicManagementSystem.DAL.Models;

namespace ClinicManagementSystem.BLL.Repository
{
	public class PatientRepository : GenericRepository<Patient> , IPatientRepository
    {
		public PatientRepository(ApplicationDbContext contexte) : base(contexte)
        {
		}
	}
}

