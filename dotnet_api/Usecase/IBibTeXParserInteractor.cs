using WebTefuTefu.Domains.Dtos;
using Microsoft.AspNetCore.Mvc;
public interface IBibTeXParserInteractor{
 public BibTeXParserResponse ParserBibTex([FromServices] IBibTeXMapConvertInteractor converter,BibTeXParserRequest request);
}
