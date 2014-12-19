using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    String ErrorMessage = "<div class='bottom'><div class='messages red'><span></span>";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #region Authenticate Login
    protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
    {
        String loginUsername = aspLogin.UserName;
        String loginPassword = aspLogin.Password;

        if (Membership.ValidateUser(loginUsername, loginPassword))
        {
            e.Authenticated = true;
            Response.Redirect("splash.aspx", false);
        }
        else
        {
            bool successfulUnlock = AutoUnlockUser(loginUsername);
            if (successfulUnlock)
            {
                //re-attempt the login
                if (Membership.ValidateUser(loginUsername, loginPassword))
                {
                    e.Authenticated = true;
                    Response.Redirect("splash.aspx", true);
                }
                else
                {
                    e.Authenticated = false;
                    // Error message to display same message if user exsits and password incorrect for security reasons.
                    Info.Text = ErrorMessage + "Your username and/or password are invalid." + " <a href='forgottenpassword.aspx'>Click here</a> if you have forgotten your details.</div></div>";
                }
            }
            e.Authenticated = false;
            Info.Text = ErrorMessage + "Your username and/or password are invalid." + " <a href='forgottenpassword.aspx'>Click here</a> if you have forgotten your details.</div></div>";
            Info.Visible = true;
            // NovaLogin.FailureText = "Your username and/or password are invalid.";
        }
    }
    #endregion

    #region Login Error
    protected void Login_LoginError(object sender, EventArgs e)
    {
        String sApplicationName = Membership.ApplicationName;
        String sUserName = aspLogin.UserName;
        String sIPAddress = Request.UserHostAddress;
        String sPassword = null;
        MembershipUser userInfo = Membership.GetUser(aspLogin.UserName);
        if (userInfo == null)
        {
            Info.Text = ErrorMessage + "Your username and/or password are invalid." + "  <a href='forgottenpassword.aspx'>Click here</a> if you have forgotten your details.</div></div>";
            sPassword = aspLogin.Password;
        }
        else
        {
            if (!(userInfo.IsApproved))
            {
                Info.Text = ErrorMessage + "Your account has not yet been approved by the site's administrators. Please try again later..." + "</div></div>";
            }
            else if (userInfo.IsLockedOut)
            {
                Info.Text = ErrorMessage + "Your account has been locked out. You will NOT be able to login for 15 minutes." + "</div></div>";
            }
            else
            {
                sPassword = aspLogin.Password;
            }
        }
    }
    #endregion
    #region Auto Unlock User
    private bool AutoUnlockUser(String username)
    {
        // Get username from membership
        MembershipUser mu = Membership.GetUser(username, false);
        if ((mu != null) &&
         (mu.IsLockedOut) &&
         (mu.LastLockoutDate.ToUniversalTime().AddMinutes(15)
                 < DateTime.UtcNow)
            )
        {
            bool retval = mu.UnlockUser();
            if (retval)
                return true;
            else
                return false; //something went wrong with the unlock
        }
        else
            return false; //not locked out in the first place
        // or still in lockout period
    }
    #endregion
}