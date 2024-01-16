using ClinicManagementSystem.BLL.Interfaces;
using ClinicManagementSystem.BLL.Repository;
using ClinicManagementSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicManagementSystem.PL.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly ISpecalizationRepository _specialization;
        private readonly IAppointmantRepository _appointmant;

        public PatientController(IPatientRepository patientRepo, IDoctorRepository doctorRepo, ISpecalizationRepository specalizationRepo, IAppointmantRepository appointmantRepo)
        {
            _patientRepository = patientRepo;
            _doctorRepository = doctorRepo;
            _specialization = specalizationRepo;
            _appointmant = appointmantRepo;
        }
        public IActionResult Index()
        {
            var patient=_patientRepository.GetAll();
            return View(patient);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patient p)
        {
                if (ModelState.IsValid)
            {
                _patientRepository.Create(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public IActionResult CreateAppoin()
        {
            List<Doctor> doctors = _doctorRepository.GetAll().ToList();
            ViewBag.DoctorList = new SelectList(doctors, "DoctorId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateAppoin(Appoitment appo)
        {
            if (ModelState.IsValid)
            {
                _appointmant.Create(appo);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int id)
        {
            var appo = _appointmant.Get(id);
            //ViewBag.Departments = _departmentrepo.GetAll();
            return View(appo);
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

        public IActionResult Delete(int id)
        {
            var appo = _appointmant.Get(id);
            return View(appo);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var appo = _appointmant.Get(id);
            _appointmant.Delete(appo);
            return RedirectToAction("Index");
        }
    }
}
