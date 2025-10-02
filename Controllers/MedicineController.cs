using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacie_management.Data;
using Pharmacie_management.Dtos.MedicineDto;

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
        public IActionResult CreateMedicine(CreateMedicineDto medicineDto)
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

        [HttpPatch("update-medicine")]
        public async Task<IActionResult> UpdateMedicineByName(UpdateMedicineDto medicine)
        {
            /*1- Find if a medicine exist 
                2- if it exist change and update 
                3- save changes 
            */
            var medicineToUpdate = await _appDbContext.Medicines.FindAsync(medicine.MedicineId);

            if (medicineToUpdate == null)
            {
                return BadRequest("the medicine doesn't exist");
            }
            if (!string.IsNullOrWhiteSpace(medicine.MedName))
            {
                medicineToUpdate.MedName = medicine.MedName;
            }
            if (medicine.MedPrice != null)
            {
                medicineToUpdate.MedPrice = medicine.MedPrice;
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(new { message = "The medicine has been updated" });
        }

        [HttpDelete("delete-medicine")]
        public async Task<IActionResult> DeleteMedicine(DeleteMedicineDto medicine)
        {
            var medicineToDelete = await _appDbContext.Medicines.FindAsync(medicine.MedicineId);

            if (medicineToDelete == null)
            {
                return BadRequest("the medicine you are trying to delete does not exist");
            }

            _appDbContext.Medicines.Remove(medicineToDelete);
            await _appDbContext.SaveChangesAsync();

            return Ok(new { message = "The medicine has been successfully deleted" });
        }
    }

}