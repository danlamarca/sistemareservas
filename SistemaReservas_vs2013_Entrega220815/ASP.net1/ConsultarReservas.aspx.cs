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
using System.Text;
using Library1;
using Library1.BO;

public partial class ConsultarReservas : System.Web.UI.Page
{
    ClsBancoDeDados oDB = new ClsBancoDeDados();
    Tratamento_Erros Tr_Error = new Tratamento_Erros();
    Valicoes_num Val_num = new Valicoes_num();
   

    //variavies globais
    string strSQL;
    int retorna_erro;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Ao inicializar pagina sempre remove todas as sessions da memoria - desempenho.
            Session.Contents.RemoveAll();

            //Sessions utilizadas pela página:
            Session["Cliente_Todos"] = new Cliente_Todos(Cliente_Todos.TipoPesquisaCliente.Todos, 0, "0");
            Session["Reserva_Todos"] = new Reserva_Todos();
        }
        else
        {
            
        }
    }

    #region Controles
    protected void Btn_img_Avancar_click(object sender, EventArgs e)
    {
        ClsBancoDeDados oDB = new ClsBancoDeDados();
        Reserva_Todos reserva_todos = new Reserva_Todos(Convert.ToDateTime(txt_reservas_de.Text), Convert.ToDateTime(txt_reservas_ate.Text));
        Session["Reserva_Todos"] = (Reserva_Todos)reserva_todos;

        grd_consulta_reserva.DataSource = reserva_todos;
        grd_consulta_reserva.DataBind();
    }

    protected void grd_cons_reserva_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        //atribui "chave" a cada linha da grid para os templates criados:
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((LinkButton)e.Row.FindControl("lnk_editar")).ToolTip = e.Row.Cells[0].Text;
            ((LinkButton)e.Row.FindControl("lnk_excluir")).ToolTip = e.Row.Cells[0].Text;
        }
    }

    protected void lnk_editar_Onclick(object sender, EventArgs e)
    {
        LinkButton lnk_editar = (LinkButton)sender;

        foreach(GridViewRow row in grd_consulta_reserva.Rows)
        {
            if (row.Cells[0].Text == lnk_editar.ToolTip.ToString())
            { 
                
            }
        }
    }

    protected void lnk_excluir_Onclick(object sender, EventArgs e)
    {
    }     
    #endregion
}
