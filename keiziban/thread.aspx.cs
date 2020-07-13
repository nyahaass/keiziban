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

            if (!ReadArticle(no))
            {

            }

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
            if (article is null) return false;

            this.hdnKanriNo.Value = utils.NullChkString(no);
            this.hdnUserNo.Value = utils.NullChkString(article.create_user);            

            this.txtTitle.Text = "タイトル名 : " + article.title_name;
            this.txtInfo.Text = "この記事は"　+ article.create_user + "さんにより " + article.create_date.ToString("yy年MM月dd日") + "に作成されました";

            this.txtThUser.Text = utils.NullChkString(article.create_user);
            this.txtThMsg.Text = utils.NullChkString(article.title_msg);
            this.txtThDate.Text = article.create_date.ToString("yy年MM月dd日");

            return true;

        }

        private bool ReadThread(int kno)
        {
            ClsThread cThread = new ClsThread();
            int threadno = cThread.GetThreadNo(kno);

            if (threadno == 0)
            {

            }
            else
            {

            }

            return true;

        }

        #region スレッド取得
        private bool GetThread(int kanrino, int threadno)
        {
            ClsThread cThread = new ClsThread();
            
            return true;
        }
        #endregion


        private bool PageNotFound()
        {
            Response.Redirect("notfound.aspx");
            return true;
        }

        private bool ThredNotFount()
        {
            this.lblTitle.Text = "スレッドに書き込みがありません";
            this.imgTitle.ImageUrl = "./img/nodata.png";
            return true;
        }

        #region 入力チェック
        private bool ChkReg()
        {
            if (this.txtInput.Text.Trim().Length == 0)
            {
                return false;

            }

            if (this.hdnThreadNo.Value.Length == 0)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region データ登録
        private bool RegData()
        {
            ClsThread cThread = new ClsThread();
            keiziban.App_Start.THREAD thread = GetRegData();


            cThread.InsThread(thread);

            return true;
        }
        #endregion

        #region データ登録の取得
        private keiziban.App_Start.THREAD  GetRegData()
        {
            keiziban.App_Start.THREAD thread = new keiziban.App_Start.THREAD();
            ClsThread cThread = new ClsThread();

            int threadno = utils.NullChkToInt(this.hdnThreadNo.Value);
            int kanrino = utils.NullChkToInt(this.hdnKanriNo.Value); ;
            int userno = utils.NullChkToInt(this.hdnUserNo.Value);
            int subno = cThread.GetSubNo(kanrino,threadno);

            thread.thread_msg = utils.NullChkString(this.txtInput.Text);


            if (subno == 0) subno++;
            if (threadno == 0) threadno++;

            thread.sub_no = subno;
            thread.kanri_no = kanrino;
            thread.thread_no = threadno;
            thread.user_id = userno;
            thread.create_date = DateTime.Now;
            thread.update_date = DateTime.Now;

            return thread;
        }
        #endregion

        #region スレッド番号の取得
        private int GetThreadNo(int kanrino)
        {

            ClsThread cThread = new ClsThread();
            int subno = cThread.GetThreadNo(kanrino);

            return subno;
        }
        #endregion

        #region スレッドサブ番号の取得
        private int GetSubNo(int kanrino, int threadno)
        {
            
            ClsThread cThread = new ClsThread();
            int subno = cThread.GetSubNo(kanrino, threadno);

            return subno;
        }
        #endregion

        protected void btnReg_Click(object sender, EventArgs e)
        {
            if (ChkReg())
            {
                return;
            }

            if (RegData())
            {
                return;
            }

            return;
        }
    }
}