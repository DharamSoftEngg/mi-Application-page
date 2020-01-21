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

/// <summary>
/// Summary description for NewApplication
/// </summary>
public class DLNewApplication
{
    MyConnection Mycon = new MyConnection();
   // SqlDataReader dr;
	public DLNewApplication()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public virtual int insert(PLNewApplication prp, string xmlDoc, string xmlDoc1, string xmlDoc2)
    {
       
        Mycon.cmd.CommandText = "USP_M_APPLICATION_Insert";
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.Parameters.AddWithValue("@APP_DATE", prp.APP_DATE);
        Mycon.cmd.Parameters.AddWithValue("@OWNERSHIP", prp.OWNERSHIP);
        Mycon.cmd.Parameters.AddWithValue("@NAME", prp.NAME);
        Mycon.cmd.Parameters.AddWithValue("@FW_NAME", prp.FW_NAME);
        Mycon.cmd.Parameters.AddWithValue("@RELATION", prp.RELATION);
        Mycon.cmd.Parameters.AddWithValue("@GENDER", prp.GENDER);
        Mycon.cmd.Parameters.AddWithValue("@D_CODE", prp.D_CODE);
        Mycon.cmd.Parameters.AddWithValue("@FinYear",prp.FinYear);
        Mycon.cmd.Parameters.AddWithValue("@B_CODE", prp.B_CODE);
        Mycon.cmd.Parameters.AddWithValue("@V_CODE", prp.V_CODE);
        Mycon.cmd.Parameters.AddWithValue("@Vendor_CODE", prp.Vendor_CODE);
        Mycon.cmd.Parameters.AddWithValue("@HNO", prp.HNO);
        Mycon.cmd.Parameters.AddWithValue("@EMAIL_ID", prp.EMAIL_ID);
        Mycon.cmd.Parameters.AddWithValue("@PH_NO", prp.PH_NO);
        Mycon.cmd.Parameters.AddWithValue("@ADDRESS", prp.ADDRESS);
        Mycon.cmd.Parameters.AddWithValue("@CASTE", prp.CASTE);
        Mycon.cmd.Parameters.AddWithValue("@TL_A", prp.TL_A);
        Mycon.cmd.Parameters.AddWithValue("@KHASRA_NO", prp.KHASRA_NO);
        Mycon.cmd.Parameters.AddWithValue("@KILA_NO", prp.KILA_NO);
        Mycon.cmd.Parameters.AddWithValue("@PRE_SUB_AVAILED", prp.PRE_SUB_AVAILED);
        Mycon.cmd.Parameters.AddWithValue("@SCHEME_NAME", prp.SCHEME_NAME);
        Mycon.cmd.Parameters.AddWithValue("@SCHEME_EST_YR", prp.SCHEME_EST_YR);
        Mycon.cmd.Parameters.AddWithValue("@PRE_SUB_AREA", prp.PRE_SUB_AREA);
        Mycon.cmd.Parameters.AddWithValue("@BAL_ELG_AREA", prp.BAL_ELG_AREA);
        Mycon.cmd.Parameters.AddWithValue("@FarmerTypeId", prp.FarmerTypeId);
        Mycon.cmd.Parameters.AddWithValue("@CROP_CODE", prp.CROP_CODE);
        Mycon.cmd.Parameters.AddWithValue("@DRP_AREA", prp.DRP_AREA);
        Mycon.cmd.Parameters.AddWithValue("@SPK_AREA", prp.SPK_AREA);
        Mycon.cmd.Parameters.AddWithValue("@TOT_AREA", prp.TOT_AREA);
        Mycon.cmd.Parameters.AddWithValue("@WATER_SOURCE", prp.WATER_SOURCE);
        Mycon.cmd.Parameters.AddWithValue("@WATER_SOURCE_DESC", prp.WATER_SOURCE_DESC);
        Mycon.cmd.Parameters.AddWithValue("@WATER_QLT", prp.WATER_QLT);
        Mycon.cmd.Parameters.AddWithValue("@SOIL_TYPE", prp.SOIL_TYPE);
        Mycon.cmd.Parameters.AddWithValue("@SOIL_QLT", prp.SOIL_QLT);
        Mycon.cmd.Parameters.AddWithValue("@ELEC_HR", prp.ELEC_HR);
        Mycon.cmd.Parameters.AddWithValue("@PUMP_HP", prp.PUMP_HP);
        Mycon.cmd.Parameters.AddWithValue("@STAGE_FLAG", prp.STAGE_FLAG);
        Mycon.cmd.Parameters.AddWithValue("@STATUS_FLAG ", prp.STATUS_FLAG);
        Mycon.cmd.Parameters.AddWithValue("@LANG_FLAG ", prp.LANG_FLAG);
        Mycon.cmd.Parameters.AddWithValue("@UserID", prp.UserID);
        Mycon.cmd.Parameters.AddWithValue("@Bank", prp.BankCode);
        Mycon.cmd.Parameters.AddWithValue("@Branch", prp.Branch);
        Mycon.cmd.Parameters.AddWithValue("@AccNo", prp.AccNo);
        Mycon.cmd.Parameters.AddWithValue("@IFSC", prp.IFSC);
        Mycon.cmd.Parameters.AddWithValue("@Aadhar", prp.AadharNo);
        Mycon.cmd.Parameters.AddWithValue("@VoterID", prp.VoterID);
        Mycon.cmd.Parameters.AddWithValue("@IsDisable", prp.Isdisable);
        Mycon.cmd.Parameters.AddWithValue("@Tehsil", prp.Tehsil);
        Mycon.cmd.Parameters.AddWithValue("@GramPanchayatCode", prp.GramPanchayat);
        Mycon.cmd.Parameters.AddWithValue("@Pincode", prp.Pincode);
        Mycon.cmd.Parameters.AddWithValue("@DOB", prp.DOB);
        Mycon.cmd.Parameters.AddWithValue("@age", prp.age);
        Mycon.cmd.Parameters.AddWithValue("@photo", prp.photo);
        Mycon.cmd.Parameters.AddWithValue("@CSCID", prp.CSCID);
        Mycon.cmd.Parameters.AddWithValue("@XMLDATA", xmlDoc);
        Mycon.cmd.Parameters.AddWithValue("@XMLDATA1", xmlDoc1);
        Mycon.cmd.Parameters.AddWithValue("@XMLDATA2", xmlDoc2);
        Mycon.cmd.Parameters.AddWithValue("@TemplateId", prp.Templateid);
        Mycon.cmd.Parameters.AddWithValue("@NRCNo", prp.NRCNo);
        Mycon.cmd.Parameters.AddWithValue("@WaterHravestingSystemID", prp.WaterHravestingSystemID);
        Mycon.cmd.Parameters.AddWithValue("@AgriCircleID", prp.AgriCircleID);
        Mycon.cmd.Parameters.AddWithValue("@ElkaId", prp.ElkaId);
        Mycon.cmd.Parameters.AddWithValue("@WaterLeftingDivices", prp.WaterLiftingDivice);
        Mycon.cmd.Parameters.AddWithValue("@CommunityID", prp.CommunityID);
        System.Data.SqlClient.SqlParameter p1 = new SqlParameter("@TRN_NO", SqlDbType.VarChar, 10);
        System.Data.SqlClient.SqlParameter p2 = new SqlParameter("@APP_NO", SqlDbType.VarChar, 25);
        p1.Direction = ParameterDirection.InputOutput;
        p1.Value = prp.TRN_NO;
        Mycon.cmd.Parameters.Add(p1);
        p2.Direction = ParameterDirection.InputOutput;
        p2.Value = prp.APP_NO;
        Mycon.cmd.Parameters.Add(p2);
        SqlParameter p3 = new SqlParameter("@msg", SqlDbType.VarChar, 200);
        p3.Direction = ParameterDirection.Output;
        Mycon.cmd.Parameters.Add(p3);
        try
        {
            Mycon.Open();
            int RetValue = Mycon.cmd.ExecuteNonQuery();
            Mycon.Close();
            prp.msg = Mycon.cmd.Parameters["@msg"].Value.ToString();
            prp.TRN_NO = Mycon.cmd.Parameters["@TRN_NO"].Value.ToString();
            prp.APP_NO = Mycon.cmd.Parameters["@APP_NO"].Value.ToString();
            return RetValue;
        }
        catch (Exception ex)
        {
            prp.msg = ex.Message.ToString();

            return 0;
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
    public DataTable Printdetail(PLNewApplication pl)
    {
       
        Mycon.Open();
        Mycon.cmd.CommandText = "USP_PrintDetailByAppNo";
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.Parameters.AddWithValue("@APP_NO", pl.APP_NO);
       
        SqlDataReader dr;
        dr = Mycon.cmd.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(dr);
        Mycon.Close();
        return dt;
    }
    public DataSet GetAppdetail(PLNewApplication pl)
    {
     
        Mycon.Open();
        Mycon.adp.SelectCommand.CommandText = "USP_BackApplication_Detail";
        Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
        Mycon.adp.SelectCommand.Parameters.Clear();
        Mycon.adp.SelectCommand.Parameters.AddWithValue("@APP_NO", pl.APP_NO);
        Mycon.adp.SelectCommand.Parameters.AddWithValue("@SPType", pl.SPType);

        DataSet ds = new DataSet();
        Mycon.adp.Fill(ds);
        Mycon.Close();
        return ds;
    }
    public virtual int BackApplication(PLNewApplication pl)
    {

        Mycon.Open();
        Mycon.cmd.CommandText = "USP_BackApplication_Detail";
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.Parameters.Clear();
        Mycon.cmd.Parameters.AddWithValue("@APP_NO", pl.APP_NO);
        Mycon.cmd.Parameters.AddWithValue("@STAGE_FLAG", pl.STAGE_FLAG);
        Mycon.cmd.Parameters.AddWithValue("@SPType", pl.SPType);
      
        Mycon.cmd.ExecuteNonQuery();
        Mycon.Close();
        return 0;
    }
    public DataTable BindTypeofSystem(PLNewApplication pl)
    {

        Mycon.Open();
        Mycon.adp.SelectCommand.CommandText = "GetDetailsFor_SMIType";
        Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
        Mycon.adp.SelectCommand.Parameters.Clear();
        Mycon.adp.SelectCommand.Parameters.AddWithValue("@action", "3");
        Mycon.adp.SelectCommand.Parameters.AddWithValue("@district", pl.D_CODE);
        Mycon.adp.SelectCommand.Parameters.AddWithValue("@FinYear", pl.FinYear);

        DataTable dt = new DataTable();
        Mycon.adp.Fill(dt);
        Mycon.Close();
        return dt;
    }
    
    public DataTable BindWaterLeftingDivices(PLNewApplication pl)
    {

        Mycon.Open();
        Mycon.adp.SelectCommand.CommandText = "GetDetail_FormerApplicationMasterDetail";
        Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
        Mycon.adp.SelectCommand.Parameters.Clear();
        Mycon.adp.SelectCommand.Parameters.AddWithValue("@OWNERSHIP", pl.OWNERSHIP);
        Mycon.adp.SelectCommand.Parameters.AddWithValue("@SPType", pl.SPType);
        Mycon.adp.SelectCommand.Parameters.AddWithValue("@APP_NO", pl.APP_NO);
        Mycon.adp.SelectCommand.Parameters.AddWithValue("@V_CODE", pl.V_CODE);
        Mycon.adp.SelectCommand.Parameters.AddWithValue("@D_CODE", pl.D_CODE);
        DataTable dt = new DataTable();
        Mycon.adp.Fill(dt);
        Mycon.Close();
        return dt;
    }
    public DataTable BindCommunity()
    {

        Mycon.Open();
        Mycon.adp.SelectCommand.CommandText = "USP_BIND_COMMUNITY";
        Mycon.adp.SelectCommand.CommandType = CommandType.StoredProcedure;
        Mycon.adp.SelectCommand.Parameters.Clear();
        DataTable dt = new DataTable();
        Mycon.adp.Fill(dt);
        Mycon.Close();
        return dt;
    }
}
