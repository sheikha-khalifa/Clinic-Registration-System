using System;
using ClinicManagementSystem.DAL.Models;

namespace ClinicManagementSystem.BLL.Interfaces
{
	public interface IPatientRepository : IGenericRepository<Patient>
	{

		string GetpatientName(int id);

		List<Appoitment> GetAllAppointment(int id);
	}


}

