using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
/// <summary>
/// Summary description for DBM
/// </summary>

public class DBM : IDisposable
{
    const string PREFIX_VARIABLE_SQL = "@";
    private string strConnect = ConfigurationManager.AppSettings["MSSQL"].ToString();

    private SqlConnection SqlConn;
    private SqlTransaction SqlTransac;

    public int Timeout { set; get; }

    public DBM()
    {
        SqlConn = new SqlConnection(strConnect);
    }

    public string[] blackList = { "--", ";--", ";", "char", "nchar", "varchar", "nvarchar", "alter", "begin", "cast", "create", "cursor", "declare", "delete", "drop", "end", "exec", "execute", "fetch", "insert", "kill", "open", "select", "sys", "sysobjects", "syscolumns", "table", "update" };
    public string CheckInput(string parameter)
    {
        string output = parameter;
        for (int i = 0; i < blackList.Length; i++)
        {
            if ((output.IndexOf(blackList[i], StringComparison.OrdinalIgnoreCase) >= 0))
            {
                output = output.Replace(blackList[i], "");
            }
        }
        return output;
    }
    public void SetConnection(string ConnectionMode, string strConnetion)
    {
        SqlConn = new SqlConnection(strConnetion);
    }

    public SqlConnection getConnection()
    {
        return SqlConn;
    }

    public void OpenConnection()
    {
        if (SqlConn.State != ConnectionState.Open)
            SqlConn.Open();
    }

    public void CloseConnection()
    {
        if (SqlTransac == null)
        {
            if (SqlConn.State != ConnectionState.Closed)
                SqlConn.Close();
        }
    }

    public void BeginTransac()
    {
        if (SqlConn.State != ConnectionState.Open)
            SqlConn.Open();
        SqlTransac = SqlConn.BeginTransaction();
    }

    public void CommitTransac()
    {
        if (SqlTransac != null)
        {
            SqlTransac.Commit();
            SqlTransac = null;
        }
        if (SqlConn.State != ConnectionState.Closed)
            SqlConn.Close();
    }

    public void RollBackTransac()
    {
        if (SqlTransac != null)
        {
            SqlTransac.Rollback();
            SqlTransac = null;
        }
        if (SqlConn.State != ConnectionState.Closed)
            SqlConn.Close();
    }

    private SqlCommand createSqlCommand(string storeName, Hashtable ht)
    {
        using (var scmCmdToExecute = new SqlCommand(storeName, SqlConn))
        {
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            if (SqlTransac != null)
                scmCmdToExecute.Transaction = SqlTransac;

            if (ht != null)
                foreach (DictionaryEntry item in ht)
                    scmCmdToExecute.Parameters.Add(new SqlParameter(PREFIX_VARIABLE_SQL + item.Key, item.Value ?? System.DBNull.Value));

            scmCmdToExecute.CommandTimeout = 50000;
            return scmCmdToExecute;
        }
    }

    private SqlCommand createSqlCommand(string sql)
    {
        using (var scmCmdToExecute = new SqlCommand(sql, SqlConn, SqlTransac))
        {
            scmCmdToExecute.CommandType = CommandType.Text;
            return scmCmdToExecute;
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        CloseConnection();
        if (null != SqlConn)
            SqlConn.Dispose();
    }

    // Thuc hien nay du lieu tu CSDL
    // annv sửa lại bỏ phần dispose
    #region GetdataSet
    /// <summary>
    ///lấy dataset
    /// </summary>
    /// <param name="sql">chuỗi</param>
    /// <returns></returns>
    public DataSet getDataSet(string sql)
    {
        using (var dt = new DataSet())
        {
            using (SqlCommand scmCmdToExecute = createSqlCommand(sql))
            {
                try
                {
                    // Execute query.
                    using (var dad = new SqlDataAdapter(scmCmdToExecute))
                    {
                        dad.Fill(dt);
                    }
                }
                catch
                {
                    throw;
                }
            }
            return dt;
        }
    }

    public DataSet getDataSet(string storeName, Hashtable _htd)
    {
        using (var ds = new DataSet())
        {
            using (SqlCommand scmCmdToExecute = createSqlCommand(storeName, _htd))
            {
                try
                {
                    using (var dad = new SqlDataAdapter(scmCmdToExecute))
                    {
                        dad.Fill(ds);
                    }
                }
                catch
                {
                    throw;
                }
            }

            return ds;
        }
    }

    public DataSet GetDataSet(string storeName, Hashtable _htd, ref string error)
    {
        using (var ds = new DataSet())
        {
            using (SqlCommand scmCmdToExecute = createSqlCommand(storeName, _htd))
            {
                try
                {
                    using (var dad = new SqlDataAdapter(scmCmdToExecute))
                    {
                        dad.Fill(ds);
                    }
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }
            }
            return ds;
        }
    }

    public DataSet GetDataSet(string sql, ref string error)
    {
        using (var ds = new DataSet())
        {
            using (SqlCommand scmCmdToExecute = createSqlCommand(sql))
            {
                try
                {
                    using (var dad = new SqlDataAdapter(scmCmdToExecute))
                    {
                        dad.Fill(ds);
                    }
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }
            }
            return ds;
        }
    }

    private DataSet getDataSet(string tableName, string Where, string orderBy)
    {
        using (var dt = new DataSet())
        {
            string storeName = "select * from " + tableName + ((Where.Length > 0) ? " where " + Where : "") + ((orderBy.Length > 0) ? " order by " + orderBy : "");
            using (SqlCommand scmCmdToExecute = createSqlCommand(storeName))
            {
                using (var dad = new SqlDataAdapter(scmCmdToExecute))
                {
                    try
                    {
                        dad.Fill(dt);
                    }
                    catch
                    {
                    }
                }
            }
            return dt;
        }
    }

    private DataSet getDataSet(int top, string tableName, string Where, string orderBy)
    {
        using (var dt = new DataSet())
        {
            string storeName = "select top " + top + "  * from " + tableName + ((Where.Length > 0) ? " where " + Where : "") + ((orderBy.Length > 0) ? " order by " + orderBy : "");
            using (SqlCommand scmCmdToExecute = createSqlCommand(storeName))
            {
                using (var dad = new SqlDataAdapter(scmCmdToExecute))
                {
                    try
                    {
                        dad.Fill(dt);
                    }
                    catch
                    {
                    }
                }
            }
            return dt;
        }
    }

    private DataSet getDataSet(string tableName, string[] fields, string Where, string orderBy)
    {
        using (var dt = new DataSet())
        {
            string field = (fields.Length > 0) ? string.Join(",", fields) : "*";

            string storeName = "select   " + field + "  from " + tableName + ((Where.Length > 0) ? " where " + Where : "") + ((orderBy.Length > 0) ? " order by " + orderBy : "");
            using (SqlCommand scmCmdToExecute = createSqlCommand(storeName))
            {
                using (var dad = new SqlDataAdapter(scmCmdToExecute))
                {
                    try
                    {
                        dad.Fill(dt);
                    }
                    catch
                    {
                    }
                }
            }
            return dt;
        }
    }

    private DataSet getDataSet(int top, string tableName, string[] fields, string Where, string orderBy)
    {
        using (var dt = new DataSet())
        {
            string field = (fields.Length > 0) ? string.Join(",", fields) : "*";
            string storeName = "select top " + top + "  " + field + "  from " + tableName + ((Where.Length > 0) ? " where " + Where : "") + ((orderBy.Length > 0) ? " order by " + orderBy : "");
            using (SqlCommand scmCmdToExecute = createSqlCommand(storeName))
            {
                using (var dad = new SqlDataAdapter(scmCmdToExecute))
                {
                    try
                    {
                        dad.Fill(dt);
                    }
                    catch
                    {
                    }
                }
            }
            return dt;
        }
    }

    private DataSet getDataSet(string tableName, string[] fields, string whereSql, string orderBySql, int pageIndex, int pageSize)
    {
        using (var dt = new DataSet())
        {
            string _fields = (fields.Length > 0) ? string.Join(",", fields) : "*";
            if (pageSize <= 0)
                throw new InvalidCastException("pageSize is incorect");

            if (string.IsNullOrEmpty(orderBySql))
                throw new InvalidCastException("orderBySql not set");

            string _where = !string.IsNullOrEmpty(whereSql) ? (" WHERE " + whereSql) : "";
            int _totalCount = pageSize * (pageIndex);
            int _prevCount = pageSize * (pageIndex - 1);
            string _sql = "SELECT {1} FROM (SELECT TOP {0} {1}, ROW_NUMBER()"
                    + " OVER(order by {2}) AS {3} FROM {4} {5}) AS {6} WHERE {3} > {7}";

            _sql = string.Format(_sql, _totalCount, _fields, orderBySql, "RowIndex",
                    tableName, _where, tableName + "_Temp", _prevCount);
            using (SqlCommand scmCmdToExecute = createSqlCommand(_sql))
            {
                using (var dad = new SqlDataAdapter(scmCmdToExecute))
                {
                    try
                    {
                        dad.Fill(dt);
                    }
                    catch
                    {
                    }
                }
            }
            return dt;
        }
    }

    #endregion

    public DataTable GetDataTable(string sql)
    {
        using (DataSet ds = getDataSet(sql))
        {
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
        }
        using (var dt1 = new DataTable())
        {
            return dt1;
        }
    }

    public DataTable GetDataTable(string storeName, ref string error)
    {
        using (DataSet ds = GetDataSet(storeName, ref error))
        {
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
        }
        using (var dt1 = new DataTable())
        {
            return dt1;
        }
    }

    public DataTable GetDataTable(string storeName, Hashtable _htd)
    {
        using (DataSet ds = getDataSet(storeName, _htd))
        {
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
        }
        using (var dt1 = new DataTable())
        {
            return dt1;
        }
    }

    public DataTable GetDataTable(string storeName, Hashtable _htd, ref string error)
    {
        using (DataSet ds = GetDataSet(storeName, _htd, ref error))
        {
            if (!string.IsNullOrEmpty(error))
                return new DataTable();

            if (ds.Tables.Count > 0)
                return ds.Tables[0];
        }
        using (var dt1 = new DataTable())
        {
            return dt1;
        }
    }
    public DataTable GetDataTable(string tableName, string Where, string orderBy)
    {
        using (DataSet ds = getDataSet(tableName, Where, orderBy))
        {
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
        }
        using (var dt1 = new DataTable())
        {
            return dt1;
        }
    }
    public DataTable GetDataTable(int top, string tableName, string Where, string orderBy)
    {
        using (DataSet ds = getDataSet(top, tableName, Where, orderBy))
        {
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
        }
        using (var dt1 = new DataTable())
        {
            return dt1;
        }
    }

    public DataTable GetDataTable(string tableName, string[] fields, string Where, string orderBy)
    {
        using (DataSet ds = getDataSet(tableName, fields, Where, orderBy))
        {
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
        }
        using (var dt1 = new DataTable())
        {
            return dt1;
        }

    }

    public DataTable GetDataTable(int top, string tableName, string[] fields, string Where, string orderBy)
    {
        using (DataSet ds = getDataSet(top, tableName, fields, Where, orderBy))
        {
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
        }
        using (var dt1 = new DataTable())
        {
            return dt1;
        }
    }

    public DataTable GetDataTable(string tableName, string[] fields, string whereSql, string orderBySql, int pageIndex, int pageSize)
    {
        using (DataSet ds = getDataSet(tableName, fields, whereSql, orderBySql, pageIndex, pageSize))
        {
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
        }
        using (var dt1 = new DataTable())
        {
            return dt1;
        }
    }

    #region GetdIDataReader
    public IDataReader GetDataReader(string sql)
    {
        SqlDataReader ds = null;
        using (SqlCommand scmCmdToExecute = createSqlCommand(sql))
        {
            try
            {

                //SqlDataAdapter dad = new SqlDataAdapter(scmCmdToExecute);
                //dad.Fill(ds);
                //dad.Dispose();
                OpenConnection();
                ds = scmCmdToExecute.ExecuteReader(CommandBehavior.CloseConnection);
                //scmCmdToExecute.Dispose();
            }
            catch
            {
                //RollBackTransac();
                //throw new Exception("Error occured." + sql, ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        return ds;
    }

    public IDataReader GetDataReader(string storeName, Hashtable _htd)
    {
        IDataReader ds = null;
        using (SqlCommand scmCmdToExecute = createSqlCommand(storeName, _htd))
        {
            try
            {
                //SqlDataAdapter dad = new SqlDataAdapter(scmCmdToExecute);
                //dad.Fill(ds);
                //dad.Dispose();
                OpenConnection();
                ds = scmCmdToExecute.ExecuteReader(CommandBehavior.CloseConnection);
                //scmCmdToExecute.Dispose();
            }
            catch
            {
                //RollBackTransac();
                //throw new Exception("Error occured." + storeName, ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        return ds;
    }

    public IDataReader GetDataReader(string tableName, string Where, string orderBy)
    {
        using (DataSet ds = getDataSet(tableName, Where, orderBy))
        {
            return ds.CreateDataReader();
        }
    }

    public IDataReader GetDataReader(int top, string tableName, string Where, string orderBy)
    {
        using (DataSet ds = getDataSet(top, tableName, Where, orderBy))
        {
            return ds.CreateDataReader();
        }
    }

    public IDataReader GetDataReader(string tableName, string[] fields, string Where, string orderBy)
    {
        using (DataSet ds = getDataSet(tableName, fields, Where, orderBy))
        {
            return ds.CreateDataReader();
        }
    }

    public IDataReader GetDataReader(int top, string tableName, string[] fields, string Where, string orderBy)
    {
        using (DataSet ds = getDataSet(top, tableName, fields, Where, orderBy))
        {
            return ds.CreateDataReader();
        }
    }

    #endregion
    public string GetField(string storeName, Hashtable _htd)
    {
        string feil = string.Empty;
        using (SqlCommand scmCmdToExecute = createSqlCommand(storeName, _htd))
        {
            try
            {
                OpenConnection();
                object obj = scmCmdToExecute.ExecuteScalar();
                if (obj != null)
                    feil = Convert.ToString(obj);
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally
            {
                CloseConnection();
            }
        }
        return feil;
    }
    public string GetField(string storeName, Hashtable _htd, ref string message)
    {
        string feil = string.Empty;
        using (SqlCommand scmCmdToExecute = createSqlCommand(storeName, _htd))
        {
            try
            {
                OpenConnection();
                object obj = scmCmdToExecute.ExecuteScalar();
                if (obj != null)
                    feil = Convert.ToString(obj);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                CloseConnection();
            }
        }
        return feil;
    }
    public string GetField(string tableName, string fieldName, string where)
    {
        string feil = string.Empty;
        string sql = "select " + ((fieldName.Length > 0) ? fieldName : " top 1 * ") + " from " + CheckInput(tableName) + ((where.Length > 0) ? " where " + CheckInput(where) : "");
        using (SqlCommand scmCmdToExecute = createSqlCommand(sql))
        {
            try
            {
                OpenConnection();

                object obj = scmCmdToExecute.ExecuteScalar();
                if (obj != null)
                    feil = Convert.ToString(obj);
            }
            catch
            {
                //RollBackTransac();
                ////throw new Exception("Error occured." + sql, ex);
            }
            finally
            {
                CloseConnection();
                //scmCmdToExecute.Dispose();
            }
        }
        return feil;
    }

    public string GetField(string sql)
    {
        string feil = string.Empty;
        using (SqlCommand scmCmdToExecute = createSqlCommand(sql))
        {
            try
            {
                OpenConnection();
                object obj = scmCmdToExecute.ExecuteScalar();
                if (obj != null)
                    feil = Convert.ToString(obj);

            }
            catch
            {
                //RollBackTransac();
                ////throw new Exception("Error occured." + sql, ex);
            }
            finally
            {
                CloseConnection();
                //scmCmdToExecute.Dispose();
            }
        }

        return feil;
    }

    public bool CallStore(string storeName, Hashtable _htd)
    {
        bool ck = false;
        using (SqlCommand scmCmdToExecute = new SqlCommand(storeName, SqlConn))
        {
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            if (SqlTransac != null)
                scmCmdToExecute.Transaction = SqlTransac;
            foreach (DictionaryEntry Item in _htd)
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key.ToString(), (Item.Value == null) ? System.DBNull.Value : Item.Value));
            }

            try
            {
                if (SqlConn.State == ConnectionState.Closed)
                    SqlConn.Open();
                scmCmdToExecute.ExecuteNonQuery();
                ck = true;
            }

            catch
            {
                //RollBackTransac();
                ////throw new Exception("Error occured: " + storeName, ex);
            }
            finally
            {
                CloseConnection();
                //scmCmdToExecute.Dispose();
            }
        }
        return ck;
    }

    public string CallStore(string err, string storeName, Hashtable _htd)
    {
        string strErr = "";
        using (SqlCommand scmCmdToExecute = new SqlCommand(storeName, SqlConn))
        {
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            if (SqlTransac != null)
                scmCmdToExecute.Transaction = SqlTransac;
            foreach (DictionaryEntry Item in _htd)
            {
                scmCmdToExecute.Parameters.Add(new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key.ToString(), (Item.Value == null) ? System.DBNull.Value : Item.Value));
            }
            try
            {
                if (SqlConn.State == ConnectionState.Closed)
                    SqlConn.Open();
                scmCmdToExecute.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //RollBackTransac();
                strErr = "Lỗi:" + ex.ToString();
            }
            finally
            {
                CloseConnection();
                //scmCmdToExecute.Dispose();
            }
        }

        return strErr;
    }

    public string Update(string objectName, string tableName, Hashtable _htd, string whereID)
    {
        string strRS = "";
        string sql = "update " + CheckInput(tableName) + " set ";
        int _count = 0;
        foreach (DictionaryEntry Item in _htd)
        {
            sql += ((_count > 0) ? ", " : "") + Item.Key.ToString().Replace("@", "") + " = " + PREFIX_VARIABLE_SQL + Item.Key.ToString();
            _count++;
        }
        sql += (whereID.Length > 0) ? " where  " + CheckInput(whereID) : "";
        using (SqlCommand scmCmdToExecute = new SqlCommand(sql, SqlConn))
        {
            if (SqlTransac != null)
                scmCmdToExecute.Transaction = SqlTransac;
            scmCmdToExecute.CommandType = CommandType.Text;

            foreach (DictionaryEntry Item in _htd)
            {
                scmCmdToExecute.Parameters.Add(Item.Value == null
                                                    ? new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key,
                                                                        System.DBNull.Value)
                                                    : new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key,
                                                                        Item.Value.ToString()));
            }

            try
            {
                OpenConnection();
                scmCmdToExecute.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                strRS = "Lỗi chi tiết: " + sql + ex.Message;
            }
            finally
            {
                CloseConnection();
            }
        }
        return strRS;
    }
    //annv
    // update into database from store procedure with values in hashtable
    // return string if error else empty 
    // 
    public string Update(string objectName, string storeName, Hashtable _htd)
    {
        string strRS = "";
        using (SqlCommand scmCmdToExecute = new SqlCommand(storeName, SqlConn))
        {
            if (SqlTransac != null)
                scmCmdToExecute.Transaction = SqlTransac;
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            SqlParameter obj = new SqlParameter();
            foreach (DictionaryEntry Item in _htd)
            {
                if (Item.Value == null)
                    scmCmdToExecute.Parameters.Add(new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key.ToString(), System.DBNull.Value));
                else
                {
                    scmCmdToExecute.Parameters.Add(new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key, Item.Value));
                }
            }

            try
            {
                OpenConnection();
                scmCmdToExecute.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                //RollBackTransac();
                strRS = "Lỗi chi tiết: " + storeName + ex.Message;
            }
            finally
            {
                CloseConnection();
                //scmCmdToExecute.Dispose();
            }
        }
        return strRS;
    }

    public string Delete(string objectName, string tableName, string whereID)
    {
        string strRS = "";
        string sql = "delete from " + tableName;

        sql += "  where   " + CheckInput(whereID);
        using (SqlCommand scmCmdToExecute = new SqlCommand(sql, SqlConn, SqlTransac))
        {
            scmCmdToExecute.CommandType = CommandType.Text;
            if (SqlTransac != null)
                scmCmdToExecute.Transaction = SqlTransac;
            try
            {
                OpenConnection();
                scmCmdToExecute.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //RollBackTransac();
                strRS = clsMessage.ErrorWhileDelete(objectName) + " chi tiết: " + sql + ex.Message;
            }
            finally
            {
                CloseConnection();
                //scmCmdToExecute.Dispose();
            }
        }
        return strRS;
    }

    //annv
    // delete from store procedure with values in hashtable
    // return string if error else empty 
    // 
    public string Delete(string objectName, string storeName, Hashtable _htd)
    {
        string strRS = "";
        using (SqlCommand scmCmdToExecute = new SqlCommand(storeName, SqlConn))
        {
            if (SqlTransac != null)
                scmCmdToExecute.Transaction = SqlTransac;
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            SqlParameter obj = new SqlParameter();
            foreach (DictionaryEntry Item in _htd)
            {
                if (Item.Value == null)
                    scmCmdToExecute.Parameters.Add(new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key.ToString(), System.DBNull.Value));
                else
                {
                    scmCmdToExecute.Parameters.Add(new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key, Item.Value));
                }
            }

            try
            {
                OpenConnection();
                scmCmdToExecute.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                RollBackTransac();
                strRS = clsMessage.ErrorWhileDelete(objectName) + " chi tiết: " + storeName + ex.Message;
            }
            finally
            {
                CloseConnection();
                //scmCmdToExecute.Dispose();
            }
        }

        return strRS;
    }

    public bool ExecuteNoneQuery(string sql, ref string error)
    {
        bool executeOK = false;
        using (SqlCommand scmCmdToExecute = createSqlCommand(sql))
        {
            try
            {
                OpenConnection();
                scmCmdToExecute.ExecuteNonQuery();
                executeOK = true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                executeOK = false;
            }
            finally
            {
                CloseConnection();
            }
        }
        return executeOK;
    }

    public void ExecuteNoneQuery(string storeName, Hashtable ht)
    {
        using (SqlCommand scmCmdToExecute = createSqlCommand(storeName, ht))
        {
            try
            {
                OpenConnection();
                scmCmdToExecute.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }
    }

    //annv
    // insert into database from store procedure with values in hashtable
    // return string if error else empty and output value 
    // 
    public string Insert(string objectName, string storeName, Hashtable _htd, ref string outName)
    {
        string strRS = "";
        string outValue = "0";
        using (var scmCmdToExecute = new SqlCommand(storeName, SqlConn))
        {
            if (SqlTransac != null)
                scmCmdToExecute.Transaction = SqlTransac;
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            if (Timeout == 0)
                scmCmdToExecute.CommandTimeout = 120;
            else
                scmCmdToExecute.CommandTimeout = Timeout;

            var obj = new SqlParameter();
            foreach (DictionaryEntry Item in _htd)
            {
                try
                {
                    if (Item.Key.ToString().Equals(outName))
                    {
                        obj = new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key, (Item.Value == null) ? System.DBNull.Value : Item.Value)
                        {
                            Direction = ParameterDirection.Output,
                            Size = 100
                        };
                        scmCmdToExecute.Parameters.Add(obj);
                    }
                    else
                    {
                        if (Item.Value.GetType().IsArray)
                        {
                            SqlParameter sqlPa = new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key, SqlDbType.Binary);
                            sqlPa.Value = Item.Value == null ? System.DBNull.Value : Item.Value;
                            scmCmdToExecute.Parameters.Add(sqlPa);
                        }
                        else
                            scmCmdToExecute.Parameters.Add(Item.Value == null
                                                                ? new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key,
                                                                                    System.DBNull.Value)
                                                                : new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key,
                                                                                    Item.Value.ToString()));
                    }
                }
                catch (Exception ex)
                {
                    strRS = "Lỗi: " + storeName + ex.Message;
                }
            }

            try
            {
                OpenConnection();
                scmCmdToExecute.ExecuteNonQuery();
                if (obj.Value != null)
                    outValue = Convert.ToString(obj.Value);
                else
                    outValue = "";
            }

            catch (Exception ex)
            {
                strRS = "Lỗi: " + storeName + ex.Message;
            }
            finally
            {
                CloseConnection();
            }
        }
        outName = outValue;
        return strRS;
    }
    /// <summary>
    /// Hàm out with Message khi thêm mới
    /// </summary>
    /// <param name="objectName"></param>
    /// <param name="storeName"></param>
    /// <param name="_htd"></param>
    /// <param name="outName"></param>
    /// <param name="outMessage"></param>
    /// <returns></returns>
    public string Insert(string objectName, string storeName, Hashtable _htd, ref string outName, ref string outMessage)
    {
        string strRS = "";
        string outValue = "0";
        using (var scmCmdToExecute = new SqlCommand(storeName, SqlConn))
        {
            if (SqlTransac != null)
                scmCmdToExecute.Transaction = SqlTransac;
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            if (Timeout == 0)
                scmCmdToExecute.CommandTimeout = 120;
            else
                scmCmdToExecute.CommandTimeout = Timeout;

            var obj = new SqlParameter();
            var objMess = new SqlParameter();
            foreach (DictionaryEntry Item in _htd)
            {
                if (Item.Key.ToString().Equals(outName))
                {
                    obj = new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key, (Item.Value == null) ? System.DBNull.Value : Item.Value)
                    {
                        Direction = ParameterDirection.Output,
                        Size = 100
                    };
                    scmCmdToExecute.Parameters.Add(obj);
                }
                else
                    if (Item.Value.GetType().IsArray)
                    {
                        SqlParameter sqlPa = new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key, SqlDbType.Binary);
                        sqlPa.Value = Item.Value == null ? System.DBNull.Value : Item.Value;
                        scmCmdToExecute.Parameters.Add(sqlPa);
                    }
                    else
                        scmCmdToExecute.Parameters.Add(Item.Value == null
                                                            ? new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key,
                                                                                System.DBNull.Value)
                                                            : new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key,
                                                                                Item.Value.ToString()));
            }
            try
            {
                OpenConnection();
                scmCmdToExecute.ExecuteNonQuery();
                if (obj.Value != null)
                    outValue = Convert.ToString(obj.Value);
                else
                    outValue = "";
            }
            catch (Exception ex)
            {
                strRS = "Lỗi: " + storeName + ex.Message;
                outMessage = ex.Message;
            }
            finally
            {
                CloseConnection();
            }
        }
        outName = outValue;
        return strRS;
    }
    public string InsertOutMessageCustomer(string objectName, string storeName, Hashtable _htd, ref string outMessage)
    {
        string strRS = "";
        string outMess = "";
        using (var scmCmdToExecute = new SqlCommand(storeName, SqlConn))
        {
            if (SqlTransac != null)
                scmCmdToExecute.Transaction = SqlTransac;
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            if (Timeout == 0)
                scmCmdToExecute.CommandTimeout = 120;
            else
                scmCmdToExecute.CommandTimeout = Timeout;

            var objMess = new SqlParameter();
            foreach (DictionaryEntry Item in _htd)
            {
                if (Item.Key.ToString().Equals(outMessage))
                {
                    objMess = new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key, (Item.Value == null) ? System.DBNull.Value : Item.Value)
                    {
                        Direction = ParameterDirection.Output,
                        Size = 100
                    };
                    scmCmdToExecute.Parameters.Add(objMess);
                }
                else
                {
                    if (Item.Value.GetType().IsArray)
                    {
                        SqlParameter sqlPa = new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key, SqlDbType.Binary);
                        sqlPa.Value = Item.Value == null ? System.DBNull.Value : Item.Value;
                        scmCmdToExecute.Parameters.Add(sqlPa);
                    }
                    else
                        scmCmdToExecute.Parameters.Add(Item.Value == null
                                                            ? new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key,
                                                                                System.DBNull.Value)
                                                            : new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key,
                                                                                Item.Value.ToString()));
                }
            }

            try
            {
                OpenConnection();
                scmCmdToExecute.ExecuteNonQuery();
                if (objMess.Value != null)
                    outMess = Convert.ToString(objMess.Value);
                else
                    outMess = "";
            }

            catch (Exception ex)
            {
                strRS = "Lỗi: " + storeName + ex.Message;
                outMess = ex.Message;
            }
            finally
            {
                CloseConnection();
            }
        }
        outMessage = outMess;
        return strRS;
    }
    public DataTable GetDataTableWithPage(string storeName, Hashtable _htd, ref string outName, ref string message)
    {
        using (var scmCmdToExecute = new SqlCommand(storeName, SqlConn))
        {
            if (SqlTransac != null)
                scmCmdToExecute.Transaction = SqlTransac;
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            var obj = new SqlParameter();
            foreach (DictionaryEntry Item in _htd)
            {

                if (Item.Key.ToString().Equals(outName))
                {
                    obj = new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key, Item.Value ?? System.DBNull.Value)
                    {
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.VarChar,
                        Size = 100
                    };
                    scmCmdToExecute.Parameters.Add(obj);
                }
                else
                {
                    if (Item.Value.GetType().IsArray)
                    {
                        SqlParameter sqlPa = new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key, SqlDbType.Binary);
                        sqlPa.Value = Item.Value == null ? System.DBNull.Value : Item.Value;
                        scmCmdToExecute.Parameters.Add(sqlPa);
                    }
                    else
                        scmCmdToExecute.Parameters.Add(Item.Value == null
                                                            ? new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key,
                                                                                System.DBNull.Value)
                                                            : new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key,
                                                                                Item.Value.ToString()));
                }
            }

            try
            {
                using (var ds = new DataSet())
                {
                    OpenConnection();
                    using (var dad = new SqlDataAdapter(scmCmdToExecute))
                    {
                        dad.Fill(ds);
                        using (var dt = ds.Tables[0])
                        {
                            outName = obj.Value != null ? Convert.ToString(obj.Value) : "";
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RollBackTransac();
                message = clsMessage.ErrorWhileInsert("") + " chi tiết: " + storeName + ex.Message;
                using (var dt = new DataTable())
                {
                    return dt;
                }
            }
            finally
            {
                CloseConnection();
            }
        }
    }

    public string CallStore(string objectName, string storeName, Hashtable _htd, ref string outName)
    {
        string strRS = "";
        string outValue = "0";
        using (SqlCommand scmCmdToExecute = new SqlCommand(storeName, SqlConn))
        {
            if (SqlTransac != null)
                scmCmdToExecute.Transaction = SqlTransac;
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;
            var obj = new SqlParameter();
            foreach (DictionaryEntry Item in _htd)
            {
                if (Item.Key.ToString().Equals(outName))
                {
                    obj = new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key, Item.Value ?? System.DBNull.Value)
                    {
                        Direction = ParameterDirection.Output,
                        Size = 4000
                    };
                    scmCmdToExecute.Parameters.Add(obj);
                }
                else
                {
                    if (Item.Value.GetType().IsArray)
                    {
                        SqlParameter sqlPa = new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key, SqlDbType.Binary);
                        sqlPa.Value = Item.Value == null ? System.DBNull.Value : Item.Value;
                        scmCmdToExecute.Parameters.Add(sqlPa);
                    }
                    else
                        scmCmdToExecute.Parameters.Add(Item.Value == null
                                                            ? new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key,
                                                                                System.DBNull.Value)
                                                            : new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key,
                                                                                Item.Value.ToString()));
                }
            }
            try
            {
                OpenConnection();
                scmCmdToExecute.ExecuteNonQuery();
                outValue = obj.Value != null ? Convert.ToString(obj.Value) : "";
            }
            catch (Exception ex)
            {
                strRS = clsMessage.ErrorWhileInsert(objectName) + " chi tiết: " + storeName + ex.Message;
            }
            finally
            {
                CloseConnection();
            }
        }
        outName = outValue;
        return strRS;
    }

    public string Insert(string objectName, string storeName, Hashtable _htd)
    {
        string strRs = "";
        using (SqlCommand scmCmdToExecute = new SqlCommand(storeName, SqlConn))
        {
            if (SqlTransac != null)
                scmCmdToExecute.Transaction = SqlTransac;
            scmCmdToExecute.CommandType = CommandType.StoredProcedure;

            foreach (DictionaryEntry Item in _htd)
            {
                if (Item.Value.GetType().IsArray)
                {
                    SqlParameter sqlPa = new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key, SqlDbType.Binary);
                    sqlPa.Value = Item.Value == null ? System.DBNull.Value : Item.Value;
                    scmCmdToExecute.Parameters.Add(sqlPa);
                }
                else
                    if (Item.Value.GetType().IsArray)
                    {
                        SqlParameter sqlPa = new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key, SqlDbType.Binary);
                        sqlPa.Value = Item.Value == null ? System.DBNull.Value : Item.Value;
                        scmCmdToExecute.Parameters.Add(sqlPa);
                    }
                    else
                        scmCmdToExecute.Parameters.Add(Item.Value == null
                                                            ? new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key,
                                                                                System.DBNull.Value)
                                                            : new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key,
                                                                                Item.Value.ToString()));
            }

            try
            {
                OpenConnection();
                scmCmdToExecute.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                strRs = "Lỗi chi tiết: " + storeName + ex.Message;
            }
            finally
            {
                CloseConnection();
            }
        }
        return strRs;
    }
    // insert into table name with collection values in hashtable
    public void Insert(string tableName, Hashtable _htd)
    {
        string sql = "insert " + tableName + "(";
        int count = 0;
        string value = " values(";
        foreach (DictionaryEntry item in _htd)
        {
            sql += ((count > 0) ? ", " : "") + item.Key.ToString().Replace("@", "");
            value += ((count > 0) ? ", " : "") + PREFIX_VARIABLE_SQL + item.Key;
            count++;
        }
        sql += ")" + value + ")";
        using (SqlCommand scmCmdToExecute = new SqlCommand(sql, SqlConn))
        {
            if (SqlTransac != null)
                scmCmdToExecute.Transaction = SqlTransac;
            scmCmdToExecute.CommandType = CommandType.Text;

            foreach (DictionaryEntry item in _htd)
            {
                scmCmdToExecute.Parameters.Add(item.Value == null
                                                    ? new SqlParameter(PREFIX_VARIABLE_SQL + item.Key,
                                                                        System.DBNull.Value)
                                                    : new SqlParameter(PREFIX_VARIABLE_SQL + item.Key,
                                                                        CheckInput(item.Value.ToString())));
            }
            try
            {
                OpenConnection();
                scmCmdToExecute.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                CloseConnection();
            }
        }
    }

    /// <authors> 
    /// TamTVb
    /// </authors > 
    /// <summary>
    ///  <para>DataTable: a table value</para>
    ///  <para>string: Store Name</para>
    ///  <para>string: Parameter Name</para>
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="table">Table value to insert</param>
    /// <param name="storeName">Name of store</param>
    /// <param name="paraName">Name of parameter</param>
    /// <exception cref="InvalidCastException"></exception>
    /// <returns>
    ///  return DataTable
    /// </returns>
    public DataTable GetDataByTable(DataTable table, string storeName, string paraName, ref string result)
    {
        using (var connection = new SqlConnection(strConnect))
        {
            try
            {
                connection.Open();
                using (var command = new SqlCommand(storeName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = command.Parameters.AddWithValue(PREFIX_VARIABLE_SQL + paraName, table);
                    param.SqlDbType = SqlDbType.Structured;

                    using (var ds = new DataSet())
                    {
                        OpenConnection();

                        using (var dad = new SqlDataAdapter(command))
                        {
                            dad.Fill(ds);
                            using (var dt = ds.Tables[0])
                            {
                                return dt;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
                using (var dt1 = new DataTable())
                {
                    return dt1;
                }

            }
            finally
            {
                CloseConnection();
            }
        }
    }

    public List<T> GetList<T>(string storeName, Hashtable _htd)
    {
        var m_Type = typeof(T);
        var m_List = new List<T>();
        try
        {
            OpenConnection();
            SqlCommand scmCmdToExecute = createSqlCommand(storeName, _htd);
            SqlDataReader dr = scmCmdToExecute.ExecuteReader();
            if (dr.FieldCount == 0)
                return null;
            int fCount = dr.FieldCount;

            while (dr.Read())
            {
                object obj = System.Activator.CreateInstance(m_Type);
                for (int i = 0; i < fCount; i++)
                {
                    if (dr[i] != System.DBNull.Value)
                    {
                        m_Type.GetProperty(dr.GetName(i)).SetValue(obj, dr[i], null);
                    }
                }
                m_List.Add((T)obj);
            }
            dr.Close();
            return m_List;
        }
        catch
        {
            return m_List;
        }
        finally
        {
            CloseConnection();
        }
    }

    public List<T> GetList<T>(string storeName, Hashtable _htd, ref string message)
    {
        message = string.Empty;
        var m_Type = typeof(T);
        var m_List = new List<T>();
        try
        {
            OpenConnection();
            SqlCommand scmCmdToExecute = createSqlCommand(storeName, _htd);
            SqlDataReader dr = scmCmdToExecute.ExecuteReader();
            if (dr.FieldCount == 0)
                return null;
            int fCount = dr.FieldCount;

            while (dr.Read())
            {
                object obj = System.Activator.CreateInstance(m_Type);
                for (int i = 0; i < fCount; i++)
                {
                    try
                    {
                        if (dr[i] != System.DBNull.Value && m_Type.GetProperty(dr.GetName(i)) != null)
                        {
                            m_Type.GetProperty(dr.GetName(i)).SetValue(obj, dr[i], null);
                        }
                    }
                    catch (Exception ex)
                    {
                        message = ex.Message;
                    }
                }
                m_List.Add((T)obj);
            }
            dr.Close();
            return m_List;
        }
        catch (Exception ex)
        {
            message = ex.Message;
            return m_List;
        }
        finally
        {
            CloseConnection();
        }
    }

    public T GetOne<T>(string storeName, Hashtable _htd, ref string message)
    {
        message = string.Empty;
        var m_Type = typeof(T);
        var list = new List<T>();
        try
        {
            OpenConnection();
            using (SqlCommand scmCmdToExecute = createSqlCommand(storeName, _htd))
            {
                using (SqlDataReader dr = scmCmdToExecute.ExecuteReader())
                {
                    if (dr.FieldCount == 0)
                        return default(T);
                    int fCount = dr.FieldCount;

                    while (dr.Read())
                    {
                        object obj = System.Activator.CreateInstance(m_Type);
                        for (int i = 0; i < fCount; i++)
                        {
                            try
                            {
                                if (dr[i] != System.DBNull.Value && dr[i] != null && m_Type.GetProperty(dr.GetName(i)) != null)
                                    m_Type.GetProperty(dr.GetName(i)).SetValue(obj, dr[i], null);
                            }
                            catch (Exception ex)
                            {
                                message = ex.Message;
                                return default(T);
                            }
                        }
                        list.Add((T)obj);
                        break;
                    }
                    dr.Close();
                }
            }

            if (list.Count > 0)
                return list[0];
            else
                return default(T);
        }
        catch (Exception ex)
        {
            message = ex.Message;
            return default(T);
        }
        finally
        {
            CloseConnection();
        }
    }

    /// <authors> 
    /// TamTVb_20141203
    /// </authors > 
    /// <summary>
    ///  <para>DataTable: a table value</para>
    ///  <para>string: Store Name</para>
    ///  <para>string: Parameter Name</para>
    /// </summary>
    /// <remarks>
    /// - 
    /// </remarks>
    /// <param name="table">Table value to insert</param>
    /// <param name="storeName">Name of store</param>
    /// <param name="paraName">Name of parameter</param>
    /// <exception cref="InvalidCastException"></exception>
    /// <returns>
    ///  int
    /// </returns>
    public int InsertByTable(DataTable table, string storeName, string paraName, ref string result)
    {
        var rowAffected = 0;
        using (var connection = new SqlConnection(strConnect))
        {
            try
            {
                connection.Open();
                var insertCommand = new SqlCommand(storeName, connection) { CommandType = CommandType.StoredProcedure };
                SqlParameter param = insertCommand.Parameters.AddWithValue(PREFIX_VARIABLE_SQL + paraName, table);
                param.SqlDbType = SqlDbType.Structured;
                rowAffected = insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = ex.Message;
                rowAffected = -1;
            }
        }
        return rowAffected;
    }
    public int InsertByTableWithParam(DataTable table, string storeName, string paraName, Hashtable _htd, ref string result)
    {
        var rowAffected = 0;
        using (var connection = new SqlConnection(strConnect))
        {
            try
            {
                connection.Open();
                var insertCommand = new SqlCommand(storeName, connection) { CommandType = CommandType.StoredProcedure };
                SqlParameter param = insertCommand.Parameters.AddWithValue(PREFIX_VARIABLE_SQL + paraName, table);
                param.SqlDbType = SqlDbType.Structured;
                foreach (DictionaryEntry Item in _htd)
                {
                    if (Item.Value.GetType().IsArray)
                    {
                        SqlParameter sqlPa = new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key, SqlDbType.Binary);
                        sqlPa.Value = Item.Value == null ? System.DBNull.Value : Item.Value;
                        insertCommand.Parameters.Add(sqlPa);
                    }
                    else
                        if (Item.Value.GetType().IsArray)
                        {
                            SqlParameter sqlPa = new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key, SqlDbType.Binary);
                            sqlPa.Value = Item.Value == null ? System.DBNull.Value : Item.Value;
                            insertCommand.Parameters.Add(sqlPa);
                        }
                        else
                            insertCommand.Parameters.Add(Item.Value == null
                                                                ? new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key,
                                                                                    System.DBNull.Value)
                                                                : new SqlParameter(PREFIX_VARIABLE_SQL + Item.Key,
                                                                                    Item.Value.ToString()));
                }
                rowAffected = insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                rowAffected = -1;
            }
        }
        return rowAffected;
    }
    public List<T> ConvertDataTableToList<T>(DataTable table, ref string message)
    {
        message = string.Empty;
        var m_Type = typeof(T);
        var m_List = new List<T>();
        try
        {
            DataTableReader dr = table.CreateDataReader();
            if (dr.FieldCount == 0)
                return null;
            int fCount = dr.FieldCount;

            while (dr.Read())
            {
                object obj = System.Activator.CreateInstance(m_Type);
                for (int i = 0; i < fCount; i++)
                {
                    if (dr[i] != System.DBNull.Value)
                    {
                        m_Type.GetProperty(dr.GetName(i)).SetValue(obj, dr[i], null);
                    }
                }
                m_List.Add((T)obj);
            }
            dr.Close();
            return m_List;
        }
        catch (Exception ex)
        {
            message = ex.Message;
            return m_List;
        }
        finally
        {

        }
    }

    public DataTable ConvertListToDataTable<T>(List<T> items)
    {
        DataTable dataTable = new DataTable(typeof(T).Name);

        //Get all the properties
        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo prop in Props)
        {
            //Setting column names as Property names
            dataTable.Columns.Add(prop.Name);
        }
        foreach (T item in items)
        {
            var values = new object[Props.Length];
            for (int i = 0; i < Props.Length; i++)
            {
                //inserting property values to datatable rows
                values[i] = Props[i].GetValue(item, null);
            }
            dataTable.Rows.Add(values);
        }
        //put a breakpoint here and check datatable
        return dataTable;
    }
}
