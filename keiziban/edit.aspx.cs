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
    public partial class edit : System.Web.UI.Page
    {
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        ClsUtils utils = new ClsUtils();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtEditDate.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH時MM分");
            ReadProfile();
        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            if (ChkProfile())
            {
                RegProfile();
            }

            return;
        }

        #region プロファイル更新：データチェック
        private bool ChkProfile()
        {
            string name = this.txtName.Text;

            if (name.Length == 0)
            {
                return false;

            }

            return true;
        }
        #endregion


        #region プロファイル更新: 更新
        private bool RegProfile()
        {
            keiziban.App_Start.PROFILE profile = new keiziban.App_Start.PROFILE();
            ClsUser cUser = new ClsUser();

            profile.user_id = utils.NullChkToInt(Session["userid"]);
            profile.user_name = utils.NullChkString(this.txtName.Text);
            profile.mail = utils.NullChkString(this.txtMail.Text);
            profile.profile_message = utils.NullChkString(this.txtProfile.Text);

            cUser.InsProfile(profile);
            ReadProfile();
            return true;
        }
        #endregion

        private bool ReadProfile()
        {

            ClsUser cUser = new ClsUser();
            int user_id = utils.NullChkToInt(Session["userid"]);
            var user = cUser.GetUserProfile(user_id);

            this.txtName.Text = user?.user_name ?? String.Empty;
            this.txtMail.Text = user?.mail ?? String.Empty;
            this.txtProfile.Text = user?.profile_message ?? String.Empty;






            return true;

        }

    }
}