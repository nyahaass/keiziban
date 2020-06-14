using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using log4net;

namespace keiziban.App_Start
{


    class CATEGORY
    {
        public int category_id { get; set; }
        public string category_name { get; set; }
    }

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

    class ClsArticle
    {


        ClsUtils utils = new ClsUtils();
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public  List<ARTICLE> GetArticles()
        {
            List<ARTICLE> articles = new List<ARTICLE>();

            ClsDb db = new ClsDb();
            DataTable tb;

            try
            {
                db.Connect();
                tb = db.ExecuteSql("select * from article_title order by create_date desc", -1);

                foreach (DataRow dr in tb.Rows)
                {
                    ARTICLE article = new ARTICLE();

                    article.kanri_no = utils.NullChkToInt(dr["kanri_no"]);
                    article.title_no = utils.NullChkToInt(dr["title_no"]);
                    article.title_name = utils.NullChkString(dr["title_name"]);
                    article.title_msg = utils.NullChkString(dr["title_msg"]);
                    article.create_user = utils.NullChkToInt(dr["create_user"]);

                    articles.Add(article);

                }
            }
            catch(Exception ex) 
            { 
                log.Error(ex.ToString());
            }
            finally
            {
                db.Disconnect();
            }

            return articles;
        }

        internal List<CATEGORY> GetCategorys()
        {
            List<CATEGORY> categorys = new List<CATEGORY>();

            ClsDb db = new ClsDb();
            DataTable tb;

            try
            {
                db.Connect();
                tb = db.ExecuteSql("select * from category order by category_id", -1);

                foreach (DataRow dr in tb.Rows)
                {
                    CATEGORY category = new CATEGORY();

                    category.category_id = utils.NullChkToInt(dr["category_id"]);
                    category.category_name = utils.NullChkString(dr["category_name"]);

                    categorys.Add(category);
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

            return categorys;
        }

        public bool InsArticle(ARTICLE article)
        {

            ClsDb db = new ClsDb();
            DataTable tb;

            try
            {
                db.Connect();
                tb = db.ExecuteNonSql("insert into article_title (title_no,title_msg,title_name,create_user,create_Date) " +
                                    "values(" + article.title_no + ",'" + article.title_msg + "','" + article.title_name + "'," + article.create_user + ",'" + article.create_date+ "')", -1);

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