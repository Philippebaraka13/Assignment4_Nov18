using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4_Nov18.KarateInstructor
{
    public partial class instructorpage : System.Web.UI.Page
    {
        KarateDataContext dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Chris\\source\\repos\\ChristopherTupper\\KarateSchool\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateDataContext(conn);

            if(!IsPostBack)
            {
                string currentUserName = HttpContext.Current.User.Identity.Name;

                var currentInstructor = (from u in dbcon.NetUsers where u.UserName == currentUserName select new {u.UserID, u.UserName}).FirstOrDefault();

                if(currentInstructor != null)
                {
                    var instructorDetails = (from i in dbcon.Instructors where i.InstructorID == currentInstructor.UserID select i).FirstOrDefault();

                    if(instructorDetails != null)
                    {
                        Label1.Text = instructorDetails.InstructorFirstName;
                        Label2.Text = instructorDetails.InstructorLastName;

                        var sectionswithMembers = (from s in dbcon.Sections
                                                   join m in dbcon.Members on s.Member_ID equals m.Member_UserID
                                                   where s.Instructor_ID == instructorDetails.InstructorID
                                                   select new
                                                   {
                                                       s.SectionName,
                                                       m.MemberFirstName,
                                                       m.MemberLastName
                                                   });

                        GridView1.DataSource = sectionswithMembers;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }
}