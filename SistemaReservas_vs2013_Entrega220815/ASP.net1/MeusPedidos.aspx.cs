using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Library1.BO;
using unirest_net.http;
using unirest_net.request;

public partial class MeusPedidos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_importar_Click(object sender, EventArgs e)
    {
        //string teste = JsonConvert.DeserializeObject<Cliente>(variavelJson);

        HttpResponse<string> jsonResponse = Unirest.post("http://httpbin.org/post")
        .header("accept", "application/json")
        .field("parameter", "value")
        .field("foo", "bar")
        .asJson<MyClass>();

        string resposta  = jsonResponse.Body; 

    }
}