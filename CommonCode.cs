using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Xml;
using System.Reflection;
using System.Collections.Generic;

/// <summary>
/// Summary description for CommonCode
/// </summary>
public class CommonCode
{
	public CommonCode()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //public void FillDDL(ref DropDownList ddl, string TableName, string TextField, string ValueField)
    //{
    //    ddl.Items.Clear();
    //    MyConnection Mycon = new MyConnection();
    //    Mycon.Open();
    //    Mycon.cmd.CommandType = CommandType.StoredProcedure;
    //    Mycon.cmd.CommandText = "USP_FillDLL";
    //    Mycon.cmd.Parameters.AddWithValue("@TableName", TableName);
    //    Mycon.cmd.Parameters.AddWithValue("@TextField", TextField);
    //    Mycon.cmd.Parameters.AddWithValue("@ValueField", ValueField);
    //    SqlDataReader sdr;
    //    DataTable dt = new DataTable();
    //    sdr = Mycon.cmd.ExecuteReader();
    //    dt.Load(sdr);
    //    ddl.DataSource = dt;
    //    ddl.DataTextField = TextField;
    //    ddl.DataValueField = ValueField;
    //    ddl.DataBind();
    //    ddl.Items.Insert(0,"---Select---");
    //    Mycon.Close();
    //}

    //added by supriya at 12 oct2018
    public void bindFinYears(ref DropDownList ddl, int startyear, int lastyear)
    {


        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("Years", typeof(string)));
        DataRow dr = null;

        //int startyear = 2015;
        //int lastyear = 2021;

        for (startyear = 2018; startyear <= lastyear; startyear++)
        {
            int endyear = startyear;
            dr = dt.NewRow();
            dr["Years"] = startyear + "-" + (++endyear);
            dt.Rows.Add(dr);


        }

        ddl.DataSource = dt;
        ddl.DataTextField = "Years";
        ddl.DataValueField = "Years";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("---Select---", "0"));



    }
public DataTable FIN_YEAR_GET()
    {
        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_FIN_YEAR_GET";
        DataTable dt = new DataTable();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            Mycon.Open();
            SqlDataReader sdr;
            sdr = Mycon.cmd.ExecuteReader();

            dt.Load(sdr);
            Mycon.Close();
            return dt;


        }
        catch (Exception ex)
        {
            ex.Message.ToString();

            return dt;
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();
            }
            Mycon.cmd.Dispose();
        }
    }

    public DataTable FIN_YEAR(DateTime Date)
    {

        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_FIN_YEAR";
        DataTable dt = new DataTable();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.Parameters.AddWithValue("@Date", Date);
        try
        {
            Mycon.Open();
            SqlDataReader sdr;
            sdr = Mycon.cmd.ExecuteReader();

            dt.Load(sdr);
            Mycon.Close();
            return dt;


        }
        catch (Exception ex)
        {
            ex.Message.ToString();

            return dt;
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();
            }
            Mycon.cmd.Dispose();
        }
    }

    public DataTable GET_TRN_NO()
    {
        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_GET_TRN_NO";
        DataTable dt = new DataTable();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            Mycon.Open();
            SqlDataReader sdr;
            sdr = Mycon.cmd.ExecuteReader();

            dt.Load(sdr);
            Mycon.Close();
            return dt;


        }
        catch (Exception ex)
        {
            ex.Message.ToString();

            return dt;
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();
            }
            Mycon.cmd.Dispose();
        }
    }

    public DataTable GET_CROPMST(string APP_NO)
    {

        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_GET_CROPMST";
        DataTable dt = new DataTable();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.Parameters.AddWithValue("@APP_NO", APP_NO);
        try
        {
            Mycon.Open();
            SqlDataReader sdr;
            sdr = Mycon.cmd.ExecuteReader();

            dt.Load(sdr);
            Mycon.Close();
            return dt;


        }
        catch (Exception ex)
        {
            ex.Message.ToString();

            return dt;
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();
            }
            Mycon.cmd.Dispose();
        }
    }

    public DataTable GET_MEMBER_DETAIL(string APP_NO)
    {

        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_GET_MEMBER_DETAIL";
        DataTable dt = new DataTable();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.Parameters.AddWithValue("@APP_NO", APP_NO);
        try
        {
            Mycon.Open();
            SqlDataReader sdr;
            sdr = Mycon.cmd.ExecuteReader();

            dt.Load(sdr);
            Mycon.Close();
            return dt;


        }
        catch (Exception ex)
        {
            ex.Message.ToString();

            return dt;
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();
            }
            Mycon.cmd.Dispose();
        }
    }

    public DataTable GET_LAND_INFORMATION(string APP_NO)
    {

        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_GET_LAND_INFORMATION";
        DataTable dt = new DataTable();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.Parameters.AddWithValue("@APP_NO", APP_NO);
        try
        {
            Mycon.Open();
            SqlDataReader sdr;
            sdr = Mycon.cmd.ExecuteReader();

            dt.Load(sdr);
            Mycon.Close();
            return dt;


        }
        catch (Exception ex)
        {
            ex.Message.ToString();

            return dt;
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();
            }
            Mycon.cmd.Dispose();
        }
    }

    public DataTable GET_CROP_INFORMATION(string APP_NO)
    {

        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_GET_CROP_INFORMATION";
        DataTable dt = new DataTable();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.Parameters.AddWithValue("@APP_NO", APP_NO);
        try
        {
            Mycon.Open();
            SqlDataReader sdr;
            sdr = Mycon.cmd.ExecuteReader();

            dt.Load(sdr);
            Mycon.Close();
            return dt;


        }
        catch (Exception ex)
        {
            ex.Message.ToString();

            return dt;
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();
            }
            Mycon.cmd.Dispose();
        }
    }

    public DataTable GET_CROP_DETAILS(string APP_NO)
    {

        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_GET_CROP_DETAILS";
        DataTable dt = new DataTable();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.Parameters.AddWithValue("@APP_NO", APP_NO);
        try
        {
            Mycon.Open();
            SqlDataReader sdr;
            sdr = Mycon.cmd.ExecuteReader();

            dt.Load(sdr);
            Mycon.Close();
            return dt;


        }
        catch (Exception ex)
        {
            ex.Message.ToString();

            return dt;
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();
            }
            Mycon.cmd.Dispose();
        }
    }

    public DataTable GET_BLOCKMST(string D_CODE)
    {

        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_GET_BLOCKMST";
        DataTable dt = new DataTable();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.Parameters.AddWithValue("@D_CODE", D_CODE);
        try
        {
            Mycon.Open();
            SqlDataReader sdr;
            sdr = Mycon.cmd.ExecuteReader();

            dt.Load(sdr);
            Mycon.Close();
            return dt;


        }
        catch (Exception ex)
        {
            ex.Message.ToString();

            return dt;
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();
            }
            Mycon.cmd.Dispose();
        }
    }

    public DataTable GET_VILLAGE(string B_CODE)
    {

        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_GET_VILLAGE";
        DataTable dt = new DataTable();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.Parameters.AddWithValue("@B_CODE", B_CODE);
        try
        {
            Mycon.Open();
            SqlDataReader sdr;
            sdr = Mycon.cmd.ExecuteReader();

            dt.Load(sdr);
            Mycon.Close();
            return dt;


        }
        catch (Exception ex)
        {
            ex.Message.ToString();

            return dt;
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();
            }
            Mycon.cmd.Dispose();
        }
    }

    public DataTable GETCASTEMST()
    {

        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_GETCASTEMST";
        DataTable dt = new DataTable();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            Mycon.Open();
            SqlDataReader sdr;
            sdr = Mycon.cmd.ExecuteReader();

            dt.Load(sdr);
            Mycon.Close();
            return dt;


        }
        catch (Exception ex)
        {
            ex.Message.ToString();

            return dt;
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();
            }
            Mycon.cmd.Dispose();
        }
    }

    public DataTable GET_FARMERTYPE(string FinYear)
    {

        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_GET_FARMERTYPE";
        DataTable dt = new DataTable();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.Parameters.AddWithValue("@FinYear", FinYear);
        try
        {
            Mycon.Open();
            SqlDataReader sdr;
            sdr = Mycon.cmd.ExecuteReader();

            dt.Load(sdr);
            Mycon.Close();
            return dt;


        }
        catch (Exception ex)
        {
            ex.Message.ToString();

            return dt;
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();
            }
            Mycon.cmd.Dispose();
        }
    }

    public DataTable GET_DSTMST()
    {

        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_GET_DSTMST";
        DataTable dt = new DataTable();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;

        try
        {
            Mycon.Open();
            SqlDataReader sdr;
            sdr = Mycon.cmd.ExecuteReader();

            dt.Load(sdr);
            Mycon.Close();
            return dt;


        }
        catch (Exception ex)
        {
            ex.Message.ToString();

            return dt;
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();
            }
            Mycon.cmd.Dispose();
        }
    }

    public DataTable GET_CROPMST_HND_DETAIL(string CTP_CODE)
    {

        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_GET_CROPMST_HND_DETAIL";
        DataTable dt = new DataTable();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.Parameters.AddWithValue("@CTP_CODE", CTP_CODE);
        try
        {
            Mycon.Open();
            SqlDataReader sdr;
            sdr = Mycon.cmd.ExecuteReader();

            dt.Load(sdr);
            Mycon.Close();
            return dt;


        }
        catch (Exception ex)
        {
            ex.Message.ToString();

            return dt;
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();
            }
            Mycon.cmd.Dispose();
        }
    }

    public DataTable GET_LAND_INFO(string KhasraNo,string KilaNo,string V_CODE)
    {

        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_GET_LAND_INFO";
        DataTable dt = new DataTable();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.Parameters.AddWithValue("@KhasraNo", KhasraNo);
        Mycon.cmd.Parameters.AddWithValue("@KilaNo", KilaNo);
        Mycon.cmd.Parameters.AddWithValue("@V_CODE", V_CODE);
        try
        {
            Mycon.Open();
            SqlDataReader sdr;
            sdr = Mycon.cmd.ExecuteReader();

            dt.Load(sdr);
            Mycon.Close();
            return dt;


        }
        catch (Exception ex)
        {
            ex.Message.ToString();

            return dt;
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();
            }
            Mycon.cmd.Dispose();
        }
    }

    public DataTable GET_CTPMST()
    {

        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_GET_CTPMST";
        DataTable dt = new DataTable();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            Mycon.Open();
            SqlDataReader sdr;
            sdr = Mycon.cmd.ExecuteReader();

            dt.Load(sdr);
            Mycon.Close();
            return dt;


        }
        catch (Exception ex)
        {
            ex.Message.ToString();

            return dt;
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();
            }
            Mycon.cmd.Dispose();
        }
    }

    public void FillDDL(ref DropDownList ddl, string selectdesc, string TextField, string ValueField, string tablename)
    {
        ddl.Items.Clear();
        MyConnection Mycon = new MyConnection();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = "USP_FillDLL";
        Mycon.cmd.Parameters.AddWithValue("@TableName", tablename);
        Mycon.cmd.Parameters.AddWithValue("@TextField", TextField);
        Mycon.cmd.Parameters.AddWithValue("@ValueField", ValueField);
        SqlDataReader sdr;
        DataTable dt = new DataTable();
        sdr = Mycon.cmd.ExecuteReader();

        dt.Load(sdr);
        ddl.DataSource = dt;

        ddl.DataTextField = TextField;
        ddl.DataValueField = ValueField;
        ddl.DataBind();
        ddl.Items.Insert(0, selectdesc);
        ddl.SelectedValue.Insert(0, "0");
        Mycon.Close();
    }
    public void FillDDLPSType(ref DropDownList ddl)
    {
        ddl.Items.Clear();
        //string str = "SELECT PS_CODE,PS_DESC FROM Master.PSTYPE ORDER BY CONVERT(NUMERIC(18,2),LEFT(PS_CODE,CHARINDEX('x',PS_CODE)-1))";
        string str = "SELECT PS_CODE,PS_DESC FROM Master.PSTYPE ORDER BY PS_CODE";
        DataTable dt = new DataTable();
        dt = EQ(str);
        if (dt.Rows.Count > 0)
        {
            ddl.DataSource = dt;
            ddl.DataTextField = "PS_DESC";
            ddl.DataValueField = "PS_CODE";
            ddl.DataBind();
        }
        ddl.Items.Insert(0, "---Select---");
    }
    
    public static String ConvertToXMLFormat<T>(ref List<T> list)
    {
        XmlDocument doc = new XmlDocument();
        XmlNode node = doc.CreateNode(XmlNodeType.Element, string.Empty, "root", null);

        foreach (T xml in list)
        {
            XmlElement element = doc.CreateElement("data");
            PropertyInfo[] allProperties = xml.GetType().GetProperties();
            foreach (PropertyInfo thisProperty in allProperties)
            {
                object value = thisProperty.GetValue(xml, null);
                XmlElement tmp = doc.CreateElement(thisProperty.Name);
                if (value != null)
                {
                    tmp.InnerXml = value.ToString();
                }
                else
                {
                    tmp.InnerXml = string.Empty;
                }
                element.AppendChild(tmp);
            }
            node.AppendChild(element);
        }
        doc.AppendChild(node);
        return doc.InnerXml;
    }
  public  String ConvertToXMLFormat1<T>(ref List<T> list)
    {
        XmlDocument doc = new XmlDocument();
        XmlNode node = doc.CreateNode(XmlNodeType.Element, string.Empty, "root", null);

        foreach (T xml in list)
        {
            XmlElement element = doc.CreateElement("data");
            PropertyInfo[] allProperties = xml.GetType().GetProperties();
            foreach (PropertyInfo thisProperty in allProperties)
            {
                object value = thisProperty.GetValue(xml, null);
                XmlElement tmp = doc.CreateElement(thisProperty.Name);
                if (value != null)
                {
                    tmp.InnerXml = value.ToString();
                }
                else
                {
                    tmp.InnerXml = string.Empty;
                }
                element.AppendChild(tmp);
            }
            node.AppendChild(element);
        }
        doc.AppendChild(node);
        return doc.InnerXml;
    }
    public void FillDDLFrom(ref DropDownList ddl, string selectdesc, string TextField, string ValueField, string tablename, string wherekey, string wherevalue)
    {
        ddl.Items.Clear();
        MyConnection Mycon = new MyConnection();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = "USP_FillDLLFrom";
        Mycon.cmd.Parameters.AddWithValue("@TableName", tablename);
        Mycon.cmd.Parameters.AddWithValue("@TextField", TextField);
        Mycon.cmd.Parameters.AddWithValue("@ValueField", ValueField);
        Mycon.cmd.Parameters.AddWithValue("@WhereField", wherekey);
        Mycon.cmd.Parameters.AddWithValue("@WhereValue", wherevalue);
        SqlDataReader sdr;
        DataTable dt = new DataTable();
        sdr = Mycon.cmd.ExecuteReader();

        dt.Load(sdr);
        ddl.DataSource = dt;

        ddl.DataTextField = TextField;
        ddl.DataValueField = ValueField;
        ddl.DataBind();
        ddl.Items.Insert(0, selectdesc);
        ddl.SelectedValue.Insert(0, "0");
        Mycon.Close();
    }
    public DataTable EQ(string Q)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.Text;
        Mycon.cmd.CommandText = Q;
        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
        return dt;
    }
    public DataTable FillGrid(string sp_name, string param_name, string id)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = sp_name;
        Mycon.cmd.Parameters.AddWithValue(param_name, id);
        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
        return dt;
    }
    public DataTable FillFarmerDetailsAndUserTypeSearch(string sp_name, string App_No, string Name, string District, string Block, string UserType)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = sp_name;
        Mycon.cmd.Parameters.AddWithValue("@App_No", App_No);
        Mycon.cmd.Parameters.AddWithValue("@Name", Name);
        Mycon.cmd.Parameters.AddWithValue("@D_NAME", District);
        Mycon.cmd.Parameters.AddWithValue("@B_NAME", Block);
        Mycon.cmd.Parameters.AddWithValue("@userType", UserType);
        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
        return dt;
    }
    public DataTable FillGrid(string sp_name)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = sp_name;
        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
        return dt;
    }
    public DataTable FillGridByView(string sp_name)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.Text;
        Mycon.cmd.CommandText = sp_name;
        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
        return dt;
    }
    public DataTable GetDetailByAppNo(string APP_NO)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = "[USP_GetDetailByAppNo]";
        Mycon.cmd.Parameters.AddWithValue("@APP_NO", APP_NO);
        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
        return dt;
    }

    public DataTable GetDetailByAppNo2(string APP_NO)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = "[USP_GetDetailByAppNo2]";
        Mycon.cmd.Parameters.AddWithValue("@APP_NO", APP_NO);
        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
        return dt;
    }
    public DataTable GetEstimateDetailByAppNo(string APP_NO)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = "[USP_GetEstimateDetailByAppNo]";
        Mycon.cmd.Parameters.AddWithValue("@APP_NO", APP_NO);
        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
        return dt;
    }
    public virtual string Delete(string tablename, string idfield, string value)
    {
        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_Delete";
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.Parameters.AddWithValue("@TableName", tablename);
        Mycon.cmd.Parameters.AddWithValue("@IDField", idfield);
        //Mycon.cmd.Parameters.AddWithValue("@WereClause",where);
        SqlParameter p1 = new SqlParameter("@Value", SqlDbType.VarChar, 10);
        p1.Direction = ParameterDirection.Input;
        p1.Value = value;
        Mycon.cmd.Parameters.Add(p1);
        SqlParameter p2 = new SqlParameter("@msg", SqlDbType.VarChar, 8000);
        p2.Direction = ParameterDirection.Output;
        Mycon.cmd.Parameters.Add(p2);
        try
        {
            Mycon.Open();
            Mycon.cmd.ExecuteNonQuery();
            Mycon.Close();

            return Mycon.cmd.Parameters["@msg"].Value.ToString();
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();
            }
            Mycon.cmd.Dispose();
        }
    }
    public void FillDLLMITYPE(ref DropDownList ddl)
    {
        ddl.Items.Clear();
        MyConnection Mycon = new MyConnection();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = "USP_FillDLL_MIType";
        SqlDataReader sdr;
        DataTable dt = new DataTable();
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        ddl.DataSource = dt;
        ddl.DataTextField = "MI_DESC";
        ddl.DataValueField = "MI_CODE";
        ddl.DataBind();
        ddl.Items.Insert(0, "---Select---");
        Mycon.Close();
    }


    public void FillDLLcropcategory(ref DropDownList ddl)
    {
        ddl.Items.Clear();
        MyConnection Mycon = new MyConnection();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = "USP_FillDLL_cropcategory";
        SqlDataReader sdr;
        DataTable dt = new DataTable();
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        ddl.DataSource = dt;
        ddl.DataTextField = "ccat_code";
        ddl.DataValueField = "ccat_code";
        ddl.DataBind();
        ddl.Items.Insert(0, "---Select---");
        Mycon.Close();
    }
    public void FillDLLPSCODE(ref DropDownList ddl)
    {
        ddl.Items.Clear();
        MyConnection Mycon = new MyConnection();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = "USP_FillDLL_PSCODE";
        SqlDataReader sdr;
        DataTable dt = new DataTable();
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        ddl.DataSource = dt;
        ddl.DataTextField = "PS_DESC";
        ddl.DataValueField = "PS_CODE";
        ddl.DataBind();
        ddl.Items.Insert(0, "---Select---");
        Mycon.Close();
    }
    public void FillDLLcroptype(ref DropDownList ddl)
    {
        ddl.Items.Clear();
        MyConnection Mycon = new MyConnection();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = "USP_FillDLL_croptype";
        SqlDataReader sdr;
        DataTable dt = new DataTable();
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        ddl.DataSource = dt;
        ddl.DataTextField = "CTP_DESC";
        ddl.DataValueField = "CTP_CODE";
        ddl.DataBind();
        ddl.Items.Insert(0, "---Select---");
        Mycon.Close();
    }
    public virtual DataTable Select(string tablename, string idfield, string value)
    {
        DataTable dt = new DataTable();
        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_Select";
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.Parameters.AddWithValue("@TableName", tablename);
        Mycon.cmd.Parameters.AddWithValue("@IDField", idfield);        
        SqlParameter p1 = new SqlParameter("@Idvalue", SqlDbType.VarChar, 10);
        p1.Direction = ParameterDirection.Input;
        p1.Value = value;
        Mycon.cmd.Parameters.Add(p1);
        SqlParameter p2 = new SqlParameter("@msg", SqlDbType.VarChar, 8000);
        p2.Direction = ParameterDirection.Output;
        Mycon.cmd.Parameters.Add(p2);
        try
        {
            Mycon.Open();
            SqlDataReader sdr;
            sdr = Mycon.cmd.ExecuteReader();
            dt.Load(sdr);

            return dt;
        }
        catch (Exception)
        {
            
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();

            }
            Mycon.cmd.Dispose();
        }
        return dt;
    }
    public DataTable FillFarmerGrid(string sp_name)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = sp_name;
        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
        return dt;
    }
    public DataTable FillFarmerDetailsSearch(string sp_name, string App_No, string Name, string District, string Block)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = sp_name;
        Mycon.cmd.Parameters.AddWithValue("@App_No", App_No);
        Mycon.cmd.Parameters.AddWithValue("@Name", Name);
        Mycon.cmd.Parameters.AddWithValue("@D_NAME", District);
        Mycon.cmd.Parameters.AddWithValue("@B_NAME", Block);
       // Mycon.cmd.Parameters.AddWithValue("@usertype", usertype); // added by supriya at 27thssep2018
       
        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
        return dt;
    }
    public DataTable FillFarmerDetailsSearch1(string sp_name, string App_No, string Name, string District, string Block, string usertype)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = sp_name;
        Mycon.cmd.Parameters.AddWithValue("@App_No", App_No);
        Mycon.cmd.Parameters.AddWithValue("@Name", Name);
        Mycon.cmd.Parameters.AddWithValue("@D_NAME", District);
        Mycon.cmd.Parameters.AddWithValue("@B_NAME", Block);
        Mycon.cmd.Parameters.AddWithValue("@usertype", usertype); // added by prashant at 15june2019

        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
        return dt;
    }
    public DataTable FarmerStageDetail(string sp_name, string App_No, string type)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = sp_name;
        Mycon.cmd.Parameters.AddWithValue("@App_No", App_No);
        Mycon.cmd.Parameters.AddWithValue("@SPtype", type);
        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
        return dt;
    }
    public DataTable GetApplForVendors(string sp_name, string VendorCode, string App_No, string Name, string District, string Block)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = sp_name;
        Mycon.cmd.Parameters.AddWithValue("@VendorCode", VendorCode);
        Mycon.cmd.Parameters.AddWithValue("@App_No", App_No);
        Mycon.cmd.Parameters.AddWithValue("@Name", Name);
        Mycon.cmd.Parameters.AddWithValue("@D_NAME", District);
        Mycon.cmd.Parameters.AddWithValue("@B_NAME", Block);
        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
        return dt;
    }
    public DataTable FillFarmerSearch(string sp_name, string App_No, string Name, string District)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = sp_name;
        Mycon.cmd.Parameters.AddWithValue("@App_No", App_No);
        Mycon.cmd.Parameters.AddWithValue("@Name", Name);
        Mycon.cmd.Parameters.AddWithValue("@D_NAME", District);
        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
        return dt;
    }
    public DataTable FillFarmerSearch1(string sp_name, string App_No, string Name, string District, string usertype)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = sp_name;
        Mycon.cmd.Parameters.AddWithValue("@App_No", App_No);
        Mycon.cmd.Parameters.AddWithValue("@Name", Name);
        Mycon.cmd.Parameters.AddWithValue("@D_NAME", District);
        Mycon.cmd.Parameters.AddWithValue("@usertype", usertype); // added by prashant at 15june2019
        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
        return dt;
    }
    public string ChangeDateToMMddyyyy(string strDate)
    {
        string strdd = strDate.Substring(0, 2);
        string strMM = strDate.Substring(3, 2);
        string strYY = strDate.Substring(6, 4);
        string DateModified = strMM + "/" + strdd + "/" + strYY;
        return DateModified;
    }
    public DataTable SelectFillddl(string sp_name, string S_Value)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = sp_name;

        Mycon.cmd.Parameters.AddWithValue("@S_Value", S_Value);
        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
        return dt;
    }
    public DataTable GetDetailByAppNoFromAPPTRN(string APP_NO)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = "[USP_GetDetailByAppNoFromAPPTRN]";
        Mycon.cmd.Parameters.AddWithValue("@APP_NO", APP_NO);
        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
        return dt;
    }
    public DataTable EQ1(string Q)
    {
        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.Text;
        Mycon.cmd.CommandText = Q;
        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
        return dt;
    }
  public Boolean FormAuthorize(string UserID, string Url)
    {
        //Url = "~" + Url.Substring(7);
       // Url = "~" + Url.Substring(14);
        //string str = "select Distinct FileName from Master.Role R inner join Master.Child C ON C.ParentID=R.ParentID where UserID='"+ @UserID +"' and Permission=1 and FileName='"+ @Url+"'";

        //string str = "select Distinct FileName from Master.Role R inner join Master.Child C ON C.ParentID=R.ParentID where UserID=(  select top(1) UserType from V_Users where  UserId= '" + @UserID + "')  and Permission=1 and FileName='" + @Url + "'";
        // DataTable dt = new DataTable();
       // dt = EQ1(str);

        MyConnection Mycon = new MyConnection();
        DataTable dt = new DataTable();
        Mycon.Open();
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.CommandText = "CheckFormAuthentication";
        Mycon.cmd.Parameters.AddWithValue("@userid", UserID);
        Mycon.cmd.Parameters.AddWithValue("@Url", Url);
        SqlDataReader sdr;
        sdr = Mycon.cmd.ExecuteReader();
        dt.Load(sdr);
        Mycon.Close();
      
     
        if (dt.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }
  public void FillDDL2(ref DropDownList ddl, string selectdesc, string TextField, string ValueField, string tablename)
  {
      ddl.Items.Clear();
      MyConnection Mycon = new MyConnection();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = "USP_FillDLL2";
      Mycon.cmd.Parameters.AddWithValue("@TableName", tablename);
      Mycon.cmd.Parameters.AddWithValue("@TextField", TextField);
      Mycon.cmd.Parameters.AddWithValue("@ValueField", ValueField);
      SqlDataReader sdr;
      DataTable dt = new DataTable();
      sdr = Mycon.cmd.ExecuteReader();

      
      dt.Load(sdr);
      ddl.DataSource = dt;

      ddl.DataTextField = TextField;
      ddl.DataValueField = ValueField;
      ddl.DataBind();
      ddl.Items.Insert(0, selectdesc);
      ddl.SelectedValue.Insert(0, "0");
      Mycon.Close();
  }
  public void FillDDLFrom2(ref DropDownList ddl, string selectdesc, string TextField, string ValueField, string tablename, string wherekey, string wherevalue)
  {
      ddl.Items.Clear();
      MyConnection Mycon = new MyConnection();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = "USP_FillDLLFrom2";
      Mycon.cmd.Parameters.AddWithValue("@TableName", tablename);
      Mycon.cmd.Parameters.AddWithValue("@TextField", TextField);
      Mycon.cmd.Parameters.AddWithValue("@ValueField", ValueField);
      Mycon.cmd.Parameters.AddWithValue("@WhereField", wherekey);
      Mycon.cmd.Parameters.AddWithValue("@WhereValue", wherevalue);
      SqlDataReader sdr;
      DataTable dt = new DataTable();
      sdr = Mycon.cmd.ExecuteReader();

      dt.Load(sdr);
      ddl.DataSource = dt;

      ddl.DataTextField = TextField;
      ddl.DataValueField = ValueField;
      ddl.DataBind();
      ddl.Items.Insert(0, selectdesc);
      ddl.SelectedValue.Insert(0, "0");
      Mycon.Close();
  }
  public void FillDDLCrop(ref DropDownList ddl, string selectdesc, string TextField1,string TextField2, string ValueField, string tablename)
  {
      ddl.Items.Clear();
      MyConnection Mycon = new MyConnection();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = "USP_FillDLLCROP";
      Mycon.cmd.Parameters.AddWithValue("@TableName", tablename);
      Mycon.cmd.Parameters.AddWithValue("@TextField1", TextField1);
      Mycon.cmd.Parameters.AddWithValue("@TextField2", TextField2);
      Mycon.cmd.Parameters.AddWithValue("@ValueField", ValueField);
      SqlDataReader sdr;
      DataTable dt = new DataTable();
      sdr = Mycon.cmd.ExecuteReader();

      dt.Load(sdr);
      ddl.DataSource = dt;
      ddl.DataTextField = TextField1;
      ddl.DataValueField = ValueField;
      ddl.DataBind();
      ddl.Items.Insert(0, selectdesc);
      ddl.SelectedValue.Insert(0, "0");
      Mycon.Close();
  }

  public void FillDDLCrop(ref DropDownList ddl)
  {
      ddl.Items.Clear();      
      DataTable dt = new DataTable();
      dt = EQ("SELECT * FROM V_Crop ORDER BY CROP_DESC");
      ddl.DataSource = dt;
      ddl.DataTextField = "CROP_DESC";
      ddl.DataValueField = "CROP_CODE";
      ddl.DataBind();
      ddl.Items.Insert(0, "---Select---");
      ddl.SelectedValue.Insert(0, "0");     
  }


  public DataTable FillVenderDetailsSearch(string sp_name, string Name)
  {
      MyConnection Mycon = new MyConnection();
      DataTable dt = new DataTable();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@Name", Name);
      SqlDataReader sdr;
      sdr = Mycon.cmd.ExecuteReader();
      dt.Load(sdr);
      Mycon.Close();
      return dt;
  }

  public DataTable FillVenderAndDisterbuterDetailsSearch(string sp_name, string VName, string DName)
  {
      MyConnection Mycon = new MyConnection();
      DataTable dt = new DataTable();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@VName", VName);
      Mycon.cmd.Parameters.AddWithValue("@DName", DName);
      SqlDataReader sdr;
      sdr = Mycon.cmd.ExecuteReader();
      dt.Load(sdr);
      Mycon.Close();
      return dt;
  }
  public DataTable GetDetailByAppNoForEstimate(string APP_NO)
  {
      MyConnection Mycon = new MyConnection();
      DataTable dt = new DataTable();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = "USP_GetDetailByAppNoForEstiMate";
      Mycon.cmd.Parameters.AddWithValue("@APP_NO", APP_NO);
      SqlDataReader sdr;
      sdr = Mycon.cmd.ExecuteReader();
      dt.Load(sdr);
      Mycon.Close();
      return dt;
  }
  public DataSet GetDetailByAppNoForEstimateNew(string APP_NO)
  {
      MyConnection MyCon = new MyConnection();
      DataSet ds = new DataSet();
      MyCon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
      MyCon.adp.SelectCommand.CommandText = "USP_GetDetailByAppNoForEstiMateANDSANCTION";
      MyCon.adp.SelectCommand.Parameters.AddWithValue("@APP_NO", APP_NO);
      MyCon.adp.Fill(ds);
      return ds;
  }
  public double DoubleConverter(string str)
  { 
      double dValue=0;

      if (Convert.ToString(str).Trim().Length == 0)
      {
          str = "0.00";
      }
      dValue = Convert.ToDouble(str);
      return dValue;
  }
  public DataTable FillFarmerDetailsVender(string sp_name, string App_No, string Name, string VenderCode)
  {
      MyConnection Mycon = new MyConnection();
      DataTable dt = new DataTable();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@App_No", App_No);
      Mycon.cmd.Parameters.AddWithValue("@Name", Name);
      Mycon.cmd.Parameters.AddWithValue("@V_CODE", VenderCode);
      SqlDataReader sdr;
      sdr = Mycon.cmd.ExecuteReader();
      dt.Load(sdr);
      Mycon.Close();
      return dt;
  }
  public DataTable GetDetailforComplaintByAppNo(string APP_NO)
  {
      MyConnection Mycon = new MyConnection();
      DataTable dt = new DataTable();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = "[USP_GetDetailforcomplaintByAppNo]";
      Mycon.cmd.Parameters.AddWithValue("@APP_NO", APP_NO);
      SqlDataReader sdr;
      sdr = Mycon.cmd.ExecuteReader();
      dt.Load(sdr);
      Mycon.Close();
      return dt;
  }
  public DataTable FillammountSearch()
  {
      MyConnection Mycon = new MyConnection();
      DataTable dt = new DataTable();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = "LENC_licencefee_Search";
      SqlDataReader sdr;
      sdr = Mycon.cmd.ExecuteReader();
      dt.Load(sdr);
      Mycon.Close();
      return dt;
  }
  public DataTable FillOwnerSearch(string sp_name, string App_No, string NURSERY_NAME, string District)
  {
      MyConnection Mycon = new MyConnection();
      DataTable dt = new DataTable();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@App_No", App_No);
      Mycon.cmd.Parameters.AddWithValue("@NURSERY_NAME", NURSERY_NAME);
      Mycon.cmd.Parameters.AddWithValue("@D_NAME", District);
      SqlDataReader sdr;
      sdr = Mycon.cmd.ExecuteReader();
      dt.Load(sdr);
      Mycon.Close();
      return dt;
  }
  public DataTable GetNurseryDetailByAppNo(string sp_name, string APP_NO)
  {
      MyConnection Mycon = new MyConnection();
      DataTable dt = new DataTable();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@APP_NO", APP_NO);
      SqlDataReader sdr;
      sdr = Mycon.cmd.ExecuteReader();
      dt.Load(sdr);
      Mycon.Close();
      return dt;
  }
  public DataTable FillFarmerDetailsSearch1(string sp_name, string App_No)
  {
      MyConnection Mycon = new MyConnection();
      DataTable dt = new DataTable();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@App_No", App_No);

      SqlDataReader sdr;
      sdr = Mycon.cmd.ExecuteReader();
      dt.Load(sdr);
      Mycon.Close();
      return dt;
  }

  public DataTable EQ1(string sp_name, string App_No, string challanno)
  {
      MyConnection Mycon = new MyConnection();
      DataTable dt = new DataTable();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@App_No", App_No);
      Mycon.cmd.Parameters.AddWithValue("@Challanno", challanno);

      SqlDataReader sdr;
      sdr = Mycon.cmd.ExecuteReader();
      dt.Load(sdr);
      Mycon.Close();
      return dt;
  }
  public DataTable GetDetailforSeedComplaintByAppNo(string APP_NO)
  {
      MyConnection Mycon = new MyConnection();
      DataTable dt = new DataTable();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = "[USP_GetSeedDetailforcomplaintByAppNo]";
      Mycon.cmd.Parameters.AddWithValue("@APP_NO", APP_NO);
      SqlDataReader sdr;
      sdr = Mycon.cmd.ExecuteReader();
      dt.Load(sdr);
      Mycon.Close();
      return dt;
  }
  public DataTable SearchFarmerDetails(string sp_name, string App_No, string Name, string District, string Block, string STAGE_FLAG, string STATUS_FLAG)
  {
      MyConnection Mycon = new MyConnection();
      DataTable dt = new DataTable();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@App_No", App_No);
      Mycon.cmd.Parameters.AddWithValue("@Name", Name);
      Mycon.cmd.Parameters.AddWithValue("@D_NAME", District);
      Mycon.cmd.Parameters.AddWithValue("@B_NAME", Block);
      Mycon.cmd.Parameters.AddWithValue("@STAGE_FLAG", STAGE_FLAG);
      Mycon.cmd.Parameters.AddWithValue("@STATUS_FLAG", STATUS_FLAG);
      SqlDataReader sdr;
      sdr = Mycon.cmd.ExecuteReader();
      dt.Load(sdr);
      Mycon.Close();
      return dt;
  }
  public DataTable FillFarmerAppDocSearch(string sp_name, string App_No, string Name, string District, string Block, string User)
  {
      MyConnection Mycon = new MyConnection();
      DataTable dt = new DataTable();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@App_No", App_No);
      Mycon.cmd.Parameters.AddWithValue("@Name", Name);
      Mycon.cmd.Parameters.AddWithValue("@D_NAME", District);
      Mycon.cmd.Parameters.AddWithValue("@B_NAME", Block);
      Mycon.cmd.Parameters.AddWithValue("@UserID", User);
      SqlDataReader sdr;
      sdr = Mycon.cmd.ExecuteReader();
      dt.Load(sdr);
      Mycon.Close();
      return dt;
  }
  public DataTable FillFarmerAppDocSearchVendor(string sp_name, string App_No, string Name, string District, string Block, string User,string TypeCode)
  {
      MyConnection Mycon = new MyConnection();
      DataTable dt = new DataTable();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@App_No", App_No);
      Mycon.cmd.Parameters.AddWithValue("@Name", Name);
      Mycon.cmd.Parameters.AddWithValue("@D_NAME", District);
      Mycon.cmd.Parameters.AddWithValue("@B_NAME", Block);
      Mycon.cmd.Parameters.AddWithValue("@UserID", User);
      SqlDataReader sdr;
      sdr = Mycon.cmd.ExecuteReader();
      dt.Load(sdr);
      Mycon.Close();
      return dt;
  }
  public DataTable GetTrxnDtls(string appno)
  {
      DataTable dt = new DataTable();
      try
      {
          MyConnection con = new MyConnection();
          con.cmd.CommandText = "dbo.GetTransactionDtls";
          con.cmd.CommandType = CommandType.StoredProcedure;
          con.cmd.Parameters.AddWithValue("@appno", appno);

          con.Open();
          SqlDataReader sdr = con.cmd.ExecuteReader();
          dt.Load(sdr);
          con.Close();
          return dt;
      }
      catch (Exception ex)
      {
          return dt;
      }
  }
  public void DeleteTimeLimitExtendedApp(string flag)
  {

      MyConnection Mycon = new MyConnection();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = "USP_DeleteTimeLimitExceededApp";
      Mycon.cmd.Parameters.Clear();
      Mycon.cmd.Parameters.AddWithValue("@Flag", flag);
      Mycon.cmd.ExecuteNonQuery();
      Mycon.Close();
  }
  public DataTable TimelimitExtendedapplicationdetailsGrid(string sp_name, string district,string fdate,string tdate,string stage)
  {
      MyConnection Mycon = new MyConnection();
      DataTable dt = new DataTable();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.Clear();
      Mycon.cmd.Parameters.AddWithValue("@DCode", district);
      Mycon.cmd.Parameters.AddWithValue("@fdate", fdate);
      Mycon.cmd.Parameters.AddWithValue("@tdate", tdate);
      Mycon.cmd.Parameters.AddWithValue("@Stage", stage);
      SqlDataReader sdr;
      sdr = Mycon.cmd.ExecuteReader();
      dt.Load(sdr);
      Mycon.Close();
      return dt;
  }

  public DataTable Reinspectionappdetails(string sp_name, string vendorcode, string fromdate, string todate)
  {
      MyConnection Mycon = new MyConnection();
      DataTable dt = new DataTable();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@vendorcode", vendorcode);
      Mycon.cmd.Parameters.AddWithValue("@fromdate", fromdate);
      Mycon.cmd.Parameters.AddWithValue("@todate", todate);
      SqlDataReader sdr;
      sdr = Mycon.cmd.ExecuteReader();
      dt.Load(sdr);
      Mycon.Close();
      return dt;
  }
  public DataTable bindddlvendor(string sp_name, string finalyear)
  {
      MyConnection Mycon = new MyConnection();
      DataTable dt = new DataTable();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@FinYear", finalyear);
      SqlDataReader sdr;
      sdr = Mycon.cmd.ExecuteReader();
      dt.Load(sdr);
      Mycon.Close();
      return dt;
  }

  public DataTable BindGridforReport(string sp_name, string CTP_CODE, string ccat_code, string PS_CODE)
  {

      MyConnection Mycon = new MyConnection();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@ccat_code", ccat_code);
      Mycon.cmd.Parameters.AddWithValue("@CTP_CODE", CTP_CODE);
      Mycon.cmd.Parameters.AddWithValue("@PS_CODE", PS_CODE);
      SqlDataReader dr = Mycon.cmd.ExecuteReader();
      DataTable dt = new DataTable();
      dt.Load(dr);
      Mycon.Close();
      return dt;
  }

  public DataTable BindGridforRepot(string sp_name, string ccat_code, string MI_TYPE)
  {

      MyConnection Mycon = new MyConnection();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@ccat_code", ccat_code);
      Mycon.cmd.Parameters.AddWithValue("@MI_TYPE", MI_TYPE);
      SqlDataReader dr = Mycon.cmd.ExecuteReader();
      DataTable dt = new DataTable();
      dt.Load(dr);
      Mycon.Close();
      return dt;
  }


  public DataTable bindgridforreport(string sp_name)
  {
      MyConnection Mycon = new MyConnection();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      SqlDataReader dr = Mycon.cmd.ExecuteReader();
      DataTable dt = new DataTable();
      dt.Load(dr);
      Mycon.Close();
      return dt;

  }
  public DataTable BindGrid(string sp_name, string date, string vendorcode)
  {

      MyConnection Mycon = new MyConnection();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@ValidUpto", date);
      Mycon.cmd.Parameters.AddWithValue("@v_code", vendorcode);
      SqlDataReader dr = Mycon.cmd.ExecuteReader();
      DataTable dt = new DataTable();
      dt.Load(dr);
      Mycon.Close();
      return dt;
  }

  public DataTable BindGridforComponent(string sp_name)
  {

      MyConnection Mycon = new MyConnection();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.Text;
      Mycon.cmd.CommandText = sp_name;
      SqlDataReader dr = Mycon.cmd.ExecuteReader();
      DataTable dt = new DataTable();
      dt.Load(dr);
      Mycon.Close();
      return dt;
  }
  public DataTable bindgridforCTM(string sp_name, string templateid, string areaid)
  {
      MyConnection Mycon = new MyConnection();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@action", "4");
      Mycon.cmd.Parameters.AddWithValue("@TamplateId", templateid);
      Mycon.cmd.Parameters.AddWithValue("@areacode", areaid);
      SqlDataReader dr = Mycon.cmd.ExecuteReader();
      DataTable dt = new DataTable();
      dt.Load(dr);
      Mycon.Close();
      return dt;

  }
  public DataTable bindddlforplantspacing(string sp_name, string tamplateid)
  {
      MyConnection Mycon = new MyConnection();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@action", "2");
      Mycon.cmd.Parameters.AddWithValue("@TamplateId", tamplateid);
      SqlDataReader dr = Mycon.cmd.ExecuteReader();
      DataTable dt = new DataTable();
      dt.Load(dr);
      Mycon.Close();
      return dt;
  }
  public DataTable bindddlforArea(string sp_name, string tamplateid, string plantspacing)
  {
      MyConnection Mycon = new MyConnection();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@action", "3");
      Mycon.cmd.Parameters.AddWithValue("@TamplateId", tamplateid);
      Mycon.cmd.Parameters.AddWithValue("@PlantSpacingCode", plantspacing);
      SqlDataReader dr = Mycon.cmd.ExecuteReader();
      DataTable dt = new DataTable();
      dt.Load(dr);
      Mycon.Close();
      return dt;

  }
  public DataTable BindddlforSMItype(string sp_name)
  {

      MyConnection Mycon = new MyConnection();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@action", "1");
      SqlDataReader dr = Mycon.cmd.ExecuteReader();
      DataTable dt = new DataTable();
      dt.Load(dr);
      Mycon.Close();
      return dt;
  }
  public DataTable BindddlforSMItypewiseVendor(string sp_name, string finalyear, string Smicode)
  {

      MyConnection Mycon = new MyConnection();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@action", "2");
      Mycon.cmd.Parameters.AddWithValue("@FinYear", finalyear);
      Mycon.cmd.Parameters.AddWithValue("@Tamplateid", Smicode);
      SqlDataReader dr = Mycon.cmd.ExecuteReader();
      DataTable dt = new DataTable();
      dt.Load(dr);
      Mycon.Close();
      return dt;
  }
  public DataTable BindddlforSMItypewiseVendor_community(string sp_name, string finalyear, string Smicode, string v_code)
  {

      MyConnection Mycon = new MyConnection();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.Parameters.AddWithValue("@action", "2");
      Mycon.cmd.Parameters.AddWithValue("@FinYear", finalyear);
      Mycon.cmd.Parameters.AddWithValue("@Tamplateid", Smicode);
      Mycon.cmd.Parameters.AddWithValue("@v_code", v_code);
      SqlDataReader dr = Mycon.cmd.ExecuteReader();
      DataTable dt = new DataTable();
      dt.Load(dr);
      Mycon.Close();
      return dt;
  }
  public DataTable BindGridForTemplateMaseter(string sp_name, string PVCHDPE, string SMI_CODE)
  {

      MyConnection Mycon = new MyConnection();
      Mycon.Open();
      Mycon.cmd.CommandText = sp_name;
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.Parameters.AddWithValue("@SMI_CODE", SMI_CODE);
      Mycon.cmd.Parameters.AddWithValue("@PVCHDPE", PVCHDPE);
      SqlDataReader dr = Mycon.cmd.ExecuteReader();
      DataTable dt = new DataTable();
      dt.Load(dr);
      Mycon.Close();
      return dt;
  }
  public void FillDDLFrom2_new(ref DropDownList ddl, string selectdesc, string TextField, string ValueField, string tablename, string wherekey, string wherevalue,string TemplateID)
  {
      ddl.Items.Clear();
      MyConnection Mycon = new MyConnection();
      Mycon.Open();
      Mycon.cmd.CommandType = CommandType.StoredProcedure;
      Mycon.cmd.CommandText = "[USP_CROP_TEMPLATE_WISE]";
      Mycon.cmd.Parameters.AddWithValue("@TableName", tablename);
      Mycon.cmd.Parameters.AddWithValue("@TextField", TextField);
      Mycon.cmd.Parameters.AddWithValue("@ValueField", ValueField);
      Mycon.cmd.Parameters.AddWithValue("@WhereField", wherekey);
      Mycon.cmd.Parameters.AddWithValue("@WhereValue", wherevalue);
      Mycon.cmd.Parameters.AddWithValue("@TemplateId", TemplateID);
      SqlDataReader sdr;
      DataTable dt = new DataTable();
      sdr = Mycon.cmd.ExecuteReader();

      dt.Load(sdr);
      ddl.DataSource = dt;

      ddl.DataTextField = TextField;
      ddl.DataValueField = ValueField;
      ddl.DataBind();
      ddl.Items.Insert(0, selectdesc);
      ddl.SelectedValue.Insert(0, "0");
      Mycon.Close();
  }
  }
