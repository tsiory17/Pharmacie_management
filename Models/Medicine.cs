using Microsoft.EntityFrameworkCore;
namespace Pharmacie_management.Models
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string? MedName { get; set; }
        public string? GenericName { get; set; }
        public string? Description { get; set; }
        public double? SellingPrice { get; set; }
        public double? percentage { get; set; } = .20;
        public double? BuyingPrice { get; set; }
        public int quantity { get; set; }
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public Medicine(int id)
        {
            MedicineId = id;
        }
        public Medicine()
        {

        }

    }
}