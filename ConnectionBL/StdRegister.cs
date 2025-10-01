using ConnectionDA;
using ConnectionModel;
using Microsoft.Data.SqlClient;
using ConnectionBL.Interface;
using Microsoft.Data.Sql;
using System.Data;




namespace ConnectionBL
{
    public class StdRegister: IRegister
    {
        public int RegisterCourse (Student student)
        {
            string sql = "INSERT INTO STUDCOURSE VALUES(@SNAME,@EMAIL,@PHONE,@DOB,@CID,@ADDRESS)";
            Dictionary<string,string>parameters=new Dictionary<string,string>();
            parameters.Add("@sname", student.Sname);
            parameters.Add("@email", student.Email);
            parameters.Add("@phone", student.Phone.ToString());
            parameters.Add("@dob", student.Dob);
            parameters.Add("@cid", student.cid.ToString());
            parameters.Add("@address", student  .Address);
            SQLHelper sQLHelper = new SQLHelper();
            return sQLHelper.ExcuteQuery(sql, parameters);

        }
        public List<Course> GetCourses()
        {
            string sql = "SELECT CID,CNAME FROM COURSE";
            Dictionary<string,string>parameters=new Dictionary<string,string>();
            SQLHelper sQLHelper = new SQLHelper();
            DataSet ds = sQLHelper.GetData(sql, parameters);
            List<Course> courses = new List<Course>();
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Course course = new Course();
                course.CID = Convert.ToInt32(row["CID"]);
                course.CNAME = row["CNAME"].ToString();
                courses.Add(course);
            }
            return courses;
        }






    }
}
