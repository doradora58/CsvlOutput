using System;
using System.IO;
using System.Text;

namespace CsvlOutput
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 出力ボタン押下時
        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = "";
            string text2 = "";
            // 4回ループを行う
            for (int i = 0; i < 5; i += 1)
            {
                // ストップウォッチクラス生成
                var sw1 = new System.Diagnostics.Stopwatch();
                // 時間計測開始
                sw1.Start();

                // ********時間計測したい処理Aを記述*****

                // 計測終了
                sw1.Stop();

                // ストップウォッチクラス生成
                var sw2 = new System.Diagnostics.Stopwatch();
                // 時間計測開始
                sw2.Start();

                // ********時間計測したい処理Bを記述*****

                // 計測終了
                sw2.Stop();

                // テキストに結果を書き出し
                text1 += sw1.ElapsedMilliseconds.ToString() + ",";
                text2 += sw2.ElapsedMilliseconds.ToString() + ",";
                
            }
            this.Result.Text += text1 + "\r\n" + text2 + "\r\n";
            // csvに結果を書き出し
            try
            {
                // ファイルを開く
                StreamWriter file = new StreamWriter(@"C:\ODBC(csv)\test.csv", true, Encoding.UTF8);

                file.WriteLine(this.Result.Text);

                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // 例外検出時にエラーメッセージを表示
            }

        }
    }
}