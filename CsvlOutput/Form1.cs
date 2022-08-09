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

        // �o�̓{�^��������
        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = "";
            string text2 = "";
            // 4�񃋁[�v���s��
            for (int i = 0; i < 5; i += 1)
            {
                // �X�g�b�v�E�H�b�`�N���X����
                var sw1 = new System.Diagnostics.Stopwatch();
                // �X�g�b�v�E�H�b�`�N���X����
                var sw2 = new System.Diagnostics.Stopwatch();
                // ********���Ԍv������������B���L�q*****
                // ********���Ԍv������������A���L�q*****

                //�ڑ�������
                string connectionString = @"DSN=TestCSV;";
                var dataTable = new DataTable();
                try
                {
                    using (var connection = new OdbcConnection(connectionString))
                    {
                        // ���Ԍv���J�n
                        sw1.Start();
                        connection.Open();
                        // �v���I��
                        sw1.Stop();

                        var sql = "SELECT * FROM Test.csv WHERE B='i' AND C='u'" +
                            "";
                        using (var commnad = new OdbcCommand(sql, connection))
                        {
                            using (var adapter = new OdbcDataAdapter(commnad))
                            {
                                // ���Ԍv���J�n
                                sw2.Start();
                                adapter.Fill(dataTable);
                                // �v���I��
                                sw2.Stop();
                            }
                        }
                    }
                    //DataTable��foreach�ł��Ȃ��̂ŁAAsEnumerable���g��
                    foreach (var row in dataTable.AsEnumerable())
                    {
                        //DataRow["��"]�Œl���擾
                        var char1 = row["A"];
                        var char2 = row["B"];
                        var char3 = row["C"];
                        var char4 = row["D"];
                        var char5 = row["E"];
                        //Console.WriteLine($"{name} {age}�� {bloodType}�^");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }




                // �e�L�X�g�Ɍ��ʂ������o��
                text1 += sw1.ElapsedMilliseconds.ToString() + ",";
                text2 += sw2.ElapsedMilliseconds.ToString() + ",";
                
            }
            this.Result.Text += text1 + "\r\n" + text2 + "\r\n";
            // csv�Ɍ��ʂ������o��
            try
            {
                // �t�@�C�����J��
                StreamWriter file = new StreamWriter(@"C:\ODBC(csv)\test.csv", true, Encoding.UTF8);

                file.WriteLine(this.Result.Text);

                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // ��O���o���ɃG���[���b�Z�[�W��\��
            }

        }
    }
}