using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet(Name = "test")]
    public string Get()
    {
        Console.WriteLine("通信しました。");
        return "Hello";
    }
}
