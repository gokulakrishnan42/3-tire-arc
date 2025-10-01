using ConnectionDA;
using ConnectionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionBL.Interface
{
    public class IRegister
    {
        public int RegisterCourse(Student student)
        {
            string sql = "INSERT INTO STUDCOURSE VALUES(@SNAME,@EMAIL,@PHONE,@DOB,@CID,@ADDRESS)";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@sname", student.Sname);
            parameters.Add("@email", student.Email);
            parameters.Add("@phone", student.Phone.ToString());
            parameters.Add("@dob", student.Dob);
            parameters.Add("@cid", student.cid.ToString());
            parameters.Add("@address", student.Address);
            SQLHelper sQLHelper = new SQLHelper();
            return sQLHelper.ExcuteQuery(sql, parameters);

        }
       
    }
}
