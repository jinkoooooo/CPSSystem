using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverForm
{
    class memDB//회원가입을 시도하는 회원의 정보를 한 변수에 담기위해 만들 클레스이다.
    {
        public string mem_name;
        public string mem_password;
        public string mem_department;
        public string mem_position;
        public int mem_jobyear;
        public string mem_number;
        public int mem_session=0;
        public string mem_context=null;
        public string mem_subscribe=null;
    }
}
