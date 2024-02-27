using WebTefuTefu.Domains.Dtos;
using WebTefuTefu.Domains.Models;
using System;
using System.Text;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebTefuTefu.Domains{
    /// <summary>
    /// BibTeX文字列を解析するインタラクター
    /// </summary>
    public class BibTeXMapConvertInteractor:IBibTeXMapConvertInteractor{
        public BibTeXMapConvertResponse BibTeXMapConvert(BibTeXMapConvertRequest request){
            Dictionary<string,string> bibtexDictionary = GetDictionaryFromBibTeX(request.BibTeXString);
            var bibTeXMap =new BibTeXMap();

            foreach(var key in bibtexDictionary.Keys){
                if(key=="author"){
                    bibTeXMap.Authors = CreateAuthorName(bibtexDictionary["author"]);
                }else if(key=="editor"){
                    bibTeXMap.Editor = CreateAuthorName(bibtexDictionary["editor"]);
                }else if(key=="pages"){
                    bibTeXMap.Pages = CreatePages(bibtexDictionary["pages"]);
                }else{
                    SetProperty(bibTeXMap, key, bibtexDictionary[key]);
                }
            }

            var res = new BibTeXMapConvertResponse(){
                BibTeXMap=bibTeXMap
            };
            return  res;
        }

        /// <summary>
        /// BibTeXを解析し、辞書型として返す。
        /// </summary>
        /// <param name="bibTeXString"></param>
        /// <returns></returns>
        private Dictionary<string,string> GetDictionaryFromBibTeX(string bibTeXString){

            var BibTeXMap = new Dictionary<string,string>();
            string parsedBibTeXString = ParseBibTeXString(bibTeXString);
            string bibTeXFirstLines = parsedBibTeXString.Split(",")[0];

            int separateIndex= bibTeXFirstLines.IndexOf("{");
            string media = bibTeXFirstLines.Substring(0,separateIndex).Trim();
            string id = bibTeXFirstLines.Substring(separateIndex+1).Trim(' ','"',',','}');
            BibTeXMap.Add("MediaType",media);
            BibTeXMap.Add("Id",id);

            string secondlineBibTeXString=parsedBibTeXString.Replace(bibTeXFirstLines,"");
            string[] lines = secondlineBibTeXString.Split("},");
            foreach (var line in lines){
                int separatorIndex = line.IndexOf('=');
                if(separatorIndex > 0){
                    string key = line.Substring(0, separatorIndex).Trim(' ', '"', ',', '}','{','\t');
                    string value = line.Substring(separatorIndex + 1).Trim(' ', '"', ',', '}','{','\t');
                    BibTeXMap.Add(key,value);
                }
            }
            foreach (var value in BibTeXMap.Keys)
            {
                Console.WriteLine($"キーの値:{value}");
                Console.WriteLine($"バリューの値:{BibTeXMap[value]}");
            }
            return BibTeXMap;
        }

        /// <summary>
        /// BibTeXの書式を整形し後々の処理がしやすいようにする関数
        /// </summary>
        /// <param name="bibTeXString"></param>
        /// <returns></returns> <summary>
        ///
        /// </summary>
        /// <param name="bibTeXString"></param>
        /// <returns></returns>
        private string ParseBibTeXString(string bibTeXString)
        {
        StringBuilder resultBuilder = new StringBuilder();
        bibTeXString = bibTeXString.Replace("\n","");
        bibTeXString = bibTeXString.Replace(" = ","=");
        bool curlyBracketsSwitch=true;
        for (int i = 0; i < bibTeXString.Length; i++)
            {
                char currentChar = bibTeXString[i];

                if (currentChar == '\'' || currentChar=='\"')
                {
                    // 奇数番目のシングルクォートを左中括弧に、偶数番目を右中括弧に変換
                    char replacement = (curlyBracketsSwitch) ? '{' : '}';
                    curlyBracketsSwitch=  !curlyBracketsSwitch;
                    resultBuilder.Append(replacement);
                }
                else if (currentChar == ':')
                {
                    resultBuilder.Append('=');
                }
                else
                {
                    resultBuilder.Append(currentChar);
                }
            }
        return resultBuilder.ToString();
        }

        private IEnumerable<AuthorName> CreateAuthorName(string authorNamesString){
            List<AuthorName> authorNames =new List<AuthorName>();
            string[] nameArray = authorNamesString.Split(new[] {" and " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach(var name in nameArray){
                /// Todoファーストネームへなどへの分解がまだ未実装。
                var authorName = new AuthorName();
                authorName.FullName=name;
                authorNames.Add(authorName);
            }

            return authorNames;

        }

        private Pages CreatePages(string page){
            Pages pages = new Pages();
            page=page.Replace("--","-");
            string[] dividePages  = page.Split("-");
            pages.FirstPage = dividePages[0];
            pages.LastPage = dividePages[1];
            return pages;
        }


        /// <summary>
        /// 動的にクラスプロパティに値を設定する
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        private void SetProperty(object obj, string propertyName, object value)
        {
            propertyName=ToUpperCamelCase(propertyName);
            PropertyInfo property = obj.GetType().GetProperty(propertyName);

            if (property != null && property.CanWrite)
            {
                property.SetValue(obj, value.ToString());
            }
        }

        private string ToUpperCamelCase(string convertString){
            return convertString.Substring(0,1).ToUpper()+convertString.Substring(1);
        }

    }

}
