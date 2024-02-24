namespace WebTefuTefu.Domains.Models
{
    /// <summary>
    /// 著者のデータ型
    /// </summary>
    public class AuthorName{
        /// <summary>
        /// ファーストネーム
        /// </summary>
        /// <value></value>
        public string FirstName{get; set;}

        /// <summary>
        /// ミドルネーム。複数ある可能性があるため配列にする
        /// </summary>
        /// <value></value>
        public string?[] MiddleName{get; set;}

        /// <summary>
        /// ラストネーム
        /// </summary>
        /// <value></value>
        public string LastName{get; set;}
    }
}
