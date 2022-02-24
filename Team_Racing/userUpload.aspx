<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userUpload.aspx.cs" Inherits="Team_Racing.userUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Upload Page</title>
    <link rel="stylesheet" href="css/main.css"/>
    <script src="https://kit.fontawesome.com/a076d05399.js"></script>
    <style>
        .checkboxes label {
    display: inline-block;
    white-space: nowrap;
    float:left;
    font-size:16px;
}

.checkboxes input {
    vertical-align:baseline;
    float:right;
}
    </style>
</head>
<body>
<form runat="server">
    <div class="navbar">
        <div class="container">
            <a class="logo" href="~/userUpload.aspx" runat="server">Celtic<span>University</span></a> <!--Logo in text format, can put images also if u guys want-->
            <!--href means the link that the user will be brought to if the user clicks on the logo-->

            <img id="mobile-cta" class="mobile-menu" src="images/menu.svg" alt="Open Navigation"/>
            <!--Hamburger icon to sum the "upload article, View others upload, username, and Logout"-->
            <!--Only Activates when its in mobile mode (since we need to use this website on other platform)-->

            <nav>
                <img id="mobile-exit" class="mobile-menu-exit" src="images/exit.svg" alt="Close Navigation"/>
                <!--x icon for user to close the navigation-->

                <ul class="primary-nav">
                    <li><asp:HyperLink ID="uploadArticle" Text="Upload Article" NavigateUrl ="~/userUpload.aspx" runat="server"></asp:HyperLink></li>
                    <li><asp:HyperLink ID="viewArticle" Text="View My Upload" NavigateUrl ="~/studentArticles.aspx" runat="server"></asp:HyperLink></li>
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
                <h2 id="dueDate" runat="server">Due Date of upload will be in x Hours</h2>

                    <br />
                    <!--Upload file-->
                    <label for="Upload file">Upload Article</label>
                    <asp:FileUpload runat="server" id="files" name="files" multiple accept=".doc,.docx,.pdf,application/msword,
                           application/vnd.openxmlformats-officedocument.wordprocessingml.document" /><br />
                    <div id="selectedFiles"></div><br /><br />

                    <label for="Upload image">Upload Image </label>
                    <asp:FileUpload runat="server" id="images" name="images" multiple accept=".png, .jpg, .jpeg" /><br />
                    <div id="selectedFiles1"></div><br /><br />

                    <!--Article title-->
                    <label for="Article" id="src_name">Article Name</label>
                    <asp:TextBox runat="server" id="ArticleID" name="Article-Title"></asp:TextBox><br/><br/>

                    <!--Checkbox list-->
                    <div class="checkboxes">
                        <label  for="TnC" >I agree and accept to the <a href="">Terms and Conditions</a><asp:CheckBox runat="server" id="TnC" /></label>
                    </div>
                    <asp:Label runat="server" ID="checkLabel" style="font-size:14px;"></asp:Label>

                    <!--Upload and back button-->
                    <asp:Button runat="server" class="Upload" Text="Upload" ID="upload" OnClick="upload_Click" />



            </div>
        </div>

    </section>
</form>

    <!--Script to display files uploaded-->
    <script>
        var selDiv = "";

        document.addEventListener("DOMContentLoaded", init, false);

        function init() {
            document.querySelector('#files').addEventListener('change', handleFileSelect, false);
            selDiv = document.querySelector("#selectedFiles");
        }

        function handleFileSelect(e) {

            if (!e.target.files) return;

            selDiv.innerHTML = "";

            var files = e.target.files;
            for (var i = 0; i < files.length; i++) {
                var f = files[i];

                selDiv.innerHTML += f.name + "<br/>";

            }

        }
    </script>

    <script>
        var selDiv1 = "";

        document.addEventListener("DOMContentLoaded", init1, false);

        function init1() {
            document.querySelector('#images').addEventListener('change', handleFileSelect1, false);
            selDiv1 = document.querySelector("#selectedFiles1");
        }

        function handleFileSelect1(e) {

            if (!e.target.files) return;

            selDiv1.innerHTML = "";

            var files = e.target.files;
            for (var i = 0; i < files.length; i++) {
                var f = files[i];

                selDiv1.innerHTML += f.name + "<br/>";

            }

        }
    </script>
    <!-- end of list of upload script-->

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

    </script>

</body>
</html>