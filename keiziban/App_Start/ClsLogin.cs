using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace keiziban.App_Start
{
    public class ClsLogin
    {

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

                db.Connect("localhost", "master", "sa", "", -1);
                tb = db.ExecuteSql(sql.ToString(), -1);

                if (tb.Rows.Count == 0)
                {
                    return false;
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                db.Disconnect();
            }

            return true;   
        }
    }
}