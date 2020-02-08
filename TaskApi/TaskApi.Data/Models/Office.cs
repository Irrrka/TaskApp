using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskApi.Data.Models
{
    public class Office : BaseModel
    {
        //CustomValidation?
        [Required]
        [MinLength(DataConstants.MinLenghtName)]
        [MaxLength(DataConstants.MaxLenghtName)]
        public string Country { get; set; }

        //CustomValidation?
        [Required]
        [MinLength(DataConstants.MinLenghtName)]
        [MaxLength(DataConstants.MaxLenghtName)]
        public string City { get; set; }

        [Required]
        [MinLength(DataConstants.MinLenghtName)]
        [MaxLength(DataConstants.MaxLenghtName)]
        public string Street { get; set; }

        [Required]
        [Range(1, 500)]
        public int StreetNumber { get; set; }

        [Required]
        public bool Headquarters { get; set; }

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
