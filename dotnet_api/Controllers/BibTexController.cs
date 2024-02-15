using Microsoft.AspNetCore.Mvc;
using WebTefufu.Controllers.Dtos;

namespace dotnet_api.Controllers;

[ApiController]



[Route("[controller]")]
/// <summary>
/// BibTeXを受けとり処理するためのコントローラー
/// </summary>
public class BibTeXController : ControllerBase
{
    [HttpGet(Name = "testBibTeX")]
    public string Get()
    {
        Console.WriteLine("通信しました。");
        return "Hello";
    }

    [HttpPost("postBibTeX")]
    public ResponseBibTeXConverter PostBibTeX(
        [FromBody] RequestBibTeXConverter request
    ){
        ResponseBibTeXConverter res = new ResponseBibTeXConverter
        {
            ResultBibTeX = request.BibTeX + "を取得しました。"
        };

        return res;
    }
}
