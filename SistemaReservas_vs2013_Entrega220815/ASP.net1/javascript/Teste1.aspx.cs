using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
    
public partial class JavaScript_Teste_Teste1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btn_salva.Attributes.Add("onclick", "window.open('teste2.aspx?teste="+txt_info.Text+"')");

        StringBuilder sb = new StringBuilder();
        btn_salva2.Attributes.Add("onclick", "altera_status('1','ok')");    
    }
}