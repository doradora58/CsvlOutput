using System;
using System.Data;
using System.Data.Odbc;
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
                // ストップウォッチクラス生成
                var sw2 = new System.Diagnostics.Stopwatch();
                // ********時間計測したい処理Bを記述*****
                // ********時間計測したい処理Aを記述*****

                //接続文字列
                string connectionString = @"DSN=TestCSV;";
                var dataTable = new DataTable();
                try
                {
                    using (var connection = new OdbcConnection(connectionString))
                    {
                        // 時間計測開始
                        sw1.Start();
                        connection.Open();
                        // 計測終了
                        sw1.Stop();

                        var sql = "SELECT * FROM Test.csv WHERE B='i' AND C='u'" +
                            "";
                        using (var commnad = new OdbcCommand(sql, connection))
                        {
                            using (var adapter = new OdbcDataAdapter(commnad))
                            {
                                // 時間計測開始
                                sw2.Start();
                                adapter.Fill(dataTable);
                                // 計測終了
                                sw2.Stop();
                            }
                        }
                    }
                    //DataTableはforeachできないので、AsEnumerableを使う
                    foreach (var row in dataTable.AsEnumerable())
                    {
                        //DataRow["列名"]で値を取得
                        var char1 = row["A"];
                        var char2 = row["B"];
                        var char3 = row["C"];
                        var char4 = row["D"];
                        var char5 = row["E"];
                        //Console.WriteLine($"{name} {age}歳 {bloodType}型");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }




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