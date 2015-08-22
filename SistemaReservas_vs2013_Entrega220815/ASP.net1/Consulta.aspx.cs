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
using System.Windows.Forms;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Library1;

public partial class Consulta : System.Web.UI.Page
{
    ClsBancoDeDados oDB = new ClsBancoDeDados();
    string strSQL;


    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Btn_Teste_Click(object sender, EventArgs e)
    {
        if (Lbl_busca_produto.Text != "")
        {
            strSQL = @"Select nome_produto [Produto],convert(varchar(30),replace(valor_produto,'.',','))";
            strSQL = strSQL + " [Valor] from tb_produto where nome_produto like '%" + Lbl_busca_produto.Text + "%'";


            Gd_Busca_Produtos.DataSource = oDB.NewDataSet(strSQL);
            Gd_Busca_Produtos.DataBind();

            if (Gd_Busca_Produtos.Rows.Count == 0)
            {
                Gd_Busca_Produtos.Visible = false;
                MessageBox.Show("Seleção não retornou nada", "ATENÇÃO!");

            }
            else
            {
                Gd_Busca_Produtos.Visible = true;

            }
        }

        else
        {
            Gd_Busca_Produtos.Visible = false;
            MessageBox.Show("Digite algum produto","ATENÇÃO!");

        }

        strSQL = "";
    }


}
