import { Pages } from "./Pages";
import { AuthorName } from "./AuthorName";

class BibTeXMap {
  // 住所
  public Address?: string = "取得不能";

  // 注釈
  public Annote?: string = "取得不能";

  // 著者名
  public Authors?: AuthorName[];

  // 本のタイトル
  public Booktitle?: string = "タイトル取得不能";

  // 相互参照用のキー
  public Crossref?: string = "取得不能";

  // 章番号
  public Chapter?: string = "章番号取得不能";

  // 書籍の版
  public Edition?: string = "版取得不能";

  // 編著者名
  public Editor?: AuthorName[];

  // 電子出版時の指定
  public Epirnt?: string = "取得不能";

  // 出版形態
  public Howpublished?: string = "取得不能";

  // 出版社以外に関係した機関
  public Institution?: string = "取得不能";

  // 雑誌名
  public Journal?: string = "雑誌名取得不能";

  // 順番指定用のパラメータ
  public Key?: string = "取得不能";

  // 出版月
  public Month?: string = "出版月取得不能";

  // 注記
  public Note?: string = "取得不能";

  // 雑誌テクニカルレポートの号数
  public Number?: string = "号数取得不能";

  // 会議の主催者
  public Organization?: string = "取得不能";

  // ページ
  public Pages?: Pages;

  // 出版社名
  public Publisher?: string = "出版社取得不能";

  // 学位論文の場合に学位の提出大学
  public School?: string = "大学名取得不能";

  // 書籍のシリーズ名
  public Series?: string = "シリーズ名取得不能";

  // タイトル
  public Title?: string = "タイトル取得不能";

  // 報告種別
  public Type?: string = "取得不能";

  // url
  public URL?: string = "URL取得不能";

  // 雑誌または、書籍の巻数
  public Volume?: string = "巻数取得不能";

  // 出版年
  public Year?: string = "出版年取得不能";

  // ISSN
  public ISSN?: string = "ISSN取得不能";

  // DOI
  public DOI?: string = "DOI取得不能";

  // 一般的ではないBibTeXフィールドを定義する。
  public Others?: string[];

  // @から始まる文字列
  public MediaType: string = "";

  // ID
  public Id: string = "";
}
