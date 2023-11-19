using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4_Nov18.KarateMembers
{
    public partial class memberpage : System.Web.UI.Page
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
                    Section section = (from x in dbcon.Sections select x).First();
                    Member user = (from x in dbcon.Members where x.Member_UserID == myUserID select x).First(); 

                    var myOtherResult = (from x in dbcon.Sections join s in dbcon.Instructors on x.Instructor_ID equals s.InstructorID where x.Member_ID == user.Member_UserID select new { x.SectionName, s.InstructorFirstName, s.InstructorLastName, x.SectionFee });

                    Label1.Text = user.MemberFirstName.ToString();
                    Label2.Text = user.MemberLastName.ToString();

                    GridView1.DataSource = myOtherResult;
                    GridView1.DataBind();
                }
            }
        }
}