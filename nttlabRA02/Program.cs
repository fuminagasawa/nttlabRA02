using System;
using System.Collections;         //追加
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nttlabRA02
{
    class Program
    {

        [STAThreadAttribute]
        static void Main(string[] args)
        {
            ArrayList startOfA = new ArrayList();
			ArrayList endOfA = new ArrayList();
			ArrayList startOfB = new ArrayList();
			ArrayList endOfB = new ArrayList();

			CSVLoader csvldr = new CSVLoader();
			TemplateMaker maker = new TemplateMaker();

			String resultStringA="";
			String resultStringB="";

			String filePath = "";
			String SavePath = "";
			String TemplatePath = "";

			if (args.Length > 0) 	filePath = args[0];
			if (args.Length > 1)	SavePath = args[1];
			if (args.Length > 2)	TemplatePath = args[2];


			if (!System.IO.File.Exists(filePath)) {

				System.Windows.Forms.OpenFileDialog ofd1 = new OpenFileDialog();
				ofd1.Title = "CSVファイルを開く";
				ofd1.ShowDialog();
				filePath = ofd1.FileName;
			}

			if (SavePath=="") {

				System.Windows.Forms.SaveFileDialog sfd1 = new SaveFileDialog();
				sfd1.Title = "保存先";
				sfd1.ShowDialog();
				SavePath = sfd1.FileName;
			}

			if (!System.IO.File.Exists(TemplatePath)) {

				System.Windows.Forms.OpenFileDialog ofd2 = new OpenFileDialog();
				ofd2.Title = "テンプレートファイルを開く";
				ofd2.ShowDialog();
				TemplatePath = ofd2.FileName;
			}

			try {

				csvldr.ReadCsv(filePath, ref startOfA, ref endOfA, ref startOfB, ref endOfB);

				maker.LoadTemplate(TemplatePath);



				for (int i = 0; i < startOfA.Count; i++) {

					resultStringA += maker.TransformDataToString("", startOfA[0].ToString(), endOfA[0].ToString(), "A", i.ToString());
				}
				for (int i = 0; i < startOfA.Count; i++) {

					resultStringB += maker.TransformDataToString("", startOfB[0].ToString(), endOfB[0].ToString(), "B", i.ToString());
				}


				System.IO.StreamWriter swA = new System.IO.StreamWriter(SavePath, false, System.Text.Encoding.GetEncoding("shift_jis"));
				swA.Write(resultStringA);
				swA.Close();

				System.IO.StreamWriter swB = new System.IO.StreamWriter(SavePath, true, System.Text.Encoding.GetEncoding("shift_jis"));
				swB.Write(resultStringB);
				swB.Close();

				Console.WriteLine(SavePath + "にスクリプトが保存されました");
			}
			catch (Exception e) {

				Console.WriteLine("エラーが発生したため処理を中断しました");

			}

		}
	}
}
