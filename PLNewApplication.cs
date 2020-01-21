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
public class PLNewApplication
{
    public PLNewApplication()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public String msg { set; get; }
    public String TRN_NO { get; set; }
    public String APP_NO { get; set; }
    public String APP_DATE { get; set; }
    public String OWNERSHIP { get; set; }
    public String NAME { get; set; }
    public String FW_NAME { get; set; }
    public String RELATION { get; set; }
    public String GENDER { get; set; }
    public String D_CODE { get; set; }
    public String FinYear { get; set; }
    public String B_CODE { get; set; }
    public String V_CODE { get; set; }
    public String Vendor_CODE { get; set; }
    public String HNO { get; set; }
    public String EMAIL_ID { get; set; }
    public String PH_NO { get; set; }
    public String ADDRESS { get; set; }
    public String CASTE { get; set; }
    public String TL_A { get; set; }
    public string KHASRA_NO { get; set; }
    public string KILA_NO { get; set; }
    public String PRE_SUB_AVAILED { set; get; }
    public String SCHEME_NAME { set; get; }
    public String SCHEME_EST_YR { set; get; }
    public String PRE_SUB_AREA { get; set; }
    public String BAL_ELG_AREA { get; set; }
    public String FarmerTypeId { get; set; }
    public String CROP_CODE { set; get; }
    public String DRP_AREA { set; get; }
    public String SPK_AREA { set; get; }
    public String TOT_AREA { set; get; }
    public String WATER_SOURCE { set; get; }
    public String WATER_SOURCE_DESC { set; get; }
    public String WATER_QLT { set; get; }
    public String SOIL_TYPE { set; get; }
    public String SOIL_QLT { set; get; }
    public String ELEC_HR { set; get; }
    public String PUMP_HP { set; get; }
    public String STAGE_FLAG { set; get; }
    public String STATUS_FLAG { set; get; }
    public String LANG_FLAG { set; get; }
    public String UserID { set; get; }
    public String BankCode { set; get; }
    public String Branch { set; get; }
    public String AccNo { set; get; }
    public String IFSC { set; get; }
    public String AadharNo { set; get; }
    public bool Isdisable { set; get; }
    public String Tehsil { set; get; }
    public String GramPanchayat { set; get; }
    public string Templateid { set; get; }
    public String photo { set; get; }
    public String DOB { set; get; }
    public int age { set; get; }
    public String Pincode { get; set; }
    public String CSCID { get; set; }
    public int SPType { get; set; }
    // added by supriya
    public String FOC_NAME { get; set; }
    public String AppType { get; set; }


    public String NRCNo { get; set; }
    public String VoterID { get; set; }
    public String WaterHravestingSystemID { get; set; }
    public String AgriCircleID { get; set; }
    public String ElkaId { get; set; }
    public String WaterLiftingDivice { get; set; }
    public String CommunityID { get; set; }

}
