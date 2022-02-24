<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="managerStatistic.aspx.cs" Inherits="Team_Racing.managerStatistic" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Manager Statistic</title>
    <link rel="stylesheet" href="css/main.css">
    <script src=" https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.min.js"></script>
    <style>      
        h2 {
            text-align: center;
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

    


    <section class="Review-section">
        <div class="container">

            <div> 
                <asp:DropDownList CssClass="select-box" ID="charttypeDropDownList" runat="server" AutoPostBack ="true">
                    <asp:ListItem Selected="True" Value="Pie"> Pie </asp:ListItem>
                    <asp:ListItem Value="Bar"> Bar </asp:ListItem>
                    <asp:ListItem Value="StackedBar"> Column </asp:ListItem>
                    </asp:DropDownList>
            </div>        
            <div>
                <br />
    <asp:Chart ID="Chart1" runat="server" Height="650px" Width="1000px">
        <Series>
            <asp:Series Name="Series1" ChartType="Pie"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
                <asp:GridView ID="GridView1" runat="server" Font-Overline="False" ForeColor="#FF3300" HorizontalAlign="Justify">
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                    <HeaderStyle ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:GridView>
    <br />
            </div>

        </div>
    </section>

    

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
    </form>

</body>
</html>