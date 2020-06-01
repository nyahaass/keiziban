using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace keiziban.App_Start
{
    class ARTICLE
    {
        public int kanri_no { get; set; }
        public int title_no { get; set; }
        public string title_name { get; set; }
        public string title_msg { get; set; }
        public int create_user { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_time { get; set; }
    }

    public class ClsArticle
    {

        ClsUtils utils = new ClsUtils();

        internal List<ARTICLE> GetArticles()
        {
            List<ARTICLE> articles = new List<ARTICLE>();

            ClsDb db = new ClsDb();
            DataTable tb;
            try
            {
                db.Connect("localhost", "master", "sa", "", -1);
                tb = db.ExecuteSql("select * from article_title order by create_date desc", -1);

                foreach (DataRow dr in tb.Rows)
                {
                    ARTICLE article = new ARTICLE();

                    article.kanri_no = utils.NullChkToInt(dr["kanri_no"]);
                    article.title_no = utils.NullChkToInt(dr["title_no"]);
                    article.title_name = utils.NullChkString(dr["title_name"]);
                    article.title_msg = utils.NullChkString(dr["title_msg"]);
                    article.create_user = utils.NullChkToInt(dr["create_user"]);

                }
            }catch(Exception e)
            {

            }finally
            {
                db.Disconnect();
            }
            return articles;
        }
    }


}