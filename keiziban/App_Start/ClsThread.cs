using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using log4net;

namespace keiziban.App_Start
{
    class CATEGORY
    {
        public int category_id { get; set; }
        public string category_name { get; set; }
    }

    class THREAD
    {
        public int thread_no { get; set; }
        public int kanri_no { get; set; }
        public int sub_no { get; set; }
        public int user_id { get; set; }
        public int good_count { get; set; }
        public string thread_msg { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
    }
    
    class ClsThread
    {
        ClsUtils utils = new ClsUtils();
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public List<THREAD> GetThreadItems(int kno, int tno)
        {
            List<THREAD> titems = new List<THREAD>();
            StringBuilder strSql = new StringBuilder();
            ClsDb db = new ClsDb();
            DataTable tb;

            strSql.AppendLine("SELECT * FROM thread");
            strSql.AppendLine("WHERE thread_no = " + tno);
            strSql.AppendLine("AND kanri_no = " + kno);
            strSql.AppendLine("ORDER BY sub_no DESC");

            try
            {
                db.Connect();
                tb = db.ExecuteSql(strSql.ToString(), -1);

                foreach (DataRow dr in tb.Rows)
                {
                    THREAD titem = new THREAD();

                    titem.thread_no = utils.NullChkToInt(dr["thread_no"]);
                    titem.kanri_no = utils.NullChkToInt(dr["kanri_no"]);
                    titem.user_id = utils.NullChkToInt(dr["user_id"]);
                    titem.good_count = utils.NullChkToInt(dr["good_count"]);
                    titem.sub_no = utils.NullChkToInt(dr["sub_no"]);
                    titem.create_date = (DateTime)dr["create_Date"];
                    titem.update_date = (DateTime)dr["update_date"];
                    titem.thread_msg = utils.NullChkString(dr["thread_msg"]);

                    titems.Add(titem);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                return titems;
            }
            finally
            {
                db.Disconnect();
            }

            return titems;
        }
        public bool InsThread(THREAD thread)
        {
            StringBuilder strSql = new StringBuilder();
            ClsDb db = new ClsDb();

            strSql.AppendLine("INSERT INTO thread");
            strSql.AppendLine("( thread_no");
            strSql.AppendLine(", kanri_no");
            strSql.AppendLine(", sub_no");
            strSql.AppendLine(", user_id");
            strSql.AppendLine(", good_count");
            strSql.AppendLine(", create_date ");
            strSql.AppendLine(", update_date");
            strSql.AppendLine(", thread_msg");
            strSql.AppendLine(") ON EXISTING UPDATE VALUES");
            strSql.AppendLine("(" + thread.thread_no);
            strSql.AppendLine("," + thread.kanri_no);
            strSql.AppendLine("," + thread.sub_no);
            strSql.AppendLine("," + thread.user_id);
            strSql.AppendLine("," + thread.good_count);
            strSql.AppendLine(",'" + thread.create_date + "'");
            strSql.AppendLine(",'" + thread.update_date + "'");
            strSql.AppendLine(",'" + thread.thread_msg + "'");
            strSql.AppendLine(")");

            try
            {
                db.Connect();
                db.ExecuteNonQuery(strSql.ToString());

            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
            finally
            {
                db.Disconnect();
            }
            return true;
        }

        //スレッド番号を返す
        //データがない場合は0を返す
        public int GetThreadNo(int kanri_no)
        {
            StringBuilder strSql = new StringBuilder();
            ClsDb db = new ClsDb();
            DataTable tb;

            strSql.AppendLine("SELECT TOP 1  thread_no FROM thread");
            strSql.AppendLine("WHERE kanri_no = " + kanri_no);            
            strSql.AppendLine("ORDER BY sub_no DESC");

            try
            {
                db.Connect();
                tb = db.ExecuteSql(strSql.ToString(), -1);

                if (tb.Rows.Count > 0)
                {
                    return utils.NullChkToInt(tb.Rows[0]["thread_no"]);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                return 0;
            }
            finally
            {
                db.Disconnect();
            }

            return 0;
        }

        //スレッドのサブ番号を返す
        //データがない場合は0を返す
        public int GetSubNo(int kanri_no , int thread_no)
        {
            StringBuilder strSql = new StringBuilder();
            ClsDb db = new ClsDb();
            DataTable tb;

            strSql.AppendLine("SELECT TOP 1  sub_no FROM thread");
            strSql.AppendLine("WHERE thread_no = " + thread_no);
            strSql.AppendLine("AND kanri_no = " + kanri_no);
            strSql.AppendLine("ORDER BY sub_no DESC");

            try
            {
                db.Connect();
                tb = db.ExecuteSql(strSql.ToString(), -1);

                if (tb.Rows.Count >0)
                {
                    return utils.NullChkToInt(tb.Rows[0]["sub_no"]);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                return 0;
            }
            finally
            {
                db.Disconnect();
            }

            return 0;
        }
    }
}