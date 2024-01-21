<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="Employee_PR_01.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Employee Details </title>


    <style>
        body {
        }

        h2 {
            color: #333;
        }

        label {
            display: inline-block;
            width: 150px;
            margin-bottom: 10px;
        }

        input[type="text"],
        input[type="date"],
        input[type="button"] {
            width: 200px;
            padding: 5px;
            margin-bottom: 10px;
        }

        input[type="radio"] {
            margin-bottom: 10px;
        }

        .error-message {
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="border: 2px solid; background-color: lightblue; margin: 80px auto; height: 400px; width: 600px; padding: 30px; border-radius: 30px">
        <div>
            <h2>Add User Details</h2>

            <label for="txtName">Name:</label>
            <asp:TextBox ID="txtName" runat="server" Style="border-radius: 5px;" placeholder="Enter Name"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <label for="txtDesignation">Designation:</label>
            <asp:TextBox ID="txtDesignation" runat="server" placeholder="Enter Designation" Style="border-radius: 5px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDesignation" runat="server" ControlToValidate="txtDesignation" ErrorMessage="Designation is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <label for="txtSalary">Salary:</label>
            <asp:TextBox ID="txtSalary" runat="server" placeholder="Enter Salary" Style="border-radius: 5px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvSalary" runat="server" ControlToValidate="txtSalary" ErrorMessage="Salary is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <label for="ddlState">State:</label>
            <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" Style="border-radius: 5px;" AppendDataBoundItems="true">
                <asp:ListItem Text="-- Select State --" Value="" />
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState" ErrorMessage="State is required." InitialValue="" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <label>Gender:</label>
            <asp:RadioButton ID="rbMale" runat="server" GroupName="gender" Checked Text="Male" />
            <asp:RadioButton ID="rbFemale" runat="server" GroupName="gender" Text="Female" />
            <br />

            <label for="txtJoiningDate">Date of Joining:</label>
            <asp:TextBox ID="txtJoiningDate" runat="server" type="date" Style="border-radius: 5px;"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvJoiningDate" runat="server" ControlToValidate="txtJoiningDate" ErrorMessage="Date of Joining is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <asp:Button ID="btnSave" runat="server" Text="Save" Style="border-radius: 5px; background-color: royalblue; border: none; width: 100px; padding: 5px; height: 40px" OnClick="btnSave_Click" />
            <br />
            <asp:Label ID="lblMessage" runat="server" CssClass="error-message"></asp:Label>
            <br />

            <asp:HyperLink runat="server" NavigateUrl="~/Default.aspx"> Go To Home</asp:HyperLink>
        </div>
    </form>
</body>
</html>
