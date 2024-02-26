using Microsoft.AspNetCore.Http.Features;
using  WebTefuTefu.Domains.Dtos;
using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace WebTefuTefu.Domains
{
    public class BibTeXParserInteractor :IBibTeXParserInteractor
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <value></value>
        public BibTeXParserInteractor(){

        }

        public BibTeXParserResponse ParserBibTex([FromServices] IBibTeXMapConvertInteractor converter, BibTeXParserRequest request)
        {
            string BibTeXString=ConvertSingleQuotes(request.BibTeX);

            var bibTeXMapConvertRequest=new BibTeXMapConvertRequest{
                BibTeXString=BibTeXString
            };
            converter.BibTeXMapConvert(bibTeXMapConvertRequest);

            BibTeXParserResponse response= new BibTeXParserResponse{
                bibTeXResult="test"
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

        // private string BibliographyBuilder(BibtexFile bib_str){
        // string bibString="";
        // foreach (BibtexEntry entry in bib_str.Entries)
        // {
        //     ///nameに関わる処理
        //     string names_string = entry.Tags["author"];
        //     string[] nameArray = names_string.Split(new[] {" and " }, StringSplitOptions.RemoveEmptyEntries)
        //         .Select(name=>name.Replace(",",""))
        //         .Select(name=>name.Replace(" ",""))
        //         .ToArray();
        //     string pages=entry.Tags["pages"].Replace("--","-");
        //     string outputNames = string.Join("・",nameArray);
        //     string formatDate = DateTime.Now.ToString("yyyy年M月d日取得");
        //     bibString=$"{outputNames}，{entry.Tags["year"]}，「{entry.Tags["title"]}」『{entry.Tags["journal"]}』{entry.Tags["number"]}({entry.Tags["volume"]}): {pages}，（{formatDate}，URLまたはデータベース名）．";

        // }

        // return bibString;
        // }

    }
}
