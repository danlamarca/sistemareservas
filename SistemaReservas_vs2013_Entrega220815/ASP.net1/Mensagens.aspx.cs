﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Library1;

public partial class Mensagens : System.Web.UI.Page
{
    ClsBancoDeDados oDB = new ClsBancoDeDados();
    Tratamento_Erros Tr_Error = new Tratamento_Erros();
    Valicoes_num Val_Num_int = new Valicoes_num();    

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}
