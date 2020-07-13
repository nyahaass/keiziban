using keiziban.App_Start;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using System.Web.UI.HtmlControls;

namespace keiziban
{
    public partial class threadlist : System.Web.UI.Page
    {
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        ClsUtils utils = new ClsUtils();

        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = utils.NullChkString(Session["userid"]);

            if (!IsPostBack)
            {
                InitSettings();
                MakeThreadlistTable();
            }

        }


        private bool InitSettings()
        {
            string hzk = utils.NullChkString(Session["hzk"]);

            if (hzk.Length == 0)
            {
                this.txtDateFr.Text = DateTime.Now.ToString("yyyy/MM/dd");
                this.txtDateTo.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
            else
            {
                this.txtDateFr.Text = hzk.Insert(4, "/").Insert(7, "/");
                this.txtDateTo.Text = this.txtDateFr.Text;
            }

            return true;
        }

        private bool MakeThreadlistTable()
        {
            //テーブルの初期化
            this.tblListItems.Rows.Clear();
            //ヘッダー作成
            MakeThreadListTableHeader();
            //ボディ作成
            MakeThreadListTableBody();
            
            return true;
        }

        private bool MakeThreadListTableHeader()
        {
            ClsThreadList cThList = new ClsThreadList();
            var listitems = cThList.GetThreadListItems();
            TableRow r = new TableHeaderRow();
            TableCell c ;

            r.TableSection = TableRowSection.TableHeader;
            
            foreach (var listitem in listitems)
            {
                c = new TableCell();
                c.Text = listitem.item_name;
                c.Attributes["class"] = listitem.col_name;
                r.Cells.Add(c);
            }

           this. tblListItems.Rows.Add(r);
            
            return true;
        }

        private bool MakeThreadListTableBody()
        {
            return true;
        }
    }
}