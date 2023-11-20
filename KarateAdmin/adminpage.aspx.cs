using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4_Nov18.KarateAdmin
{
    public partial class adminpage : System.Web.UI.Page
    {
        KarateDataContext dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Chris\\source\\repos\\ChristopherTupper\\KarateSchool\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateDataContext(conn);
            string myUser = User.Identity.Name;
            //string myUser = "user1";

            int myUserID = (from x in dbcon.NetUsers where x.UserName == HttpContext.Current.Session["nUserName"].ToString() select x.UserID).First();
            //int myMemberID = myUser.UserID;



            if (!IsPostBack)
            {
                var myOtherResult = (from x in dbcon.Members select new {x.MemberFirstName, x.MemberLastName, x.MemberPhoneNumber, x.MemberDateJoined});
                
                GridView1.DataSource = myOtherResult;
                GridView1.DataBind();

                var myResult = (from x in dbcon.Instructors select new {x.InstructorFirstName, x.InstructorLastName });
                GridView2.DataSource = myResult;
                GridView2.DataBind();

                var dropList = (from x in dbcon.NetUsers select x.UserType).Distinct();

                DropDownList1.DataSource = dropList;
                DropDownList1.DataBind();
            }
        }

        protected void addUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (DropDownList1.SelectedValue == "Instructor")
                {
                    SqlConnection con = new SqlConnection(conn);

                    string query = "insert into NetUser (UserName, UserPassword, UserType) values ('" + TextBox15.Text + "', '" + TextBox16.Text + "', '" + DropDownList1.SelectedValue + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    int addID = (from x in dbcon.NetUsers where x.UserName == TextBox15.Text select new { x.UserID }).First().UserID;

                    query = "insert into Instructor (InstructorID, InstructorFirstName, InstructorLastName, InstructorPhoneNumber) values ('" + addID + "', '" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "')";
                    cmd = new SqlCommand(query, con);
                    adapter = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    adapter.Fill(ds);
                }else if(DropDownList1.SelectedValue == "Member")
                {
                    SqlConnection con = new SqlConnection(conn);

                    string query = "insert into NetUser (UserName, UserPassword, UserType) values ('" + TextBox15.Text + "', '" + TextBox16.Text + "', '" + DropDownList1.SelectedValue + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    int addID = (from x in dbcon.NetUsers where x.UserName == TextBox15.Text select new { x.UserID }).First().UserID;

                    query = "insert into Member (Member_UserId, MemberFirstName, MemberLastName, MemberPhoneNumber, MemberEmail, MemberDateJoined) values ('" + addID + "', '" + TextBox1.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "')";
                    cmd = new SqlCommand(query, con);
                    adapter = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    adapter.Fill(ds);
                }else if(DropDownList1.SelectedValue == "Administrator")
                {
                    SqlConnection con = new SqlConnection(conn);

                    string query = "insert into NetUser (UserName, UserPassword, UserType) values ('" + TextBox15.Text + "', '" + TextBox16.Text + "', '" + DropDownList1.SelectedValue + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                }
            }
            catch { }
                var myOtherResult = (from x in dbcon.Members select new { x.MemberFirstName, x.MemberLastName, x.MemberPhoneNumber, x.MemberDateJoined });

                GridView1.DataSource = myOtherResult;
                GridView1.DataBind();

                var myResult = (from x in dbcon.Instructors select new { x.InstructorFirstName, x.InstructorLastName });
                GridView2.DataSource = myResult;
                GridView2.DataBind();
        }

        protected void deleteInstructor_Click(object sender, EventArgs e)
        {
            // This is an unsafe function. Selecting a Member_UserID will make it delete the Member from NetUsers, but not from Members.
            try
            {
                SqlConnection con = new SqlConnection(conn);

                string query = "delete from Instructor where InstructorID = '" + TextBox8.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                query = "delete from Section where Instructor_ID = '" + TextBox8.Text + "'";
                cmd = new SqlCommand(query, con);
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adapter.Fill(ds);

                query = "delete from NetUser where UserID = '" + TextBox8.Text + "'";
                cmd = new SqlCommand(query, con);
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adapter.Fill(ds);
            }
            catch { }
                var myOtherResult = (from x in dbcon.Members select new { x.MemberFirstName, x.MemberLastName, x.MemberPhoneNumber, x.MemberDateJoined });

                GridView1.DataSource = myOtherResult;
                GridView1.DataBind();

                var myResult = (from x in dbcon.Instructors select new { x.InstructorFirstName, x.InstructorLastName });
                GridView2.DataSource = myResult;
                GridView2.DataBind();
        }

        protected void deleteMember_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conn);

                string query = "delete from Member where Member_UserID = '" + TextBox9.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
            }
            catch { }
                var myOtherResult = (from x in dbcon.Members select new { x.MemberFirstName, x.MemberLastName, x.MemberPhoneNumber, x.MemberDateJoined });

                GridView1.DataSource = myOtherResult;
                GridView1.DataBind();

                var myResult = (from x in dbcon.Instructors select new { x.InstructorFirstName, x.InstructorLastName });
                GridView2.DataSource = myResult;
                GridView2.DataBind();
        }

        protected void addToSection_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(conn);

                string query = "insert into Section (Member_ID, SectionName, SectionStartDate, Instructor_ID, SectionFee) values ('" + TextBox10.Text + "', '" + TextBox11.Text + "', '" + TextBox12.Text + "', '" + TextBox13.Text + "', '" + TextBox14.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
            }
            catch { }
                var myOtherResult = (from x in dbcon.Members select new { x.MemberFirstName, x.MemberLastName, x.MemberPhoneNumber, x.MemberDateJoined });

                GridView1.DataSource = myOtherResult;
                GridView1.DataBind();

                var myResult = (from x in dbcon.Instructors select new { x.InstructorFirstName, x.InstructorLastName });
                GridView2.DataSource = myResult;
                GridView2.DataBind();
        }
    }
}