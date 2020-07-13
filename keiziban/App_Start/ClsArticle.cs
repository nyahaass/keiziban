using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using log4net;

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

    class ClsArticle
    {
        ClsUtils utils = new ClsUtils();
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public  List<ARTICLE> GetArticles()
        {
            List<ARTICLE> articles = new List<ARTICLE>();
            StringBuilder strSql = new StringBuilder();
            ClsDb db = new ClsDb();
            DataTable tb;

            strSql.AppendLine("SELECT * FROM article_title");
            strSql.AppendLine("ORDER BY create_date DESC");

            try
            {
                db.Connect();
                tb = db.ExecuteSql(strSql.ToString(), -1);

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

        public ARTICLE GetArticle(int no)
        {
            StringBuilder strSql = new StringBuilder();
            ClsDb db = new ClsDb();
            DataTable tb;

            strSql.AppendLine("SELECT * FROM article_title");
            strSql.AppendLine("WHERE kanri_no = " + utils.NullChkToInt(no));
            strSql.AppendLine("ORDER BY create_date DESC");

            try
            {
                db.Connect();
                tb = db.ExecuteSql(strSql.ToString(), -1);

                if (tb.Rows.Count == 0) return null;

                foreach (DataRow dr in tb.Rows)
                {
                    ARTICLE article = new ARTICLE();

                    article.kanri_no = utils.NullChkToInt(dr["kanri_no"]);
                    article.title_no = utils.NullChkToInt(dr["title_no"]);
                    article.title_name = utils.NullChkString(dr["title_name"]);
                    article.title_msg = utils.NullChkString(dr["title_msg"]);
                    article.create_user = utils.NullChkToInt(dr["create_user"]);

                    return article;
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

            return null;
        }

        internal List<CATEGORY> GetCategorys()
        {
            List<CATEGORY> categorys = new List<CATEGORY>();
            StringBuilder strSql = new StringBuilder();
            ClsDb db = new ClsDb();
            DataTable tb;

            strSql.AppendLine("SELECT * FROM category");
            strSql.AppendLine("ORDER BY category_id");

            try
            {
                db.Connect();
                tb = db.ExecuteSql(strSql.ToString(), -1);

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
            StringBuilder strSql = new StringBuilder();
            ClsDb db = new ClsDb();
            DataTable tb;

            strSql.AppendLine("INSERT INTO article_title");
            strSql.AppendLine("(title_no,");
            strSql.AppendLine("title_msg, ");
            strSql.AppendLine("title_name, ");
            strSql.AppendLine("create_user, ");
            strSql.AppendLine("create_Date) ");
            strSql.AppendLine("VALUES(");
            strSql.AppendLine(article.title_no.ToString());
            strSql.AppendLine(", '" + article.title_msg +"'");
            strSql.AppendLine(", '" + article.title_name + "'");
            strSql.AppendLine(", '" + article.create_user + "'");
            strSql.AppendLine(", '" + article.create_date + "'");
            strSql.AppendLine("')");

            try
            {
                db.Connect();
                tb = db.ExecuteSql(strSql.ToString(), -1);
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