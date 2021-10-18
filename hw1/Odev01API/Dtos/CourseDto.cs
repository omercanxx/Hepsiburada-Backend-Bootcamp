using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Odev01API.Dtos
{
    public class CourseDto
    {
        public CourseDto(int id, string title, decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
            IsActive = true;
        }
        [DisplayName("Id")]
        [Required(ErrorMessage = "Id alanı dolu olmalı")]
        public int Id { get; protected set; }
        [DisplayName("İsim")]
        [Required]
        public string Title { get; protected set; }
        [DisplayName("Fiyat")]
        [Required]
        public decimal Price { get; protected set; }
        [DisplayName("Aktif")]
        public bool IsActive { get; protected set; }

        public void UpdateTitle(string title)
        {
            Title = title;
        }
        public void UpdatePrice(decimal price)
        {
            Price = price;
        }
        public void UpdateActivation(bool isActive)
        {
            IsActive = isActive;
        }
    }
}

