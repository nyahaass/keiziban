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
    class USER
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
    }

    class ClsLogin
    {
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        ClsUtils utils = new ClsUtils();

        public USER chkLogin(string id, string pass)
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
                    return new USER();
                }

                USER user = new USER();

                user.user_id = utils.NullChkToInt(tb.Rows[0]["user_id"]);
                user.user_name = utils.NullChkString(tb.Rows[0]["user_name"]);

                return user;
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
            finally
            {
                db.Disconnect();
            }
            return  new USER();
        }
    }
}