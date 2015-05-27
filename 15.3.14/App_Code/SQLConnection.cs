using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for SQLConnection
/// </summary>
public class SQLConnection
{
    private string dbPath;
    private OleDbConnection conn;
    private OleDbCommand cmd;
    private OleDbDataAdapter dAdapter;
    private DataSet ds;
    private string SQLsentence;

	public SQLConnection(string dbPath)
	{
        this.dbPath = dbPath;
        string connectionSTR = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};", this.dbPath);
        conn = new OleDbConnection(connectionSTR);
        cmd = new OleDbCommand(SQLsentence, conn);
        dAdapter = new OleDbDataAdapter(cmd);
	}
    public DataSet GetData(string SQLSentence)
    {
        conn.Open();
        ds = new DataSet();
        cmd.CommandText = SQLSentence;
        dAdapter.SelectCommand = cmd;
        dAdapter.Fill(ds);
        conn.Close();
        return ds;
    }
    public bool CheckExistance(string SQLSentence)
    {
        bool flag;
        conn.Open();
        cmd.CommandText = SQLSentence;
        OleDbDataReader dRead = cmd.ExecuteReader();
        flag = (bool)dRead.Read();
        conn.Close();
        return flag;
    }
    public void Update(string SQLSentence)
    {
        conn.Open();
        cmd.CommandText = SQLSentence;
        cmd.ExecuteNonQuery();
        conn.Close();
    }
    public void Insert(string SQLSentence)
    {
        conn.Open();
        cmd.CommandText = SQLSentence;
        cmd.ExecuteNonQuery();
        conn.Close();
    }
}