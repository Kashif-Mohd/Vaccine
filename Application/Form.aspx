<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Form.aspx.cs" Inherits="Application.Form" Culture = "en-GB" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Form</title>
    <meta charset="utf-8"/>
	<meta name="viewport" content="width=device-width, initial-scale=1"/>

    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
	<link href="bootstrap-3.3.6-dist/css/bootstrap.min.css" rel="stylesheet"/>
	<script src="bootstrap-3.3.6-dist/js/bootstrap.min.js"> </script>
	<link rel="stylesheet" href="css/style.css"/>

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
                d1 += DaysInMonth(y2, m2);
            }
            if (m1 < m2) {
                y1--;
                m1 += 12;
            }
            return [y1 - y2, m1 - m2, d1 - d2];
        }
        function CalculateAge() {
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

            birthDate = new Date(birthYear, birthMonth-1, birthDay);
            visitDate = new Date(visitYear, visitMonth - 1, visitDay);

            var dife = datediff(visitDate, birthDate);
            var monleft = (dife[0] * 12) + dife[1];
            if (dife[2] >= 15)
                monleft += 0.5;
            document.getElementById("TextCAge").value = monleft;
            //document.getElementById("TextCAge").value = dife[0] + " years, " + dife[1] + " months, and " + dife[2] + " days";
        }

        
        function codename() {
            if (document.form1.TextCAge.value != "") {
                //document.form1.TextMAge.disabled = true;
                //document.form1.TextCAge.disabled = false;
                document.form1.TextMAge.style.visibility = 'hidden';
                document.form1.TextCAge.style.visibility = 'visible';

                document.form1.TextCAge.focus();
            }
            else if (document.form1.TextMAge.value != "") {

                document.form1.TextCAge.disabled = true;
                document.form1.TextMAge.disabled = false;

                document.form1.TextMAge.focus();

            }
            else if (document.form1.TextCAge.value == "" && document.form1.TextMAge.value == "") {

                document.form1.TextCAge.disabled = false;
                document.form1.TextMAge.disabled = false;
            }
        }
</script>    
</head>
<body>
    <form class="form-inline" id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManger1" runat="Server"></asp:ScriptManager>
        <nav class="navbar navbar-default ">
	    <div class= "">
		<div class="navbar-header">
            <asp:Label ID="Label1" class="navbar-brand" runat="server" Text="Label1.text" style="text-transform: uppercase;border-right:groove;border-color:lightgray;"></asp:Label>
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
        		<li><a href="UpdateForm.aspx">FORM UPDATE</a></li>              
        		<li><a href="RegistrationForm.aspx">REGISTER</a></li>
        		<li><a href="login.aspx" class="nav navbar-nav navbar-right">LOG OUT</a></li>
      		</ul>
        </div>
        </div>
      </nav>

    <div class= "container-fluid bg-4 text-center" >
	<h2 class="margin">Temporary logging of daily vaccines administration</h2>
	<div class="row">
		<div class="col-sm-3 margin text-left" style="top: 0px; left: 0px; border-right-style: groove; border-right-color: inherit; border-right-width: medium;"><h4 class="margin text-center">Child's Data</h4>
            <asp:Panel ID="Panel1" runat="server">
                <label style="font-size: small">Date of Visit</label><asp:TextBox ID="TxtDOV" runat="server" class="form-control align" placeholder="dd/MM/yyyy" ClientIDMode="Static"></asp:TextBox><br />
                <cc1:MaskedEditExtender runat="server" TargetControlID="TxtDOV" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" class="align" ControlToValidate="TxtDOV" ErrorMessage="*Required field is empty" Font-Size="Smaller" ForeColor="Red" ></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareDOV" runat="server" ControlToValidate="TxtDOV" Operator="LessThanEqual" Type="Date" ErrorMessage="*Invalid Date"  Font-Size="Smaller" ForeColor="Red"></asp:CompareValidator>
                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtDate" ValidationExpression="(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$" ErrorMessage="*Invalid Date" Font-Size="Smaller" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>--%>
                </asp:Panel><br />

            <asp:Panel ID="Panel2" runat="server">
                <label style="font-size: small">Card No.</label><asp:TextBox ID="TextCardno" runat="server" class="form-control align" ></asp:TextBox><br />
                <cc1:MaskedEditExtender ID="CardMask" runat="server" TargetControlID="TextCardno" Mask="VPT9999/99" MaskType="Number" ClearMaskOnLostFocus="false" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" class="align" ControlToValidate="TextCardno" ErrorMessage="*Required field is empty" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>
            </asp:Panel><br /><br />

            <asp:Panel ID="Panel3" runat="server">
                <label style="font-size: small">DSS ID</label><asp:TextBox ID="TextDSSID" runat="server" class="form-control align" style="text-transform: uppercase;" MaxLength="15"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" class="align" ControlToValidate="TextDSSID" ErrorMessage="*Required field is empty" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>
            </asp:Panel><br /><br />

            <asp:Panel ID="Panel4" runat="server">
                <label style="font-size: small">Child Name</label><asp:TextBox ID="TextName" runat="server"  class="form-control align" ClientIDMode="Static" ></asp:TextBox><br />
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" class="align" ControlToValidate="TextName" ErrorMessage="*Required field is empty" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>--%>              
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextName" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="*Invalid characters." Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>
            </asp:Panel><br />

            <asp:Panel ID="Panel5" runat="server">
                <label style="font-size: small">MotherName</label><asp:TextBox ID="TextMname" runat="server" class="form-control align" onblur="disable()" ></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" class="align" ControlToValidate="TextMname" ErrorMessage="*Required field is empty" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>          
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  ControlToValidate="TextMname" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="*Invalid characters." Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>
            </asp:Panel><br />

            <asp:Panel ID="Panel6" runat="server">
                <label style="font-size: small">FatherName</label><asp:TextBox ID="TextFname" runat="server" class="form-control align" placeholder="Father/Husband Name"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" class="align" ControlToValidate="TextFname" ErrorMessage="*Required field is empty" Font-Size="Smaller" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextFname" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="*Invalid characters." Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>
            </asp:Panel><br />

            <asp:Panel ID="Panel7" runat="server" ClientIDMode="Static">
                <label style="font-size: small">Date of Birth</label><asp:TextBox ID="TextDOB" runat="server" ClientIDMode="Static" onblur="CalculateAge()" class="form-control align" placeholder="dd/MM/yyyy"></asp:TextBox><br />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="TextDOB" Mask="99/99/9999" MaskType="Date"></cc1:MaskedEditExtender>
                <asp:CompareValidator ID="CompareDOB" runat="server" ControlToCompare="TxtDOV" ControlToValidate="TextDOB" Type="Date" Operator="LessThan" ErrorMessage="Incorrect Date" Font-Size="Smaller" ForeColor="Red"></asp:CompareValidator>
            </asp:Panel><br />

            <asp:Panel ID="Panel8" runat="server" ClientIDMode="Static">
                <label style="font-size: small">Child Age</label><asp:TextBox ID="TextCAge" runat="server" class="form-control align" onkeydown="hide()" placeholder="(in months)" ClientIDMode="Static"></asp:TextBox>
            </asp:Panel><br /><br />

            <asp:Panel ID="Panel9" runat="server" ClientIDMode="Static">
                <label style="font-size: small">Mother Age</label><asp:TextBox ID="TextMAge" runat="server" class="form-control align" ClientIDMode="Static" placeholder="(in years)"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegEx" runat="server" ControlToValidate="TextMAge" ValidationExpression="^[0-9]+$" ErrorMessage="Invalid input" Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>
            </asp:Panel><br />

            <asp:Panel ID="Panel10" runat="server">
                <label style="font-size: small">Gender</label>
                <asp:DropDownList ID="DropDownList" runat="server" class="form-control align" >
                    <asp:ListItem Text="Select Gender" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </asp:Panel><br />

            <%--<asp:Button id="Btnshow" runat="server" Text="Show" CssClass="btn" OnClick="Btnshow_Click" />--%>
		</div>

        <div runat="server" class="col-sm-7">

		<div id="child" runat="server"><h3 class="margin">Child Vaccines</h3>

			<div id="birth" class="col-sm-2" style="border-right:groove;border-color:lightgray;" runat="server"><h4 class="margin"><strong>At Birth</strong></h4>	
                <asp:CheckBox runat="server" ID="CheckBCG" class="tab" /><label>BCG</label><br />
                <asp:CheckBox runat="server" ID="CheckOPV0" class="tab"/><label>OPV0</label>
			</div>

			<div id="week6" class="col-sm-2" style="border-right: groove;border-color:lightgray;" runat="server" ><h4 class="margin"><strong>6 Weeks</strong></h4>	
				<asp:CheckBox runat="server" ID="CheckOPV1" class="tab"/><label>OPV1</label><br />
				<asp:CheckBox runat="server" ID="CheckPenta1" class="tab"/><label>Penta1</label><br />
				<asp:CheckBox runat="server" ID="CheckPCV1" class="tab"/><label>PCV1</label><br />
			</div>

            <div id="week10" class="col-sm-2" style="border-right:groove;border-color:lightgray;" runat="server" ><h4 class="margin"><strong>10 Weeks</strong></h4>
				<asp:CheckBox runat="server" ID="CheckOPV2" class="tab"/><label>OPV2</label><br />
				<asp:CheckBox runat="server" ID="CheckPenta2" class="tab"/><label>Penta2</label> <br />
				<asp:CheckBox runat="server" ID="CheckPCV2" class="tab"/><label>PCV2</label><br />
			</div>
			
            <div id="week14" class="col-sm-2" style="border-right:groove;border-color:lightgray;" runat="server" ><h4 class="margin"><strong>14 Weeks</strong></h4>
				<asp:CheckBox runat="server" ID="CheckOPV3" class="tab"/><label>OPV3 </label><br />
				<asp:CheckBox runat="server" ID="CheckPenta3" class="tab"/><label>Penta3</label><br />
				<asp:CheckBox runat="server" ID="CheckPCV3" class="tab"/><label>PCV3</label><br />
                <asp:CheckBox runat="server" ID="CheckIPV3" class="tab"/><label>IPV3</label><br />
			</div>

			<div id="months9" class="col-sm-2" style="border-right:groove;border-color:lightgray;" runat="server" ><h4 class="margin"><strong>9 Months</strong></h4>
				<asp:CheckBox runat="server" ID="CheckMeasles1" class="tab"/><label>Measles1</label>
			</div>  
            
            <div id="months15" class="col-sm-2" style="border-right:groove;border-color:lightgray;" runat="server" ><h4 class="margin"><strong>15 Months</strong></h4>
				<asp:CheckBox runat="server" ID="CheckMeasles2" class="tab"/><label>Measles2</label>
			</div>           
	    </div>
       
        <hr />
         <div id="mother" runat="server" style="margin-top:35%;"><h3 style="margin-bottom:30px;">Mother Vaccines</h3>
             <div class="col-sm-2"  style="border-right: groove;border-color:lightgray;"><asp:CheckBox runat="server" ID="CheckTT1" class="tab"/><label>TT1</label></div>
             <div class="col-sm-2"  style="border-right: groove;border-color:lightgray;"><asp:CheckBox runat="server" ID="CheckTT2" class="tab"/><label>TT2</label></div>
             <div class="col-sm-2"  style="border-right: groove;border-color:lightgray;"><asp:CheckBox runat="server" ID="CheckTT3" class="tab"/><label>TT3</label></div>
             <div class="col-sm-2"  style="border-right: groove;border-color:lightgray;"><asp:CheckBox runat="server" ID="CheckTT4" class="tab"/><label>TT4</label></div>
             <div class="col-sm-2"  style="border-right: groove;border-color:lightgray;"><asp:CheckBox runat="server" ID="CheckTT5" class="tab"/><label>TT5</label></div>
	    </div>

        </div>

        <div id="remarks" class="col-md-2" runat="server" style="margin-top:5%;"><h4 class="margin"><strong>Remarks</strong></h4>
		    <asp:TextBox ID="txtremarks" runat="server" class="form-control" size="15"></asp:TextBox>
	    </div>
        
    <asp:Button id="Btnsbmt" runat="server" Text="Submit" onclick="Button1_Click"  CssClass="btn" style="width: 20%;margin-top:30px;" />
   </div>
</div>
            
</form>

<script type="text/javascript">
    function hide() {
        var age = document.getElementById("TextCAge").value;
        if (age < 1.5) {
            document.getElementById("week6").style.display = 'none';
            document.getElementById("week10").style.display = 'none';
            document.getElementById("week14").style.display = 'none';
            document.getElementById("months9").style.display = 'none';
            document.getElementById("months15").style.display = 'none';
        }
        else if (age < 2.5) {
            document.getElementById("week10").style.display = 'none';
            document.getElementById("week14").style.display = 'none';
            document.getElementById("months9").style.display = 'none';
            document.getElementById("months15").style.display = 'none';
        }
        else if (age < 3.5) {
            document.getElementById("week14").style.display = 'none';
            document.getElementById("months9").style.display = 'none';
            document.getElementById("months15").style.display = 'none';            
        }
        else if (age < 9) {
            document.getElementById("months9").style.display = 'none';
            document.getElementById("months15").style.display = 'none';
        }
        else if (age < 15) {
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
            document.getElementById("mother").style.visibility = 'hidden';
        }
        else if (document.getElementById("<%=TextName.ClientID%>").value == "" && document.getElementById("<%=TextMname.ClientID%>").value != "") {
            document.getElementById("child").style.visibility = 'hidden';
            document.getElementById("mother").style.visibility = 'visible';
        }
        else {
            document.getElementById("child").style.display = 'visible';
            document.getElementById("mother").style.display = "visible";
        }
    }
</script>

</body>
</html>
