using ClinicManagementSystem.BLL.Interfaces;
using ClinicManagementSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.PL.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly ISpecalizationRepository _specialization;
        private readonly IAppointmantRepository _appointmant;

        public AdminController(IPatientRepository patientRepo, IDoctorRepository doctorRepo, ISpecalizationRepository specalizationRepo, IAppointmantRepository appointmantRepo)
        {
            _patientRepository = patientRepo;
            _doctorRepository = doctorRepo;
            _specialization = specalizationRepo;
            _appointmant = appointmantRepo;
        }
        public IActionResult Index()
        {
            var app = _appointmant.GetAll();
            return View(app);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
         public IActionResult Create(Doctor doc)
        {
            _doctorRepository.Create(doc);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var doctor = _doctorRepository.Get(id);
            _doctorRepository.Delete(doctor);
            return RedirectToAction("Index");
        }

        
        public IActionResult Update(int id)
        {
            var doctor = _doctorRepository.Get(id);
            return View(doctor);
        }
        [HttpPost]
        public IActionResult Update(Doctor doc)
        {
            if (ModelState.IsValid)
            {
                _doctorRepository.Update(doc);
                return RedirectToAction("Index");
            }
            return View(doc);
        }


        public IActionResult UpdateAppoitment(int id)
        {
            var appointment = _appointmant.Get(id);
            return View(appointment);
        }
        [HttpPost]
        public IActionResult Update(Appoitment appo)
        {
            if (ModelState.IsValid)
            {
                _appointmant.Update(appo);
                return RedirectToAction("Index");
            }
            return View(appo);
        }

    }
}
