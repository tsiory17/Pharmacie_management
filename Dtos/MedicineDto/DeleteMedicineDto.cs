using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Pharmacie_management.Dtos.MedicineDto
{
    public class DeleteMedicineDto
    {
        public int MedicineId { get; set; }
    
    }
}