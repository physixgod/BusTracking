using BusTracking.Domain.ENTITIES;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers;
[Route("bustracking/[controller]")]
[ApiController]
public class Test:ControllerBase

{
    [HttpPost("uploadfile")]
    public test uploadfile()
    {
        test xd = new test();
        return xd;
    }
    
    

}