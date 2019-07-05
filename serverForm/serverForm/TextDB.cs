using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace serverForm
{
    class TextDB
    {
        // DB

        public static String url = "SERVER=LOCALHOST; USER=root; DATABASE=testbase;" + "PORT=3306; PASSWORD=inhatc; SSLMODE=NONE";
        // DB접속 URL 설정 - SERVER : DB주소, USER : ID명, DATABASE : DB명, PORT : TCP 포트번호
        // PASSWORD : 비밀번호, SSLMODE : NONE (SSL 사용안함)
        private MySqlConnection mConnection; // DB접속
        private MySqlCommand mCommand; // 쿼리문
        private MySqlDataReader mDataReader; // 실행문
        //*DB

        public void TestDB()
        {
                // 여기서 부터 원하는 데이터를 받아와서 처리
                //string tempName = mDataReader["name"].ToString();

        }

        public bool selectName(String mem_num)//이름 존재 유무 실험
        {
            try
            {
                connectDB();
                mConnection.Open(); //DB 연결통로를 연다.
                mCommand.CommandText = "SELECT * FROM TEST where name='"+mem_num+"'"; // 쿼리문
                mDataReader = mCommand.ExecuteReader(); // 쿼리문 실행

                if (mDataReader.Read())//해당 이름이 존재하는지 확인.
                {
                    closeDB();//DB 연결통로를 닫는다 (이하동일)
                    return true;
                }
                else
                {
                    closeDB();
                    return false;
                }
            }
            catch(Exception e)
            {
                closeDB();
                Console.WriteLine(e.ToString());
                return false;
            }
            
        }

        public void connectDB()
        {
            mConnection = new MySqlConnection(url); // DB접속
            mCommand = new MySqlCommand(); // 쿼리문 생성
            mCommand.Connection = mConnection; // DB에 연결
        }

        public void closeDB()
        {
            mConnection.Close();
        }
    }
}
