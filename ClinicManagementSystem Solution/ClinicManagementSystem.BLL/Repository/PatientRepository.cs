using System;
using ClinicManagementSystem.BLL.Interfaces;
using ClinicManagementSystem.DAL.Context;
using ClinicManagementSystem.DAL.Models;

namespace ClinicManagementSystem.BLL.Repository
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly ApplicationDbContext _context;
		public PatientRepository(ApplicationDbContext contexte) : base(contexte)
        {
            _context = contexte;
		}

        public List<Appoitment> GetAllAppointment(int id)
        {
            var appoints = _context.Appoitments.Where(a=>a.PatientID==id).ToList();
            return appoints;
        }

        public string GetpatientName(int id)
        {
            return _context.Patients.FirstOrDefault(n => n.PatientID == id).Name;
        }
    }
}

