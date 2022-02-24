<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminMaintainSystemData.aspx.cs" Inherits="Team_Racing.adminMaintainSystemData" %>

<!DOCTYPE html>
<html>
<head>

    <meta charset="utf-8" />
    <title>MaintainSystemData</title>
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
                    <li><asp:Label runat="server" ID="Labelusername" Text="123"></asp:Label></li>
                    <li class="go-premium-cta"><asp:Button runat="server" ID="buttonLogout" Text="Log Out" OnClick="buttonLogout_Click" OnClientClick="Confirm()" CausesValidation="false"></asp:Button></li>
                </ul>


            </nav>
        </div>
    </div>

    <section class="MaintainSystemData-section">
        <div class="container">
            <div>
                <form action="#">
              
                    <fieldset>
                        <legend style="font-size:32px">Maintain First Due Date:</legend>
                        <label for="Due Date">Current Due Date:</label>
                        <br />
                        <asp:Textbox runat="server" ID="currentDueDateTextBox" TextMode="DateTime" Enabled="false" ></asp:Textbox>
                        <label for="Due Date">Due Date:</label>
                        <br />
                        <asp:TextBox runat="server" ID="duedatedateTextBox"  TextMode="Date" ValidateRequestMode="Enabled" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="duedatedateTextBoxRequiredFieldValidator" 
                                                        runat="server" Font-Size="Medium" ForeColor="Red" Display="Dynamic" 
                                                        ControlToValidate="duedatedateTextBox" ErrorMessage="Please choose a date."></asp:RequiredFieldValidator>
                        <br />
                        <label for="Due Date Time">Due Date Time:</label>
                        <br />
                        <asp:TextBox runat="server" ID="duedatetimeTextBox1"  TextMode="Time" ValidateRequestMode="Enabled" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="duedatetimeTextBox1RequiredFieldValidator" 
                                                        runat="server" Font-Size="Medium" ForeColor="Red" Display="Dynamic" 
                                                        ControlToValidate="duedatetimeTextBox1" ErrorMessage="Please choose a time."></asp:RequiredFieldValidator>
                        <br />


                    </fieldset>

                        <br />
                        <br />

                    <fieldset>
                        <legend style="font-size:32px">Maintain Closure Due Date:</legend>
                        <label for="Due Date">Current Closure Due Date:</label>
                        <br />
                        <asp:Textbox runat="server" ID="currentclosureduedateTextbox" TextMode="DateTime" Enabled="false" ></asp:Textbox>
                        <label for="Due Date">Closure Due Date:</label>
                        <br />
                        <asp:TextBox runat="server" ID="closureduedatedateTextBox"  TextMode="Date" ValidateRequestMode="Enabled" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="closureduedatedateTextBoxRequiredFieldValidator" 
                                                        runat="server" Font-Size="Medium" ForeColor="Red" Display="Dynamic" 
                                                        ControlToValidate="closureduedatedateTextBox" ErrorMessage="Please choose a date."></asp:RequiredFieldValidator>
                        <br />
                        <label for="Due Date Time">Closure Due Date Time:</label>
                        <br />
                        <asp:TextBox runat="server" ID="closuredatetimeTextBox"  TextMode="Time" ValidateRequestMode="Enabled" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="closuredatetimeTextBoxRequiredFieldValidator" 
                                                        runat="server" Font-Size="Medium" ForeColor="Red" Display="Dynamic" 
                                                        ControlToValidate="closuredatetimeTextBox" ErrorMessage="Please choose a time."></asp:RequiredFieldValidator>
                        <br />
                    </fieldset>

                    <div class="button">
                        <br />
                        <asp:Button ID="saveButton" Text="Save" runat="server" OnClick="saveButton_Click"  />
                        <asp:Button ID="resetButton" Text="Reset" runat="server" OnClick="resetButton_Click"  />
                    </div>

                    

                </form>



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
