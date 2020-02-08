namespace TaskApi.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Employee : BaseModel
    {
        [Required]
        [MinLength(DataConstants.MinLenghtName)]
        [MaxLength(DataConstants.MaxLenghtName)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(DataConstants.MinLenghtName)]
        [MaxLength(DataConstants.MaxLenghtName)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? StartingDate { get; set; }

        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        [Range(20, 250)]
        public int VacationDays { get; set; }

        public EmployeeExperienceLevel ExperienceLevel { get; set; }

        //public int OfficeId { get; set; }

        //public virtual Office Office { get; set; }

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
