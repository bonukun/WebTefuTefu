using Microsoft.AspNetCore.Mvc;
using WebTefuTefu.Domains;
using WebTefuTefu.Domains.Dtos;
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

/// <summary>
/// 送信されたBibTeX文字列を特定書式に整形するAPI
/// </summary>
/// <param name="request"></param>
/// <returns></returns>
    [HttpPost("postBibTeX")]
    public BibTeXParserResponse PostBibTeX(
        [FromBody] BibTeXParserRequest request,
        [FromServices] IBibTeXParserInteractor service,
        [FromServices] IBibTeXMapConvertInteractor converter

    ){
        var res = service.ParserBibTex(converter,request);
        return res;
    }
}
