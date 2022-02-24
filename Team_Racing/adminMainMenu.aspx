<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminMainMenu.aspx.cs" Inherits="Team_Racing.adminMainMenu" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>AdminMainMenu</title>
    <link rel="stylesheet" href="css/main.css">

</head>
<body>
    <form runat="server">
    <div class="navbar">
        <div class="container">
            <a class="logo" href="~/adminMainMenu.aspx" runat="server">Celtic<span>University</span></a>

            <img id="mobile-cta" class="mobile-menu" src="images/menu.svg" alt="Open Navigation">

            <nav>
                <img id="mobile-exit" class="mobile-menu-exit" src="images/exit.svg" alt="Close Navigation">

                <ul class="primary-nav">
                    <li><asp:HyperLink ID="registerUser" Text="Register User" NavigateUrl ="~/adminMainMenu.aspx" runat="server"></asp:HyperLink></li>
                    <li><asp:HyperLink ID="maintainSystemData" Text="Maintain System Data" NavigateUrl ="~/adminMaintainSystemData.aspx" runat="server"></asp:HyperLink></li>
                </ul>

                <ul class="secondary-nav">
                    <li><asp:Label runat="server" ID="Labelusername"></asp:Label></li>
                    <li class="go-premium-cta"><asp:Button runat="server" ID="buttonLogout" Text="Log Out" OnClick="buttonLogout_Click" OnClientClick="Confirm()" CausesValidation="false"></asp:Button></li>
                </ul>
                

            </nav>


        </div>
    </div>
    <section class="admin">
        <div class="container">
            <div class="content">
                <div>
                    <h2>Register Users</h2>

                    <form action="#">
                        <div class="user-details">
                            <span class="details">Full Name</span>
                            <asp:TextBox runat="server" ID="nameTextBox" placeholder="Enter the student/coordinator/manager name."></asp:TextBox>  
                            <asp:RequiredFieldValidator ID="nametextboxRequiredFieldValidator" 
                                                        runat="server" Font-Size="Medium" ForeColor="Red" Display="Dynamic" 
                                                        ControlToValidate="nameTextBox" ErrorMessage="Please enter the user's name."></asp:RequiredFieldValidator>
                        </div>
                        <div class="user-details">
                            <span class="details">Username</span>
                            <asp:TextBox runat="server" ID="usernameTextBox" placeholder="Enter the username."></asp:TextBox>
                            <asp:RequiredFieldValidator ID="usernameTextBoxRequiredFieldValidator" 
                                                        runat="server" Font-Size="Medium" ForeColor="Red" Display="Dynamic" 
                                                        ControlToValidate="usernameTextBox" ErrorMessage="Please enter the user's username."></asp:RequiredFieldValidator>
                        </div>
                        <div class="user-details">
                            <span class="details">Email</span>
                            <asp:TextBox runat="server" ID="emailTextBox" placeholder="Enter the email."></asp:TextBox>
                            <asp:RequiredFieldValidator ID="emailtextboxRequiredFieldValidator2" 
                                                        runat="server" Font-Size="Medium" ForeColor="Red" Display="Dynamic" 
                                                        ControlToValidate="emailTextBox" ErrorMessage="Please enter the user's email."></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="validateEmail"  runat="server" Font-Size="Medium" ForeColor="Red" Display="Dynamic"
                                                        ErrorMessage="Invalid email format." ControlToValidate="emailTextBox"  
                                                        ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />

                        </div>
                        <div class="user-details">
                            <span class="details">Phone Number</span>
                            <asp:TextBox runat="server" ID="phonenumberTextBox" placeholder="Enter the phone number."></asp:TextBox>
                            <asp:RequiredFieldValidator ID="phonenumbertextboxRequiredFieldValidator" 
                                                        runat="server" Font-Size="Medium" ForeColor="Red" Display="Dynamic" 
                                                        ControlToValidate="phonenumberTextBox" ErrorMessage="Please enter the user's phone number."></asp:RequiredFieldValidator>
                        </div>

                        <div class="user-details">
                            <span class="details">Roles</span>
                            <div class="roles-box">
                                <asp:DropDownList ID="rolesDropDownList" runat="server" style='width:165px; height:38px'>
                                    <asp:ListItem Selected="True" Value="Roles"> Roles </asp:ListItem>
                                    <asp:ListItem Value="Student"> Student </asp:ListItem>
                                    <asp:ListItem Value="Coordinator"> Marketing Coordinator </asp:ListItem>
                                    <asp:ListItem Value="Manager"> Marketing Manager </asp:ListItem>
                                </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="rolesdropdownlistRequiredFieldValidator" 
                                                         runat="server" Font-Size="Medium" ForeColor="Red" Display="Dynamic" 
                                                         ControlToValidate="rolesDropDownList" InitialValue="Roles" ErrorMessage="Please select a role." />
                        </div>

                             <div class="user-details">
                            <span class="details">Faculty</span>
                            <div class="faculty-box">
                                <asp:DropDownList ID="facultyDropDownList" runat="server" style='width:245px; height:38px'>
                                    <asp:ListItem Selected="True" Value="Faculty"> Faculty </asp:ListItem>
                                    <asp:ListItem Value="1"> Faculty of Engineering & Information Technology </asp:ListItem>
                                    <asp:ListItem Value="2"> Faculty of Business & Hospitality Management </asp:ListItem>
                                    <asp:ListItem Value="3"> Faculty of Early Childhood Care & Education </asp:ListItem>
                                    <asp:ListItem Value="4"> Faculty of Mass Communication Studies </asp:ListItem>
                                </asp:DropDownList>
                                 <asp:RequiredFieldValidator ID="facultydropdownlistRequiredFieldValidator" 
                                                             runat="server" Font-Size="Medium" ForeColor="Red" Display="Dynamic" 
                                                             ControlToValidate="facultyDropDownList" InitialValue="Faculty" ErrorMessage="Please select a faculty." />
                        </div>

                        </div>
                        <div class="user-details">
                            <span class="details">Password</span>
                            <asp:TextBox runat="server" ID="passwordTextBox" placeholder="Enter the password."></asp:TextBox>
                            <asp:RequiredFieldValidator ID="passwordtextboxRequiredFieldValidator" 
                                                        runat="server" Font-Size="Medium" ForeColor="Red" Display="Dynamic" 
                                                        ControlToValidate="passwordTextBox" ErrorMessage="Please enter the user's password."></asp:RequiredFieldValidator>
                        </div>

                        
                        <span class="Date-Of-Birth-title">Date of birth</span>
                        <asp:TextBox runat="server" ID="dateTextBox" placeholder="Enter the date of birth." TextMode="Date"></asp:TextBox>
                        
                            <div class="user-details">
                        <span class="details">Gender</span>
                        <div class="Gender-box">
                            <asp:DropDownList ID="genderDropDownList" runat="server" style='width:100px; height:38px'>
                            <asp:ListItem Selected="True" Value="Gender"> Gender </asp:ListItem>
                            <asp:ListItem Value="Male"> Male </asp:ListItem>
                            <asp:ListItem Value="Female"> Female </asp:ListItem>                         
                            </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="genderRequiredFieldValidator" 
                                                         runat="server" Font-Size="Medium" ForeColor="Red" Display="Dynamic" 
                                                         ControlToValidate="genderDropDownList" InitialValue="Gender" ErrorMessage="Please select gender." />
                        </div>

                         
                        <br/ >
                        <div class="button">
                            <asp:Button ID="registerButton" Text="Register" runat="server" OnClick="registerButton_Click" />
                            <asp:Button ID="resetButton" Text="Reset" runat="server" OnClick="resetButton_Click" CausesValidation="false" />
                        </div>
                </div>
                        </form>
            </div>

            



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

