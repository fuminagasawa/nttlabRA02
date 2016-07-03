using System;
using System.Collections;         //追加
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace nttlabRA02
{
    class CSVLoader
    {

        public void ReadCsv( String CSVfilePath,  ref ArrayList startOfA, ref ArrayList endOfA, ref ArrayList startOfB, ref ArrayList endOfB)
        {



            System.String line;
            System.IO.StreamReader reader = new System.IO.StreamReader(CSVfilePath);


			// csvファイルを開く
			while ((line = reader.ReadLine()) != null){

				// 読み込んだ一行をカンマ毎に分けて配列に格納する
				var values = line.Split(',');

			// 出力する
	/*			foreach (var value in values){

					System.Console.Write("{0} \t ", value);
				}
	*/
				if (values.Length > 2){

					if (values[0].Length > 5)	startOfA.Add(values[0]);
					if (values[1].Length > 5)	endOfA.Add(values[1]);
				
				}

				if (values.Length > 4) {

					if (values[3].Length > 5) 	startOfB.Add(values[3]);
					if (values[4].Length > 5)	endOfB.Add(values[4]);


				}

			}


        }

    }
}
