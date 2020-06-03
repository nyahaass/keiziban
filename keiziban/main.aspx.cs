using keiziban.App_Start;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace keiziban
{
    public partial class main : System.Web.UI.Page
    {
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            ClsDb db = new ClsDb();
            DataTable tb;
            db.Connect();
            tb = db.ExecuteSql("select * from article_title", -1);

            db.Disconnect();

            this.rptListItems.DataSource = tb;
            this.rptListItems.DataBind();
        }
    }
}