using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

/// <summary>
/// Summary description for SQLDB
/// </summary>
public class SQLDB
{
    protected string dbKey = "MROS";
    protected string tableName = "";
    protected string rowFilter = "";
    protected string connString = System.Configuration.ConfigurationManager.AppSettings["MROS"];
    SqlConnection CONN = null;

    /// <summary>
    /// SQL�غc�l�A�w�]�s�u��ƪ�
    /// </summary>
    public SQLDB()  //constructor
    {
        this.CONN = new SqlConnection(this.connString);
    }

    /// <summary>
    /// SQL�غc�l�A�w�]�s�u��ƪ�
    /// </summary>
    public SQLDB(String _tableName)  //constructor
    {
        this.tableName = _tableName;
        this.CONN = new SqlConnection(this.connString.Replace(@"[^\w\.@!]", ""));
    }

    /// <summary>
    /// SQL�غc�l�A�w�]�s�u��ƪ�BDBKey
    /// </summary>
    public SQLDB(String _tableName, String _DBKey)  //constructor
    {
        this.connString = System.Configuration.ConfigurationManager.AppSettings[_DBKey];
        this.tableName = _tableName;
        this.CONN = new SqlConnection(this.connString.Replace(@"[^\w\.@!]", ""));
    }

    public string RowFilter
    {
        set { this.rowFilter = value; }
    }

    /// <summary>
    /// �]�w�s�u��Ʈw
    /// </summary>
    public void SetCONN(string _DBKey)
    {
        this.connString = System.Configuration.ConfigurationManager.AppSettings[_DBKey];
        this.CONN = new SqlConnection(this.connString.Replace(@"[^\w\.@!]", ""));
    }

    /// <summary>
    /// Select�禡
    /// </summary>
    public DataSet Select() //Ū��table
    {
        return this.Select("", "", "");
    }

    /// <summary>
    /// Select�禡
    /// </summary>
    public DataSet Select(string _rowFilter) //Ū��table
    {
        return this.Select(_rowFilter.Replace(@"[^\w\.@!]", ""), "", "");
    }

    /// <summary>
    /// Select�禡
    /// </summary>
    public DataSet Select(string _rowFilter, string _sort) //Ū��table
    {
        return Select(_rowFilter.Replace(@"[^\w\.@!]", ""), _sort.Replace(@"[^\w\.@!]", ""), "");
    }

    /// <summary>
    /// Select�禡
    /// </summary>
    public DataSet Select(string _rowFilter, string _sort, string _tableName) //Ū��table
    {
        if (this.CONN == null)
            this.CONN = new SqlConnection(this.connString.Replace(@"[^\w\.@!]", ""));     //�Y�w���_�s�u,�Y���s�s�u

        StringBuilder strSQL = new StringBuilder(" SELECT * FROM ");
        if (_tableName != "")
        {
            strSQL.Append(_tableName);
        }
        else
        {
            strSQL.Append(this.tableName);
        }

        if (_rowFilter.Trim().Length > 0)
        {
            strSQL.Append(" Where " + _rowFilter);
        }

        if (_sort.Trim().Length > 0)
        {
            strSQL.Append(" Order by " + _sort);
        }

        DataSet DS = new DataSet();

        try
        {
            SqlDataAdapter DA = new SqlDataAdapter(strSQL.ToString().Replace(@"[^\w\.@!]", ""), this.CONN);
			if (_tableName != "")
			{
				DA.Fill(DS, _tableName);
			}
			else
			{
				DA.Fill(DS, this.tableName);
			}

        }
        catch (Exception ex)
        {
            System.Console.Write(ex);
        }
        finally
        {
            this.CONN.Close();
            strSQL = null;
            this.CONN = null;
        }

        return DS;
    }

    /// <summary>
    /// �۩wSelect�禡
    /// </summary>
    public DataSet SelectQuery(string _strSQL) //Ū��table
    {
        return this.SelectQuery(_strSQL.Replace(@"[^\w\.@!]", ""), "T");
    }

    /// <summary>
    /// �۩wSelect�禡
    /// </summary>
    public DataSet SelectQuery(string _strSQL, string _tableName) //Ū��table
    {
        if (this.CONN == null)
            this.CONN = new SqlConnection(this.connString.Replace(@"[^\w\.@!]", ""));     //�Y�w���_�s�u,�Y���s�s�u

        DataSet DS = new DataSet();

        try
        {
            SqlDataAdapter DA = new SqlDataAdapter(_strSQL.Replace(@"[^\w\.@!]", ""), this.CONN);
			if (_tableName != "")
			{
				DA.Fill(DS, _tableName);
			}
			else
			{
				DA.Fill(DS, this.tableName);
			}
		}
        catch (Exception ex)
        {
            System.Console.Write(ex);
        }
        finally
        {
            this.CONN.Close();
            this.CONN = null;
        }
        return DS;

    }

    public bool Save(DataSet _DSChanges)
    {
        bool suc = false;
        if (this.CONN == null)
            this.CONN = new SqlConnection(this.connString);     //�Y�w���_�s�u,�Y���s�s�u

        StringBuilder strSQL = new StringBuilder("SELECT TOP 0 * FROM ");
        strSQL.Append(_DSChanges.Tables[0].TableName);

        this.CONN.Open();
        //
        SqlTransaction TRANS = this.CONN.BeginTransaction(IsolationLevel.ReadCommitted);
        SqlCommand CMD = new SqlCommand(strSQL.ToString().Replace(@"[^\w\.@!]", ""), this.CONN);
        CMD.Transaction = TRANS;

        try
        {
            SqlDataAdapter DA = new SqlDataAdapter(CMD);
            //DA.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            SqlCommandBuilder CB = new SqlCommandBuilder(DA);
            //DA.DeleteCommand = CB.GetDeleteCommand();
            DA.Update(_DSChanges, _DSChanges.Tables[0].TableName);

            TRANS.Commit();
            suc = true;
        }
        catch (Exception ex)
        {
            TRANS.Rollback();
            System.Console.Write(ex);
        }
        finally
        {
            this.CONN.Close();
            strSQL = null;
            CMD = null;
        }
        return suc;
    }

    public bool Insert(DataSet _DSChanges)
    {
        return Save(_DSChanges);
    }

    public bool Update(DataSet _DSChanges)
    {
        return Save(_DSChanges);
    }

    public bool Delete(DataSet _DSChanges)
    {
        return Save(_DSChanges);
    }

    /// <summary>
    /// �R���A_rowFilter --> id = 1 and type='xxx'
    /// </summary>
    public bool Delete(string _rowFilter)
    {
        return Delete(_rowFilter, this.tableName);
    }

    /// <summary>
    /// �R���Acondition --> id = 1 and type='xxx'
    /// </summary>
    public bool Delete(string _rowFilter, string table)
    {
        bool suc = false;
        if (_rowFilter.Trim().Length > 0)
        {
            String strSQL = "Delete from " + table + " where " + _rowFilter;
            try
            {
                //�Y�w���_�s�u,�Y���s�s�u
                if (CONN == null)
                {
                    CONN = new SqlConnection(connString);
                }
                //�Y�w�s�u
                if (CONN != null)
                {
                    CONN.Open();
                    SqlCommand comm = new SqlCommand(strSQL.Replace(@"[^\w\.@!]", ""), CONN);
                    if (comm.ExecuteNonQuery() > 0)
                        suc = true;
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex);
            }
            finally
            {
                CONN.Close();
                CONN = null;
            }
        }

        return suc;
    }

    /// <summary>
    /// Execute SQL for insert,update,delete
    /// </summary>
    public bool ExecuteStatement(string _strSQL)   //for insert,update,delete
    {
        bool suc = false;
        if (this.CONN == null)
            this.CONN = new SqlConnection(this.connString);     //�Y�w���_�s�u,�Y���s�s�u

        try
        {
            this.CONN.Open();
            SqlCommand CMD = new SqlCommand(_strSQL.Replace(@"[^\w\.@!]", ""), this.CONN);
            if (CMD.ExecuteNonQuery() > 0)
                suc = true;
        }
        catch (Exception ex)
        {
            System.Console.Write(ex);
        }
        finally
        {
            this.CONN.Close();
        }
        return suc;

    }

    /// <summary>
    /// �̯S�w����A�o���@DataRow
    /// </summary>
    public DataRow GetDataRow(DataSet ds, string _rowFilter)
    {
        DataRow dr = null;
        try
        {
            if (ds != null)
            {
                DataView dv = ds.Tables[0].DefaultView;
                dv.RowFilter = _rowFilter;
                DataTable dt = dv.ToTable();
                if (dt.Rows.Count == 1)
                {
                    dr = dt.Rows[0];
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.Write(ex);
        }

        return dr;
    }




    /*
    protected DataSet GetTableSchema()
    {
        if (this.CONN == null)
            this.CONN = new SqlConnection(connString);     //�Y�w���_�s�u,�Y���s�s�u

        try
        {
            SqlDataAdapter DA = new SqlDataAdapter("Select top 0 * From " + tablename, this.CONN);
            //DA.Update(DSChanges, tablename);
        }
        catch (Exception ex)
        {
            System.Console.Write(ex);
        }
        finally
        {
            this.CONN.Close();
            this.CONN = null;
        }

    }
     */


    /// <summary>
    /// Select �ۤv�ջy�k
    /// </summary>
    public DataSet SelectSQL(string _SQL) //SQL�ۤv��
    {
        if (this.CONN == null)
            this.CONN = new SqlConnection(this.connString.Replace(@"[^\w\.@!]", ""));     //�Y�w���_�s�u,�Y���s�s�u

        StringBuilder strSQL = new StringBuilder(_SQL.Replace(@"[^\w\.@!]", ""));
    
        DataSet DS = new DataSet();

        try
        {
            SqlDataAdapter DA = new SqlDataAdapter(strSQL.ToString().Replace(@"[^\w\.@!]", ""), this.CONN);
            if (strSQL.ToString() != "")
            {
                DA.Fill(DS, strSQL.ToString());
            }
            else
            {
                return DS;
            }

        }
        catch (Exception ex)
        {
            System.Console.Write(ex);
        }
        finally
        {
            this.CONN.Close();
            strSQL = null;
            this.CONN = null;
        }

        return DS;
    }





}
