namespace WebTefuTefu.Domains.Dtos{
    /// <summary>
    /// BibTeXを辞書型に変換する際のリクエスト
    /// </summary>
    public class BibTeXMapConvertRequest{
        /// <summary>
        /// 変換対象のBibTeX文字列
        /// </summary>
        /// <value></value>
        public string BibTeXString {get;set;}
    }

}
