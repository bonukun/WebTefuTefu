import { base_ref } from "./base";

export class Article extends base_ref {
  //著者名，刊行年，表題，誌名，巻数，ページ
  //中沢 潤・国本 小百合・祐宗 省三（1978）．幼児の弁別学習──非次元性課題における過剰訓練効果── 心理学研究，49，131-136
  //{authors}{（year）}．{title}── {jounarl}，{volume}，{pages}
  // author: string;
  // year: string;
  // title: string;
  // jounal: string;
  // volume: string;
  // pages: string;

  constructor() {
    super();
    this.author = "";
    this.year = "";
    this.title = "";
    this.journal = "";
    this.volume = "";
    this.pages = "";
  }

  to_list = () => {
    return ["year", "title", "jounal", "volume", "pages"];
  };

  authors = {
    lastName: "",
    firstName: "",
  };

  perse_aturhors = (author_list: any) => {
    const author_num = Object.getOwnPropertyNames(author_list).length - 1;
    let authors_data = author_list[0].lastName + " " + author_list[0].firstName;

    for (let i = 1; i < author_num; i++) {
      authors_data +=
        "・" + author_list[i].lastName + " " + author_list[i].firstName;
    }
    return authors_data;
  };

  perse_data = (author_list: any, bib_data: {}) => {
    const a = Object.getOwnPropertyNames(author_list).length;

    const authors_data = this.perse_aturhors(author_list);
    let data: string = `${authors_data}（${bib_data.year}）．${bib_data.title}── ${bib_data.jounal}，${bib_data.volume}，${bib_data.pages}`;
    return data;
  };
}
