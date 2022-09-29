using MyApp.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
namespace MyApp.db
{
    public class ABState
    {
        private string ConnectionStrings = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        public int insertSignup(EntitySignUp model)
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            SqlCommand comm = new SqlCommand("SP_Signup", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@name", model.name);
            comm.Parameters.AddWithValue("@email", model.email);
            comm.Parameters.AddWithValue("@password", model.password);
            comm.Parameters.AddWithValue("@cPassword", model.cPassword);
            conn.Open();
            int result = 0;
            if (model.password == model.cPassword)
            {
                result = comm.ExecuteNonQuery();
                conn.Close();
                if (result>0)
                {
                    Uri link = new Uri("http://localhost:44395/Login/verifyEmail?email=" + model.email);
                    string to = model.email; //To address    
                    string from = "shubham@yourflow.com.au"; //From address    
                    MailMessage message = new MailMessage(from, to);

                    string mailbody = "Welcome to Our team My Own Research" + "<br/> To verify account click this link " +
                        "<a href='" + link + "'>" + " Click here </a>";
                    message.Subject = "My Own Research";
                    message.Body = mailbody;
                    message.BodyEncoding = Encoding.UTF8;
                    message.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                    System.Net.NetworkCredential basicCredential1 = new
                    System.Net.NetworkCredential("shubham@yourflow.com.au", "Shubhj@21");
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = basicCredential1;
                    //make less secure app on then it will be sent the mail.
                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("email Already register");
                }
            }
            else
            {
                Console.WriteLine("Check Password");
            }
            return result;
        }
        public int VerifyEmailId(string email)
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            SqlCommand comm = new SqlCommand("SP_VerificationCheck", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@email", email);
            conn.Open();
            int result = comm.ExecuteNonQuery();
            conn.Close();
            if (result > 0)
            {
                Console.WriteLine("Email Verify Succesfully");
            }
            else
            {
                Console.WriteLine("Something went Wrong");

            }
            return result;
        }
        public int forPassword(forgotModel model)
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            int result=0;
            SqlCommand comm = new SqlCommand("SP_ForgotPass", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@email", model.forEmail);
            conn.Open();
            SqlDataReader ad = comm.ExecuteReader();
            if (ad.Read())
            {
                string email = ad["email"].ToString();
                string password = ad["password"].ToString();

                string to = model.forEmail; //To address    
                string from = "shubham@yourflow.com.au"; //From address    
                MailMessage message = new MailMessage(from, to);

                message.Subject = "Your Password";
                message.Body = string.Format("Hello : our email ID: <h1>{0}</h1></br></br> Your Password is : <h1>{1}</h1>", email, password);
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("shubham@yourflow.com.au", "Shubhj@21");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                //make less secure app on then it will be sent the mail.
                try
                {
                    client.Send(message);
                    result = 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return result;
        }
        public int Login(EntityLogin login)
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            int Result=0;
            SqlCommand comm = new SqlCommand("SP_Login", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@email", login.strEmail);
            comm.Parameters.AddWithValue("@password", login.strPassword);

            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            DataTable tb = new DataTable();
            adapter.Fill(tb);
            if (tb.Rows.Count > 0)
            {
                foreach (DataRow item in tb.Rows)
                {
                    login.userId = Convert.ToInt32(item["userId"]);
                    login.name = Convert.ToString(item["name"]);
                }
                Result = 1;
            }
            else
            {
                Result = 0;
            }
            return Result;
        }
        public DataSet Get_Country()
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            //get all country
            SqlCommand comm = new SqlCommand("SP_GetCountry", conn);
            SqlDataAdapter ad = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            return ds;
        }
        public DataSet Country(string resId)
        {
            //get all state
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            SqlCommand comm = new SqlCommand("SP_BindCountry", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@resId", resId);
            SqlDataAdapter ad = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            return ds;
        }
        public DataSet Get_State(string CountryId)
        {
            //get all state
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            SqlCommand comm = new SqlCommand("SP_GetState", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@CountryId", CountryId);
            SqlDataAdapter ad = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            return ds;
        }
        public DataSet Get_City(string StateId)
        {
            //get all city
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            SqlCommand comm = new SqlCommand("SP_GetCity", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandTimeout = 120;
            comm.Parameters.AddWithValue("@StateId", StateId);
            SqlDataAdapter ad = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            return ds;
        }
    }
}
