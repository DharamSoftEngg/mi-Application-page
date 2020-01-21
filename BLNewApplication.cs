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

/// <summary>
/// Summary description for NewApplication
/// </summary>
public class BLNewApplication
{
CommonCode cc = new CommonCode();
	public BLNewApplication()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public virtual int insert(PLNewApplication prp, string xmlDoc, string xmlDoc1, string xmlDoc2)
    {
        DLNewApplication obj = new DLNewApplication();
        return obj.insert(prp, xmlDoc, xmlDoc1, xmlDoc2);
    }
public DataTable Get_Trn_No()
    {
        DataTable dtTRN_NO = new DataTable();
        return dtTRN_NO = cc.EQ("SELECT ISNULL(MAX([TRN_NO]),0) AS TRN_NO FROM [Trans].[MEMBERS]");
    }


    public DataTable GET_CROPMST(string APP_NO)
    {
        DataTable dt = new DataTable();
        return dt = cc.EQ("SELECT Trans.APPLICATIONS.*,Replace(Replace(Trans.APPLICATIONS.EMAIL_ID,'[at]','@'),'[dot]','.') as EMAIL_ID1,Convert(Varchar,APP_DATE,103) As APP_DATE,Convert(Varchar,DOB,103) As DOBA, Master.CROPMST.CTP_CODE,(select [D_NAME] from [Master].[DSTMST] where [Master].[DSTMST].[D_CODE]=Trans.APPLICATIONS.D_CODE)district,(Select [V_NAME] from [Master].[VILLMST] where [Master].[VILLMST].[V_CODE]=Trans.APPLICATIONS.V_CODE)village ,(Select [AgriSubdivisionName] from [dbo].[M_AgricultureSubdivsion] where [dbo].[M_AgricultureSubdivsion].[Tableid]=Trans.APPLICATIONS.TehsilCode)SUBDIVISION ,(Select [ElekaName] from [dbo].[M_Eleka] where [dbo].[M_Eleka].[E_Code]=Trans.APPLICATIONS.ElkaId)ELEKANAME ,(Select Distinct [GramPanchName] from [dbo].[M_GramPanchayat] where [dbo].[M_GramPanchayat].[Tableid]=Trans.APPLICATIONS.GramPanchayatCode)GRAMPANCHAYAT ,(Select [C_NAME] from [Master].[AGRI_CIRCLEMST] where [Master].[AGRI_CIRCLEMST].[C_CODE]=Trans.APPLICATIONS.AgriCircleID)Circle ,(Select [B_NAME] from [Master].[BLOCKMST] where [Master].[BLOCKMST].[B_CODE]=Trans.APPLICATIONS.B_CODE)BLOCKNAME FROM Trans.APPLICATIONS LEFT JOIN Master.CROPMST ON Trans.APPLICATIONS.CROP_CODE = Master.CROPMST.CROP_CODE where APP_NO='" + APP_NO + "'");
    }

    public DataTable GET_MEMBER_DETAIL(string APP_NO)
    {
        DataTable dt = new DataTable();
        return dt = cc.EQ("SELECT TRN_NO, APP_NO, NAME, FW_NAME, GENDER,GENDER AS GENDERF, P_ADDRESS, C_ADDRESS, CASTE,CASTE AS CASTEF, DRP_AREA, SPK_AREA, TOT_AREA,TL_A,PRE_SUB_AVAILED,SCHEME_NAME,SCHEME_EST_YR,PRE_SUB_AREA,BAL_ELG_AREA  FROM Trans.MEMBERS where APP_NO='" + APP_NO + "'");
    }

    public DataTable GET_LAND_INFORMATION(string APP_NO)
    {
        DataTable dt = new DataTable();
        return dt = cc.EQ("SELECT Land_Information.* FROM Land_Information where APP_NO='" + APP_NO + "'");
    }
    public DataTable GET_CROP_INFORMATION(string APP_NO)
    {
        DataTable dt = new DataTable();
        return dt = cc.EQ("SELECT APP_CROP_DETAILS.TRN_NO, APP_CROP_DETAILS.APP_NO, APP_CROP_DETAILS.CROP_TYPE AS CROP_TYPE_CODE, APP_CROP_DETAILS.CROP_CODE AS CROP_CODE_CODE, APP_CROP_DETAILS.DRP_AREA, APP_CROP_DETAILS.SPK_AREA, Master.CTPMST.CTP_DESC AS CROP_TYPE , Master.CROPMST.CROP_DESC AS CROP_CODE FROM APP_CROP_DETAILS INNER JOIN Master.CTPMST ON APP_CROP_DETAILS.CROP_TYPE = Master.CTPMST.CTP_CODE INNER JOIN Master.CROPMST ON APP_CROP_DETAILS.CROP_CODE = Master.CROPMST.CROP_CODE where APP_NO='" + APP_NO + "'");
    }

    public DataTable GET_MEMBER_DETAILS_ON_APP(string APP_NO)
    {
        DataTable dt = new DataTable();
        return dt = cc.EQ("SELECT TRN_NO, APP_NO, NAME, FW_NAME, GENDER,GENDER AS GENDERF, P_ADDRESS, C_ADDRESS, CASTE,CASTE AS CASTEF, DRP_AREA, SPK_AREA, TOT_AREA FROM Trans.MEMBERS where APP_NO='" + APP_NO + "'");
    }


    public DataTable GET_CROP_DETAILS(string APP_NO)
    {
        DataTable dt = new DataTable();
        return dt = cc.EQ("SELECT APP_CROP_DETAILS.* FROM APP_CROP_DETAILS where APP_NO='" + APP_NO + "'");

    }

    public DataTable GET_DSTMST()
    {
        DataTable dt = new DataTable();
        return dt = cc.EQ("SELECT D_CODE,D_NAME_Hindi FROM Master.DSTMST");

    }

    public DataTable GET_BLOCKMST(string D_CODE)
    {
        DataTable dt = new DataTable();
        return dt = cc.EQ("SELECT B_CODE,B_NAME_HINDI FROM Master.BLOCKMST where D_CODE='" + D_CODE + "'");
    }


    public DataTable GET_VILLAGE(string B_CODE)
    {
        DataTable dt = new DataTable();
        return dt = cc.EQ("SELECT '0' as V_CODE,'---चयन---' as  V_NAME_HINDI union select RTRIM(LTRIM(V_CODE)) as V_CODE ,V_NAME_HINDI FROM Master.VILLMST where B_CODE='" + B_CODE + "'");
    }

    public DataTable GET_CASTEMST()
    {
        DataTable dt = new DataTable();
        return dt = cc.EQ("SELECT CASTE_CODE,CASTE_NAME_HINDI FROM Master.CASTEMST");
    }

    public DataTable GET_FARMERTYPE(string FinYear)
    {
        DataTable dt = new DataTable();
        return dt = cc.EQ("SELECT FarmerTypeId,FarmerTypeHindi,FarmerType FROM Master.FarmerType where FinYear='" + FinYear + "'");
    }

    public DataTable GET_CTPMST()
    {
        DataTable dt = new DataTable();

        return dt = cc.EQ("SELECT CTP_CODE,CTP_DESC_HINDI FROM Master.CTPMST");
    }

    public DataTable GET_CROPMST_HND_DETAIL(string CTP_CODE)
    {
        DataTable dt = new DataTable();
        return dt = cc.EQ("SELECT  '0' as CROP_CODE,'---चयन---' as  CROP_DESC_HINDI union select RTRIM(LTRIM(CROP_CODE)) as CROP_CODE,CROP_DESC_HINDI FROM Master.CROPMST where CTP_CODE='" + CTP_CODE + "'");
    }

    public DataTable GET_VILL_ON_ON_BLOCK(string B_CODE)
    {
        DataTable dt = new DataTable();
        return dt = cc.EQ("SELECT V_CODE,V_NAME_HINDI FROM Master.VILLMST where B_CODE='" + B_CODE + "'");
    }

    public DataTable GET_LAND_INFO(string KhasraNo, string KilaNo, string V_CODE)
    {
        DataTable dt = new DataTable();
        return dt = cc.EQ("SELECT COUNT(*) FROM Land_Information left JOIN Trans.APPLICATIONS ON Land_Information.APP_NO = Trans.APPLICATIONS.APP_NO WHERE KhasraNo='" + KhasraNo + "' And KilaNo='" + KilaNo + "' AND v_CODE='" + V_CODE + "' and Delete_Status='0'");

    }
    public DataTable Printdetail(PLNewApplication pl)
    {
        DLNewApplication obj = new DLNewApplication();
        return obj.Printdetail(pl);
    }
    public DataSet GetAppdetail(PLNewApplication pl)
    {
        DLNewApplication obj = new DLNewApplication();
        return obj.GetAppdetail(pl);
    }

    public virtual int BackApplication(PLNewApplication pl)
    {
        DLNewApplication obj = new DLNewApplication();
        return obj.BackApplication(pl);
    }
    public DataTable BindTypeofSystem(PLNewApplication pl)
    {
        DLNewApplication obj = new DLNewApplication();
        return obj.BindTypeofSystem(pl);
    }

    

        public DataTable BindWaterLeftingDivices(PLNewApplication pl)
    {
        DLNewApplication obj = new DLNewApplication();
        return obj.BindWaterLeftingDivices(pl);
    }
        public DataTable BindCommunity()
        {
            DLNewApplication obj = new DLNewApplication();
            return obj.BindCommunity();
        }
}
