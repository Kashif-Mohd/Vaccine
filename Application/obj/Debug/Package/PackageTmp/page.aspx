<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page.aspx.cs" Inherits="Application.page" EnableEventValidation="false" Culture="en-GB"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    <link href="bootstrap-3.3.6-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/style.css" />

    <style type="text/css">
        html {
            height: 100% !important;
        }

        body {
            margin: 0;
            min-height: 100% !important;
        }
    </style>
    <%--<style>
        body
        {
            background-image: url("vaccine.jpg");
            background-position: center;
            background-size:  cover;
            background-repeat:no-repeat; 
        }
    </style> --%>

    <script type="text/javascript">

        //Next Button
        function clicknext() {
            if (document.getElementById("txtdss").value == '') {
                alert("Enter DSSID !")
                document.getElementById("txtdss").focus();
                return false;
            }

            else if (document.getElementById("txtcard").value == 'VPT____/__') {
                alert("Enter Card No. !")
                document.getElementById("txtcard").focus();
                return false;
            }
        }
    </script>
</head>
<body style="background-color: #f6f6f6;">
    <form id="form1" runat="server" class="form-horizontal">
        <asp:ScriptManager ID="ScriptManger1" runat="Server"></asp:ScriptManager>
        <nav class="navbar navbar-default navbar-fixed-top">
            <div class="">
                <div class="navbar-header">
                    <asp:Label ID="Label1" class="navbar-brand" runat="server" Text="Label1.text" Style="text-transform: uppercase;"></asp:Label>
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                </div>
                <!--<a class="navbar-brand" href="#"></a>-->

                <div class="collapse navbar-collapse" id="myNavbar">
                    <ul class="nav navbar-nav navbar-right">
                        <%--<li><a href="Form.aspx">FORM ENTER</a></li>--%>        		
                        <li><a href="Search.aspx">SEARCH ID</a></li>
                        <li><a href="ExportData.aspx">EXPORT DATA</a></li>  
                        <li><a href="RegistrationForm.aspx">REGISTER</a></li>
                        <li><a href="login.aspx">LOG OUT</a></li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="jumbotron text-center" style="margin-top: 3%;">
            <h1>Mother And Child Vaccination Program</h1>
        </div>
        <div class="container-fluid bg-4 text-center" style="position: relative; margin-top: -25px;">
            <div style="margin: 5% auto; width: 20%;">
                <div class="form-group" style="margin: auto;">
                    <asp:TextBox ID="txtdss" runat="server" ClientIDMode="Static" placeholder="DSSID" class="form-control" Width="100%" MaxLength="13" Style="text-transform: uppercase;" />
                    <asp:RequiredFieldValidator ID="Required1" runat="server" class="align" ControlToValidate="txtdss" ErrorMessage="*Required field is empty" Font-Size="Smaller" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegEx2" runat="server" ControlToValidate="txtdss" ValidationExpression="^[a-zA-Z0-9\s]+$" ErrorMessage="Invalid input" Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="txtcard" runat="server" ClientIDMode="Static" placeholder="card no" class="form-control" Width="100%" MaxLength="10"></asp:TextBox>
                    <cc1:MaskedEditExtender ID="CardMask" runat="server" TargetControlID="txtcard" Mask="VPT9999/99" MaskType="Number" ClearMaskOnLostFocus="false" />
                    <%--<asp:RequiredFieldValidator ID="Required2" runat="server" class="align" ControlToValidate="txtdss" ErrorMessage="*Required field is empty" Font-Size="Smaller" ForeColor="Red" ></asp:RequiredFieldValidator> <br />--%>
                    <%--<asp:RegularExpressionValidator ID="RegEx1" runat="server" ControlToValidate="txtcard" ValidationExpression="^[0-9]+$" ErrorMessage="Invalid input" Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                </div>
                <br />
                <asp:Button ID="submitbtn" CssClass="btn" Style="padding: 10px;" runat="server" Text="Submit" OnClick="submitbtn_Click" Width="100%" OnClientClick="return clicknext();" />
            </div>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-2.1.3.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/js/bootstrap.min.js"></script>

</body>
</html>
