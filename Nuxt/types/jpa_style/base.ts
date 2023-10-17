export class base_ref {
  //著者名，刊行年，表題，誌名，巻数，ページ
  //中沢 潤・国本 小百合・祐宗 省三（1978）．幼児の弁別学習──非次元性課題における過剰訓練効果── 心理学研究，49，131-136
  address: string | null;
  annote: string | null;
  author: string | null;
  booktitle: string | null;
  crossref: string | null;
  chapter: string | null;
  edition: string | null;
  editor: string | null;
  eprint: string | null;
  howpublished: string | null;
  institution: string | null;
  journal: string | null;
  key: string | null;
  month: string | null;
  note: string | null;
  number: string | null;
  organization: string | null;
  pages: string | null;
  publisher: string | null;
  school: string | null;
  series: string | null;
  title: string | null;
  type: string | null;
  url: string | null;
  volume: string | null;
  year: string | null;

  constructor() {
    // すべてのプロパティをループで初期化する
    for (const key in this) {
      if (this.hasOwnProperty(key)) {
        this[key] = "";
      }
    }
  }

  to_list = () => {
    Object.entries(this).forEach(([key, fromValue]) => {
      const value = fromValue;
      value.value = "いえええい";
      console.log(value.value);
    });
  };
}
