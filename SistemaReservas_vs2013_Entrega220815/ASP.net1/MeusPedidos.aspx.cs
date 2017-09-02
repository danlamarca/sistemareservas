using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using unirest_net.http;


public partial class MeusPedidos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string json=String.Empty;

        HttpResponse<string> jsonResponse = Unirest.post("http://httpbin.org/post")
        .header("accept", "application/json")
        .field("parameter", "value")
        .field("foo", "bar")
        .asJson<json>();

        string retorno = jsonResponse.Body;
        Dictionary<string,string> retorno2 = jsonResponse.Headers;
    }
}