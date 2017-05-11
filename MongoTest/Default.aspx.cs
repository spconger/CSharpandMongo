using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var mongo = new MongoClient();
        var db = mongo.GetDatabase("techStore");
        var productCollection= db.GetCollection<BsonDocument>("productCollection");
        var documents  = productCollection.Find(new BsonDocument()).ToList();
        List<string> productNames = new List<string>();
        foreach(var d in documents)
        {
            string prod = d.GetElement("product").ToString();
            int i = prod.IndexOf("=");
            prod = prod.Substring(i + 1);
            productNames.Add(prod);
            
            
        }
        GridView1.DataSource = productNames;
        GridView1.DataBind();

    }
}