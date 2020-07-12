using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using log4net;
using System.Data.SqlClient;

namespace keiziban.App_Start
{
    public class ClsDb
    {
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// SQLコネクション
        /// </summary>
        private OdbcConnection _con = null;

        /// <summary>
        /// トランザクション・オブジェクト
        /// </summary>
        /// <remarks></remarks>
        private OdbcTransaction _trn = null;

        /// <summary>
        /// DB接続
        /// </summary>
        /// <remarks></remarks>
        public void Connect()
        {
            try
            {
                if (_con == null)
                {
                    _con = new OdbcConnection();
                }

                String cst = ConfigurationManager.AppSettings["dbConStr"]; 
                if (cst.Length == 0)
                {
                    return ;
                }

                _con.ConnectionString = cst;
               _con.Open();

            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        /// <summary>
        /// DB切断
        /// </summary>
        public void Disconnect()
        {
            try
            {
                _con.Close();

            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        /// <summary>
        /// SQLの実行
        /// </summary>
        /// <param name="sql">SQL文</param>
        /// <param name="tot">タイムアウト値</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DataTable ExecuteSql(String sql, int tot)
        {
            DataTable dt = new DataTable();

            try
            {
                OdbcCommand sqlCommand = new OdbcCommand(sql, _con, _trn);

                if (tot > -1)
                {
                    sqlCommand.CommandTimeout = tot;
                }

                OdbcDataAdapter adapter = new OdbcDataAdapter(sqlCommand);

                adapter.Fill(dt);
                adapter.Dispose();
                sqlCommand.Dispose();

               

            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }

            return dt;
        }

        public bool ExecuteNonQuery(string sql)
        {
            // 接続文字列の取得
            var connectionString = ConfigurationManager.AppSettings["dbConStr"];

            if (sql.Length == 0) return true;

            using (var connection = new OdbcConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    // データベースの接続開始
                    connection.Open();

                    // SQLの準備
                    command.CommandText = sql;


                    // SQLの実行
                    command.ExecuteNonQuery();

                    return true;
                }
                catch (Exception exception)
                {
                    log.Error(exception.ToString());
                    return false;
                }
                finally
                {
                    // データベースの接続終了
                    connection.Close();
                }
            }
        }

            /// <summary>
            /// トランザクション開始
            /// </summary>
            /// <remarks></remarks>
            public void BeginTransaction()
        {
            try
            {
                _trn = _con.BeginTransaction();

            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }

        /// <summary>
        /// コミット
        /// </summary>
        /// <remarks></remarks>
        public void CommitTransaction()
        {
            try
            {
                if (_trn != null)
                {
                    _trn.Commit();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());

            }
            finally
            {
                _trn = null;
            }
        }

        /// <summary>
        /// ロールバック
        /// </summary>
        /// <remarks></remarks>
        public void RollbackTransaction()
        {
            try
            {
                if (_trn != null)
                {
                    _trn.Rollback();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
            finally
            {
                _trn = null;
            }
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        /// <remarks></remarks>
        ~ClsDb()
        {
            Disconnect();
        }
    }
}