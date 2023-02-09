using Marani.Domain.AppCode.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marani.Domain.Models.Entities
{
    public class Subscribe : BaseEntity
    {
        [Required(ErrorMessage = "{0} cannot be left empty")]
        public string Email { get; set; }
        public DateTime ApprovedDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
