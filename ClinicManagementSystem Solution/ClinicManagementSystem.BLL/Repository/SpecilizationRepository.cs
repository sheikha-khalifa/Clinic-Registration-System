using System;
using ClinicManagementSystem.BLL.Interfaces;
using ClinicManagementSystem.DAL.Context;
using ClinicManagementSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.BLL.Repository
{
	public class SpecilizationRepository : GenericRepository<Spatialization>, ISpecalizationRepository
    {		public SpecilizationRepository(ApplicationDbContext contexte) : base(contexte)
        {
 
        }
        
    }
}

