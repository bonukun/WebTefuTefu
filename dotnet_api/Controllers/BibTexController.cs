using Microsoft.AspNetCore.Mvc;
using WebTefufu.Controllers.Dtos;
using WebTefufu.Domains;
using WebTefufu.Domains.Dtos;
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
        BibTeXParserInteractor interactor = new BibTeXParserInteractor();
        var resulut_string = interactor.ParserBibTex(new RequestBibTeXParser { BibTeX=request.BibTeX});
        res.ResultBibTeX=resulut_string.BibTeXResult;

        return res;
    }
}
