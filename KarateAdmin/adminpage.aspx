<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminpage.aspx.cs" Inherits="Assignment4_Nov18.KarateAdmin.adminpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <p>
        <br />
        Hi,
        <asp:LoginName ID="LoginName1" runat="server" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LoginStatus ID="LoginStatus1" runat="server" />
    </p>
    <p>
&nbsp;
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </p>
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="addUser" runat="server" OnClick="addUser_Click" Text="Add" />
&nbsp;: UserName<asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
&nbsp;UserPassword<asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
&nbsp; UserType<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
        </asp:DropDownList>
    </p>
        <p>
    &nbsp;FirstName<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;LastName
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;PhoneNumber<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp; Email<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
&nbsp;DateJoined<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    </p>
    <p>
    </p>
        <p>
            <asp:Button ID="deleteInstructor" runat="server" OnClick="deleteInstructor_Click" Text="Delete" />
&nbsp;Instructor: ID
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
    </p>
        <p>
            <asp:Button ID="deleteMember" runat="server" OnClick="deleteMember_Click" Text="Delete" />
&nbsp;Member: ID
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
    </p>
        <p>
    </p>
        <p>
            <asp:Button ID="addToSection" runat="server" OnClick="addToSection_Click" Text="Add" />
&nbsp;Member: ID<asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
&nbsp;to Section: Name<asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
&nbsp;SectionStartDate<asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
&nbsp;InstructorID<asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
&nbsp;SectionFee<asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
    </p>
</asp:Content>
