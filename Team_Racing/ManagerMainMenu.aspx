<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerMainMenu.aspx.cs" Inherits="Team_Racing.ManagerMainMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manager Main Menu</title>
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
            <a class="logo" href="~/ManagerMainMenu.aspx" runat="server">Celtic<span>University</span></a> <!--Logo in text format, can put images also if u guys want-->
            <!--href means the link that the user will be brought to if the user clicks on the logo-->

            <img id="mobile-cta" class="mobile-menu" src="images/menu.svg" alt="Open Navigation">
            <!--Hamburger icon to sum the "upload article, View others upload, username, and Logout"-->
            <!--Only Activates when its in mobile mode (since we need to use this website on other platform)-->

            <nav>
                <img id="mobile-exit" class="mobile-menu-exit" src="images/exit.svg" alt="Close Navigation">
                <!--x icon for user to close the navigation-->

                <ul class="primary-nav">
                    <li><asp:HyperLink ID="managermain" Text="View Student Articles" NavigateUrl ="~/ManagerMainMenu.aspx" runat="server"></asp:HyperLink></li>
                    <li><asp:HyperLink ID="managerstatistic" Text="View Statistic" NavigateUrl ="~/managerStatistic.aspx" runat="server"></asp:HyperLink></li>
                </ul>

                <ul class="secondary-nav">
                    <li><asp:Label runat="server" ID="Labelusername" Text="123"></asp:Label></li>
					<li class="go-premium-cta"><asp:Button runat="server" ID="labelLogout" Text="Log Out" OnClick="buttonLogout_Click" OnClientClick="Confirm()"></asp:Button></li>
                </ul>
            </nav>
        </div>
    </div>
    

        <div>
            <section class="image-picker">
                <asp:GridView runat="server" ID="gridView1" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" RowStyle-Width="40px" style="table-layout:fixed; font-size:14px">
                    <Columns>
                        
                        <asp:TemplateField HeaderText="No" HeaderStyle-CssClass="itemCheck" HeaderStyle-Width="5%">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="articleId" Text='<%# Eval("no") %>'></asp:Label>
                            </ItemTemplate>
                        <ItemStyle Width="100px"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="itemCheck"  HeaderStyle-Width="15%">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="studentName" Text='<%# Eval("name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Username" HeaderStyle-CssClass="itemCheck"  HeaderStyle-Width="15%">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="studentUsername" Text='<%# Eval("username") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Article" HeaderStyle-CssClass="itemCheck"  HeaderStyle-Width="35%">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="article" Text='<%# Eval("article_title") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ArticleDescription" HeaderStyle-CssClass="itemCheck"  HeaderStyle-Width="25%">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="articledescription" Text='<%# Eval("article_description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Image" HeaderStyle-CssClass="itemCheck"  HeaderStyle-Width="20%">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="image" Text='<%# Eval("image_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Faculty" HeaderStyle-CssClass="itemCheck"  HeaderStyle-Width="30%">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="faculty" Text='<%# Eval("faculty_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-CssClass="itemCheck"  HeaderStyle-Width="10%">
                        <ItemTemplate>
                                <asp:LinkButton runat="server" ID="linkButton" Text="View" OnClick="LinkButton_Click" data-name='<%# Eval("name") %>' data-article='<%# Eval("article_title") %>' data-description='<%# Eval("article_description") %>' data-image='<%# Eval("image_name") %>' data-username='<%# Eval("username") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-CssClass="itemCheck"  HeaderStyle-Width="10%">
                        <ItemTemplate>
                                <asp:LinkButton runat="server" ID="download1Button" Text="Download" OnClick="download1Button_Click" data-name='<%# Eval("name") %>' data-article='<%# Eval("article_title") %>' data-description='<%# Eval("article_description") %>' data-image='<%# Eval("image_name") %>' data-username='<%# Eval("username") %>'></asp:LinkButton>
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

                <br />
            </section>
            <br />

            
        </div>

    </form>
     <script>

         //function for pop out log out message
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
