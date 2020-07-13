using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using log4net;

namespace keiziban.App_Start
{
    class THREAD_LIST_ITEM
    {
        public int item_no { get; set; }
        public int seq_no { get; set; }
        public int view_no { get; set; }
        public string item_name { get; set; }
        public string col_name { get; set; }
    }
    
    class ClsThreadList
    {
        ClsUtils utils = new ClsUtils();
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public List<THREAD_LIST_ITEM> GetThreadListItems()
        {
            List<THREAD_LIST_ITEM> tlItems = new List<THREAD_LIST_ITEM>();
            StringBuilder strSql = new StringBuilder();
            ClsDb db = new ClsDb();
            DataTable tb;

            strSql.AppendLine("SELECT * FROM thread_item_mst");
            strSql.AppendLine("ORDER BY view_no");

            try
            {
                db.Connect();
                tb = db.ExecuteSql(strSql.ToString(), -1);

                foreach (DataRow dr in tb.Rows)
                {
                    THREAD_LIST_ITEM tlItem = new THREAD_LIST_ITEM();

                    tlItem.item_no = utils.NullChkToInt(dr["item_no"]);
                    tlItem.seq_no = utils.NullChkToInt(dr["seq_no"]);
                    tlItem.view_no = utils.NullChkToInt(dr["view_no"]);
                    tlItem.item_name = utils.NullChkString(dr["item_name"]);
                    tlItem.col_name = utils.NullChkString(dr["col_name"]);

                    tlItems.Add(tlItem);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
            finally
            {
                db.Disconnect();
            }

            return tlItems;
        }
    }
}