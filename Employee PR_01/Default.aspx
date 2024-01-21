<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Employee_PR_01._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div style="width:500px; margin:20px auto; text-align:center">

        <asp:Button runat="server" Text="Add New Employee"  ID="btnAddEmployee" OnClick="btnAddEmployee_Click"  style="border:none; padding:6px; width:200px; border-radius:20px; background-color:coral"/>

    </div>

        <asp:GridView runat="server" AutoGenerateColumns="false" ID="gvHome" OnRowCommand="gvHome_RowCommand" ItemStyle-HorizontalAlign="Center" Width="100%" RowStyle-VerticalAlign="Middle"   RowStyle-BorderStyle="Solid" RowStyle-BorderWidth="1px"   HeaderStyle-BackColor="#6699ff" BackColor="LightBlue" OnRowDataBound="gvHome_RowDataBound">
     <Columns  >
<%--         <asp:BoundField HeaderText="S.No." ItemStyle-HorizontalAlign="Center"  />--%>
           <asp:BoundField  HeaderText="S.No."   DataField="EmployeeId" SortExpression="EmployeeId" ItemStyle-HorizontalAlign="Center"  />
         <asp:HyperLinkField  HeaderText="Employee Name" DataTextField="EmployeeName" DataNavigateUrlFields="EmployeeId" DataNavigateUrlFormatString="EmployeeEdit.aspx?id={0}" ItemStyle-HorizontalAlign="left"/>
         <asp:BoundField HeaderText="Designation" DataField="Designation" SortExpression="Designation" ItemStyle-HorizontalAlign="left" />
         <asp:BoundField HeaderText="Salary" DataField="Salary" SortExpression="Salary" ItemStyle-HorizontalAlign="left" DataFormatString="{0:C2}" />
         <asp:BoundField HeaderText="State" DataField="State" SortExpression="State" ItemStyle-HorizontalAlign="left"/>
         <asp:BoundField HeaderText="Gender" DataField="Gender" SortExpression="Gender" ItemStyle-HorizontalAlign="left"/>
         <asp:BoundField HeaderText="DateOfJoining " DataField="DateOfJoining" SortExpression="DateOfJoining" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="left"/>
<asp:ButtonField  HeaderText="Delete" ButtonType="Button" Text="Delete" CommandName="ButtonClick"  ControlStyle-BackColor="#ff0000" ControlStyle-ForeColor="#ffffff" ItemStyle-HorizontalAlign="left"  />
               
        
       

     </Columns>

 </asp:GridView>

</asp:Content>
