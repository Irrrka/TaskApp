using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskApi.Data.Models
{
    [NotMapped]
    public class BaseModel
    {
        public int Id { get; protected set; }
    }
}
