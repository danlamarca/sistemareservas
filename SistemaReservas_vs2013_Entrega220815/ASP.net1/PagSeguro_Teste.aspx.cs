using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Net;
using System.Text;


public partial class PagSeguro_Teste : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Recupera_Nova_Sessao()
    {//tecnlogia WebClient

        string username = "john";
        string referer = "myprogram";
        string urlAddress = "http://www.yoursite.tld/somepage.php";

        using (WebClient client = new WebClient())
        {
            NameValueCollection postData = new NameValueCollection() 
           { 
                  { "username", username },  //order: {"parameter name", "parameter value"}
                  { "referer", referer }
           };

            // client.UploadValues returns page's source as byte array (byte[])
            // so it must be transformed into a string
            string pagesource = Encoding.UTF8.GetString(client.UploadValues(urlAddress, postData));
        }
    }
}