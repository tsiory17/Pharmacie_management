using Microsoft.EntityFrameworkCore;
namespace Pharmacie_management.Models
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string? MedName { get; set; }
        public double MedPrice { get; set; }
    }
}