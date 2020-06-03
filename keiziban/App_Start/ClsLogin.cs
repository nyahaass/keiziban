using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Runtime.Remoting.Messaging;
using log4net;

namespace keiziban.App_Start
{
    public class ClsLogin
    {
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool chkLogin(string id, string pass)
        {
            ClsDb db = new ClsDb();
            DataTable tb;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM users");
                sql.AppendLine("WHERE user_id = " + id);
                sql.AppendLine("AND password = " +pass);

                db.Connect();
                tb = db.ExecuteSql(sql.ToString(), -1);

                if (tb.Rows.Count == 0)
                {
                    return false;
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
            return true;   
        }
    }
}