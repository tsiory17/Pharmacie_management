using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Pharmacie_management.Dtos.MedicineDto
{
    public class UpdateMedicineDto
    {
        public int MedicineId { get; set; }
        public string? MedName { get; set; }
        public double? MedPrice { get; set; }
    }
}