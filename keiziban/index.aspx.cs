using keiziban.App_Start;
using System;

namespace keiziban
{
    public partial class index : System.Web.UI.Page
    {
        ClsUtils utils = new ClsUtils();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // ボタンイベント: ログインボタン押し時
        protected void btn_Login_Click(object sender, EventArgs e)
        {
            string id = utils.NullChkString(this.txtId.Text);
            string pass = utils.NullChkString(this.txtPass.Text);

            if (id.Length == 0)
            {
                // ユーザ名の入力がない場合はデフォルトページへ
                RedirectDefaultPage(); 
            }

            if (pass.Length == 0)
            {
                // パスワードの入力がない場合はデフォルトページへ
                RedirectDefaultPage();
            }
            //ログイン処理
            RegLogin(id, pass);
        }

        private void RedirectDefaultPage()
        {
            Response.Redirect("index.aspx");
        }

        private void RedirectMainPage()
        {
            Response.Redirect("main.aspx");
        }

        private void RegLogin(string id, string pass)
        {
            ClsLogin login = new ClsLogin();
            keiziban.App_Start.USER user = new keiziban.App_Start.USER();
            user = login.chkLogin(id, pass);

            if (user.user_id >=0)
            {
                //TODO:ログイン処理の実装
                Session["userid"] = user.user_id;
                Session["username"] = user.user_name;

                RedirectMainPage();
            }else
            {
                // 認証に失敗した場合はデフォルトページへ
                RedirectDefaultPage();
            }
            return;
        }
    }
}