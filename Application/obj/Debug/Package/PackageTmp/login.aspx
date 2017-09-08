<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Application.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Vaccination</title>
    <meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />

    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    <script src="js/index.js"></script>
	<link href="bootstrap-3.3.6-dist/css/bootstrap.min.css" rel="stylesheet" />
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" ></script>
	<link rel="stylesheet" href="css/style.css" />   
    <style type="text/css">
        
        .auto-style1
        {
            height: 45px;
        }
    </style>
</head>

<body class="background">
<div class="login-page">
  <div class="form">
    <form class="login-form" id="form1" runat="server">
        <asp:Panel  id="panel1" runat="server">
            <%--<asp:TextBox id="Textname" runat="server" placeholder="username"/>
            <asp:TextBox id="Textpaswrd" runat="server" placeholder="password"/>
            <asp:Button CssClass="btn" id="button" runat="server" text="login" OnClick="button_Click"/>  
            <p class="message">Not registered? <a href="#">Create an account</a></p>--%>
            <asp:Login ID="Login1" runat="server" Width="265px" OnAuthenticate="Login1_Authenticate" FailureText="your login attempt was unsuccessful.">
                <LayoutTemplate>
                    <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                        <tr>
                            <td>
                                <table cellpadding="0" style="width:265px;">
                                    <tr>
                                        <td align="center" class="auto-style1" style="color:ghostwhite"><h2><b>VACCINATION</b></h2></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server" Width="250px" placeholder="user name"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="250px" placeholder="password"></asp:TextBox>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="color:Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login1" Style="background-color:#1abc9c; height: 52px;" Width="250px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:Login>
        </asp:Panel>            
    </form>
  </div>
</div>

</body>
</html>
