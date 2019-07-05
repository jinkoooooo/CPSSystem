using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace serverForm
{
    class MessageDB
    {
        int mem_num;
        int[] mem_post;

        public MessageDB(string mem_num, String mem_post)
        {
            this.mem_num = int.Parse(mem_num);
            //this.mem_post = mem_post.Split;
        }


        


        public static String url = "SERVER=LOCALHOST; USER=root; DATABASE=testbase;" + "PORT=3306; PASSWORD=inhatc; SSLMODE=NONE";
        // DB접속 URL 설정 - SERVER : DB주소, USER : ID명, DATABASE : DB명, PORT : TCP 포트번호
        // PASSWORD : 비밀번호, SSLMODE : NONE (SSL 사용안함)
        private MySqlConnection mConnection; // DB접속
        private MySqlCommand mCommand; // 쿼리문
        private MySqlDataReader mDataReader; // 실행문

        public int countDB()
        {
            try
            {
                connectDB();
                mConnection.Open(); //DB 연결통로를 연다.
                mCommand.CommandText = "select count(*) from member"; // 메세지 저장 쿼리문
                mDataReader = mCommand.ExecuteReader(); // 쿼리문 실행
                closeDB();
                return int.Parse(mDataReader[0].ToString()); //총 회원숫자 불러옴. 
            }
            catch (Exception e)
            {
                closeDB();
                return -1; //오류날시 -1 리턴
            }
        }

        //public String serchMessage(

        public void insertMessage(String str)//메세지 임시 저장 메서드
        {
            try
            {
                connectDB();
                mConnection.Open(); //DB 연결통로를 연다.
                mCommand.CommandText = "insert into repository(mem_number, data_context) values('"+mem_num+"','"+str+"')"; // 메세지 저장 쿼리문
                mDataReader = mCommand.ExecuteReader(); // 쿼리문 실행
                closeDB();
            }
            catch (Exception e)
            {
                closeDB();
            }

        }

        public void deleteMessage()
        {
            try
            {
                connectDB();
                mConnection.Open(); //DB 연결통로를 연다.
                mCommand.CommandText = "delete from repository where mem_number='"+mem_num+"'"; // 메세지 삭제 쿼리문
                mDataReader = mCommand.ExecuteReader(); // 쿼리문 실행
                closeDB();
            }
            catch (Exception e)
            {
                closeDB();
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
