namespace WebTefuTefu.Domains.Dtos{
/// <summary>
/// コントローラーから送信されるリクエストの型を定義
/// </summary>
    public class BibTeXParserRequest {
        /// <summary>
        /// BibTeX
        /// </summary>
        public string BibTeXString {get; set;}
    }
}
