using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace nttlabRA02
{
    class TemplateMaker
    {

		public String Template;

        public void LoadTemplate(String filePath)
        {

			System.IO.StreamReader sr = new System.IO.StreamReader(filePath, Encoding.GetEncoding("Shift_JIS"));

			Template = sr.ReadToEnd();

			sr.Close();
//			Console.WriteLine("Temp\n"+ text);
		}

		public String TransformDataToString(String FILE_FROM, String TIME_START, String TIME_END, String ACCOUNT, String NUMBER) {

			String result = "";

			result = Template;

			result = Regex.Replace(result, "<%FILE_FROM%>",FILE_FROM );
			result = Regex.Replace(result, "<%TIME_START%>", TIME_START);
			result = Regex.Replace(result, "<%TIME_END%>", TIME_END);
			result = Regex.Replace(result, "<%ACCOUNT%>", ACCOUNT);
			result = Regex.Replace(result, "<%FILE_NUMBER%>", NUMBER);


			return result;
		}

	}
}
