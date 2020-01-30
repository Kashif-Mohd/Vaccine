 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportData.aspx.cs" Inherits="Application.ExportData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DATA</title>
    <meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />

    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
	<link href="bootstrap-3.3.6-dist/css/bootstrap.min.css" rel="stylesheet" />
	<link rel="stylesheet" href="css/style.css" />

    <style type="text/css">
        
        html {
          height: 100% !important
        }
        body {
            margin:0;
          min-height: 100% !important
        }

    </style>
</head>

<body style="background-color:#f6f6f6;">
    <form id="form1" runat="server" class="form-inline">
        <asp:ScriptManager ID="ScriptManger1" runat="Server"></asp:ScriptManager>
      <nav class="navbar navbar-default navbar-fixed-top">
	    <div class= "">
		<div class="navbar-header">
            <asp:Label ID="Label1" class="navbar-brand" runat="server" Text="Label1.text" style="text-transform: uppercase;"></asp:Label>
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
        		<%--<li><a href="Form.aspx">FORM ENTER</a></li>
        		<li><a href="UpdateForm.aspx">FORM UPDATE</a></li>        --%> 
                <li><a href="page.aspx">HOME</a></li>      
        		<li><a href="RegistrationForm.aspx">REGISTER</a></li>
        		<li><a href="login.aspx">LOG OUT</a></li>
      		</ul>
        </div>
    </div>
</nav> 

<%--<div class="jumbotron text-center" style="margin-top:2%;">
  <h1>Mother And Child Vaccination Program</h1>
</div>--%>
  <div class= "container-fluid bg-4 text-center" >     
    <div style="margin-top:8%;margin-bottom:2%; width:100%;">
      <div class="form-group" >         
        <asp:RadioButtonList ID="radioList" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" >
            <asp:ListItem Text="Mother records"  Value="1"></asp:ListItem>
            <asp:ListItem Text="Child records" Value="2"></asp:ListItem>
            <asp:ListItem Text="All records" Selected="True" Value="3"></asp:ListItem>
        </asp:RadioButtonList>
      </div>          
        <div class="form-group">
            <asp:Button id="sbmtbtn" CssClass="btn" style="padding:8px;" runat="server" Text="submit" width="200" OnClick="sbmtbtn_Click"/>           
        </div>
    </div> 

    <div style="margin: auto; width:80%;">

        <asp:Button id="Exprtbtn" CssClass="btn" style="padding:8px;margin:auto" runat="server" Text="Export to Excel" width="20%" Visible="false" OnClick="Exprtbtn_Click" /><br /><br />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" AllowPaging="True" PageSize="100" OnPageIndexChanging="GridView1_PageIndexChanging"  CellPadding="5" ForeColor="Black" GridLines="Vertical" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
       
                            
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#1abc9c" Font-Bold="True" ForeColor="White" height="40px" HorizontalAlign="Center" />         
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#eafff3" height="40px" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>

        
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="true" >
                        
        </asp:GridView>
        
    </div>
  </div>

 </form>

    <script src="https://code.jquery.com/jquery-2.1.3.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/js/bootstrap.min.js"></script>

</body>
</html>
