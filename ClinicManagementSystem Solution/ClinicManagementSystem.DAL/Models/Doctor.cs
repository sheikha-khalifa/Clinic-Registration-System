using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagementSystem.DAL.Models
{
	public class Doctor
	{
        [Key]
		public int DoctorId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Column(TypeName ="decimal(7,3)")]
        public double Salary { get; set; }

        [Required]
		public int Age { get; set; }

        [Required]
		public long PhoneNo { get; set; }


        //Foriegn Key Spatialization Entity
        [ForeignKey("Spatialization")]
        public int SpatializationId { get; set; }
		public Spatialization? Spatialization { get; set; }

	}
}

