using WebTefuTefu.Domains.Dtos;
using WebTefuTefu.Domains.Models;
using System;
using System.Text;

namespace WebTefuTefu.Domains{
    /// <summary>
    /// BibTeX文字列を解析するインタラクター
    /// </summary>
    public class BibTeXMapConvertInteractor:IBibTeXMapConvertInteractor{
        public BibTeXMapConvertResponse BibTeXMapConvert(BibTeXMapConvertRequest request){
            Dictionary<string,string> bibtexMaps = GetKeyMapfromBibTeX(request.BibTeXString);

            var res = new BibTeXMapConvertResponse();
            return  res;
        }

        private Dictionary<string,string> GetKeyMapfromBibTeX(string bibTeXString){
            string parsedBibTeXString = ParseBibTeXString(bibTeXString);
            string[] bibTeXLines = parsedBibTeXString.Split("},");

            int separeteIndex= bibTeXLines[0].IndexOf("{");
            string media = bibTeXLines[0].Substring(0,separeteIndex).Trim();
            string refKey = bibTeXLines[0].Substring(separeteIndex+1).Trim(' ','"',',','}');
            Console.WriteLine("ここからデバッグ情報");
            Console.WriteLine(media);
            Console.WriteLine("二つ目");
            Console.WriteLine(refKey);
            Console.WriteLine("4つ目");
            var a = new Dictionary<string,string>();
            a.Add("a","f");
            return a;
        }

        private string ParseBibTeXString(string bibTeXString)
        {
        StringBuilder resultBuilder = new StringBuilder();
        bibTeXString.Replace("\n","");
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

    }

}
