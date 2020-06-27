using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using log4net;

namespace keiziban.App_Start
{

    class PROFILE
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string mail { get; set; }
        public string profile_message { get; set; }
    }

    class ClsUser
    {
        ClsUtils utils = new ClsUtils();
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public PROFILE GetUserProfile(int user_id)
        {

            StringBuilder strSql = new StringBuilder();
            ClsDb db = new ClsDb();
            DataTable tb;

            try
            {
                db.Connect();
                strSql.AppendLine("SELECT * FROM users WHERE user_id =" + user_id);
                tb = db.ExecuteSql(strSql.ToString() , -1);

                if (tb.Rows.Count >0)
                {
                    PROFILE user = new PROFILE();

                    user.user_name = utils.NullChkString(tb.Rows[0]["user_name"]);
                    user.mail = utils.NullChkString(tb.Rows[0]["email"]);
                    user.profile_message = utils.NullChkString(tb.Rows[0]["profile_message"]);

                    return user;

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

            return new PROFILE();
        }

        public bool InsProfile(PROFILE user)
        {
            StringBuilder strSql = new StringBuilder();
            ClsDb db = new ClsDb();

            try
            {
                strSql.AppendLine("UPDATE users SET user_name =  '" + user.user_name);
                strSql.AppendLine("',email = '" + user.mail);
                strSql.AppendLine("', profile_message = '" + user.profile_message);
                strSql.AppendLine("' WHERE user_id = " + user.user_id);

                db.Connect();
                db.ExecuteSql(strSql.ToString() , -1);                                     

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