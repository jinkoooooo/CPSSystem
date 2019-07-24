using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverForm
{
    class makeMember_num// 사원번호 랜덤생성 기능을 구현하기위한 클래스이다.
    {
        public string mknum(string jobYear, string departmer, string position)
        {



            //부서 순서대로 0,1,2,3   직책 순서대로 0,1,2,3

            string mem_num = null;//사원번호 넣을 변수
            Random rand_num = new Random();
            int tmpRand;

            mem_num += jobYear;//사원번호

           
            switch (departmer)
            {
                case "영업팀":
                    mem_num += "0";
                    break;
                case "개발팀":
                    mem_num += "1";
                    break;
                case "본부팀":
                    mem_num += "2";
                    break;
                case "설비팀":
                    mem_num += "3";
                    break;
            }

            switch (position)
            {
                case "사원":
                    mem_num += "0";
                    break;
                case "선임":
                    mem_num += "1";
                    break;
                case "책임":
                    mem_num += "2";
                    break;
                case "사장":
                    mem_num += "3";
                    break;
            }

            //mem_num += departmer;//부서
            //mem_num += position;//직책  --> 이까지하면 ex)201712 정도가됨. 뒷 3자리는 이후생성.

            while (true)
            {
                string temp = mem_num;

                tmpRand = rand_num.Next(0, 999);//렌덤값 3자리 생성

                temp += tmpRand;

                mapperDB testDB = new mapperDB(); //DB연결을 위해 DB클레스 변수 선언.

                if (testDB.selectNumber(temp))//생성된 사원번호가 이미 존재한다.
                {
                    continue;//재생성을위해 진행
                }
                else//존재하지 않는다.
                {
                    mem_num = temp;
                    break;
                }
            }

            return mem_num;//생성된 사원번호 반환.
        }
    }
}
