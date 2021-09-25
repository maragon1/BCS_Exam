using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BCS_Exam.Models
{
    public partial class SpokenToGuests
    {
        [Key]
        public string ResId { get; set; }
        public string UserEmail { get; set; }
    }
}
