<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Form.aspx.cs" Inherits="Application.Form" Culture="en-GB" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Form</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    <link href="bootstrap-3.3.6-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="bootstrap-3.3.6-dist/js/bootstrap.min.js"> </script>
    <link rel="stylesheet" href="css/style.css" />
    <script type="text/javascript">



        function DaysInMonth(Y, M) {
            with (new Date(Y, M, 1, 12)) {
                setDate(0);
                return getDate();
            }
        }
        function datediff(date1, date2) {
            var y1 = date1.getFullYear(), m1 = date1.getMonth(), d1 = date1.getDate(),
            y2 = date2.getFullYear(), m2 = date2.getMonth(), d2 = date2.getDate();
            if (d1 < d2) {
                m1--;
                //d1 += d2;   
                d1 += DaysInMonth(y2, m2);
            }
            if (m1 < m2) {
                y1--;
                m1 += 12;
            }
            return [y1 - y2, m1 - m2, d1 - d2];
        }
        function CalculateAge() {

            if (document.getElementById("TextDOB").value != "") {
                var dob = document.getElementById("TextDOB").value;
                var birthYear = parseInt(dob.substring(6, 10));
                var birthMonth = parseInt(dob.substring(3, 5));
                var birthDay = parseInt(dob.substring(0, 2));
                var year;

                var dov = document.getElementById("TxtDOV").value;
                var visitYear = parseInt(dov.substring(6, 10));
                var visitMonth = parseInt(dov.substring(3, 5));
                var visitDay = parseInt(dov.substring(0, 2));
                var year;

                birthDate = new Date(birthYear, birthMonth - 1, birthDay);
                visitDate = new Date(visitYear, visitMonth - 1, visitDay);

                var dife = datediff(visitDate, birthDate);
                var monleft = (dife[0] * 12) + dife[1];

                document.getElementById("AgeMonths").value = monleft;
                document.getElementById("AgeDays").value = dife[2];
                //document.getElementById("AgeMonths").value = dife[0] + " years, " + dife[1] + " months, and " + dife[2] + " days"; 
            }
        }


        function OnlyNumeric(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /[0-9]/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }




    </script>
</head>
<body style="background-color: #f6f6f6;">
    <form class="form-inline" id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManger1" runat="Server"></asp:ScriptManager>



        <nav class="navbar navbar-default">
            <div class="">
                <div class="navbar-header">
                    <asp:Label ID="Label1" class="navbar-brand" runat="server" Text="Label1.text" Style="text-transform: uppercase; border-right: groove; border-color: lightgray;"></asp:Label>
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                </div>

                <div class="collapse navbar-collapse" id="myNavbar">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="page.aspx">HOME</a></li>
                        <%--<li><a href="UpdateForm.aspx">FORM UPDATE</a></li>--%>
                        <li><a href="RegistrationForm.aspx">REGISTER</a></li>
                        <li><a href="login.aspx" class="nav navbar-nav navbar-right">LOG OUT</a></li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="container-fluid bg-4 text-center">
            <h2 class="margin">Temporary Logging of Daily Vaccines Administration</h2>
            <div class="row" style="margin: auto; width: 100%;">
                <div class="col-sm-3 margin text-left" style="top: 0px; left: 0px; margin-top: 20px; border-right-style: groove; border-right-color: inherit; border-right-width: medium;">
                    <%--  <h4 class="margin text-center">Child's Data</h4>--%>
                    <asp:Panel ID="Panel1" runat="server">
                        <label style="font-size: small">Date of Visit</label><asp:TextBox ID="TxtDOV" runat="server" class="form-control align" placeholder="dd/MM/yyyy" ClientIDMode="Static"></asp:TextBox><br />
                        <cc1:MaskedEditExtender runat="server" TargetControlID="TxtDOV" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" class="align" ControlToValidate="TxtDOV" ErrorMessage="*Required field is empty" Font-Size="Smaller" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareDOV" runat="server" ControlToValidate="TxtDOV" Operator="LessThanEqual" Type="Date" ErrorMessage="*Invalid Date" Font-Size="Smaller" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$" ErrorMessage="*Invalid Date" Font-Size="Smaller" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>--%>
                    </asp:Panel>
                    <br />
                    <br />

                    <asp:Panel ID="Panel2" runat="server">
                        <label style="font-size: small">Card No.</label><asp:TextBox ID="TextCardno" runat="server" class="form-control align"></asp:TextBox><br />
                        <cc1:MaskedEditExtender ID="CardMask" runat="server" TargetControlID="TextCardno" Mask="VPT9999/99" MaskType="Number" ClearMaskOnLostFocus="false" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" class="align" ControlToValidate="TextCardno" ErrorMessage="*Required field is empty" Font-Size="Smaller" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </asp:Panel>
                    <br />
                    <br />
                    <asp:Panel ID="Panel11" runat="server">
                        <label style="font-size: small">QR Code</label><asp:TextBox ID="txtQRcode" runat="server" placeholder="14 digit code" onkeypress="return OnlyNumeric(event)" class="form-control align" MaxLength="14"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" class="align" ControlToValidate="txtQRcode" ErrorMessage="*Required field is empty" Font-Size="Smaller" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="rexNumber" class="align" ControlToValidate="txtQRcode" ValidationExpression="^[0-9]{14}$" ErrorMessage="*Please enter 14 digit code!" ForeColor="Red" Display="Dynamic" />
                    </asp:Panel>
                    <br />
                    <br />

                    <asp:Panel ID="Panel3" runat="server">
                        <label style="font-size: small">DSS ID</label><asp:TextBox ID="TextDSSID" runat="server" class="form-control align" Style="text-transform: uppercase;" MaxLength="15"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" class="align" ControlToValidate="TextDSSID" ErrorMessage="*Required field is empty" Font-Size="Smaller" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </asp:Panel>
                    <br />
                    <br />

                    <asp:Panel ID="Panel4" runat="server">
                        <label style="font-size: small">Child Name</label><asp:TextBox ID="TextName" runat="server" class="form-control align" ClientIDMode="Static" Style="text-transform: uppercase;"></asp:TextBox><br />
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" class="align" ControlToValidate="TextName" ErrorMessage="*Required field is empty" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextName" ValidationExpression="^[a-zA-Z\s\.]+$" ErrorMessage="*Invalid characters." Font-Size="Smaller" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </asp:Panel>
                    <br />
                    <br />

                    <asp:Panel ID="Panel5" runat="server">
                        <label style="font-size: small">MotherName</label><asp:TextBox ID="TextMname" runat="server" onblur="disable()" class="form-control align" Style="text-transform: uppercase;"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" class="align" ControlToValidate="TextMname" ErrorMessage="*Required field is empty" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextMname" ValidationExpression="[a-zA-Z\s\.]+$" ErrorMessage="*Invalid characters." Font-Size="Smaller" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </asp:Panel>
                    <br />
                    <br />

                    <asp:Panel ID="Panel6" runat="server">
                        <label style="font-size: small">FatherName</label><asp:TextBox ID="TextFname" runat="server" class="form-control align" placeholder="Father/Husband Name" Style="text-transform: uppercase;"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" class="align" ControlToValidate="TextFname" ErrorMessage="*Required field is empty" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextFname" ValidationExpression="[a-zA-Z\s\.]+$" ErrorMessage="*Invalid characters." Font-Size="Smaller" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </asp:Panel>
                    <br />
                    <br />

                    <asp:Panel ID="Panel7" runat="server" ClientIDMode="Static">
                        <label style="font-size: small">Date of Birth</label><asp:TextBox ID="TextDOB" runat="server" ClientIDMode="Static" onblur="CalculateAge(); disableage()" class="form-control align" placeholder="dd/MM/yyyy"></asp:TextBox><br />
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="TextDOB" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
                        <asp:CompareValidator ID="CompareDOB" runat="server" ControlToCompare="TxtDOV" ControlToValidate="TextDOB" Type="Date" Operator="LessThanEqual" ErrorMessage="Incorrect Date" Font-Size="Smaller" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                    </asp:Panel>
                    <br />
                    <br />

                    <asp:Panel ID="Panel8" runat="server" ClientIDMode="Static">
                        <label style="font-size: small">Child Age</label>
                        <asp:TextBox ID="AgeDays" runat="server" class="form-control" Style="float: right" onkeydown="hide()" size="6" placeholder="(days)" ClientIDMode="Static" MaxLength="2"></asp:TextBox>
                        <asp:TextBox ID="AgeMonths" runat="server" class="form-control" Style="float: right" placeholder="(months)" size="6" ClientIDMode="Static" MaxLength="2"></asp:TextBox>
                    </asp:Panel>
                    <br />
                    <br />

                    <asp:Panel ID="Panel9" runat="server" ClientIDMode="Static">
                        <label style="font-size: small">Mother Age</label><asp:TextBox ID="TextMAge" runat="server" class="form-control align" onkeypress="return OnlyNumeric(event)" MaxLength="2" ClientIDMode="Static" placeholder="(in years)"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegEx" runat="server" ControlToValidate="TextMAge" ValidationExpression="^[0-9]+$" ErrorMessage="Invalid input" Font-Size="Smaller" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </asp:Panel>
                    <br />
                    <br />

                    <asp:Panel ID="Panel10" runat="server">
                        <label style="font-size: small">Gender</label>
                        <asp:RadioButtonList ID="radioList" runat="server" class="align">
                            <asp:ListItem Text="Male" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </asp:Panel>
                    <br />

                    <%--<asp:Button id="Btnshow" runat="server" Text="Show" CssClass="btn" OnClick="Btnshow_Click" />--%>
                </div>

                <div runat="server" class="col-sm-7">

                    <div id="child" runat="server">
                        <h3 class="margin"><u>Child Vaccines</u></h3>

                        <div id="birth" class="col-sm-2" style="border-right: groove; border-color: lightgray;" runat="server">
                            <h4 class="margin"><strong>At Birth</strong></h4>
                            <br />
                            <label style="font-size: small">Date of Visit</label><asp:TextBox ID="txtDateV1" runat="server" class="form-control align" placeholder="dd/MM/yyyy" ClientIDMode="Static" Width="100px"></asp:TextBox><br />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtDateV1" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
                            <br />
                            <br />
                            <asp:CheckBox runat="server" ID="CheckBCG" ClientIDMode="Static" class="tab" onclick="EnableG1(this)" /><label>BCG</label><br />
                            <asp:CheckBox runat="server" ID="CheckOPV0" ClientIDMode="Static" class="tab" onclick="EnableG1(this)" /><label>OPV0</label>
                        </div>

                        <div id="week6" class="col-sm-2" style="border-right: groove; border-color: lightgray;" runat="server">
                            <h4 class="margin"><strong>6 Weeks</strong></h4>
                            <br />
                            <label style="font-size: small">Date of Visit</label><asp:TextBox ID="txtDateV2" runat="server" class="form-control align" placeholder="dd/MM/yyyy" ClientIDMode="Static" Width="100px"></asp:TextBox><br />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtDateV2" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
                            <br />
                            <br />
                            <asp:CheckBox runat="server" onclick="EnableG2(this)" ID="CheckOPV1" class="tab" /><label>OPV1</label><br />
                            <asp:CheckBox runat="server" onclick="EnableG2(this)" ID="CheckPenta1" class="tab" /><label>Penta1</label><br />
                            <asp:CheckBox runat="server" onclick="EnableG2(this)" ID="CheckPCV1" class="tab" /><label>PCV1</label><br />
                            <asp:CheckBox runat="server" onclick="EnableG2(this)" ID="CheckRota1" class="tab" /><label>Rota1</label><br />
                        </div>

                        <div id="week10" class="col-sm-2" style="border-right: groove; border-color: lightgray;" runat="server">
                            <h4 class="margin"><strong>10 Weeks</strong></h4>
                            <br />
                            <label style="font-size: small">Date of Visit</label><asp:TextBox ID="txtDateV3" runat="server" class="form-control align" placeholder="dd/MM/yyyy" ClientIDMode="Static" Width="100px"></asp:TextBox><br />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtDateV3" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
                            <br />
                            <br />
                            <asp:CheckBox runat="server" onclick="EnableG3(this)" ID="CheckOPV2" class="tab" /><label>OPV2</label><br />
                            <asp:CheckBox runat="server" onclick="EnableG3(this)" ID="CheckPenta2" class="tab" /><label>Penta2</label>
                            <asp:CheckBox runat="server" onclick="EnableG3(this)" ID="CheckPCV2" class="tab" /><label>PCV2</label><br />
                            <asp:CheckBox runat="server" onclick="EnableG3(this)" ID="CheckRota2" class="tab" /><label>Rota2</label><br />
                        </div>

                        <div id="week14" class="col-sm-2" style="border-right: groove; border-color: lightgray;" runat="server">
                            <h4 class="margin"><strong>14 Weeks</strong></h4>
                            <br />
                            <label style="font-size: small">Date of Visit</label><asp:TextBox ID="txtDateV4" runat="server" class="form-control align" placeholder="dd/MM/yyyy" ClientIDMode="Static" Width="100px"></asp:TextBox><br />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDateV4" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
                            <br />
                            <br />
                            <asp:CheckBox runat="server" onclick="EnableG4(this)" ID="CheckOPV3" class="tab" /><label>OPV3 </label>
                            <br />
                            <asp:CheckBox runat="server" onclick="EnableG4(this)" ID="CheckPenta3" class="tab" /><label>Penta3</label><br />
                            <asp:CheckBox runat="server" onclick="EnableG4(this)" ID="CheckPCV3" class="tab" /><label>PCV3</label><br />
                            <asp:CheckBox runat="server" onclick="EnableG4(this)" ID="CheckIPV3" class="tab" /><label>IPV3</label><br />
                        </div>

                        <div id="months9" class="col-sm-2" style="border-right: groove; border-color: lightgray;" runat="server">
                            <h4 class="margin"><strong>9 Months</strong></h4>
                            <br />
                            <label style="font-size: small">Date of Visit</label><asp:TextBox ID="txtDateV5" runat="server" class="form-control align" placeholder="dd/MM/yyyy" ClientIDMode="Static" Width="100px"></asp:TextBox><br />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtDateV5" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
                            <br />
                            <br />
                            <asp:CheckBox runat="server" onclick="EnableG5(this)" ID="CheckMeasles1" class="tab" /><label>Measles1</label>
                            <br />
                            <br /><label style="font-size: small"><b>Between 9 to 15 months </b></label>
                            <asp:TextBox ID="txtDateV7" runat="server" class="form-control align" placeholder="dd/MM/yyyy" ClientIDMode="Static" Width="100px"></asp:TextBox><br />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender13" runat="server" TargetControlID="txtDateV7" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
                            <br />
                            <br />
                            <asp:CheckBox runat="server" onclick="EnableG7(this)" ID="CheckTCV" class="tab" /><label>TCV</label>
                        </div>

                        <div id="months15" class="col-sm-2" style="border-right: groove; border-color: lightgray;" runat="server">
                            <h4 class="margin"><strong>15 Months</strong></h4>
                            <br />
                            <label style="font-size: small">Date of Visit</label><asp:TextBox ID="txtDateV6" runat="server" class="form-control align" placeholder="dd/MM/yyyy" ClientIDMode="Static" Width="100px"></asp:TextBox><br />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txtDateV6" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
                            <br />
                            <br />
                            <asp:CheckBox runat="server" onclick="EnableG6(this)" ID="CheckMeasles2" class="tab" /><label>Measles2</label>
                        </div>

                    </div>


                    <div id="mother" runat="server" style="margin-top: 350px;">
                        <h3 style="margin-bottom: 30px;"><u>Mother Vaccines</u></h3>
                        <div class="col-sm-2" style="border-right: groove; border-color: lightgray;">
                            <label style="font-size: small">Date of Visit</label><asp:TextBox ID="txtDateMV1" runat="server" class="form-control align" placeholder="dd/MM/yyyy" ClientIDMode="Static" Width="100px"></asp:TextBox><br />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txtDateMV1" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
                            <br />
                            <br />
                            <asp:CheckBox runat="server" ID="CheckTT1" onclick="EnableMG1(this)" class="tab" /><label>TT1</label>
                        </div>
                        <div class="col-sm-2" style="border-right: groove; border-color: lightgray;">
                            <label style="font-size: small">Date of Visit</label><asp:TextBox ID="txtDateMV2" runat="server" class="form-control align" placeholder="dd/MM/yyyy" ClientIDMode="Static" Width="100px"></asp:TextBox><br />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="txtDateMV2" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
                            <br />
                            <br />
                            <asp:CheckBox runat="server" ID="CheckTT2" onclick="EnableMG2(this)" class="tab" /><label>TT2</label>
                        </div>
                        <div class="col-sm-2" style="border-right: groove; border-color: lightgray;">
                            <label style="font-size: small">Date of Visit</label><asp:TextBox ID="txtDateMV3" runat="server" class="form-control align" placeholder="dd/MM/yyyy" ClientIDMode="Static" Width="100px"></asp:TextBox><br />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="txtDateMV3" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
                            <br />
                            <br />
                            <asp:CheckBox runat="server" ID="CheckTT3" onclick="EnableMG3(this)" class="tab" /><label>TT3</label>
                        </div>
                        <div class="col-sm-2" style="border-right: groove; border-color: lightgray;">
                            <label style="font-size: small">Date of Visit</label><asp:TextBox ID="txtDateMV4" runat="server" class="form-control align" placeholder="dd/MM/yyyy" ClientIDMode="Static" Width="100px"></asp:TextBox><br />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender11" runat="server" TargetControlID="txtDateMV4" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
                            <br />
                            <br />
                            <asp:CheckBox runat="server" ID="CheckTT4" onclick="EnableMG4(this)" class="tab" /><label>TT4</label>
                        </div>
                        <div class="col-sm-2" style="border-color: lightgray;">
                            <label style="font-size: small">Date of Visit</label><asp:TextBox ID="txtDateMV5" runat="server" class="form-control align" placeholder="dd/MM/yyyy" ClientIDMode="Static" Width="100px"></asp:TextBox><br />
                            <cc1:MaskedEditExtender ID="MaskedEditExtender12" runat="server" TargetControlID="txtDateMV5" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
                            <br />
                            <br />
                            <asp:CheckBox runat="server" ID="CheckTT5" onclick="EnableMG5(this)" class="tab" /><label>TT5</label>
                        </div>
                    </div>

                </div>

                <div id="remarks" class="col-sm-2" runat="server" style="margin-top: 70px; ma">
                    <h4 class="margin"><strong>Remarks</strong></h4>
                    <textarea id="txtremarks" runat="server"></textarea>
                    <%--<asp:TextBox ID="txtremarks" runat="server" class="form-control" size="15"></asp:TextBox>--%>
                </div>
                <br />
                <asp:Button ID="Btnsbmt" runat="server" Text="Submit" OnClick="Button1_Click" CssClass="btn" Style="width: 20%; margin-top: 40px;" />
            </div>
        </div>



    </form>

    <script type="text/javascript">


        window.onload = function () {
            var G1Vacc1 = document.getElementById('<%= CheckBCG.ClientID %>');
            var G1Vacc2 = document.getElementById('<%= CheckOPV0.ClientID %>');

            var G2Vacc1 = document.getElementById('<%= CheckOPV1.ClientID %>');
            var G2Vacc2 = document.getElementById('<%= CheckPenta1.ClientID %>');
            var G2Vacc3 = document.getElementById('<%= CheckPCV1.ClientID %>');
            var G2Vacc4 = document.getElementById('<%= CheckRota1.ClientID %>');

            var G3Vacc1 = document.getElementById('<%= CheckOPV2.ClientID %>');
            var G3Vacc2 = document.getElementById('<%= CheckPenta2.ClientID %>');
            var G3Vacc3 = document.getElementById('<%= CheckPCV2.ClientID %>');
            var G3Vacc4 = document.getElementById('<%= CheckRota2.ClientID %>');

            var G4Vacc1 = document.getElementById('<%= CheckOPV3.ClientID %>')
            var G4Vacc2 = document.getElementById('<%= CheckPenta3.ClientID %>')
            var G4Vacc3 = document.getElementById('<%= CheckPCV3.ClientID %>')
            var G4Vacc4 = document.getElementById('<%= CheckIPV3.ClientID %>')

            var G5Vacc1 = document.getElementById('<%= CheckMeasles1.ClientID %>')

            var G6Vacc1 = document.getElementById('<%= CheckMeasles2.ClientID %>')

            var G7Vacc1 = document.getElementById('<%= CheckTCV.ClientID %>')


            var MVaccG1 = document.getElementById('<%= CheckTT1.ClientID %>');
            var MVaccG2 = document.getElementById('<%= CheckTT2.ClientID %>');
            var MVaccG3 = document.getElementById('<%= CheckTT3.ClientID %>');
            var MVaccG4 = document.getElementById('<%= CheckTT4.ClientID %>');
            var MVaccG5 = document.getElementById('<%= CheckTT5.ClientID %>');


            //Child:
            if (!G1Vacc1.checked && !G1Vacc2.checked) {
                document.getElementById('<%= txtDateV1.ClientID %>').readOnly = true;
            }
            if (!G2Vacc1.checked && !G2Vacc2.checked && !G2Vacc3.checked && !G2Vacc4.checked) {
                document.getElementById('<%= txtDateV2.ClientID %>').readOnly = true;
            }
            if (!G3Vacc1.checked && !G3Vacc2.checked && !G3Vacc3.checked && !G3Vacc4.checked) {
                document.getElementById('<%= txtDateV3.ClientID %>').readOnly = true;
            }
            if (!G4Vacc1.checked && !G4Vacc2.checked && !G4Vacc3.checked && !G4Vacc4.checked) {
                document.getElementById('<%= txtDateV4.ClientID %>').readOnly = true;
            }
            if (!G5Vacc1.checked) {
                document.getElementById('<%= txtDateV5.ClientID %>').readOnly = true;
            }
            if (!G6Vacc1.checked) {
                document.getElementById('<%= txtDateV6.ClientID %>').readOnly = true;
            }
            if (!G7Vacc1.checked) {
                document.getElementById('<%= txtDateV7.ClientID %>').readOnly = true;
            }


            //Mother:
            if (!MVaccG1.checked) {
                document.getElementById('<%= txtDateMV1.ClientID %>').readOnly = true;
            }
            if (!MVaccG2.checked) {
                document.getElementById('<%= txtDateMV2.ClientID %>').readOnly = true;
            }
            if (!MVaccG3.checked) {
                document.getElementById('<%= txtDateMV3.ClientID %>').readOnly = true;
            }
            if (!MVaccG4.checked) {
                document.getElementById('<%= txtDateMV4.ClientID %>').readOnly = true;
            }
            if (!MVaccG5.checked) {
                document.getElementById('<%= txtDateMV5.ClientID %>').readOnly = true;
            }

        }




        //Hide Child (Date of Visit):

        function EnableG1(checkBox) {
            var G1Vacc1 = document.getElementById('<%= CheckBCG.ClientID %>');
            var G1Vacc2 = document.getElementById('<%= CheckOPV0.ClientID %>');


            if (checkBox.checked) {
                document.getElementById('<%= txtDateV1.ClientID %>').removeAttribute('readonly');
            }
            else if (!G1Vacc1.checked && !G1Vacc2.checked) {
                document.getElementById('<%= txtDateV1.ClientID %>').readOnly = true;
                 document.getElementById('<%= txtDateV1.ClientID %>').value = '';
             }
     }


     function EnableG2(checkBox) {
         var G2Vacc1 = document.getElementById('<%= CheckOPV1.ClientID %>');
        var G2Vacc2 = document.getElementById('<%= CheckPenta1.ClientID %>');
        var G2Vacc3 = document.getElementById('<%= CheckPCV1.ClientID %>');
        var G2Vacc4 = document.getElementById('<%= CheckRota1.ClientID %>');


        if (checkBox.checked) {
            document.getElementById('<%= txtDateV2.ClientID %>').removeAttribute('readonly');
        }
        else if (!G2Vacc1.checked && !G2Vacc2.checked && !G2Vacc3.checked && !G2Vacc4.checked) {
            document.getElementById('<%= txtDateV2.ClientID %>').readOnly = true;
             document.getElementById('<%= txtDateV2.ClientID %>').value = '';
         }
 }


 function EnableG3(checkBox) {
     var G3Vacc1 = document.getElementById('<%= CheckOPV2.ClientID %>');
     var G3Vacc2 = document.getElementById('<%= CheckPenta2.ClientID %>');
     var G3Vacc3 = document.getElementById('<%= CheckPCV2.ClientID %>');
     var G3Vacc4 = document.getElementById('<%= CheckRota2.ClientID %>');


     if (checkBox.checked) {
         document.getElementById('<%= txtDateV3.ClientID %>').removeAttribute('readonly');
    }
    else if (!G3Vacc1.checked && !G3Vacc2.checked && !G3Vacc3.checked && !G3Vacc4.checked) {
        document.getElementById('<%= txtDateV3.ClientID %>').readOnly = true;
        document.getElementById('<%= txtDateV3.ClientID %>').value = '';
    }
}


function EnableG4(checkBox) {
    var G4Vacc1 = document.getElementById('<%= CheckOPV3.ClientID %>')
    var G4Vacc2 = document.getElementById('<%= CheckPenta3.ClientID %>')
    var G4Vacc3 = document.getElementById('<%= CheckPCV3.ClientID %>')
    var G4Vacc4 = document.getElementById('<%= CheckIPV3.ClientID %>')


    if (checkBox.checked) {
        document.getElementById('<%= txtDateV4.ClientID %>').removeAttribute('readonly');
    }
    else if (!G4Vacc1.checked && !G4Vacc2.checked && !G4Vacc3.checked && !G4Vacc4.checked) {
        document.getElementById('<%= txtDateV4.ClientID %>').readOnly = true;
        document.getElementById('<%= txtDateV4.ClientID %>').value = '';
    }
}

function EnableG5(checkBox) {
    var G5Vacc1 = document.getElementById('<%= CheckMeasles1.ClientID %>')

    if (checkBox.checked) {
        document.getElementById('<%= txtDateV5.ClientID %>').removeAttribute('readonly');
    }
    else if (!G5Vacc1.checked) {
        document.getElementById('<%= txtDateV5.ClientID %>').readOnly = true;
        document.getElementById('<%= txtDateV5.ClientID %>').value = '';
    }
}

function EnableG6(checkBox) {
    var G6Vacc1 = document.getElementById('<%= CheckMeasles2.ClientID %>')
    if (checkBox.checked) {
        document.getElementById('<%= txtDateV6.ClientID %>').removeAttribute('readonly');
    } else if (!G6Vacc1.checked) {
        document.getElementById('<%= txtDateV6.ClientID %>').readOnly = true;
        document.getElementById('<%= txtDateV6.ClientID %>').value = '';
    }
}

function EnableG7(checkBox) {
    var G7Vacc1 = document.getElementById('<%= CheckTCV.ClientID %>')
    if (checkBox.checked) {
        document.getElementById('<%= txtDateV7.ClientID %>').removeAttribute('readonly');
            } else if (!G7Vacc1.checked) {
                document.getElementById('<%= txtDateV7.ClientID %>').readOnly = true;
        document.getElementById('<%= txtDateV7.ClientID %>').value = '';
    }
}


//Hide Mother (Date of Visit):

function EnableMG1(checkBox) {
    var MVaccG1 = document.getElementById('<%= CheckTT1.ClientID %>');

    if (checkBox.checked) {
        document.getElementById('<%= txtDateMV1.ClientID %>').removeAttribute('readonly');
    }
    else if (!MVaccG1.checked) {
        document.getElementById('<%= txtDateMV1.ClientID %>').readOnly = true;
        document.getElementById('<%= txtDateMV1.ClientID %>').value = '';
    }
}

function EnableMG2(checkBox) {
    var MVaccG2 = document.getElementById('<%= CheckTT2.ClientID %>');

    if (checkBox.checked) {
        document.getElementById('<%= txtDateMV2.ClientID %>').removeAttribute('readonly');
    }
    else if (!MVaccG2.checked) {
        document.getElementById('<%= txtDateMV2.ClientID %>').readOnly = true;
        document.getElementById('<%= txtDateMV2.ClientID %>').value = '';
    }
}

function EnableMG3(checkBox) {
    var MVaccG3 = document.getElementById('<%= CheckTT3.ClientID %>');

    if (checkBox.checked) {
        document.getElementById('<%= txtDateMV3.ClientID %>').removeAttribute('readonly');
    }
    else if (!MVaccG3.checked) {
        document.getElementById('<%= txtDateMV3.ClientID %>').readOnly = true;
        document.getElementById('<%= txtDateMV3.ClientID %>').value = '';
    }
}
function EnableMG4(checkBox) {
    var MVaccG4 = document.getElementById('<%= CheckTT4.ClientID %>');

    if (checkBox.checked) {
        document.getElementById('<%= txtDateMV4.ClientID %>').removeAttribute('readonly');
    }
    else if (!MVaccG4.checked) {
        document.getElementById('<%= txtDateMV4.ClientID %>').readOnly = true;
        document.getElementById('<%= txtDateMV4.ClientID %>').value = '';
    }
}
function EnableMG5(checkBox) {
    var MVaccG5 = document.getElementById('<%= CheckTT5.ClientID %>');

    if (checkBox.checked) {
        document.getElementById('<%= txtDateMV5.ClientID %>').removeAttribute('readonly');
    }
    else if (!MVaccG5.checked) {
        document.getElementById('<%= txtDateMV5.ClientID %>').readOnly = true;
        document.getElementById('<%= txtDateMV5.ClientID %>').value = '';
    }
}




function hide() {
    var age = parseInt(document.getElementById("AgeMonths").value, 10);
    var days = parseInt(document.getElementById("AgeDays").value, 10);

    if (days >= 5)
        age += .5;

    if (age < 1.5) {
        document.getElementById("week6").style.display = 'none';
        document.getElementById("week10").style.display = 'none';
        document.getElementById("week14").style.display = 'none';
        document.getElementById("months9").style.display = 'none';
        document.getElementById("months15").style.display = 'none';

    }
    else if (age < 2.5) {
        document.getElementById("week6").style.display = 'block';
        document.getElementById("week10").style.display = 'none';
        document.getElementById("week14").style.display = 'none';
        document.getElementById("months9").style.display = 'none';
        document.getElementById("months15").style.display = 'none';
    }
    else if (age < 3.5) {
        document.getElementById("week6").style.display = 'block';
        document.getElementById("week10").style.display = 'block';
        document.getElementById("week14").style.display = 'none';
        document.getElementById("months9").style.display = 'none';
        document.getElementById("months15").style.display = 'none';
    }
    else if (age < 9) {
        document.getElementById("week6").style.display = 'block';
        document.getElementById("week10").style.display = 'block';
        document.getElementById("week14").style.display = 'block';
        document.getElementById("months9").style.display = 'none';
        document.getElementById("months15").style.display = 'none';
    }
    else if (age < 15) {
        document.getElementById("week6").style.display = 'block';
        document.getElementById("week10").style.display = 'block';
        document.getElementById("week14").style.display = 'block';
        document.getElementById("months9").style.display = 'block';
        document.getElementById("months15").style.display = 'none';
    }
    else {
        document.getElementById("week6").style.display = 'block';
        document.getElementById("week10").style.display = 'block';
        document.getElementById("week14").style.display = 'block';
        document.getElementById("months9").style.display = 'block';
        document.getElementById("months15").style.display = 'block';
    }
}

function disable() {
    if (document.getElementById("<%=TextName.ClientID%>").value != "") {
        document.getElementById("mother").style.display = 'none';
        document.getElementById("TextMAge").value = "";
        document.getElementById("TextMAge").disabled = true;
        document.getElementById("child").style.display = 'block';
        document.getElementById("TextDOB").disabled = false;
        document.getElementById("AgeMonths").disabled = false;
        document.getElementById("AgeDays").disabled = false;

    }
    else if (document.getElementById("<%=TextName.ClientID%>").value == "" && document.getElementById("<%=TextMname.ClientID%>").value != "") {
        document.getElementById("child").style.display = 'none';
        document.getElementById("mother").style.marginTop = '50px';
        document.getElementById("mother").style.display = 'block';
        document.getElementById("TextDOB").value = ""; document.getElementById("AgeMonths").value = ""; document.getElementById("AgeDays").value = "";
        document.getElementById("TextDOB").disabled = true;
        document.getElementById("AgeMonths").disabled = true;
        document.getElementById("AgeDays").disabled = true;
        document.getElementById("TextMAge").disabled = false;
        document.getElementById("radioList").rows[1].cells[0].childNodes[0].checked = true;
    }
    else {
        document.getElementById("child").style.display = 'block';
        document.getElementById("mother").style.marginTop = '300px';
        document.getElementById("mother").style.display = 'block';
        document.getElementById("TextDOB").disabled = false;
        document.getElementById("TextMAge").disabled = false;
    }
}


function disableage() {
    if (document.getElementById("TextDOB").value == "" || document.getElementById("TextDOB").value == "__/__/____") {
        document.getElementById("AgeMonths").disabled = false;
        document.getElementById("AgeDays").disabled = false;

        document.getElementById("AgeMonths").value = "";
        document.getElementById("AgeDays").value = "";
    }
    else {
        document.getElementById("AgeMonths").disabled = true;
        document.getElementById("AgeDays").disabled = true;
    }
}

    </script>

</body>
</html>
