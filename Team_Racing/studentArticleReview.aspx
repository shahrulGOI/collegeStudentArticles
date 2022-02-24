<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentArticleReview.aspx.cs" Inherits="Team_Racing.studentArticleReview" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<title>Review Upload</title>
	<link rel="stylesheet" href="css/main.css">
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
					<li class="current"><asp:HyperLink ID="viewArticle" Text="View My Article" NavigateUrl ="~/studentArticles.aspx" runat="server"></asp:HyperLink></li>
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
				<h2>&nbsp;</h2>


					<label for="Article">Article Uploaded</label>
					<iframe runat="server" id="iframe1"></iframe>

					<label for="View Upload">Comment</label>
					<asp:TextBox ID="readcommentTextBox" TextMode="MultiLine" runat="server" Rows="5" Columns="150" Height="150px" Enabled="False" ReadOnly="True"></asp:TextBox>
          
					<label for="View Upload">Your comment</label>
					<asp:TextBox ID="commentTextBox" runat="server" Rows="5" Columns="150" Height="150px"></asp:TextBox>

					<asp:Button ID="sendcommentButton" CssClass="Upload" runat="server" Text="Send" OnClick="sendcommentButton_Click"></asp:Button>
					<!--i put it as href so that user will be brought to start new upload page-->
			</div>
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
