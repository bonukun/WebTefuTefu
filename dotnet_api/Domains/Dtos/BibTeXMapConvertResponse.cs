using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTefuTefu.Domains.Models;
namespace WebTefuTefu.Domains.Dtos{
    /// <summary>
    /// BibTeXを辞書型に変換する際のレスポンス
    /// </summary>
    public class BibTeXMapConvertResponse{
        public string? Address{get;set;}
        public string? Annote{get;set;}
        public IEnumerable<AuthorName> Authors{get;set;}

        public string? Booktitle{get;set;}
        public string? Crossref{get;set;}
        public int Chapter{get;set;}
        public string? Edition{get;set;}
        public IEnumerable<AuthorName> Editor{get;set;}
        public string? Epirnt {get;set;}
        public string? Howpublished{get;set;}
        public string? Institution{get;set;}
        public string? Journal{get;set;}
        public string? Key {get;set;}
        public string? Month {get;set;}
        public string? Note {get;set;}
        public int  Number {get;set;}
        public string? Organization {get;set;}
        public Page Pages {get;set;}
        public string? Publisher {get;set;}
        public string? School {get;set;}
        public string? Series {get;set;}
        public string? Title {get;set;}
        public string? Type {get;set;}
        public string? Url {get;set;}
        public int Volume  {get;set;}
        public int Year {get;set;}

    }

}
