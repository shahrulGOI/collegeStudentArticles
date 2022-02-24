<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TeamRacing.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<style>
	 .button {
    float: right;
    padding-top: 10px;
	}
	 .alert-label{
		 color:red;
		 font-size: 14px;
	 }
	</style>
    <title>Celtic University Magazine</title>
    <link href="css/loginStyle.css" rel="stylesheet" type="text/css" media="all"/>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1"/>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /> 
	<meta name="keywords" content="Square login form web template, Sign up Web Templates, Flat Web Templates, Login signup Responsive web template, Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, Sony Ericsson, Motorola web design" />
	<link href='//fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800' rel='stylesheet' type='text/css'/>
</head>
<body>
	<div class="login-form">
		<div class="top-login">
			<span></span>
		</div>
		<div class="login-image">
			<h1>Login</h1>
			<div class="login-top">
				<form runat="server">
					<div class="login-ic" runat="server">
						<i ></i>
						<asp:TextBox runat="server" ID="textUsername"  Value="User name" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'User name';}"></asp:TextBox>
						<div class="clear"> </div>
					</div>
					<div class="login-ic">
						<i class="icon"></i>
						<asp:TextBox runat="server" ID="textPassword" type="password"  value="Password" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'password';}" ></asp:TextBox>
						<div class="clear"> </div>
					</div>
			
					<div class="log-bwn">
						<asp:Button runat="server" id="buttonSignIn" type="submit"  value="Sign In" Text="Log In" OnClick="buttonSignIn_Click" />
					</div>
					<div class="button">
						<asp:LinkButton runat="server" ID="adminButton" Text="Admin Login" type="submit" OnClick="adminButton_Click"></asp:LinkButton>
					</div>
					<div class="guest">
						<li><asp:HyperLink ID="guestmain" Text="Login as Guest" NavigateUrl ="~/GuestMainMenu.aspx" runat="server"></asp:HyperLink></li>
					</div>
					<div class="alert-label">
						<asp:Label ID="alertLabel" Text="" runat="server"></asp:Label>
					</div>
				</form>
			</div>
		</div>
	</div>		
</body>
</html>

