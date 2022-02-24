<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminLogin.aspx.cs" Inherits="Team_Racing.adminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<style>
	 .alert-label{
		 color:red;
		 font-size: 14px;
	 }
	</style>
    <title></title>
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
			<h1>Admin Login</h1>
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
				<div class="alert-label">
					<asp:Label ID="alertLabel" Text="" runat="server"></asp:Label>
				</div>
				</form>
			</div>
				</div>
</div>		
<!--header start here-->
</body>
</html>