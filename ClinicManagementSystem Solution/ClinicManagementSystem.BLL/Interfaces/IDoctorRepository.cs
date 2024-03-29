﻿using System;
using ClinicManagementSystem.DAL.Models;

namespace ClinicManagementSystem.BLL.Interfaces
{
	public interface IDoctorRepository :IGenericRepository<Doctor>
	{
		List<Doctor> GetDoctorsBySpecialization(int id);
	}
}

