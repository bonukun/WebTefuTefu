namespace WebTefuTefu.Domains.Models
{
    public class BibTeXMap{
        /// <summary>
        /// 住所
        /// /// </summary>
        /// <value></value>
        public string? Address{get;set;} ="取得不能";

        /// <summary>
        /// 注釈
        /// </summary>
        /// <value></value>
        public string? Annote{get;set;} ="取得不能";

        /// <summary>
        /// 著者名
        /// </summary>
        /// <value></value>
        public IEnumerable<AuthorName>? Authors{get;set;}

        /// <summary>
        /// 本のタイトル
        /// </summary>
        /// <value></value>
        public string? Booktitle{get;set;}="タイトル取得不能";

        /// <summary>
        /// 相互参照用のキー
        /// </summary>
        /// <value></value>
        public string? Crossref{get;set;}="取得不能";

        /// <summary>
        ///　章番号
        /// </summary>
        /// <value></value>
        public string? Chapter{get;set;}="章番号取得不能";

        /// <summary>
        /// 書籍の版
        /// </summary>
        /// <value></value>
        public string? Edition{get;set;}="版取得不能";

        /// <summary>
        /// 編著者名
        /// </summary>
        /// <value></value>
        public IEnumerable<AuthorName>? Editor{get;set;}

        /// <summary>
        ///　電子出版時の指定
        /// </summary>
        /// <value></value>
        public string? Epirnt {get;set;}="取得不能";

        /// <summary>
        /// 出版形態
        /// </summary>
        /// <value></value>
        public string? Howpublished{get;set;}="取得不能";

        /// <summary>
        /// 出版社以外に関係した機関
        /// </summary>
        /// <value></value>
        public string? Institution{get;set;}="取得不能";

        /// <summary>
        /// 雑誌名
        /// </summary>
        /// <value></value>
        public string? Journal{get;set;}="雑誌名取得不能";

        /// <summary>
        /// 順番指定用のパラメータ
        /// </summary>
        /// <value></value>
        public string? Key {get;set;}="取得不能";

        /// <summary>
        /// 出版月
        /// </summary>
        /// <value></value>
        public string? Month {get;set;}="出版月取得不能";

        /// <summary>
        /// 注記
        /// </summary>
        /// <value></value>
        public string? Note {get;set;}="取得不能";

        /// <summary>
        /// 雑誌テクニカルレポートの号数
        /// </summary>
        /// <value></value>
        public string?  Number {get;set;}="号数取得不能";

        /// <summary>
        /// 会議の主催者
        /// </summary>
        /// <value></value>
        public string? Organization {get;set;}="取得不能";

        /// <summary>
        /// ページ
        /// </summary>
        /// <value></value>
        public Pages? Pages {get;set;}

        /// <summary>
        /// 出版社名
        /// </summary>
        /// <value></value>
        public string? Publisher {get;set;}="出版社取得不能";

        /// <summary>
        /// 学位論文の場合に学位の提出大学
        /// </summary>
        /// <value></value>
        public string? School {get;set;}="大学名取得不能";

        /// <summary>
        /// 書籍のシリーズ名
        /// </summary>
        /// <value></value>
        public string? Series {get;set;}="シリーズ名取得不能";

        /// <summary>
        /// タイトル
        /// </summary>
        /// <value></value>
        public string? Title {get;set;}="タイトル取得不能";

        /// <summary>
        /// 報告種別
        /// </summary>
        /// <value></value>
        public string? Type {get;set;}="取得不能";

        /// <summary>
        /// url
        /// </summary>
        /// <value></value>
        public string? URL {get;set;}="URL取得不能";

        /// <summary>
        /// 雑誌または、書籍の巻数
        /// </summary>
        /// <value></value>
        public string? Volume  {get;set;}="巻数取得不能";

        /// <summary>
        /// 出版年
        /// </summary>
        /// <value></value>
        public string? Year {get;set;}="出版年取得不能";

        /// <summary>
        /// ISSN
        /// </summary>
        /// <value></value>
        public string? ISSN {get;set;}="ISSN取得不能";

        /// <summary>
        /// DOI
        /// </summary>
        public string? DOI {get;set;}="DOIs取得不能";


        /// <summary>
        /// 一般的ではないBibTeXフィールドを定義する。
        /// </summary>
        /// <value></value>
        public IEnumerable<string>? Others{get;set;}

        /// <summary>
        /// @から始まる文字列
        /// </summary>
        /// <value></value>
        public string MediaType {get; set;}

        /// <summary>
        /// ID
        /// </summary>
        /// <value></value>
        public string Id {get; set;}

    }

}
