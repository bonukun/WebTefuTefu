import { base_ref } from "./base";

export class Article extends base_ref {
  //著者名，刊行年，表題，誌名，巻数，ページ
  //中沢 潤・国本 小百合・祐宗 省三（1978）．幼児の弁別学習──非次元性課題における過剰訓練効果── 心理学研究，49，131-136
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
}
