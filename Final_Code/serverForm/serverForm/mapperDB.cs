using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;//dapper

namespace serverForm
{
    class mapperDB //데이터 베이스 접근 관련 메서드들을 코딩하는 클래스 공간.
    {

        public static String url = "SERVER=LOCALHOST; USER="+ServerForm.User+"; DATABASE="+ServerForm.Schema+";" + "PORT="+ServerForm.DBPort+"; PASSWORD="+ServerForm.Passwd+"; SSLMODE=NONE";
        // DB접속 URL 설정 - SERVER : DB주소, USER : ID명, DATABASE : DB명, PORT : TCP 포트번호
        // PASSWORD : 비밀번호, SSLMODE : NONE (SSL 사용안함)
        private MySqlConnection mConnection; // DB접속
        private MySqlCommand mCommand; // 쿼리문
        private MySqlDataReader mDataReader; // 실행문
                                             //*DB


        public bool selectlogin(memDB selectDB)
        {
            try
            {
                connectDB();

                mCommand.CommandText
                    = "Select mem_password from member where mem_number = '" + selectDB.mem_number + "'";

                mDataReader = mCommand.ExecuteReader(); // 쿼리문 실행
                if (mDataReader.Read())//존재하는지 확인
                {
                    string pw = mDataReader["mem_password"].ToString();//패스워드 확인
                    if (pw == selectDB.mem_password)
                    {
                        closeDB();//DB 연결통로를 닫는다 (이하동일)
                        return true;
                    }
                    else
                    {
                        closeDB();//DB 연결통로를 닫는다 (이하동일)
                        return false;
                    }


                }
                else
                {

                    closeDB();
                    return false;
                }
            }
            catch (Exception e)
            {
                closeDB();
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public List<string> insertSub(String getCheckData, String getMemNumber)
        {
            try
            {
                connectDB(); // DB연동
                string getName = "";
                string getPosition = "";
                string getDepartment = "";
                string compareSubscribe = "";
                string[] split = getCheckData.Split(new String[] { "]" }, StringSplitOptions.None);
                List<string> listMemnum = new List<string>();
                List<string> listGetData = new List<string>();
                for (int i = 0; i < split.Length - 1; i++)
                {
                    string[] split_text = split[i].Split(new String[] { "|" }, StringSplitOptions.None);
                    getName = split_text[0];
                    getPosition = split_text[1];
                    getDepartment = split_text[2];
                    mCommand.CommandText = "SELECT mem_number FROM member where mem_name='" + getName
                        + "' and mem_position='" + getPosition + "' and mem_department='" + getDepartment + "'";
                    mDataReader = mCommand.ExecuteReader();
                    while (mDataReader.Read())
                    {
                        listMemnum.Add(mDataReader["mem_number"].ToString());
                    }
                    mDataReader.Close();

                    mCommand.CommandText = "SELECT * FROM subscribe where mem_subscribe='" + getMemNumber + "' and mem_number='" + listMemnum[i] + "' ";
                    mDataReader = mCommand.ExecuteReader();
                    while (mDataReader.Read())
                    {
                        compareSubscribe = mDataReader["mem_number"].ToString();
                    }
                    mDataReader.Close();


                    if (listMemnum[i] != getMemNumber && listMemnum[i] != compareSubscribe)
                    {

                        mCommand.CommandText = "insert into subscribe(mem_number, mem_subscribe)" + " values('" + listMemnum[i] + "','" + getMemNumber + "')";
                        mDataReader = mCommand.ExecuteReader();
                        mDataReader.Close();

                        mCommand.CommandText = "SELECT * FROM member where mem_number='" + listMemnum[i] + "'";
                        mDataReader = mCommand.ExecuteReader();
                        while (mDataReader.Read()) //쿼리문이 돌아서 값이 있으면 루프
                        {
                            listGetData.Add(mDataReader["mem_name"].ToString() + "|" + mDataReader["mem_position"].ToString()
                                + "|" + mDataReader["mem_department"].ToString() + "]");
                            // 리스트에 DB에서 꺼낸 데이터 값 넣음
                            // 이름, 직책, 부서 순으로
                        }
                        mDataReader.Close();
                    }
                    else
                    {
                        return null;
                    }
                }
                closeDB();
                return listGetData;
            }
            catch (Exception e) //실패하면
            {
                closeDB();
                return null;
            }
        }

        public List<string> LoadFormPutData(String getNumber)
        {
            try
            {
                List<string> listSub = new List<string>();
                List<string> getSub = new List<string>();
                connectDB();
                mCommand.CommandText = "SELECT * FROM subscribe where mem_subscribe='" + getNumber + "'";
                mDataReader = mCommand.ExecuteReader();
                while (mDataReader.Read()) //쿼리문이 돌아서 값이 있으면 루프
                {
                    listSub.Add(mDataReader["mem_number"].ToString());
                    // 리스트에 DB에서 꺼낸 데이터 값 넣음
                    // 이름, 직책, 부서 순으로
                }
                mDataReader.Close();
                for (int i = 0; i < listSub.Count; i++)
                {
                    mCommand.CommandText = "SELECT * FROM member where mem_number='" + listSub[i] + "'";
                    mDataReader = mCommand.ExecuteReader();
                    while (mDataReader.Read()) //쿼리문이 돌아서 값이 있으면 루프
                    {
                        getSub.Add(mDataReader["mem_name"].ToString() + "|" + mDataReader["mem_position"].ToString()
                            + "|" + mDataReader["mem_department"].ToString() + "]");
                    }
                    mDataReader.Close();
                }
                closeDB();
                return getSub;
            }
            catch (Exception e) //실패하면
            {
                closeDB();
                return null;
            }
        }

        public List<string> Findthendelete(String getCheckData, String getMemNumber)
        {
            try
            {
                connectDB(); // DB연동
                string getName = "";
                string getPosition = "";
                string getDepartment = "";
                string[] split = getCheckData.Split(new String[] { "]" }, StringSplitOptions.None);
                List<string> getSub = new List<string>();
                List<string> selectSub = new List<string>();
                for (int i = 0; i < split.Length - 1; i++)
                {
                    string[] split_text = split[i].Split(new String[] { "|" }, StringSplitOptions.None);
                    getName = split_text[0];
                    getPosition = split_text[1];
                    getDepartment = split_text[2];
                    mCommand.CommandText = "select mem_number FROM MEMBER where mem_name='" + getName
                        + "' and mem_position='" + getPosition + "' and mem_department='" + getDepartment + "'";
                    mDataReader = mCommand.ExecuteReader();

                    List<string> listSub = new List<string>();
                    while (mDataReader.Read())
                    {
                        listSub.Add(mDataReader["mem_number"].ToString());
                    }
                    mDataReader.Close();
                    mCommand.CommandText = "delete from subscribe where mem_number='" + listSub[i] + "' and mem_subscribe='" + getMemNumber + "'";
                    mDataReader = mCommand.ExecuteReader();
                    mDataReader.Close();
                }
                mCommand.CommandText = "SELECT * FROM subscribe where mem_subscribe='" + getMemNumber + "'";
                mDataReader = mCommand.ExecuteReader();
                while (mDataReader.Read()) //쿼리문이 돌아서 값이 있으면 루프
                {
                    selectSub.Add(mDataReader["mem_number"].ToString());
                }
                mDataReader.Close();
                for (int i = 0; i < selectSub.Count; i++)
                {
                    mCommand.CommandText = "SELECT * FROM member where mem_number='" + selectSub[i] + "'";
                    mDataReader = mCommand.ExecuteReader();
                    while (mDataReader.Read()) //쿼리문이 돌아서 값이 있으면 루프
                    {
                        getSub.Add(mDataReader["mem_name"].ToString() + "|" + mDataReader["mem_position"].ToString()
                            + "|" + mDataReader["mem_department"].ToString() + "]");
                    }
                    mDataReader.Close();
                }
                closeDB();
                return getSub;
            }
            catch (Exception e) //실패하면
            {
                closeDB();
                return null;
            }
        }
        public List<string> selectSearchName(String getName, String getPosition, String getDepartment)
        {   // 검색 함수
            try
            {
                connectDB(); // DB연동
                // SQL문 생성
                if (getName != "" && getPosition != "" && getDepartment != "")
                {

                    mCommand.CommandText = "SELECT * FROM member where mem_name='" + getName + "' and mem_position='" + getPosition + "' and mem_department='" + getDepartment + "'";
                }
                else if (getName != "" && getPosition != "" && getDepartment == "")
                {
                    mCommand.CommandText = "SELECT * FROM member where mem_name='" + getName + "' and mem_position='" + getPosition + "'";
                }
                else if (getName != "" && getPosition == "" && getDepartment != "")
                {
                    mCommand.CommandText = "SELECT * FROM member where mem_name='" + getName + "' and mem_department='" + getDepartment + "'";
                }
                else if (getName == "" && getPosition != "" && getDepartment != "")
                {
                    mCommand.CommandText = "SELECT * FROM member where mem_position='" + getPosition + "' and mem_department='" + getDepartment + "'";
                }
                else if (getName != "" && getPosition == "" && getDepartment == "")
                {
                    mCommand.CommandText = "SELECT * FROM member where mem_name='" + getName + "'";
                }
                else if (getName == "" && getPosition != "" && getDepartment == "")
                {
                    mCommand.CommandText = "SELECT * FROM member where mem_position='" + getPosition + "'";
                }
                else if (getName == "" && getPosition == "" && getDepartment != "")
                {
                    mCommand.CommandText = "SELECT * FROM member where mem_department='" + getDepartment + "'";
                }

                List<string> listSub = new List<string>();

                mDataReader = mCommand.ExecuteReader(); // 쿼리문 실행
                while (mDataReader.Read()) //쿼리문이 돌아서 값이 있으면 루프
                {
                    listSub.Add(mDataReader["mem_name"].ToString() + "|" + mDataReader["mem_position"].ToString()
                        + "|" + mDataReader["mem_department"].ToString() + "]");
                    // 리스트에 DB에서 꺼낸 데이터 값 넣음
                    // 이름, 직책, 부서 순으로
                }
                closeDB();//DB 연결통로를 닫는다 (이하동일)
                return listSub; //리스트값 반환
            }
            catch (Exception e) //실패하면
            {
                closeDB();
                return null;
            }

        }


        public void insertJoin(memDB insertDB)//회원가입시 insert 기능.
        {
            try
            {
                connectDB();
                
                mCommand.CommandText
                    = "insert into member(mem_name, mem_password, mem_department, mem_position, mem_jobyear, mem_number, mem_session)" +
                    " values('"+insertDB.mem_name+ "','" + insertDB.mem_password+ "','" + insertDB.mem_department+ "','" + insertDB.mem_position
                    + "'," + insertDB.mem_jobyear+ ",'" + insertDB.mem_number+ "',0)" ; // 쿼리문

                mDataReader = mCommand.ExecuteReader(); // 쿼리문 실행
                
                closeDB();//DB 연결통로를 닫는다 (이하동일)
            }
            catch (Exception e)
            {
                closeDB();
                Console.WriteLine(e.ToString());
            }
        }

        public bool selectNumber(String mem_num)//사원번호 생성시 사원번호 중복 확인에 사용됨.
        {
            try
            {
                connectDB();

                mCommand.CommandText = "SELECT * FROM member where mem_number='"+mem_num+"'"; // 쿼리문
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

        public void connectDB() // DB 연결메서드
        {
            try
            {
                mConnection = new MySqlConnection(url); // DB접속
                mCommand = new MySqlCommand(); // 쿼리문 생성
                mCommand.Connection = mConnection; // DB에 연결

                mConnection.Open(); //DB 연결통로를 연다.
            }
            catch(Exception e)
            {

            }
            
        }

        public void closeDB()//DB 연결종료 메서드
        {
            mConnection.Close();
        }
    }
}
