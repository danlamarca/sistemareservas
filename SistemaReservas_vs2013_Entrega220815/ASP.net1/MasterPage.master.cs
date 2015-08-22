using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Carregando as Sessões  
        Session["CGC"] = "64968218000117";
        Session["Matricula"] = "0123";
    }

    protected void Btn_Comprar_Onclick(Object sender, EventArgs e)
    {
        Response.Redirect("area_teste.aspx", false);

    }

    protected void Btn_Buscar_Produto_Onclick(Object sender, EventArgs e)
    {
        Response.Redirect("Consulta.aspx", false);

    }
    protected void Btn_Buscar_Produto2_Onclick(Object sender, EventArgs e)
    {
        Response.Redirect("Consulta.aspx", false);

    }

}
