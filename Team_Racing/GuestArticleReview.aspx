<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuestArticleReview.aspx.cs" Inherits="Team_Racing.GuestArticleReview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Guest Article View</title>
    <link rel="stylesheet" href="css/main.css"/>
    <style>
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
            
        }

            table.center {
                margin-left: auto;
                margin-right: auto;
                table-layout: fixed;
                width: 100%;
            }
        .auto-style1 {
            width: 43%;
        }
        .auto-style2 {
            width: 99%;
            height: 600px;
        }
        .auto-style3 {
            height: 45px;
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
                <asp:Table class="center" runat="server" style="border:hidden">

                    <asp:TableRow runat="server">
                        <asp:TableCell RowSpan="2" id="iframtablecell" > <iframe runat="server" id="iframe" style='margin-right: 0px;' frameborder='0' class="auto-style2"></iframe> </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server" >
                        <asp:TableCell style="border:hidden"><iframe runat="server" id="iframe2" style='margin-right: 0px;' frameborder='0' class="auto-style2"></iframe></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />

                
                <a href="GuestMainMenu.aspx" class="Back">Back</a>
            </div>
        </section></form>

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
