using  WebTefuTefu.Domains.Dtos;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WebTefuTefu.Domains.Models;

namespace WebTefuTefu.Domains
{
    public class BibTeXParserInteractor :IBibTeXParserInteractor
    {
        private readonly BibTeXMapConvertInteractor _converter;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <value></value>
        public BibTeXParserInteractor(){
            _converter = new BibTeXMapConvertInteractor();
        }

        public BibTeXParserResponse ParserBibTex(BibTeXParserRequest request)
        {
            string BibTeXString=ConvertSingleQuotes(request.BibTeXString);

            var bibTeXMapConvertRequest=new BibTeXMapConvertRequest{
                BibTeXString=BibTeXString
            };
            var bibTexMap = _converter.BibTeXMapConvert(bibTeXMapConvertRequest).BibTeXMap;
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
        /// <summary>
        /// 暫定対応の関数
        /// </summary>
        /// <param name="bibtex"></param>
        /// <returns></returns>
        private string BibliographyBuilder( BibTeXMap bibtex){
        string name = string.Join("・",bibtex.Authors.Select(e=>e.FullName.Replace(",","").Replace(" ","")).ToArray());
        string page = string.Join("-",bibtex.Pages?.FirstPage,bibtex.Pages?.LastPage)??"ページ取得不可能";
        string formatDate = DateTime.Now.ToString("yyyy年M月d日取得");
        string bibString=$"{name}，{bibtex.Year}，「{bibtex.Title}」『{bibtex.Journal}』{bibtex.Number}({bibtex.Volume}): {page}，（{formatDate}，{bibtex.URL}）．";

        return bibString;
        }
    }
}
