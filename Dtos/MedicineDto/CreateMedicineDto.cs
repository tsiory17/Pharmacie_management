using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Pharmacie_management.Dtos.MedicineDto
{
    public class CreateMedicineDto
    {
        [Required]
        public string? MedName { get; set; }
        public string? GenericName { get; set; }
        public string? Description { get; set; }
        public double? SellingPrice { get; set; }
        public double? percentage { get; set; } = .20;
        public double? BuyingPrice { get; set; }

        public int quantity { get; set; }
        public string? Location { get; set; }

        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }

        public void SetSellingPrice()
        {
             this.SellingPrice = this.BuyingPrice * (1+this.percentage);
        }
    }
}