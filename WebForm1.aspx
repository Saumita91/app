<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="WebForm1.aspx.cs"
    Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bootstrap Form</title>

    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <script src="~/Scripts/bootstrap.bundle.min.js"></script>
</head>

<body>
    <form id="form1" runat="server">

        <div class="container mt-4">

            <!-- Name -->
            <div class="row mb-3">
                <div class="col-md-4">
                    <asp:Label runat="server" CssClass="form-label">Name</asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <!-- Gender -->
            <div class="row mb-3">
                <div class="col-md-4">
                    <asp:Label runat="server" CssClass="form-label">Gender</asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal" CssClass="form-check">
                        <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>

            <!-- Mobile -->
            <div class="row mb-3">
                <div class="col-md-4">
                    <asp:Label runat="server" CssClass="form-label">Mobile</asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
            </div>

            <!-- Department -->
            <div class="row mb-3">
                <div class="col-md-4">
                    <asp:Label runat="server" CssClass="form-label">Department</asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-select">
                    </asp:DropDownList>
                </div>
            </div>

            <!-- Submit -->
            <div class="row">
                <div class="col-md-8" align="center">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                </div>
            </div>

            <div class="row">
                <div class="col-md-12 table-responsive">
                    <asp:GridView ID="gvEmployee" runat="server" Width="100%" OnRowDataBound="gvEmployee_RowDataBound"
                        OnRowCancelingEdit="gvEmployee_RowCancelingEdit" OnRowUpdating="gvEmployee_RowUpdating" OnRowDeleting="gvEmployee_RowDeleting"
                        OnRowEditing="gvEmployee_RowEditing" AutoGenerateColumns="false" DataKeyNames="GenderId,DeptId">
                        <Columns>
                            <asp:BoundField DataField="EmpId" HeaderText="Employee ID" ReadOnly="true" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:TemplateField HeaderText="Gender">
                                <ItemTemplate>
                                    <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:RadioButtonList ID="rblGender" runat="server"
                                        RepeatDirection="Horizontal"
                                        CssClass="form-check">
                                        <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Mobile" HeaderText="Mobile No" ReadOnly="true" />
                            <asp:TemplateField HeaderText="Department">
                                <ItemTemplate>
                                    <asp:Label ID="lblDept" runat="server" Text='<%# Eval("DeptName") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlDept" runat="server" CssClass="form-select"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:CommandField ShowEditButton="true" />
                            <asp:CommandField ShowDeleteButton="true" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </div>

    </form>
</body>
</html>
