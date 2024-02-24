namespace WebTefuTefu.Domains.Models
{
    public class BibTeXMap{
        /// <summary>
        /// 住所
        /// /// </summary>
        /// <value></value>
        public string? Address{get;set;}

        /// <summary>
        /// 注釈
        /// </summary>
        /// <value></value>
        public string? Annote{get;set;}

        /// <summary>
        /// 著者名
        /// </summary>
        /// <value></value>
        public IEnumerable<AuthorName>? Authors{get;set;}

        /// <summary>
        /// 本のタイトル
        /// </summary>
        /// <value></value>
        public string? Booktitle{get;set;}

        /// <summary>
        /// 相互参照用のキー
        /// </summary>
        /// <value></value>
        public string? Crossref{get;set;}

        /// <summary>
        ///　章番号
        /// </summary>
        /// <value></value>
        public int? Chapter{get;set;}

        /// <summary>
        /// 書籍の版
        /// </summary>
        /// <value></value>
        public string? Edition{get;set;}

        /// <summary>
        /// 編著者名
        /// </summary>
        /// <value></value>
        public IEnumerable<AuthorName>? Editor{get;set;}

        /// <summary>
        ///　電子出版時の指定
        /// </summary>
        /// <value></value>
        public string? Epirnt {get;set;}

        /// <summary>
        /// 出版形態
        /// </summary>
        /// <value></value>
        public string? Howpublished{get;set;}

        /// <summary>
        /// 出版社以外に関係した機関
        /// </summary>
        /// <value></value>
        public string? Institution{get;set;}

        /// <summary>
        /// 雑誌名
        /// </summary>
        /// <value></value>
        public string? Journal{get;set;}

        /// <summary>
        /// 順番指定用のパラメータ
        /// </summary>
        /// <value></value>
        public string? Key {get;set;}

        /// <summary>
        /// 出版月
        /// </summary>
        /// <value></value>
        public string? Month {get;set;}

        /// <summary>
        /// 注記
        /// </summary>
        /// <value></value>
        public string? Note {get;set;}

        /// <summary>
        /// 雑誌テクニカルレポートの号数
        /// </summary>
        /// <value></value>
        public int?  Number {get;set;}

        /// <summary>
        /// 会議の主催者
        /// </summary>
        /// <value></value>
        public string? Organization {get;set;}

        /// <summary>
        /// ページ
        /// </summary>
        /// <value></value>
        public Pages? Pages {get;set;}

        /// <summary>
        /// 出版社名
        /// </summary>
        /// <value></value>
        public string? Publisher {get;set;}

        /// <summary>
        /// 学位論文の場合に学位の提出大学
        /// </summary>
        /// <value></value>
        public string? School {get;set;}

        /// <summary>
        /// 書籍のシリーズ名
        /// </summary>
        /// <value></value>
        public string? Series {get;set;}

        /// <summary>
        /// タイトル
        /// </summary>
        /// <value></value>
        public string? Title {get;set;}

        /// <summary>
        /// 報告種別
        /// </summary>
        /// <value></value>
        public string? Type {get;set;}

        /// <summary>
        /// url
        /// </summary>
        /// <value></value>
        public string? Url {get;set;}

        /// <summary>
        /// 雑誌または、書籍の関数
        /// </summary>
        /// <value></value>
        public int? Volume  {get;set;}

        /// <summary>
        /// 出版年
        /// </summary>
        /// <value></value>
        public int? Year {get;set;}
    }

}
