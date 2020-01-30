<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Application.Search" EnableEventValidation = "false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Search</title>
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
    <form id="form1" runat="server" class="form-horizontal">
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

<div class="jumbotron text-center" style="margin-top:2%;">
  <h1>Mother And Child Vaccination Program</h1>
</div>
  <div class= "container-fluid bg-4 text-center" style="margin-top:-2%;" >     
    <div style="margin:5% auto; width:30%;">
      <div class="form-group" style="margin-left:45%">
        <asp:RadioButtonList ID="radioList" runat="server" >
            <asp:ListItem Text="search mother" Value="1"></asp:ListItem>
            <asp:ListItem Text="search by child" Value="2"></asp:ListItem>
        </asp:RadioButtonList>
        </div>  
      <div class="form-group" style="margin:auto;">
          <label class="control-label col-sm-5"><strong>DSSID:</strong></label>
          <div class="col-sm-7">
              <asp:TextBox id="txtdss" runat="server" placeholder="DSSID" class="form-control"  MaxLength="12" Style="text-transform: uppercase;"/>
              <asp:RegularExpressionValidator ID="RegEx2" runat="server" ControlToValidate="txtdss" ValidationExpression="^[a-zA-Z0-9]+$" ErrorMessage="Invalid input" Font-Size="Smaller" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
          </div>                
      </div><br />
      <div class="form-group" style="margin:auto;">    
          <label class="control-label col-sm-5"><strong>Child NAME:</strong></label>
          <div class="col-sm-7">
              <asp:TextBox ID="txtcname" runat="server" placeholder="Child name"  class="form-control" ></asp:TextBox>
          </div>
      </div><br />
      <div class="form-group" style="margin:auto;">    
          <label class="control-label col-sm-5"><strong>WOMAN NAME:</strong></label>
          <div class="col-sm-7">
              <asp:TextBox ID="txtmname" runat="server" placeholder="Mother/Woman name" class="form-control"  ></asp:TextBox>
          <%--<asp:RequiredFieldValidator ID="Required2" runat="server" class="align" ControlToValidate="txtcard" ErrorMessage="*Required field is empty" Font-Size="Smaller" ForeColor="Red" ></asp:RequiredFieldValidator> <br />--%>
          <%--<asp:RegularExpressionValidator ID="RegEx1" runat="server" ControlToValidate="txtcard" ValidationExpression="^[0-9]+$" ErrorMessage="Invalid input" Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>--%>     
          </div>
      </div><br />
      <div class="form-group" style="margin:auto;">    
          <label class="control-label col-sm-5"><strong>HUSBAND NAME:</strong></label>
          <div class="col-sm-7">
              <asp:TextBox ID="txthname" runat="server" placeholder="Father/Husband name" class="form-control" ></asp:TextBox>
          <%--<asp:RequiredFieldValidator ID="Required2" runat="server" class="align" ControlToValidate="txtcard" ErrorMessage="*Required field is empty" Font-Size="Smaller" ForeColor="Red" ></asp:RequiredFieldValidator> <br />--%>
          <%--<asp:RegularExpressionValidator ID="RegEx1" runat="server" ControlToValidate="txtcard" ValidationExpression="^[0-9]+$" ErrorMessage="Invalid input" Font-Size="Smaller" ForeColor="Red"></asp:RegularExpressionValidator>--%>     
          </div>
      </div><br />
         <asp:Button id="searchbtn" CssClass="btn" style="padding:10px;" runat="server" Text="search" OnClick="searchbtn_Click" width="60%"/>
    </div> 

    <div style="margin:2% auto; width:80%;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="True" PageSize="100" OnPageIndexChanging="GridView1_PageIndexChanging"  CellPadding="5" ForeColor="Black" GridLines="Vertical" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
        <Columns>    
            <asp:BoundField HeaderText="Woman Name" DataField="Woman Name" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HeaderText="Husband Name" DataField="Husband Name" />
            <asp:BoundField HeaderText="DSS ID" DataField="dss_id_member" />            
            <asp:BoundField HeaderText="DOB" DataField="dob" />
            <asp:BoundField HeaderText="Mother Age" DataField="age" />
            <asp:BoundField HeaderText="Gender" DataField="gender" />
            <asp:HyperLinkField DataNavigateUrlFields="dss_id_member, Woman Name, Husband Name" DataNavigateUrlFormatString="Form.aspx?id={0}&mname={1}&hname={2}" Text="Select"/>
        </Columns>   
                            
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


        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CellPadding="5" ForeColor="Black" GridLines="Vertical" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
        <Columns>  
            <asp:BoundField HeaderText="Child Name" DataField="Child Name" />          
            <asp:BoundField HeaderText="Mother Name" DataField="Mother Name" />
            <asp:BoundField HeaderText="Father Name" DataField="Father name" />
            <asp:BoundField HeaderText="DSS ID" DataField="dss_id_member" />            
            <asp:BoundField HeaderText="DOB" DataField="dob" />
            <asp:BoundField HeaderText="Gender" DataField="gender" />
            <asp:HyperLinkField DataNavigateUrlFields="dss_id_member, Child Name, Mother Name, Father name, dob" DataNavigateUrlFormatString="Form.aspx?id={0}&cname={1}&mname={2}&hname={3}&dob={4}" Text="Select"/>
            <%--<asp:BoundField HeaderText="Member type" DataField="member_type" />--%>
        </Columns>   
                            
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#1abc9c" Font-Bold="True" ForeColor="White" height="40px" HorizontalAlign="Center" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#eafff3" height="40px" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </div>
  </div>

 </form>

    <script src="https://code.jquery.com/jquery-2.1.3.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/js/bootstrap.min.js"></script>

</body>
</html>
