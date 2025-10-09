using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacie_management.Data;
using Pharmacie_management.Dtos.MedicineDto;
using Pharmacie_management.Models;

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

        [HttpPost]
        public IActionResult CreateMedicine(CreateMedicineDto medicineDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _appDbContext.Medicines.Add( new Medicine
            {
                MedName = medicineDto.MedName,
                MedPrice = medicineDto.MedPrice
            });

            _appDbContext.SaveChanges();

            return Ok(new { message = "new medicine created" });
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateMedicineByName(int id,[FromBody] UpdateMedicineDto medicine)
        {
            /*1- Find if a medicine exist 
                2- if it exist change and update 
                3- save changes 
            */
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var medicineToUpdate = await _appDbContext.Medicines.FindAsync(id);

            if (medicineToUpdate == null )
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            // var medicineToDelete = await _appDbContext.Medicines.FindAsync(id);

            // if (medicineToDelete == null)
            // {
            //     return BadRequest("the medicine you are trying to delete does not exist");
            // }
            var medicineToDelete = new Medicine(id);
            _appDbContext.Medicines.Remove(medicineToDelete);
            await _appDbContext.SaveChangesAsync();

            return Ok(new { message = "The medicine has been successfully deleted" });
        }
    }

}