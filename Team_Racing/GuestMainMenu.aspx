<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuestMainMenu.aspx.cs" Inherits="Team_Racing.GuestMainMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Guest Main Menu</title>
    <link rel="stylesheet" href="css/main.css" />
    <script src="jquery.min.js"></script>
    <script src="image-picker.min.js"></script>
    <style>
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
            width: 100%;
        }

        table.center {
            margin-left: auto;
            margin-right: auto;
            table-layout: fixed;
            width: 100%;
        }
        .itemCheck{
            word-break: break-all;
            word-wrap: break-word;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
<div class="navbar">
        <div class="container">
            <a class="logo" href="~/GuestMainMenu.aspx" runat="server">Celtic<span>University</span></a> <!--Logo in text format, can put images also if u guys want-->

            <img id="mobile-cta" class="mobile-menu" src="images/menu.svg" alt="Open Navigation"/>

            <nav>
                <img id="mobile-exit" class="mobile-menu-exit" src="images/exit.svg" alt="Close Navigation"/>

                <ul class="primary-nav">
                   <li><asp:HyperLink ID="guestmain" Text="View Student Articles" NavigateUrl ="~/GuestMainMenu.aspx" runat="server"></asp:HyperLink></li>
                </ul>

                <ul class="secondary-nav">
                    <li><a href="#">Guest</a></li>
                    <li class="go-premium-cta"><asp:Button runat="server" ID="labelLogout" Text="Log Out" OnClick="buttonLogout_Click" OnClientClick="Confirm()"></asp:Button></li>
                </ul>
            </nav>
        </div>
    </div>
    
    <section class="Review-section">
        <div class="container">
            <section class="image-picker">
                <asp:GridView runat="server" ID="gridView1" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" RowStyle-Width="40px" style="table-layout:fixed; font-size:14px">
                    <Columns>                       
                        <asp:TemplateField HeaderText="No" HeaderStyle-CssClass="itemCheck" HeaderStyle-Width="30px">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="articleId" Text='<%# Eval("no") %>'></asp:Label>
                            </ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="itemCheck"  HeaderStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="studentName" Text='<%# Eval("name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Article" HeaderStyle-CssClass="itemCheck"  HeaderStyle-Width="350px">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="article" Text='<%# Eval("article_title") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Faculty" HeaderStyle-CssClass="itemCheck"  HeaderStyle-Width="300px">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="faculty" Text='<%# Eval("faculty_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-CssClass="itemCheck"  HeaderStyle-Width="100px">
                        <ItemTemplate>
                                <asp:LinkButton runat="server" ID="linkButton" Text="View" OnClick="LinkButton_Click" data-name='<%# Eval("name") %>' data-article='<%# Eval("article_title") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </section>
            <br />
        </div>
        </section>
    </form>
     <script>
         $('.image-picker').imagepicker();

         function Confirm() {
             var confirm_value = document.createElement("INPUT");
             confirm_value.type = "hidden";
             confirm_value.name = "confirm_value";
             if (confirm("Are you sure want to log out?")) {
                 confirm_value.value = "Yes";
             } else {
                 confirm_value.value = "No";
             }
             document.forms[0].appendChild(confirm_value);
         }


         const mobileBtn = document.getElementById('mobile-cta')
         nav = document.querySelector('nav')
         mobileBtnExit = document.getElementById('mobile-exit');

         mobileBtn.addEventListener('click', () => {
             nav.classList.add('menu-btn');
         })

         mobileBtnExit.addEventListener('click', () => {
             nav.classList.remove('menu-btn');
         })
     </script>
</body>
</html>
