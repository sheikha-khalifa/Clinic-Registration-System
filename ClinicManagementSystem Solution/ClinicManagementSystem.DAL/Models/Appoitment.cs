using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagementSystem.DAL.Models
{
	public class Appoitment
	{
		[Key]
		public int AppointmentId { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime Date { get; set; }

		[Required]
		public string Status { get; set; }

		//Foreign Key Patient Entity
		[ForeignKey("Patient")]
        public int PatientID { get; set; }
        public Patient Patient { get; set; }

        //Foriegn Key Doctor Entity
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
		public Doctor Doctor { get; set; }


    }
}

