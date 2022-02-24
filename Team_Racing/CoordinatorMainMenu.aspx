<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CoordinatorMainMenu.aspx.cs" Inherits="Team_Racing.WebForm2" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<title>Coordinator Main Menu</title>
	<link rel="stylesheet" href="css/main.css">
	<script src="https://kit.fontawesome.com/a076d05399.js"></script>
</head>
<body>
<form runat="server">
	<div class="navbar">
		<div class="container">
			<a class="logo" href="~/CoordinatorMainMenu.aspx" runat="server">Celtic<span>University</span></a>
			<img id="mobile-cta" class="mobile-menu" src="images/menu.svg" alt="Open Navigation">

			<nav>
				<img id="mobile-exit" class="mobile-menu-exit" src="images/exit.svg" alt="Close Navigation">
				<!--x icon for user to close the navigation-->

				<ul class="primary-nav">
					<li><asp:HyperLink ID="uploadArticle" Text="View Student Articles" NavigateUrl ="~/CoordinatorMainMenu.aspx" runat="server"></asp:HyperLink></li>

				</ul>
				<ul class="secondary-nav">
					<li><asp:Label runat="server" ID="Labelusername" Text="123"></asp:Label></li>
					<li class="go-premium-cta"><asp:Button runat="server" ID="labelLogout" Text="Log Out" OnClick="buttonLogout_Click" OnClientClick="Confirm()"></asp:Button></li>
				</ul>
			</nav>
		</div>
	</div>

	<section class="Review-section">
			<div>
		<asp:DropDownList runat="server" AutoPostBack="true" ID="studentDropDownList" Width="250px" Height="45px" Font-Size="18px" >
		</asp:DropDownList>
	</div>
		<div class="container">
			<section class="image-picker">
				<table class="center">

					<tr>
					<td style="text-align:center; border:hidden;"> <asp:Image runat="server" ID="image1" style='width:100%; height:500px; border:none;' frameborder='0' /><asp:Button runat="server" ID="btn1" Text="View" style="text-align:center;background-color:transparent; color:black; font-family: 'Times New Roman', Times, serif" OnClick="btn1_Click"  /></td>
                    <td style="text-align:center; border:hidden;"> <asp:Image runat="server" ID="image2" style='width:100%; height:500px; border:none;' frameborder='0' /><asp:Button runat="server" ID="btn2" Text="View" style="text-align:center;background-color:transparent; color:black; font-family: 'Times New Roman', Times, serif" OnClick="btn2_Click"  /></td>
                    <td style="text-align:center; border:hidden;"> <asp:Image runat="server" ID="image3" style='width:100%; height:500px; border:none;' frameborder='0' /><asp:Button runat="server" ID="btn3" Text="View" style="text-align:center;background-color:transparent; color:black; font-family: 'Times New Roman', Times, serif" OnClick="btn3_Click"  /></td>
					</tr>
				</table>
			</section>
		</div>
	</section>
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

<!--Style for notification button, tried to put into css but doesnt work-->
<style>
	body {
		font-family: Arial, Helvetica, sans-serif;
	}

	.notification {
		background-color: rgb(59, 129, 255);
		color: white;
		text-decoration: none;
		padding: 15px 26px;
		position: relative;
		display: inline-block;
		border-radius: 2px;
	}

		.notification:hover {
			background: hsl(219, 100%, 50%);
		}

		.notification .notice {
			position: absolute;
			top: -10px;
			right: -10px;
			padding: 5px 10px;
			border-radius: 50%;
			background-color: rgb(250, 48, 48);
			color: white;
		}
</style>

<script>

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
</html>
