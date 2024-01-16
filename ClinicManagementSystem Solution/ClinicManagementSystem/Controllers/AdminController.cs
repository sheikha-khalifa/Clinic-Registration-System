using ClinicManagementSystem.BLL.Interfaces;
using ClinicManagementSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            ViewBag.Patients = _patientRepository.GetAll();
            ViewBag.Doctors = _doctorRepository.GetAll();
            ViewBag.Spatializations = _specialization.GetAll();
            return View(app);
        }
        public IActionResult IndexDoctor()
        {
            var doc = _doctorRepository.GetAll();
            ViewBag.Spatializations = _specialization.GetAll();
            return View(doc);
        }
        public IActionResult IndexSpecialization()
        {
            var spe = _specialization.GetAll();
            return View(spe);
        }
     

        public IActionResult Create()
        {
            ViewBag.Spatializations = _specialization.GetAll();

            List<Spatialization> splist = _specialization.GetAll().ToList();
            ViewBag.Sps = new SelectList(splist, "SpatializationID", "Name");
            return View();
        }
        [HttpPost]
         public IActionResult Create(Doctor doc)
        {
            if (ModelState.IsValid)
            {
            _doctorRepository.Create(doc);
            return RedirectToAction("IndexDoctor");

            }
            return View(doc);
        }
        public IActionResult CreateSpecilization()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSpecilization(Spatialization spe)
        {
            _specialization.Create(spe);
            return RedirectToAction("IndexSpecialization");
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

        [HttpGet]
        public IActionResult UpdateAppoitment(int id)
        {
            var appo = _appointmant.Get(id);
            ViewBag.Patients = _patientRepository.GetAll();
            ViewBag.Doctors = _doctorRepository.GetAll();
            return View(appo);
        }
        [HttpPost]
        public IActionResult UpdateAppoitment(Appoitment appo)
        {
            if (ModelState.IsValid)
            {
                _appointmant.Update(appo);
                return RedirectToAction("Index");
            }
            return View(appo);
        }

        public IActionResult Details(int? id )
        {
            if (id == null)
            {
                return BadRequest();
            }
            var appo = _appointmant.Get(id.Value);
            return View(appo);
        }

    }
}
