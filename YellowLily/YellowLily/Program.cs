using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YellowLily
{
    class Program
    {
        /// <summary>
        /// LINQ問題集 : 第二弾
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //問題6
            var idols = Question6(new[] { "やよい", "いおり", "あずさ" }, new[] { 14, 15, 21 });

            //問題7
            var records = Question7(@"datas/record.csv");

            //それぞれの結果をここで出力してね。
            foreach (var r in records.OrderByDescending(x => x))
                Console.WriteLine($"{r.Item1},{r.Item2}");
        }

        /// <summary>
        /// 問題6 難易度 : DEBUT
        /// [説明] : Idolは作れる！名前と年齢からアイドルを作って表示しよう！
        /// [入力] : 名前・年齢のデータソース
        /// [出力] : 添付画像参照 / メソッドの返しはIEnumerable<Idol> Idolは下の方に定義してあるよん
        /// [備考] : Zip練習！ぜひ使ってみてください。
        /// </summary>
        private static IEnumerable<Idol> Question6(IEnumerable<string> names, IEnumerable<int> ages) => 
            Enumerable.Zip(names, ages, (x, y) => new Idol() { Name = x, Age = y });
        //Idolは作れない！
        // idolMokoki はまだIdolではなかった…
        // var idolModoki = names.Zip(ages, (x, y) => new { x, y });

        // var modoko = names.Select((x, i) => new Idol { Name = x, Age = ages.ElementAt(i) });           

        // var idol = new Idol();


        //var namuko = Enumerable.Zip(names, ages, (x, y) => new Idol { Name = x, Age = y });

        //var mellowyellow = names.Zip(ages, (x, y) => new Idol { Name = x, Age = y });

        //var namuko = Enumerable.Zip(names, ages, (x,y) => new Idol { Name = x, Age = y });

        //var cinderella = names.Zip(ages, (x, y) => new Idol { Name = x, Age = y });



        //    return namuko;
        //}

        /// <summary>
        /// 問題7 難易度 : REGULER+
        /// [説明] : 60ガシャの結果を集計しよう。よく使うよ！
        /// [入力] : 読み込むcsvファイルのパス
        /// [出力] : 添付画像参照 / メソッドの返しはIEnumerable<Tuple<string,int>>
        /// [備考] : Tupleとファイル読み込みは結構使うよ！ゴリゴリやっちゃっていいんで書いてみて！
        ///          １行じゃなくて全然大丈夫です。自分の分かりやすいように変数で受けながら、作成してみてね
        /// </summary>
        private static IEnumerable<Tuple<string, int>> Question7(string FilePath)
        {
            return File.ReadAllLines(FilePath, Encoding.Default)
                            //ヘッダ部いらないんで読み飛ばす
                            .Skip(1)
                            //２列目だけ取得する
                            .Select(x => x.Split(',').Last())
                            //レアリティ毎に集計
                            .GroupBy(x => x)
                            //集計したキーと数を組にして返却
                            .Select(x => Tuple.Create(x.Key, x.Count()));




            // 全行を読み込むぜ！
            //var sources = File.ReadAllLines(FilePath, Encoding.Default).Select(x => x.Split(',').Last());

            //var ranks = sources.Select(x => x.Split(',').Last());

            //var ranker = sources.Select(x => x.Split(',').Last().Equals(header.Select(y => y)))

            //// 全件出した
            ////var ranks = header.SelectMany(x =>
            ////                sources.Select(y =>
            ////                    new[] { x, y.Split(',').Last() }));


            //var ranks = header.Select(x => Tuple.Create(x, sources.Count(y => x == y)));
            //sources.Select(y => y.Split(',').Last()).Count(y => y == x)));
            //x と y.Split(',').Last() が いっしょなののカウントが欲しいなの
            //Tuple.Create(x, y.Equals(x))).Count(z => z.Equals(true)));

            //return ranks;


            //foreach (var a in ranks)
            //    Console.WriteLine($"{a.Item1},{a.Item2}");


            //return null;


            // ------------------------ 要塞 --------------------------------
            //// 全行を読み込むぜ！
            //var sources = File.ReadAllLines(FilePath, Encoding.Default);

            //// 各ランクが何枚あるか集計するで
            //// 要塞化したで、センス無さすぎて草
            //var ssrCount = sources.Select(x => x.Split(',').Last().Equals(header.ElementAt(0)))
            //    .Count(x => x.Equals(true));

            //var srCount = sources.Select(x => x.Split(',').Last().Equals(header.ElementAt(1)))
            //    .Count(x => x.Equals(true));

            //var rCount = sources.Select(x => x.Split(',').Last().Equals(header.ElementAt(2)))
            //    .Count(x => x.Equals(true));

            //// 集計結果を配列にまとめた　←　は？
            //var rankCount = new[] { ssrCount, srCount, rCount };

            //// Zip化した
            //var ret = rankCount.Zip(header, (rank, count) => new { rank, count });

            //// まだ　return ret　できてないで



            // ------------------------ ダサいコードたち --------------------------------
            //    // 各ランクが何枚あるかの変数
            //    // 最初に宣言してるのがメモリモグモグGCをもっとうまく使える
            //    var rCount = 0;
            //    var srCount = 0;
            //    var ssrCount = 0;

            //    //ファイルを読み込んで集計
            //    try {
            //        using (var csv = new StreamReader(FilePath))
            //        {
            //            // 読み終わるまで回せ
            //            while (!csv.EndOfStream)
            //            {
            //                // 一行読む
            //                var line = csv.ReadLine();
            //                // ,で要素を区切り、ランクを集計
            //                // headerの要素と読んだデータが一致してたらカウントアップ
            //                // ElementAtを使ってるのが負け
            //                if (line.Split(',').Last() == header.ElementAt(0))
            //                    ssrCount++;
            //                else if (line.Split(',').Last() == header.ElementAt(1))
            //                    srCount++;
            //                else if (line.Split(',').Last() == header.ElementAt(2))
            //                    rCount++;
            //            }
            //            // 集計結果を配列にまとめた　←ださそう
            //            var rankCount = new[] { ssrCount, srCount, rCount };
            //            // Zip化した
            //            var ret = rankCount.Zip(header, (rank, count) => new { rank, count });

            //            // ここで　return ret　をしようと思ったら型があってなかったよ;;
            //            // return ret;
            //        }
            //    }
            //    catch(IOException e)
            //    {
            //        // ファイルを開くのに失敗したとき
            //        Console.WriteLine(e.Message);
            //    }
            //    return null;
            //}

        }
    }

    /// <summary>
    /// Idolクラス : C#は1ファイル内にクラスいっぱいかけます。
    /// </summary>
    public class Idol
    {

        //名前
        public string Name { get; set; }
        //年齢
        public int Age { get; set; }
    }


}
