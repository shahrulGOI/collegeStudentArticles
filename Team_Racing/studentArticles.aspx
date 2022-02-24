<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentArticles.aspx.cs" Inherits="Team_Racing.studentReview" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>My Articles</title>
    <link rel="stylesheet" href="css/main.css">
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
    </style>
</head>
<body>
<form runat="server">
    <div class="navbar">
        <div class="container">
            <a class="logo" href="~/userUpload.aspx" runat="server">Celtic<span>University</span></a> <!--Logo in text format, can put images also if u guys want-->

            <img id="mobile-cta" class="mobile-menu" src="images/menu.svg" alt="Open Navigation">

            <nav>
                <img id="mobile-exit" class="mobile-menu-exit" src="images/exit.svg" alt="Close Navigation">

                
                <ul class="primary-nav">
                    <li><asp:HyperLink ID="uploadArticle" Text="Upload Article" NavigateUrl ="~/userUpload.aspx" runat="server"></asp:HyperLink></li>
                    <li class="current"><asp:HyperLink ID="viewArticle" Text="View My Upload" NavigateUrl ="~/studentArticles.aspx" runat="server"></asp:HyperLink></li>
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
            <table class="center">

                <tr>
                    <td style="text-align:center; border:hidden;"> <asp:Image runat="server" ID="image1" style='width:100%; height:500px; border:none;' frameborder='0' /><asp:Button runat="server" ID="btn1" Text="View" style="text-align:center;background-color:transparent; color:black; font-family: 'Times New Roman', Times, serif" OnClick="btn1_Click" /></td>
                    <td style="text-align:center; border:hidden;"> <asp:Image runat="server" ID="image2" style='width:100%; height:500px; border:none;' frameborder='0' /><asp:Button runat="server" ID="btn2" Text="View" style="text-align:center;background-color:transparent; color:black; font-family: 'Times New Roman', Times, serif" OnClick="btn2_Click" /></td>
                    <td style="text-align:center; border:hidden;"> <asp:Image runat="server" ID="image3" style='width:100%; height:500px; border:none;' frameborder='0' /><asp:Button runat="server" ID="btn3" Text="View" style="text-align:center;background-color:transparent; color:black; font-family: 'Times New Roman', Times, serif" OnClick="btn3_Click" /></td>
                </tr>
            </table>
            <br />
        </div>
        </section>
</form>

   <script type="text/javascript">


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

