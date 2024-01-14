using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.DAL.Models
{
	public class Patient
	{
		[Key]
		public int PatientID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

		[Required]
		public int Age { get; set; }

		[Required]
		public long PhoneNo { get; set; }

		public ICollection<Appoitment> Appoitments { get; set; }
	}
}

