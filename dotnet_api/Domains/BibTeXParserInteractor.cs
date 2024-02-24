using BibtexLibrary;
using Microsoft.AspNetCore.Http.Features;
using  WebTefufu.Domains.Dtos;
using System;
using System.Text;

namespace WebTefufu.Domains
{
    public class BibTeXParserInteractor :IBibTeXParserInteractor
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <value></value>
        public BibTeXParserInteractor(){

        }

        public BibTeXParserResponse ParserBibTex(BibTeXParserRequest request)
        {
            Console.WriteLine("#############");
            Console.WriteLine(request.BibTeX);
            string BibTeXString=ConvertSingleQuotes(request.BibTeX);
            Console.WriteLine(BibTeXString);
            /// Todo 次のライブラリはTitleなどに全角記号が含まれていると高確率でエラー落ちするため、ライブラリの変更か自作を検討する
            BibtexFile result=BibtexLibrary.BibtexImporter.FromString(BibTeXString);
            string Bibliography =BibliographyBuilder(result);


            BibTeXParserResponse response= new BibTeXParserResponse{
                bibTeXResult=Bibliography
            };
            return response ;
        }

        private string ConvertSingleQuotes(string input)
    {
        StringBuilder resultBuilder = new StringBuilder();
        bool curlyBracketsSwitch=true;
        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];


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

        private string BibliographyBuilder(BibtexFile bib_str){
        string bibString="";
        foreach (BibtexEntry entry in bib_str.Entries)
        {
            ///nameに関わる処理
            string names_string = entry.Tags["author"];
            string[] nameArray = names_string.Split(new[] {" and " }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(name=>name.Replace(",",""))
                                   .Select(name=>name.Replace(" ",""))
                                   .ToArray();
            string pages=entry.Tags["pages"].Replace("--","-");
            string outputNames = string.Join("・",nameArray);
            string formatDate = DateTime.Now.ToString("yyyy年M月d日取得");
            bibString=$"{outputNames}，{entry.Tags["year"]}，「{entry.Tags["title"]}」『{entry.Tags["journal"]}』{entry.Tags["number"]}({entry.Tags["volume"]}): {pages}，（{formatDate}，URLまたはデータベース名）．";

        }

        return bibString;
        }

    }
}
