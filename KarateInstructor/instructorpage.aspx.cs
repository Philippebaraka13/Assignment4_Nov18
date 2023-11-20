using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment4_Nov18.KarateInstructor
{
    public partial class instructorpage : System.Web.UI.Page
    {
        KarateDataContext dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kamok\\Source\\Repos\\Assignment4_Nov18_Instrutor\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30"; 

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateDataContext(conn);

            if (!IsPostBack)
            {
                // Assuming the user's login name is stored in a session or in the context after they log in
                string currentUserName = HttpContext.Current.User.Identity.Name;
                // You would replace the 'NetUsers' with the actual context of your user database
                var currentInstructor = (from u in dbcon.NetUsers
                                         where u.UserName == currentUserName
                                         select new
                                         {
                                             u.UserID,
                                             u.UserName
                                         }).FirstOrDefault();

                if (currentInstructor != null)
                {
                    // Find the instructor's record in the Instructors table using the UserID from NetUsers
                    var instructorDetails = (from i in dbcon.Instructors
                                             where i.InstructorID == currentInstructor.UserID
                                             select i).FirstOrDefault();

                    if (instructorDetails != null)
                    {
                        Label1.Text = instructorDetails.InstructorFirstName;
                        Label2.Text = instructorDetails.InstructorLastName;

                        // Query to fetch all sections taught by the logged-in instructor and the corresponding members
                        var sectionsWithMembers = (from s in dbcon.Sections
                                                   join m in dbcon.Members on s.Member_ID equals m.Member_UserID // Adjusted to use Member_UserID
                                                   where s.Instructor_ID == instructorDetails.InstructorID
                                                   select new
                                                   {
                                                       s.SectionName,
                                                       MemberFirstName = m.MemberFirstName,
                                                       MemberLastName = m.MemberLastName
                                                   }).ToList();

                        GridView1.DataSource = sectionsWithMembers;
                        GridView1.DataBind();
                    }
                    else
                    {
                        // Handle the case where the instructor is not found in Instructors table
                        Label1.Text = "Instructor not found in Instructors table.";
                        Label2.Text = "";
                    }
                }
                else
                {
                    // Handle the case where the instructor is not found in NetUsers table
                    Label1.Text = "Instructor not found in NetUsers table.";
                    Label2.Text = "";
                }
            }
        }
    }
}
