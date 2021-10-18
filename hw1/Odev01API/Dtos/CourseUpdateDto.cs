using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Odev01API.Dtos
{
    public class CourseUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("İsim")]
        [Required]
        public string Title { get; set; }
        [DisplayName("Fiyat")]
        [Required]
        public decimal Price { get; set; }
    }
}
