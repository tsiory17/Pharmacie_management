using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Pharmacie_management.Dtos.MedicineDto
{
    public class CreateMedicineDto
    {
        [Required]
        public string? MedName { get; set; }
        public double MedPrice { get; set; }
    }
}