<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Employee_PR_01.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3></h3>
        <p> The application utilizes the Employee class as a data structure to encapsulate essential information such as names, birthdate, gender, contact details, salary, and joining date. The structured representation of employee data ensures efficient data management and retrieval, providing a centralized platform for tracking and updating employee biodata.</p>
    </main>
</asp:Content>
