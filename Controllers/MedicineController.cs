using Microsoft.AspNetCore.Mvc;
using Pharmacie_management.Data;
using Pharmacie_management.Dtos;

namespace Pharmacie_management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicineController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public MedicineController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost("add-medicine")]
        public IActionResult CreateMedicine(MedicineDto medicineDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _appDbContext.Medicines.Add(new Models.Medicine
            {
                MedName = medicineDto.MedName,
                MedPrice = medicineDto.MedPrice
            });
            _appDbContext.SaveChanges();
            return Ok(new { message = "new medicine created" });
        }
    }

}