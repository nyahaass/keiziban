using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using log4net;

namespace keiziban.App_Start
{

    class PROFILE
    {
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


            ClsDb db = new ClsDb();
            DataTable tb;

            try
            {
                db.Connect();
                tb = db.ExecuteSql("select * from users where user_id = " + user_id, -1);

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
    }
}