using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.DAL.Models
{
	public class Spatialization
	{
		public int SpatializationID { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

		public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

		public ICollection<Doctor> Doctors { get; set; }
	}
}

