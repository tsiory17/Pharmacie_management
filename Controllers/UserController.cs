using Microsoft.AspNetCore.Mvc;
using Pharmacie_management.Data;
using Pharmacie_management.Dtos.UserDto;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _appDbContext;
    public UserController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpPatch("update-user")]
    public async Task<IActionResult> UpdateUser(UpdateUserDto user)
    {
        var userToUpdate = await _appDbContext.Users.FindAsync(user.UserId);
        if (userToUpdate == null)
        {
            return BadRequest("user not found");
        }
        if (!string.IsNullOrWhiteSpace(user.Name))
        {
            userToUpdate.Name = user.Name;
        }
        if (user.Password != null && user.Password.Length >= 4)
        {
            userToUpdate.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        }

        await _appDbContext.SaveChangesAsync();

        return Ok("user has been updated");
    }

    [HttpDelete("delete-user")]
    public async Task<IActionResult> DeleteUser(DeleteUserDto user)
    {
        var userToDelete = await _appDbContext.Users.FindAsync(user.UserId);

        if (userToDelete == null)
        {
            return BadRequest("the user you are trying to delete does not exist");
        }

        _appDbContext.Users.Remove(userToDelete);
        await _appDbContext.SaveChangesAsync();
        

        return Ok(new { message = "The user has been successfully deleted" });
    }
}