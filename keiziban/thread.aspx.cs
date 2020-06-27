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
    public partial class thread : System.Web.UI.Page
    {
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        ClsUtils utils = new ClsUtils();

        protected void Page_Load(object sender, EventArgs e)
        {

            string no = utils.NullChkString(Request.QueryString["no"]);

            ReadArticle();

            if (no.Length == 0)
            {
                PageNotFound();
            }
            if (!IsPostBack)
            {
            
            }
            
        }

        private bool ReadArticle()
        {
            ClsArticle db = new ClsArticle();
            var articles = db.GetArticles();

            this.rptListItems.DataSource = articles;
            this.rptListItems.DataBind();

            return true;

        }

        private bool PageNotFound()
        {

            return true;
        }
    }
}