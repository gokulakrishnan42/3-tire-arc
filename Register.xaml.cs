using ConnectionBL;
using ConnectionDA;
using ConnectionModel;
using Microsoft.Data.SqlClient;
using System.Data;
using ConnectionModel;
using System.Windows;

namespace connection
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
            StdRegister or = new StdRegister();
            List<Course> data = or.GetCourses();
            

            comboCourse.DisplayMemberPath = "CNAME";   
            comboCourse.SelectedValuePath = "CID";
            comboCourse.ItemsSource = data;



        }



        private void btnreg_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            StdRegister or =new StdRegister();
            student.Sname = txtname.Text;
            student.Email= txtemail.Text;
            student.Phone=Convert.ToInt32(txtphone.Text);
            student.Dob = DateDOB.SelectedDate?.ToString("yyyy-MM-dd");
            student.cid = Convert.ToInt16(comboCourse.SelectedValue);
            student.Address = txtAddress.Text;
            int result = or.RegisterCourse(student);













            //try
            //{



            //    SqlConnection sql = new SqlConnection();
            //    sql.ConnectionString = @"Data Source=DESKTOP-O42HGKC\SQLEXPRESS;Initial Catalog=EMPLOYEE;integrated Security=true; Encrypt=false";
            //    sql.Open();
            //    SqlCommand cmd = new SqlCommand("INSERT INTO StudCourse VALUES(@sname,@email,@phone,@dob,@cid,@Address)", sql);
            //    cmd.Parameters.AddWithValue("@sname", txtname.Text);
            //    cmd.Parameters.AddWithValue("@email", txtemail.Text);
            //    cmd.Parameters.AddWithValue("@phone", txtphone.Text);
            //    cmd.Parameters.AddWithValue("@dob", DateDOB.SelectedDate);
            //    cmd.Parameters.AddWithValue("@cid", comboCourse.SelectedValue);
            //    cmd.Parameters.AddWithValue("@address", txtAddress.Text);

            //    int val = cmd.ExecuteNonQuery();
            //    if (val > 0)
            //    {
            //        MessageBox.Show("Student Resgistration Successfully");
            //    }



            //}


            //catch (SqlException ex)
            //{
            //    MessageBox.Show("SQL Error: " + ex.Message);


            //}
            //finally
            //{ }
        }

        //private int RegisterCourse(Student student)
        //{
        //    throw new NotImplementedException();
        //}
    }
}



//"INSERT INTO StudCourse (SNAME, EMAIL, PHONE, DOB, CID, ADDRESS) " +
//    "VALUES (@sname, @email, @phone, @dob, @cid, @address)", sql);




























