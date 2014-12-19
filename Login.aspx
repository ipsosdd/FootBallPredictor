<%@ Page Title="Login | Football Predictor" MasterPageFile="~/Master/Login.master" Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ContentPlaceHolderID="Body" runat="server">



<div class="loginPanel" id="login" data-speed="60">
<asp:Panel ID="temp" Visible="true" runat="server">
    <%--<img src="Images/Football/Login_Football.jpg" alt="img_loginBanner" style="width:auto;z-index:-1;" />--%>
    <asp:Login runat="server" ID="aspLogin" OnAuthenticate="Login_Authenticate" OnLoginError="Login_LoginError" DestinationPageUrl="~/Pages/Splash.aspx"
        RememberMeText="true" TitleText="Username Default">
        <LayoutTemplate>
        <h2>Username</h2>
        <asp:TextBox ID="Username" runat="server" ></asp:TextBox><br /><br />
        <h2>Password</h2>
        <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox>
        <asp:LinkButton ID="lbLogin" runat="server" CommandName="Login">Login</asp:LinkButton>
        </LayoutTemplate>
    </asp:Login>
    <asp:Literal ID="Info" runat="server" Text="Please enter your login details"></asp:Literal>
</asp:Panel>
</div>


<div class="loginPanel" id="signup"  data-speed="3">
<article> <h1>Water</h1> <p>You think water moves fast? You should see ice. It moves like it has a mind. Like it knows it killed the world once and got a taste for murder. After the avalanche, it took us a week to climb out. Now, I don't know exactly when we turned on each other, but I know that seven of us survived the slide... and only five made it out. Now we took an oath, that I'm breaking now. We said we'd say it was the snow that killed the other two, but it wasn't. Nature is lethal but it doesn't hold a candle to man. </p> </article>
<br />
<br />

    
</div>

</asp:Content>