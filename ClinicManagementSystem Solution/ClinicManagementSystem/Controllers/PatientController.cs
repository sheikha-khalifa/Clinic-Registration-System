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
        [HttpGet]
        public IActionResult CreateAppoin(int id)
        {
            List<Spatialization> spec = _specialization.GetAll().ToList();
            ViewBag.specList = new SelectList(spec, "SpatializationID", "Name");

            //ViewBag.SpeLis = _specialization.GetAll();

            var patientName = _patientRepository.GetpatientName(id);
            ViewBag.patientName = patientName;
            ViewBag.patientID = id;
            //List<Doctor> doctors = _doctorRepository.GetAll().ToList();
            //ViewBag.DoctorList = new SelectList(doctors, "DoctorId", "Name");
            //var appointment = new Appoitment { PatientID = id, Patien = patient };

            // Populate ViewBag.DoctorList and ViewBag.specList as needed

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
            return View(appo);
        }
        public IActionResult GetDocInSpec(int id)
        {
            var doctors = _doctorRepository.GetDoctorsBySpecialization(id);
            return Json(doctors);
        }

        public IActionResult ViewAppointments(int id)
        {
            List<Appoitment> apooi = _patientRepository.GetAllAppointment(id);
            ViewBag.PatientName = _patientRepository.Get(id).Name;
            return View(apooi);
        }
    }
}
