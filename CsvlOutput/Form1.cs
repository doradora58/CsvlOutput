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
                // ���Ԍv���J�n
                sw1.Start();

                // ********���Ԍv������������A���L�q*****

                // �v���I��
                sw1.Stop();

                // �X�g�b�v�E�H�b�`�N���X����
                var sw2 = new System.Diagnostics.Stopwatch();
                // ���Ԍv���J�n
                sw2.Start();

                // ********���Ԍv������������B���L�q*****

                // �v���I��
                sw2.Stop();

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