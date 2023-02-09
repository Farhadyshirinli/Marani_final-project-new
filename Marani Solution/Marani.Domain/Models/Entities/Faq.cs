using Marani.Domain.AppCode.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Marani.Domain.Models.Entities
{
    public class Faq : BaseEntity
    {
        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

    }
}
