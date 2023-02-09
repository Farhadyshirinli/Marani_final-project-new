using Marani.Domain.AppCode.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace Marani.Domain.Models.Entities
{
    public class ContactPost : BaseEntity
    {
        [Required(ErrorMessage ="The {0} field is required")]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        public string Answer { get; set; }
        public int? AnsweredByUserId { get; set; }
        public DateTime? AnswerDate { get; set; }

    }
}
