using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Library1;


public partial class Apresentacao : System.Web.UI.Page
{
    RetornaUsuario RetUsuario = new RetornaUsuario();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Usuario:            
            string[] user = new string[2];
            user = RetUsuario.ValidaUsuario(3);

            Session["User_Codigo"] = user[0];
            Session["User_Nome"] = user[1];
            Session["User_Matricula"] = user[2];
        }
    }
}
