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
        ClsUtils utils = new ClsUtils();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClsArticle db = new ClsArticle();
            var articles = db.GetArticles();

            this.rptListItems.DataSource = articles;
            this.rptListItems.DataBind();

            var category = db.GetCategorys();

            this.ddlMenu.DataSource = category;
            this.ddlMenu.DataValueField = "category_id";
            this.ddlMenu.DataTextField = "category_name";
            this.ddlMenu.DataBind();

            this.txtLogDate.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH時MM分");
        }

        #region ツイート：ボタン押し時
        protected void btnReg_Click(object sender, EventArgs e)
        {


            if (ChkArticle())
            {
                RegArticle();
            }

            return;
        }
        #endregion

        #region ツイート：チェック
        private bool ChkArticle()
        {
            string ddlno = utils.NullChkString(this.ddlMenu.SelectedValue);
            string input = utils.NullChkString(this.txtInput.Text);

            if (input.Length == 0)
            {
                return false;
            }

            if (ddlno is null)
            {
                return false;
            }
            return true;
        }
        #endregion


        #region ツイート: 登録
        private bool RegArticle()
        {
            keiziban.App_Start.ARTICLE tweet = new keiziban.App_Start.ARTICLE();
            ClsArticle article = new ClsArticle();

            tweet.create_user = utils.NullChkToInt(Session["user_id"]);
            tweet.create_date = DateTime.Now;
            return true;
        }
        #endregion

    }
}