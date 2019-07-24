using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cpssystem
{
    class papagoAPI
    {
        public string transStr(string str, string rangage)
        {
            string url = "https://openapi.naver.com/v1/language/translate";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", "qBE7Bt05mNteUf2STtAW"); // 개발자센터에서 발급받은 Client ID
            request.Headers.Add("X-Naver-Client-Secret", "Vgbc6FBobo"); // 개발자센터에서 발급받은 Client Secret
            request.Method = "POST";
            string query = str;
            byte[] byteDataParams = Encoding.UTF8.GetBytes("source=ko&target="+rangage+"&text=" + query);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteDataParams.Length;
            Stream st = request.GetRequestStream();
            st.Write(byteDataParams, 0, byteDataParams.Length);
            st.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string text = reader.ReadLine();
            stream.Close();
            response.Close();
            reader.Close();
            string[] words = text.Split(new Char[] { '"' });

            return words[19];
        }
    }
}
