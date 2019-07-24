using System;
using System.IO;
using System.Net;
using System.Text;


namespace papagoTest
{

    

    class Program
    {

        public static string idKey = "qBE7Bt05mNteUf2STtAW";

        public static string secretKey = "Vgbc6FBobo";
        static void Main(string[] args)
        {
            string url = "https://openapi.naver.com/v1/language/translate";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", idKey); // 개발자센터에서 발급받은 Client ID
            request.Headers.Add("X-Naver-Client-Secret", secretKey); // 개발자센터에서 발급받은 Client Secret
            request.Method = "POST";
            string query = "오늘 날씨는 어떻습니까?";
            byte[] byteDataParams = Encoding.UTF8.GetBytes("source=ko&target=en&text=" + query);
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

            Console.WriteLine(words[19]);
        }
    }
}
