using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace testForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        static void ReadCsv()
        {
/*            try
            {
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(openFileDialog1.FileName))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        var line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        var values = line.Split(',');
                        // 出力する
                        foreach (var value in values)
                        {
                            System.Console.Write("{0} ", value);
                        }
                        System.Console.WriteLine();
                    }
                }
            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                System.Console.WriteLine(e.Message);
            }
*/        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            
            //CSVファイルのあるフォルダ
            string csvDir = Path.GetDirectoryName(openFileDialog1.FileName)+"/";
            //CSVファイルの名前
            string csvFileName = Path.GetFileName(openFileDialog1.FileName);

            //接続文字列
            string conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                + csvDir + ";Extended Properties=\"text;HDR=No;FMT=Delimited\"";
            System.Data.OleDb.OleDbConnection con =
                new System.Data.OleDb.OleDbConnection(conString);

            string commText = "SELECT * FROM [" + csvFileName + "]";
            System.Data.OleDb.OleDbDataAdapter da =
                new System.Data.OleDb.OleDbDataAdapter(commText, con);

            //DataTableに格納する
            DataTable dt = new DataTable();


            da.Fill(dt);

            dataGridView1.DataSource = dt;

            ReadCsv();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
