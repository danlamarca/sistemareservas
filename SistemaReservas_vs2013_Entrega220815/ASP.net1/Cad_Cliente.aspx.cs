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
using System.Windows.Forms;
using Library1;
using Library1.BO;

public partial class Cad_Cliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if(!IsPostBack)
        {
            Session["Cliente_Todos"] = new Cliente_Todos(Cliente_Todos.TipoPesquisaCliente.Todos, 0, "0");
            grd_cli.DataSource = (Cliente_Todos)Session["Cliente_Todos"];
            grd_cli.DataBind();
        }

    }

    #region Definicoes
    #endregion

    #region Metodos
    private void Limpar()
    {
        txt_nome.Text = "";
        txt_cpf.Text = "";
        txt_endereco.Text = "";
    }

    private void Preenche_Grid()
    {
        Session["Cliente_Todos"] = new Cliente_Todos(Cliente_Todos.TipoPesquisaCliente.Todos, 0, "0");
        grd_cli.DataSource = (Cliente_Todos)Session["Cliente_Todos"];
        grd_cli.DataBind();
    }
    #endregion

    #region Eventos
    protected void btn_ok_Onclick(object sender, EventArgs e)
    {
        Cliente cli = new Cliente();
        Cliente_Todos cli_todos = new Cliente_Todos();
        Cliente_Todos cli_todos_carregado = new Cliente_Todos(); 

        #region Validacoes
        if (txt_cpf.Text == "" || txt_nome.Text == "")
        {
            MessageBox.Show("Favor preencher os campos corretamente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
            return;
        }
        if ((from aa in (Cliente_Todos)Session["Cliente_Todos"] where aa._CPF == txt_cpf.Text select aa).Count()>0)
        {
            MessageBox.Show("Já existe um cliente com o cpf cadastrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
            return;
        }
        #endregion

        if (Session["Cliente_Todos"] != null)
        {
            cli_todos_carregado = (Cliente_Todos)Session["Cliente_Todos"];

            cli._NOME = txt_nome.Text;
            cli._CPF = txt_cpf.Text;
            cli._ENDERECO = txt_endereco.Text;

            cli_todos_carregado.Add(cli);
            Session["Cliente_Todos"] = cli_todos_carregado;

            grd_cli.DataSource = (Cliente_Todos)Session["Cliente_Todos"];
            grd_cli.DataBind();
        }
        else
        {
            cli._NOME = txt_nome.Text;
            cli._CPF = txt_cpf.Text;
            cli._ENDERECO = txt_endereco.Text;

            cli_todos.Add(cli);
            Session["Cliente_Todos"] = cli_todos;

            grd_cli.DataSource = (Cliente_Todos)Session["Cliente_Todos"];
            grd_cli.DataBind();
        }
        Limpar();
    }

    protected void lnk_editar_Onclick(object sender, EventArgs e)
    {
        Limpar();
        LinkButton lnk_editar = (LinkButton)sender;

        foreach (GridViewRow row in grd_cli.Rows)
        {
            if (row.Cells[1].Text == lnk_editar.ToolTip.ToString())
            {
                txt_nome.Text = row.Cells[0].Text;
                txt_cpf.Text = row.Cells[1].Text;                
                txt_endereco.Text = row.Cells[2].Text;

                //Utilizo link para deletar linha selecionada da session:
                var cli_teste = (from aa in (Cliente_Todos)Session["Cliente_Todos"] where aa._CPF == row.Cells[1].Text select aa);

                //Utilizo lambda para deletar registro da session
                var cli = ((Cliente_Todos)Session["Cliente_Todos"]).SingleOrDefault(x => x._CPF == row.Cells[1].Text);
                if (cli != null)
                {
                    ((Cliente_Todos)Session["Cliente_Todos"]).Remove(cli);
                }

                grd_cli.DataSource = (Cliente_Todos)Session["Cliente_Todos"];
                grd_cli.DataBind();
            }
        }
    }

    protected void lnk_excluir_Onclick(object sender, EventArgs e)    
    {
        Limpar();
        LinkButton lnk_excluir = (LinkButton)sender;

        foreach (GridViewRow row in grd_cli.Rows)
        {
            if (row.Cells[1].Text == lnk_excluir.ToolTip.ToString())
            { 
                //Utilizo link para deletar linha selecionada da session:
                //var cli_teste = (from aa in (Cliente_Todos)Session["Cliente_Todos"] where aa._CPF == row.Cells[1].Text select aa);

                //Utilizo lambda para deletar registro da session
                var cli = ((Cliente_Todos)Session["Cliente_Todos"]).SingleOrDefault(x => x._CPF == row.Cells[1].Text);
                if (cli != null)
                {
                    ((Cliente_Todos)Session["Cliente_Todos"]).Remove(cli);
                }

                grd_cli.DataSource = (Cliente_Todos)Session["Cliente_Todos"];
                grd_cli.DataBind();
            }
        }
    }

    protected void btn_Confirma_Onclick(object sender, EventArgs e)
    {        
        Cliente cli_confere = new Cliente();
        cli_confere.Deletar();

        foreach (Cliente cli in (Cliente_Todos)Session["Cliente_Todos"])
        {
            cli.Salvar();
        }

        MessageBox.Show("Usuario(s) cadastrado(s) corretamente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, System.Windows.Forms.MessageBoxOptions.DefaultDesktopOnly);
        Limpar();
        Response.Redirect("Apresentacao.aspx");
        //Preenche_Grid();
    }

    protected void grd_cli_OnRowDataBound(object sender, GridViewRowEventArgs e)
    { 
        //atribui "chave" a cada linha da grid para os templates criados:
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            ((LinkButton)e.Row.FindControl("lnk_editar")).ToolTip = e.Row.Cells[1].Text;
            ((LinkButton)e.Row.FindControl("lnk_excluir")).ToolTip = e.Row.Cells[1].Text;
        }
       
    }
    #endregion
}