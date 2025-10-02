using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Pharmacie_management.Dtos
{
    public class MedicineDto
    {
        [Required]
        public string? MedName { get; set; }
        public double MedPrice { get; set; }
    }
}