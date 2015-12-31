using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library1;
using System.Windows.Forms;
using System.IO;

public partial class AreaTeste : System.Web.UI.Page
{
    ClsBancoDeDados oDB = new ClsBancoDeDados();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void button1_click(object sender, EventArgs e)
    { 
        string diretorio = "C:/Users/Danilo Moreira/Source/Repos/sistemareservasNew/SistemaReservas_vs2013_Entrega220815";
        SaveFileDialog janelaSalva = new SaveFileDialog();

        janelaSalva.InitialDirectory = diretorio;
        janelaSalva.Filter = "ArquivoTexto|*.text";

        //if (janelaSalva.ShowDialog() == DialogResult.OK)
        //{
            string arquivo = janelaSalva.FileName;
            StreamWriter sw = File.CreateText("C:/Users/Danilo Moreira/Source/Repos/sistemareservasNew/SistemaReservas_vs2013_Entrega220815/Teste2.txt");

            sw.WriteLine("Teste de arquivo em: " + DateTime.Now.ToString());
        //}

    }
}