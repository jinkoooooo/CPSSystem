using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace serverForm
{
    class MessageDB // 메세지 전송 관련해서 실험중인 클레스임 . 아직 사용할 필요 없음.
    {
        public string mem_num;//메시지 전송한 사원번호를 담기위한 변수

        string dateNow = null;//메시지 전송 시간을 담기위한 변수
        public int cnt = 0;//이 멤버를 구독하는 구독자 수.

        public MessageDB()
        {
            //선언메서드.
        }

        public static String url = "SERVER=LOCALHOST; USER=" + ServerForm.User + "; DATABASE=" + ServerForm.Schema + ";" + "PORT=" + ServerForm.DBPort + "; PASSWORD=" + ServerForm.Passwd + "; SSLMODE=NONE";
        // DB접속 URL 설정 - SERVER : DB주소, USER : ID명, DATABASE : DB명, PORT : TCP 포트번호
        // PASSWORD : 비밀번호, SSLMODE : NONE (SSL 사용안함)
        private MySqlConnection mConnection; // DB접속
        private MySqlCommand mCommand; // 쿼리문
        private MySqlDataReader mDataReader; // 실행문

        public int countSub()//메시지를 전송한 사원을 구독하는 사람수를 불러옴.
        {
            try
            {
                connectDB();

                mCommand.CommandText = "select count(*) as cnt from subscribe where mem_number ='"+mem_num+"'"; // 메세지 저장 쿼리문
                mDataReader = mCommand.ExecuteReader(); // 쿼리문 실행
                
                if (mDataReader.Read())
                {
                    int cnt = int.Parse(mDataReader["cnt"].ToString());
                    closeDB();
                    return cnt;
                }
                else
                {
                    closeDB();
                    return -2;
                }
            }
            catch (Exception e)
            {
                closeDB();
                
                return -1; //오류날시 -1 리턴
            }
        }

        public string readSub(string send_mem)//메시지를 전송한 사원을 구독하는 사람을 불러옴.(성공)
        {
            try
            {
                connectDB();

                mCommand.CommandText = "select * from subscribe where mem_number ='" + send_mem + "'"; // 메세지 저장 쿼리문
                mDataReader = mCommand.ExecuteReader(); // 쿼리문 실행

                if (mDataReader.Read())
                {
                    string subMem=null;
                    subMem = mDataReader["mem_subscribe"].ToString();//첫번째 구독자 가져옴.
                    while (mDataReader.Read())//그이후 모든 구독자 가져옴.
                    {
                        subMem += "/"+ mDataReader["mem_subscribe"].ToString();
                    }
                    closeDB();
                    return subMem;
                }
                else
                {
                    closeDB();
                    return "구독자 없음.";
                }
            }
            catch (Exception e)
            {
                closeDB();

                return "readSub에러"; //오류날시 -1 리턴
            }
        }

        public bool searchMessage()
        {
            try
            {
                connectDB();
                mCommand.CommandText = "select * from repository where post_number = '" + mem_num + "'";//서버로 전송된 메시지가 있는지 검색하는 메서드.
                mDataReader = mCommand.ExecuteReader();

                if (mDataReader.Read())
                {
                    closeDB();
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
                return false;
            }         
        }


        public int updateCnt(string send_mem)
        {
            try
            {
                connectDB();
                mCommand.CommandText = "select data_count from repository where mem_number ='" + send_mem + "'";//서버로 전송된 메시지의 수신 카운트 수를 불러옴.
                mDataReader = mCommand.ExecuteReader();
                int tmp = 0;
                if (mDataReader.Read())
                {
                    tmp = int.Parse(mDataReader[0].ToString());
                }
                closeDB();

                tmp = tmp - 1;

                connectDB();
                mCommand.CommandText = "update repository set data_count='" + tmp + "' where mem_number ='" + send_mem + "'";//DB의 메시지 구독자수 변경
                mCommand.ExecuteReader();
                closeDB();

                return tmp;
            }
            catch(Exception e)
            {
                return -1;
            }
        }

        public void insertMessage(String str)//메세지 임시 저장 메서드
        {
            dateNow = System.DateTime.Now.ToString("HH:mm:ss");//메시지 전송 시간
            string[] split_sub = readSub(mem_num).Split(new String[] { "/" }, StringSplitOptions.None);
            try
            {
                
                //int cnt = countSub();
                for(int i = 0; i < split_sub.Length; i++)
                {
                    connectDB();
                    mCommand.CommandText = "insert into repository(post_number, data_time, data_context, send_number) values('" + split_sub[i] + "','" + dateNow + "','" + str +"','"+mem_num+"')"; // 메세지 저장 쿼리문
                    mDataReader = mCommand.ExecuteReader(); // 쿼리문 실행
                    closeDB();
                }
                
            }
            catch (Exception e)
            {
                closeDB();
            }

        }

        public List<string> readMessage()
        {
            List<string> dataMs = new List<string>(100);//메시지 반환 변수

            try
            {

                connectDB();

                mCommand.CommandText = "select * from repository, member where repository.send_number=member.mem_number and repository.post_number='" + mem_num+"'"; // 메세지 불러옴 쿼리문
                mDataReader = mCommand.ExecuteReader(); // 쿼리문 실행

                while(mDataReader.Read())
                {//메시지들을 리스트에 담는다.
                    dataMs.Add(mDataReader["mem_name"].ToString()+"("+ mDataReader["mem_position"].ToString() + ") : " + mDataReader["data_context"].ToString() + "    (" + mDataReader["data_time"].ToString() + ")");
                }

                closeDB();
                return dataMs;
            }
            catch (Exception e)
            {
                closeDB();
                dataMs[0]= "DB오류";
                return null;
            }
        }

        public void deleteMessage()
        {
            try
            {
                connectDB();
                
                mCommand.CommandText = "delete from repository where post_number='"+ mem_num + "'"; // 메세지 삭제 쿼리문
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

            mConnection.Open(); //DB 연결통로를 연다.
        }

        public void closeDB()
        {
            mConnection.Close();
        }
    }
}
