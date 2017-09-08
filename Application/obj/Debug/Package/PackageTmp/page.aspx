<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page.aspx.cs" Inherits="Application.page" EnableEventValidation = "false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
	<meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />

    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
	<link href="bootstrap-3.3.6-dist/css/bootstrap.min.css" rel="stylesheet" />
	<link rel="stylesheet" href="css/style.css" />
    <%--<style>
        body
        {
            background-image: url("vaccine.jpg");
            background-position: center;
            background-size:  cover;
            background-repeat:no-repeat;  
        }
    </style> --%>   
</head>
<body>

  <div class="jumbotron text-center">
  <h1>Mother And Child Vaccination Program</h1>
  </div>

    <form id="form1" runat="server">
      <nav class="navbar navbar-default navbar-fixed-top">
	    <div class= "">
		<div class="navbar-header">
			<button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
				<span class="icon-bar"></span>
        		<span class="icon-bar"></span>
        		<span class="icon-bar"></span>
        		<span class="icon-bar"></span>
        	</button>        	
        </div>
        <!--<a class="navbar-brand" href="#"></a>-->
        <asp:Label ID="Label1" class="navbar-brand" runat="server" Text="Label1.text" style="text-transform: uppercase;"></asp:Label>
        <div class="collapse navbar-collapse" id="myNavbar">
        	<ul class="nav navbar-nav navbar-right">
        		<li><a href="Form.aspx">FORM ENTER</a></li>
        		<%--<li><a href="Form.aspx">2ND ENTRY</a></li>--%>               
        		<li><a href="RegistrationForm.aspx">REGISTER</a></li>
        		<li><a href="login.aspx">LOG OUT</a></li>
      		</ul>
        </div>
    </div>
</nav> 

  <div class= "container-fluid bg-4 text-center" style="position:relative;margin-top:-25px;"  >
      <asp:Panel id="panel1" runat="server" class="form-inline" style="margin:5%;">
            <asp:TextBox id="txtsearch" runat="server" placeholder="DSSID or Card No" size="30" class="form-control" />
            <asp:Button id="searchbtn" CssClass="btn" style="padding:10px;width:10%;" runat="server" Text="Search" OnClick="searchbtn_Click"/>
        </asp:Panel>
      <div>
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound = "OnRowDataBound" OnSelectedIndexChanged = "OnSelectedIndexChanged" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
            <Columns>
               <asp:BoundField HeaderText="Date" DataField="Date" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField HeaderText="Card No." DataField="Card_No" />
                <%--<asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" text="<%#Eval("DSS_ID") %>"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>  --%>              
                <asp:BoundField HeaderText="DSS ID" DataField="DSS_ID" />
                <asp:BoundField HeaderText="Child Name" DataField="Child_Name" />
                <asp:BoundField HeaderText="Mother Name" DataField="Mother_Name" />
                <asp:BoundField HeaderText="Father/Husband Name" DataField="Father_Name" />
                <asp:BoundField HeaderText="DOB" DataField="DOB" DataFormatString="{0:MM/dd/yyyy}"/>
                <asp:BoundField HeaderText="Child Age" DataField="Child_Age" />
                <asp:BoundField HeaderText="Mother Age" DataField="Mother_Age" />
                <asp:BoundField HeaderText="Gender" DataField="Gender" />
           </Columns>   
                            
              <AlternatingRowStyle BackColor="White" />
              <FooterStyle BackColor="#CCCC99" />
              <HeaderStyle BackColor="#1abc9c" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
              <RowStyle BackColor="#F7F7DE" />
              <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
              <SortedAscendingCellStyle BackColor="#FBFBF2" />
              <SortedAscendingHeaderStyle BackColor="#848384" />
              <SortedDescendingCellStyle BackColor="#EAEAD3" />
              <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </div>
  </div>

 </form>

</body>
</html>
