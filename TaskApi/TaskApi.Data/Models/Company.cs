namespace TaskApi.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Company : BaseModel
    {
        [Required]
        [MaxLength(DataConstants.MaxLenghtName)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        public virtual ICollection<Office> Offices { get; set; } = new List<Office>();

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
