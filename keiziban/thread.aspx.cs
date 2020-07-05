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

            int no = utils.NullChkToInt(Request.QueryString["no"]);
            string userid = utils.NullChkString(Session["userid"]);
            

            if (no == 0)
            {
                PageNotFound();
            }

            ReadArticle(no);

            if (!IsPostBack)
            {
            
            }
            
        }

        private bool ReadArticle(int no)
        {
            ClsArticle db = new ClsArticle();
            var article = db.GetArticle(no);

            //this.rptListItems.DataSource = articles;
            //this.rptListItems.DataBind();
            if (article is null) return true;

            this.threadno.Value = utils.NullChkString(no);

            this.txtTitle.Text = "タイトル名 : " + article.title_name;
            this.txtInfo.Text = "この記事は"　+ article.create_user + "さんにより " + article.create_date.ToString("yy年MM月dd日") + "に作成されました";

            this.txtThUser.Text = utils.NullChkString(article.create_user);
            this.txtThMsg.Text = utils.NullChkString(article.title_msg);
            this.txtThDate.Text = article.create_date.ToString("yy年MM月dd日");

            return true;

        }

        private bool PageNotFound()
        {
            Response.Redirect("notfound.aspx");
            return true;
        }

        protected bool btnReg_Click(object sender, EventArgs e)
        {
            if (ChkReg())
            {
                return false;
            }

            if (RegData())
            {
                return true;
            }

            return true;

        }

        #region 入力チェック
        private bool ChkReg()
        {
            if (this.txtInput.Text.Trim().Length == 0)
            {
                return false;

            }

            if (this.threadno.Value.Length == 0)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region データ登録
        private bool RegData()
        {
            return true;
        }
        #endregion
    }
}