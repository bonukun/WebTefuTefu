using  WebTefuTefu.Domains.Dtos;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WebTefuTefu.Domains.Models;

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
            string BibTeXString=ConvertSingleQuotes(request.BibTeXString);

            var bibTeXMapConvertRequest=new BibTeXMapConvertRequest{
                BibTeXString=BibTeXString
            };
            var bibTexMap = converter.BibTeXMapConvert(bibTeXMapConvertRequest).BibTeXMap;
            var res = new BibTeXParserResponse{
                bibTeXResult=BibliographyBuilder(bibTexMap)
            };
            return res ;
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
        ///
        private string BibliographyBuilder( BibTeXMap bibtex){
        string name = string.Join("・",bibtex.Authors.Select(e=>e.FullName.Replace(",","").Replace(" ","")).ToArray());
        string page = string.Join("-",bibtex.Pages?.FirstPage,bibtex.Pages?.LastPage)??"ページ取得不可能";
        string formatDate = DateTime.Now.ToString("yyyy年M月d日取得");
        string bibString=$"{name}，{bibtex.Year}，「{bibtex.Title}」『{bibtex.Journal}』{bibtex.Number}({bibtex.Volume}): {page}，（{formatDate}，{bibtex.URL}）．";


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

        return bibString;
        }

    }
}
