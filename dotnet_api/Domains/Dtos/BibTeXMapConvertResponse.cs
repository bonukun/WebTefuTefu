using Microsoft.AspNetCore.Mvc.RazorPages;
using WebTefuTefu.Domains.Models;
namespace WebTefuTefu.Domains.Dtos{
    /// <summary>
    /// BibTeXを辞書型に変換する際のレスポンス
    /// </summary>
    public class BibTeXMapConvertResponse{
        /// <summary>
        /// BiBTeXを辞書にしたもの
        /// </summary>
        /// <value></value>
        public BibTeXMap BibTeXMap {get; set;}

    }

}
