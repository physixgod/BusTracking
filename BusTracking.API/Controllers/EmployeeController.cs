using BusTracking.Application.Interfaces;
using BusTracking.Domain.ENTITIES;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers;
[Route("bustracking/[controller]")]
[ApiController] 
public class EmployeeController:ControllerBase
{
    private readonly IEmployeesRepository _employeesRepository;

    public EmployeeController(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    [HttpPost("AddEmployee")]
    public IActionResult AddEmployee(Employees employee)
    {
 
        _employeesRepository.AddEmployee(employee);
        return Ok(employee);
    }

    [HttpGet("GetAllEmployees")]
    public IActionResult GetAllEmployees()
    {
        return Ok(_employeesRepository.GetAllEmployess());
    }
    [HttpPost("upload-image/{rfid}")]
    public async Task<IActionResult> UploadImage(int rfid, IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("File not selected");
        }

        var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
        if (!Directory.Exists(uploadsPath))
        {
            Directory.CreateDirectory(uploadsPath);
        }

        var fileName = $"{rfid}_{file.FileName}";
        var filePath = Path.Combine(uploadsPath, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var imageUrl = Path.Combine("uploads", fileName);
        var employee = await _employeesRepository.UpdateEmployeeImageUrl(rfid, imageUrl);
        if (employee == null)
        {
            return NotFound();
        }

        return Ok(new { imageUrl = employee.EmployeeImageUrl });
    }
    [HttpGet("get_image/{rfid}")]
    public IActionResult GetEmployeeImage(int rfid)
    {
        var employee = _employeesRepository.GetAllEmployess().FirstOrDefault(e => e.Rfid == rfid);
        if (employee == null || string.IsNullOrEmpty(employee.EmployeeImageUrl))
        {
            return NotFound();
        }

        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), employee.EmployeeImageUrl);
        if (!System.IO.File.Exists(imagePath))
        {
            return NotFound();
        }

        var imageFileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
        return File(imageFileStream, "image/jpeg");
    }
}
    
