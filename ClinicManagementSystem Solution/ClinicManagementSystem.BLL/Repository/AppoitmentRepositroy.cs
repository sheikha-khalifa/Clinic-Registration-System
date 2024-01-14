using System;
using ClinicManagementSystem.BLL.Interfaces;
using ClinicManagementSystem.DAL.Context;
using ClinicManagementSystem.DAL.Models;

namespace ClinicManagementSystem.BLL.Repository
{
	public class AppoitmentRepositroy :GenericRepository<Appoitment>, IAppointmantRepository
    {
		public AppoitmentRepositroy(ApplicationDbContext context) :base (context)
		{
		}
	}
}

