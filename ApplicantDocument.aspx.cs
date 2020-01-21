using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

public partial class TransactionForms_ApplicantDocument : System.Web.UI.Page
{

    CommonCode cc = new CommonCode();
    PL_MendatoryDocs pl = new PL_MendatoryDocs();
    BL_MendatoryDocs bl = new BL_MendatoryDocs();

    PL_ApplicantDocument pal = new PL_ApplicantDocument();
    BL_ApplicantDocument bal = new BL_ApplicantDocument(); 
       protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~\\Login.aspx");
            }
            else
            {
                string str = "~" + Request.FilePath;
                DataTable dtYear = new DataTable();
                dtYear = cc.EQ("select dbo.FIN_YEAR('" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd") + "')");
                if (Session["FinYear"].ToString().Trim() == dtYear.Rows[0][0].ToString().Trim())
                {
                    btnSave.Enabled = true;
                    btnReset.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                    btnReset.Enabled = false;
                }
                string Userid = Session["UserID"].ToString();
                if (!cc.FormAuthorize(Userid, str))
                {
                    Response.Redirect("~\\MessagePage.aspx");
                }
            }
            BindgrdApplForMendatoryDocs();
            cc.FillDDL2(ref ddlVendor, "---Select---", "V_Name", "V_Code", "Master.VENDOR");

            if (Session["TypeCode"] != null)
            {
                ddlVendor.SelectedValue = Session["TypeCode"].ToString();
                ddlVendor.Enabled = false;

                string strDistributor = "SELECT V_CODE, Distb_CODE, Distb_NAME, Status FROM Master.Distributor WHERE V_Code='" + ddlVendor.SelectedValue.Trim() + "' And Status='A'";
                DataTable dtDistributor = SQL_DBCS.ExecuteDataTable(strDistributor);
                ddlDistributor.DataSource = dtDistributor;
                ddlDistributor.DataTextField = "Distb_NAME";
                ddlDistributor.DataValueField = "Distb_CODE";
                ddlDistributor.DataBind();
                ddlDistributor.Items.Insert(0, "---Select---");
                ddlDistributor.SelectedIndex = 0;

                //cc.FillDDLFrom2(ref ddlDistributor, "---Select---", "Distb_NAME", "Distb_CODE", "Master.Distributor", "V_Code", ddlVendor.SelectedValue.Trim());
                txtApplNo.Focus();
            }
            BindgrdgrdUploadedMendatoryDocs();


            if (Request.QueryString["ApplNo"] != null)
            {
                //txtApplNo.Text = Request.QueryString["ApplNo"].ToString();
                string SQL = "", App_no;
                App_no = Request.QueryString["ApplNo"].ToString();
                SQL = @"SELECT App_No,Name,V_NAME,B_NAME,D_NAME FROM Trans.APPLICATIONS  
INNER JOIN Master.VILLMST ON Trans.APPLICATIONS.V_CODE=Master.VILLMST.V_CODE
INNER JOIN Master.DSTMST ON Trans.APPLICATIONS.D_Code=Master.DSTMST.D_CODE
INNER JOIN Master.BLOCKMST ON Master.DSTMST.D_CODE = Master.BLOCKMST.D_CODE WHERE APP_NO='" + App_no + "'";
                DataTable dt = new DataTable();
                dt = cc.EQ(SQL);
                if (dt.Rows.Count > 0)
                {
                    lblAppNo.Text = dt.Rows[0]["App_No"].ToString();
                    lblFarmerName.Text = dt.Rows[0]["Name"].ToString();
                    lblAddress.Text = "Village:" + dt.Rows[0]["V_NAME"].ToString() + ",  Block:" + dt.Rows[0]["B_NAME"].ToString() + ",  District:" + dt.Rows[0]["D_NAME"].ToString();
                }
            }
        }
       
    }

    public void BindgrdApplForMendatoryDocs()
    {

        DataTable dt = new DataTable();
        dt = cc.FillFarmerDetailsSearch("USP_T_GetApplForMendatoryDocs", txtApplNo.Text.Trim(), txtFarmerName.Text.Trim(), txtDistrict.Text.Trim(), txtBlock.Text.Trim());
        if (dt.Rows.Count > 0)
        {
            grdApplForMendatoryDocs.DataSource = dt;
            grdApplForMendatoryDocs.DataBind();
        }
        else
        {
            grdApplForMendatoryDocs.DataSource = null;
            grdApplForMendatoryDocs.DataBind();
        }
    }
    private void BindgrdgrdUploadedMendatoryDocs()
    {
        string str = "";
        DataTable dt = new DataTable();
        if (Session["Location"].ToString() == "State")
        {
            str = "SELECT * FROM V_MendatoryDocs WHERE VendorCode='" + ddlVendor.SelectedValue.Trim() + "' order by distb_name ";
            dt = cc.EQ(str);
        }
        if (Session["UserType"].ToString() == "3" || Session["UserType"].ToString() == "4")
        {
            if (ddlVendor.SelectedIndex > 0)
                str = "SELECT * FROM V_MendatoryDocs WHERE D_CODE='" + Session["Location"].ToString() + "' and VendorCode='" + ddlVendor.SelectedValue.Trim() + "' order by distb_name ";
            else
                str = "SELECT * FROM V_MendatoryDocs WHERE D_CODE='" + Session["Location"].ToString() + "' order by distb_name ";
            dt = cc.EQ(str);
        }


        if (dt.Rows.Count > 0)
        {
            grdUploadedMendatoryDocs.DataSource = dt;
            grdUploadedMendatoryDocs.DataBind();
            ViewState["dt"] = dt;
        }
        else
        {
            grdUploadedMendatoryDocs.DataSource = null;
            grdUploadedMendatoryDocs.DataBind();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindgrdApplForMendatoryDocs();
    }
    protected void grdApplForMendatoryDocs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdApplForMendatoryDocs.PageIndex = e.NewPageIndex;
        BindgrdApplForMendatoryDocs();
    }
    protected void lnkAppNo_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        LinkButton lnk = (LinkButton)sender;
        GridViewRow grdRow = (GridViewRow)lnk.Parent.Parent;
        //foreach (GridViewRow row in grdApplForMendatoryDocs.Rows)
        //    row.BackColor = System.Drawing.Color.Transparent;
        //grdRow.BackColor = System.Drawing.Color.Yellow;

        LinkButton lnkAppNo = (LinkButton)grdRow.FindControl("lnkAppNo");
        Label lblFName = (Label)grdRow.FindControl("lblFName");
        Label lblDist = (Label)grdRow.FindControl("lblDist");
        Label lblBlock = (Label)grdRow.FindControl("lblBlock");
        Label lblVillage = (Label)grdRow.FindControl("lblVillage");
        lblAppNo.Text = lnkAppNo.Text.Trim().ToString();
        lblFarmerName.Text = lblFName.Text.Trim().ToString();
        lblAddress.Text = "Village:" + lblVillage.Text.Trim().ToString() + ",  Block:" + lblBlock.Text.Trim().ToString() + ",  District:" + lblDist.Text.Trim().ToString();
        DataTable dtOwnerShip = new DataTable();
        dtOwnerShip = cc.EQ("SELECT CASE WHEN OWNERSHIP='I' THEN 'Individual' ELSE 'Community' END AS OWNERSHIP FROM Trans.APPLICATIONS where App_no='" + lnkAppNo.Text.Trim() + "'");
        if (dtOwnerShip.Rows.Count > 0)
        {
            lblOwnerShipType.Text = dtOwnerShip.Rows[0]["OWNERSHIP"].ToString();
        }
    }
    protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        cc.FillDDLFrom2(ref ddlDistributor, "---Select---", "Distb_NAME", "Distb_CODE", "Master.Distributor", "V_Code", ddlVendor.SelectedValue.Trim());
        BindgrdgrdUploadedMendatoryDocs();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        if (lblAppNo.Text.Trim() == "")
        {
            lblMsg.Text = "Please Select Application No.";
            txtApplNo.Focus();
            return;
        }
        if (ddlVendor.SelectedIndex == 0)
        {
            lblMsg.Text = "Please Select Vendor";
            ddlVendor.Focus();
            return;
        }
        if (ddlDistributor.SelectedIndex == 0)
        {
            lblMsg.Text = "Please Select Distributor";
            ddlVendor.Focus();
            return;
        }
        if (fulLandRec.HasFile == false)
        {
            lblMsg.Text = "Please Upload Land Record File";
            fulLandRec.Focus();
            return;
        }
        if (fulLandMap.HasFile == false)
        {
            lblMsg.Text = "Please Upload Land Map File";
            fulLandMap.Focus();
            return;
        }
        if (fulSoilTestRpt.HasFile == false)
        {
            lblMsg.Text = "Please Upload Soil Test Report";
            fulSoilTestRpt.Focus();
            return;
        }
        if (fulWaterTestRpt.HasFile == false)
        {
            lblMsg.Text = "Please Upload Water Test Report";
            fulWaterTestRpt.Focus();
            return;
        }
        if (fuApplFilledManually.HasFile == false)
        {
            lblMsg.Text = "Please Upload Application Filled Manually";
            fuApplFilledManually.Focus();
            return;
        }

        if (fupsystemD.HasFile == false)
        {
            lblMsg.Text = "Please Upload System Design File";
            fupsystemD.Focus();
            return;
        }
        try
        {
          
            //pl.APP_NO = lblAppNo.Text.Trim();
            //pl.VendorCode = ddlVendor.SelectedValue.Trim();
            //pl.Distb_Code = ddlDistributor.SelectedValue.Trim();

            //string FolderPath = "";
            //string FileName = "";
            //string FilePath = "";

            //FolderPath = Server.MapPath("../writereaddata/LandRecord");
            //FileName = strLandRecord;
            //FilePath = Path.Combine(FolderPath, FileName);
            //if (File.Exists(FilePath))
            //{
            //    File.SetAttributes(FilePath, FileAttributes.Normal);
            //    File.Delete(FilePath);
            //}
            //if (fulLandRec.HasFile)
            //{
            //    string[] strFileLandRec = fulLandRec.FileName.Split('.');

            //    if (strFileLandRec[1].ToLower() == "txt" || strFileLandRec[1].ToLower() == "pdf" || strFileLandRec[1].ToLower() == "jpg" || strFileLandRec[1].ToLower() == "jpeg" || strFileLandRec[1].ToLower() == "png" || strFileLandRec[1].ToLower() == "bmp" || strFileLandRec[1].ToLower() == "gif" || strFileLandRec[1].ToLower() == "doc" || strFileLandRec[1].ToLower() == "docx")
            //    {
            //        FileName = lblAppNo.Text.Trim().ToString().Replace("/", "_") + "_LR" + "." + (strFileLandRec.Length > 0 ? strFileLandRec[1].ToString() : "");
            //        FilePath = Path.Combine(FolderPath, FileName);
            //        fulLandRec.SaveAs(FilePath);
            //        pl.LAND_REC_FILENM = FileName;
            //    }
            //    else
            //    {
            //        lblMsg.Text = "Land Recod File Should Have Extention Of Either txt,doc,docx,jpg,jpeg,png,bmp,gif or pdf";
            //        return;
            //    }
            //}


            
            //FolderPath = "";
            //FileName = "";
            //FilePath = "";

            //FolderPath = Server.MapPath("../writereaddata/LandMap");
            //FileName = strLandMap;
            //FilePath = Path.Combine(FolderPath, FileName);
            //if (File.Exists(FilePath))
            //{
            //    File.SetAttributes(FilePath, FileAttributes.Normal);
            //    File.Delete(FilePath);
            //}
            //if (fulLandMap.HasFile)
            //{
            //    string[] strFileLandMap = fulLandMap.FileName.Split('.');
            //    if (strFileLandMap[1].ToLower() == "txt" || strFileLandMap[1].ToLower() == "pdf" || strFileLandMap[1].ToLower() == "jpg" || strFileLandMap[1].ToLower() == "jpeg" || strFileLandMap[1].ToLower() == "png" || strFileLandMap[1].ToLower() == "bmp" || strFileLandMap[1].ToLower() == "gif" || strFileLandMap[1].ToLower() == "doc" || strFileLandMap[1].ToLower() == "docx")
            //    {
            //        FileName = lblAppNo.Text.Trim().ToString().Replace("/", "_") + "_LM" + "." + (strFileLandMap.Length > 0 ? strFileLandMap[1].ToString() : "");
            //        FilePath = Path.Combine(FolderPath, FileName);
            //        fulLandMap.SaveAs(FilePath);
            //        pl.LAND_MAP_FILENM = FileName;
            //    }
            //    else
            //    {
            //        lblMsg.Text = "Land Map File Should Have Extention Of Either txt,doc,docx,jpg,jpeg,png,bmp,gif or pdf";
            //        return;
            //    }
            //}
            //FolderPath = "";
            //FileName = "";
            //FilePath = "";

            //FolderPath = Server.MapPath("../writereaddata/SoilTest");
            //FileName = strSoilTest;
            //FilePath = Path.Combine(FolderPath, FileName);
            //if (File.Exists(FilePath))
            //{
            //    File.SetAttributes(FilePath, FileAttributes.Normal);
            //    File.Delete(FilePath);
            //}
            //if (fulSoilTestRpt.HasFile)
            //{
            //    string[] strFileSoilTest = fulSoilTestRpt.FileName.Split('.');
            //    if (strFileSoilTest[1].ToLower() == "txt" || strFileSoilTest[1].ToLower() == "pdf" || strFileSoilTest[1].ToLower() == "jpg" || strFileSoilTest[1].ToLower() == "jpeg" || strFileSoilTest[1].ToLower() == "png" || strFileSoilTest[1].ToLower() == "bmp" || strFileSoilTest[1].ToLower() == "gif" || strFileSoilTest[1].ToLower() == "doc" || strFileSoilTest[1].ToLower() == "docx")
            //    {
            //        FileName = lblAppNo.Text.Trim().ToString().Replace("/", "_") + "_ST" + "." + (strFileSoilTest.Length > 0 ? strFileSoilTest[1].ToString() : "");
            //        FilePath = Path.Combine(FolderPath, FileName);
            //        fulSoilTestRpt.SaveAs(FilePath);
            //        pl.SOIL_TST_FILENM = FileName;
            //    }
            //    else
            //    {
            //        lblMsg.Text = "Soil Test Report File Should Have Extention Of Either txt,doc,docx,jpg,jpeg,png,bmp,gif or pdf";
            //        return;
            //    }
            //}
            //FolderPath = "";
            //FileName = "";
            //FilePath = "";

            //FolderPath = Server.MapPath("../writereaddata/WaterTest");
            //FileName = strWaterTest;
            //FilePath = Path.Combine(FolderPath, FileName);
            //if (File.Exists(FilePath))
            //{
            //    File.SetAttributes(FilePath, FileAttributes.Normal);
            //    File.Delete(FilePath);
            //}
            //if (fulWaterTestRpt.HasFile)
            //{
            //    string[] strFileWaterTest = fulWaterTestRpt.FileName.Split('.');
            //    if (strFileWaterTest[1].ToLower() == "txt" || strFileWaterTest[1].ToLower() == "pdf" || strFileWaterTest[1].ToLower() == "jpg" || strFileWaterTest[1].ToLower() == "jpeg" || strFileWaterTest[1].ToLower() == "png" || strFileWaterTest[1].ToLower() == "bmp" || strFileWaterTest[1].ToLower() == "gif" || strFileWaterTest[1].ToLower() == "doc" || strFileWaterTest[1].ToLower() == "docx")
            //    {
            //        FileName = lblAppNo.Text.Trim().ToString().Replace("/", "_") + "_WT" + "." + (strFileWaterTest.Length > 0 ? strFileWaterTest[1].ToString() : "");
            //        FilePath = Path.Combine(FolderPath, FileName);
            //        fulWaterTestRpt.SaveAs(FilePath);
            //        pl.WATER_TST_FILENM = FileName;
            //    }
            //    else
            //    {
            //        lblMsg.Text = "Water Test Report File Should Have Extention Of Either txt,doc,docx,jpg,jpeg,png,bmp,gif or pdf";
            //        return;
            //    }
            //}
            //FolderPath = "";
            //FileName = "";
            //FilePath = "";


            //FolderPath = Server.MapPath("../writereaddata/AppForm");
            //FileName = strApplFrm;
            //FilePath = Path.Combine(FolderPath, FileName);
            //if (File.Exists(FilePath))
            //{
            //    File.SetAttributes(FilePath, FileAttributes.Normal);
            //    File.Delete(FilePath);
            //}
            //if (fuApplFilledManually.HasFile)
            //{
            //    string[] strFileApplFilledManually = fuApplFilledManually.FileName.Split('.');
            //    if (strFileApplFilledManually[1].ToLower() == "txt" || strFileApplFilledManually[1].ToLower() == "pdf" || strFileApplFilledManually[1].ToLower() == "jpg" || strFileApplFilledManually[1].ToLower() == "jpeg" || strFileApplFilledManually[1].ToLower() == "png" || strFileApplFilledManually[1].ToLower() == "bmp" || strFileApplFilledManually[1].ToLower() == "gif" || strFileApplFilledManually[1].ToLower() == "doc" || strFileApplFilledManually[1].ToLower() == "docx")
            //    {
            //        FileName = lblAppNo.Text.Trim().ToString().Replace("/", "_") + "_AM" + "." + (strFileApplFilledManually.Length > 0 ? strFileApplFilledManually[1].ToString() : "");
            //        FilePath = Path.Combine(FolderPath, FileName);
            //        fuApplFilledManually.SaveAs(FilePath);
            //        pl.APP_FRM_FILENM = FileName;
            //    }
            //    else
            //    {
            //        lblMsg.Text = "'Application Filled manually' Should Have Extention Of Either txt,doc,docx,jpg,jpeg,png,bmp,gif or pdf";
            //        return;
            //    }
            //}

            //FolderPath = "";
            //FileName = "";
            //FilePath = "";


            //FolderPath = Server.MapPath("../writereaddata/SystemDesign");
            //FileName = strSystemDesign;
            //FilePath = Path.Combine(FolderPath, FileName);
            //if (File.Exists(FilePath))
            //{
            //    File.SetAttributes(FilePath, FileAttributes.Normal);
            //    File.Delete(FilePath);
            //}

            //if (fupsystemD.HasFile)
            //{
            //    string[] strfupsystemD = fupsystemD.FileName.Split('.');
            //    if (strfupsystemD[1].ToLower() == "txt" || strfupsystemD[1].ToLower() == "pdf" || strfupsystemD[1].ToLower() == "jpg" || strfupsystemD[1].ToLower() == "jpeg" || strfupsystemD[1].ToLower() == "png" || strfupsystemD[1].ToLower() == "bmp" || strfupsystemD[1].ToLower() == "gif" || strfupsystemD[1].ToLower() == "doc" || strfupsystemD[1].ToLower() == "docx")
            //    {
            //        FileName = lblAppNo.Text.Trim().ToString().Replace("/", "_") + "_AM" + "." + (strfupsystemD.Length > 0 ? strfupsystemD[1].ToString() : "");
            //        FilePath = Path.Combine(FolderPath, FileName);
            //        fupsystemD.SaveAs(FilePath);
            //        pl.SystemDesign_FILENM = FileName;
            //    }
            //    else
            //    {
            //        lblMsg.Text = "'System Design File' Should Have Extention Of Either txt,doc,docx,jpg,jpeg,png,bmp,gif or pdf";
            //        return;
            //    }
            //}

          
            byte[] LAND_REC_FILENMDATAimageSize = null;
            byte[] LAND_MAP_FILENMDATAimageSize = null;
            byte[] SOIL_TST_FILENMDATAimageSize = null;
            byte[] WATER_TST_FILEDATAimageSize = null;
            string FileName = ""; 
            

            pal.APP_NO = lblAppNo.Text.Trim();
            pal.VendorCode = ddlVendor.SelectedValue.Trim();
            pal.Distb_Code = ddlDistributor.SelectedValue.Trim();
            if (fulLandRec.HasFile)
            {
                if (fulLandRec.PostedFile != null && fulLandRec.PostedFile.FileName != "")
                {
                    string[] strFileLandRec = fulLandRec.FileName.Split('.');
                   
                    if (strFileLandRec[1].ToLower() == "txt" || strFileLandRec[1].ToLower() == "pdf" || strFileLandRec[1].ToLower() == "jpg" || strFileLandRec[1].ToLower() == "jpeg" || strFileLandRec[1].ToLower() == "png" || strFileLandRec[1].ToLower() == "bmp" || strFileLandRec[1].ToLower() == "gif" || strFileLandRec[1].ToLower() == "doc" || strFileLandRec[1].ToLower() == "docx")
                    {
                        FileName = lblAppNo.Text.Trim().ToString().Replace("/", "_") + "_LR" ;
                        //FilePath = Path.Combine(FolderPath, FileName);
                        //fulLandRec.SaveAs(FilePath);
                        //pl.LAND_REC_FILENM = FileName;
                        pal.LAND_REC_FILENAME = FileName;
                        pal.LAND_REC_FILETYPE = "." + (strFileLandRec.Length > 0 ? strFileLandRec[1].ToString() : "");
                        LAND_REC_FILENMDATAimageSize = new byte[fulLandRec.PostedFile.ContentLength];
                        HttpPostedFile uploadedImage = fulLandRec.PostedFile;
                        uploadedImage.InputStream.Read(LAND_REC_FILENMDATAimageSize, 0, (int)fulLandRec.PostedFile.ContentLength);
                        pal.LAND_REC_FILENMDATA = LAND_REC_FILENMDATAimageSize;
                    }
                    else
                    {
                        lblMsg.Text = "Land Recod File Should Have Extention Of Either txt,doc,docx,jpg,jpeg,png,bmp,gif or pdf";
                        return;
                    }
                }
            }
           
            FileName = "";
           
            if (fulLandMap.HasFile)
            {

                if (fulLandMap.PostedFile != null && fulLandMap.PostedFile.FileName != "")
                {
                    string[] strFileLandMap = fulLandMap.FileName.Split('.');
                    if (strFileLandMap[1].ToLower() == "txt" || strFileLandMap[1].ToLower() == "pdf" || strFileLandMap[1].ToLower() == "jpg" || strFileLandMap[1].ToLower() == "jpeg" || strFileLandMap[1].ToLower() == "png" || strFileLandMap[1].ToLower() == "bmp" || strFileLandMap[1].ToLower() == "gif" || strFileLandMap[1].ToLower() == "doc" || strFileLandMap[1].ToLower() == "docx")
                    {
                        FileName = lblAppNo.Text.Trim().ToString().Replace("/", "_") + "_LM" ;
                        //FilePath = Path.Combine(FolderPath, FileName);
                        //fulLandMap.SaveAs(FilePath);
                        //pl.LAND_MAP_FILENM = FileName;

                        pal.LAND_MAP_FILENAME=FileName;
                        pal.LAND_MAP_FILENTYPE="." + (strFileLandMap.Length > 0 ? strFileLandMap[1].ToString() : "");
                        LAND_MAP_FILENMDATAimageSize = new byte[fulLandMap.PostedFile.ContentLength];
                        HttpPostedFile uploadedImage = fulLandMap.PostedFile;
                        uploadedImage.InputStream.Read(LAND_MAP_FILENMDATAimageSize, 0, (int)fulLandMap.PostedFile.ContentLength);
                         pal.LAND_MAP_FILENMDATA = LAND_MAP_FILENMDATAimageSize;




                    }
                    else
                    {
                        lblMsg.Text = "Land Map File Should Have Extention Of Either txt,doc,docx,jpg,jpeg,png,bmp,gif or pdf";
                        return;
                    }
                }
            }

          
            FileName = "";
           

            if (fulSoilTestRpt.HasFile)
            {

                if (fulSoilTestRpt.PostedFile != null && fulSoilTestRpt.PostedFile.FileName != "")
                {
                    string[] strFileSoilTest = fulSoilTestRpt.FileName.Split('.');
                    if (strFileSoilTest[1].ToLower() == "txt" || strFileSoilTest[1].ToLower() == "pdf" || strFileSoilTest[1].ToLower() == "jpg" || strFileSoilTest[1].ToLower() == "jpeg" || strFileSoilTest[1].ToLower() == "png" || strFileSoilTest[1].ToLower() == "bmp" || strFileSoilTest[1].ToLower() == "gif" || strFileSoilTest[1].ToLower() == "doc" || strFileSoilTest[1].ToLower() == "docx")
                    {
                        FileName = lblAppNo.Text.Trim().ToString().Replace("/", "_") + "_ST";
                        //FilePath = Path.Combine(FolderPath, FileName);
                        //fulSoilTestRpt.SaveAs(FilePath);
                        //pl.SOIL_TST_FILENM = FileName;
                        pal.SOIL_TST_FILETYPE = "." + (strFileSoilTest.Length > 0 ? strFileSoilTest[1].ToString() : "");
                        pal.SOIL_TST_FILENAME = FileName;


                        SOIL_TST_FILENMDATAimageSize = new byte[fulSoilTestRpt.PostedFile.ContentLength];
                        HttpPostedFile uploadedImage = fulSoilTestRpt.PostedFile;
                        uploadedImage.InputStream.Read(SOIL_TST_FILENMDATAimageSize, 0, (int)fulSoilTestRpt.PostedFile.ContentLength);
                        pal.SOIL_TST_FILENMDATA = SOIL_TST_FILENMDATAimageSize;
                        
                    }
                    else
                    {
                        lblMsg.Text = "Soil Test Report File Should Have Extention Of Either txt,doc,docx,jpg,jpeg,png,bmp,gif or pdf";
                        return;
                    }
                }
            }

            
            FileName = "";
           


            if (fulWaterTestRpt.HasFile)
            {

                if (fulWaterTestRpt.PostedFile != null && fulWaterTestRpt.PostedFile.FileName != "")
                {
                    string[] strFileWaterTest = fulWaterTestRpt.FileName.Split('.');
                    if (strFileWaterTest[1].ToLower() == "txt" || strFileWaterTest[1].ToLower() == "pdf" || strFileWaterTest[1].ToLower() == "jpg" || strFileWaterTest[1].ToLower() == "jpeg" || strFileWaterTest[1].ToLower() == "png" || strFileWaterTest[1].ToLower() == "bmp" || strFileWaterTest[1].ToLower() == "gif" || strFileWaterTest[1].ToLower() == "doc" || strFileWaterTest[1].ToLower() == "docx")
                    {
                        FileName = lblAppNo.Text.Trim().ToString().Replace("/", "_") + "_WT";
                        //FilePath = Path.Combine(FolderPath, FileName);
                        //fulWaterTestRpt.SaveAs(FilePath);
                        //pl.WATER_TST_FILENM = FileName;

                        pal.WATER_TST_FILENAME = FileName;
                        pal.WATER_TST_FILETYPE = "." + (strFileWaterTest.Length > 0 ? strFileWaterTest[1].ToString() : "");

                        WATER_TST_FILEDATAimageSize = new byte[fulWaterTestRpt.PostedFile.ContentLength];
                        HttpPostedFile uploadedImage = fulWaterTestRpt.PostedFile;
                        uploadedImage.InputStream.Read(WATER_TST_FILEDATAimageSize, 0, (int)fulWaterTestRpt.PostedFile.ContentLength);
                        pal.WATER_TST_FILEDATA = WATER_TST_FILEDATAimageSize;
                      
                        
                    }
                    else
                    {
                        lblMsg.Text = "Water Test Report File Should Have Extention Of Either txt,doc,docx,jpg,jpeg,png,bmp,gif or pdf";
                        return;
                    }
                }
            }
           
            FileName = "";
           
            byte[] APP_FRM_FILENMDATAimageSize = null;
            if (fuApplFilledManually.HasFile)
            {

                if (fuApplFilledManually.PostedFile != null && fuApplFilledManually.PostedFile.FileName != "")
                {
                    string[] strFileApplFilledManually = fuApplFilledManually.FileName.Split('.');
                    if (strFileApplFilledManually[1].ToLower() == "txt" || strFileApplFilledManually[1].ToLower() == "pdf" || strFileApplFilledManually[1].ToLower() == "jpg" || strFileApplFilledManually[1].ToLower() == "jpeg" || strFileApplFilledManually[1].ToLower() == "png" || strFileApplFilledManually[1].ToLower() == "bmp" || strFileApplFilledManually[1].ToLower() == "gif" || strFileApplFilledManually[1].ToLower() == "doc" || strFileApplFilledManually[1].ToLower() == "docx")
                    {
                        FileName = lblAppNo.Text.Trim().ToString().Replace("/", "_") + "_AM";

                        pal.APP_FRM_FILENAME = FileName;
                        pal.APP_FRM_FILETYPE = "." + (strFileApplFilledManually.Length > 0 ? strFileApplFilledManually[1].ToString() : "");

                        APP_FRM_FILENMDATAimageSize = new byte[fuApplFilledManually.PostedFile.ContentLength];
                        HttpPostedFile uploadedImage = fuApplFilledManually.PostedFile;
                        uploadedImage.InputStream.Read(APP_FRM_FILENMDATAimageSize, 0, (int)fuApplFilledManually.PostedFile.ContentLength);

                        pal.APP_FRM_FILENMDATA = APP_FRM_FILENMDATAimageSize;
                       

                    }
                    else
                    {
                        lblMsg.Text = "'Application Filled manually' Should Have Extention Of Either txt,doc,docx,jpg,jpeg,png,bmp,gif or pdf";
                        return;
                    }
                }
            }
           
            FileName = "";
         
            byte[] SystemDesign_FILETYPEimageSize = null;
            if (fupsystemD.HasFile)
            {

                if (fupsystemD.PostedFile != null && fupsystemD.PostedFile.FileName != "")
                {
                    string[] strfupsystemD = fupsystemD.FileName.Split('.');
                    if (strfupsystemD[1].ToLower() == "txt" || strfupsystemD[1].ToLower() == "pdf" || strfupsystemD[1].ToLower() == "jpg" || strfupsystemD[1].ToLower() == "jpeg" || strfupsystemD[1].ToLower() == "png" || strfupsystemD[1].ToLower() == "bmp" || strfupsystemD[1].ToLower() == "gif" || strfupsystemD[1].ToLower() == "doc" || strfupsystemD[1].ToLower() == "docx")
                    {
                        FileName = lblAppNo.Text.Trim().ToString().Replace("/", "_") + "_AM"; 
                        //FilePath = Path.Combine(FolderPath, FileName);
                        //fupsystemD.SaveAs(FilePath);
                        //pl.SystemDesign_FILENM = FileName;
                        pal.SystemDesign_FILENAME = FileName;
                        pal.SystemDesign_FILETYPE = "." + (strfupsystemD.Length > 0 ? strfupsystemD[1].ToString() : "");
                        SystemDesign_FILETYPEimageSize = new byte[fupsystemD.PostedFile.ContentLength];
                        HttpPostedFile uploadedImage = fupsystemD.PostedFile;
                        uploadedImage.InputStream.Read(SystemDesign_FILETYPEimageSize, 0, (int)fupsystemD.PostedFile.ContentLength);
                       
                        pal.SystemDesign_FILENMDATA = SystemDesign_FILETYPEimageSize;
                    }
                    else
                    {
                        lblMsg.Text = "'System Design File' Should Have Extention Of Either txt,doc,docx,jpg,jpeg,png,bmp,gif or pdf";
                        return;
                    }
                }
            }

            bal.Insert(pal);
            btnReset_Click(null, null);
            lblMsg.Text = pal.msg.ToString();
            if (btnSave.Text == "Update")
            {
                lblMsg.Text = "Record Updated Successfully...";
                btnSave.Text = "Save";
            }
        }
        catch (Exception ex)
        {
            //lblMsg.Text = ex.Message;
            //return;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtApplNo.Text = "";
        txtFarmerName.Text = "";
        txtDistrict.Text = "";
        txtBlock.Text = "";
        BindgrdApplForMendatoryDocs();
        //foreach (GridViewRow row in grdApplForMendatoryDocs.Rows)
        //    row.BackColor = System.Drawing.Color.Transparent;
        //lblMsg.Text = "";
        lblAppNo.Text = "";
        lblFarmerName.Text = "";
        lblAddress.Text = "";
        ddlDistributor.SelectedIndex = 0;
        BindgrdgrdUploadedMendatoryDocs();
        strLandRecord = "";
        strLandMap = "";
        strSoilTest = "";
        strWaterTest = "";
        strApplFrm = "";
        strSystemDesign = "";
        txtApplNo.Focus();
        ddlVendor.SelectedIndex = 0;
        btnSave.Text = "Save";
    }
    protected void grdUploadedMendatoryDocs_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdUploadedMendatoryDocs.PageIndex = e.NewPageIndex;
        grdUploadedMendatoryDocs.DataSource = (DataTable)ViewState["dt"];
        grdUploadedMendatoryDocs.DataBind();
    }
    protected void btnRemoveLR_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        string strLocation = Server.MapPath("../writereaddata/LandRecord");
        string filePath = Path.Combine(strLocation, strLandRecord);
        if (File.Exists(filePath))
        {
            try
            {
                File.Delete(filePath);
                lblMsg.Text = "Land Record File Removed";
            }
            catch (System.IO.IOException ex)
            {
                lblMsg.Text = ex.Message;
                return;
            }
        }
        else
            lblMsg.Text = "Land Record File Not Found";
    }
    protected void btnRemoveST_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        string strLocation = Server.MapPath("../writereaddata/SoilTest");
        string filePath = Path.Combine(strLocation, strSoilTest);
        if (File.Exists(filePath))
        {
            try
            {
                File.Delete(filePath);
                lblMsg.Text = "Soil Test Report Removed";
            }
            catch (System.IO.IOException ex)
            {
                lblMsg.Text = ex.Message;
                return;
            }
        }
        else
            lblMsg.Text = "Soil Test Report Not Found";
    }
    protected void btnRemoveWT_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        string strLocation = Server.MapPath("../writereaddata/WaterTest");
        string filePath = Path.Combine(strLocation, strWaterTest);
        if (File.Exists(filePath))
        {
            try
            {
                File.Delete(filePath);
                lblMsg.Text = "Water Test Report Removed";
            }
            catch (System.IO.IOException ex)
            {
                lblMsg.Text = ex.Message;
                return;
            }
        }
        else
            lblMsg.Text = "Water Test Report Not Found";
    }
    protected void btnRemoveAM_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        string strLocation = Server.MapPath("../writereaddata/AppForm");
        string filePath = Path.Combine(strLocation, strApplFrm);
        if (File.Exists(filePath))
        {
            try
            {
                File.Delete(filePath);
                lblMsg.Text = "Application File Removed";
            }
            catch (System.IO.IOException ex)
            {
                lblMsg.Text = ex.Message;
                return;
            }
        }
        else
            lblMsg.Text = "Application File Not Found";
    }
    protected void lnkLAND_REC_FILENM_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;

       
        GridViewRow row = (GridViewRow)lnk.Parent.Parent;
        int i = row.RowIndex;
        Label lblAPP_NO = (Label)grdUploadedMendatoryDocs.Rows[i].FindControl("lblAPP_NO");
        if (!string.IsNullOrEmpty(lnk.CommandArgument.ToString()))
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '../writereaddata/LandRecord/" + lnk.CommandArgument.Trim() + "', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        }
        else
        {


            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '../TransactionForms/ImageFile.aspx?LandRec=" + lblAPP_NO.Text + "' , null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        
        }
    }
    protected void lnkLAND_MAP_FILENM_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;

        GridViewRow row = (GridViewRow)lnk.Parent.Parent;
        int i = row.RowIndex;
        Label lblAPP_NO = (Label)grdUploadedMendatoryDocs.Rows[i].FindControl("lblAPP_NO");

        if (!string.IsNullOrEmpty(lnk.CommandArgument.ToString()))
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '../writereaddata/LandMap/" + lnk.CommandArgument.Trim() + "', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '../TransactionForms/ImageFile.aspx?LandMap=" + lblAPP_NO.Text + "' , null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        }
    }
    protected void lnkSOIL_TST_FILENM_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;

        GridViewRow row = (GridViewRow)lnk.Parent.Parent;
        int i = row.RowIndex;
        Label lblAPP_NO = (Label)grdUploadedMendatoryDocs.Rows[i].FindControl("lblAPP_NO");
        if (!string.IsNullOrEmpty(lnk.CommandArgument.ToString()))
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '../writereaddata/SoilTest/" + lnk.CommandArgument.Trim() + "', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '../TransactionForms/ImageFile.aspx?SoilMap=" + lblAPP_NO.Text + "' , null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        
        }
    }
    protected void lnkWATER_TST_FILENM_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow row = (GridViewRow)lnk.Parent.Parent;
        int i = row.RowIndex;
        Label lblAPP_NO = (Label)grdUploadedMendatoryDocs.Rows[i].FindControl("lblAPP_NO");
        if (!string.IsNullOrEmpty(lnk.CommandArgument.ToString()))
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '../writereaddata/WaterTest/" + lnk.CommandArgument.Trim() + "', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '../TransactionForms/ImageFile.aspx?WaterMap=" + lblAPP_NO.Text + "' , null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

        }
    }
    protected void lnkAPP_FRM_FILENM_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;

        GridViewRow row = (GridViewRow)lnk.Parent.Parent;
        int i = row.RowIndex;
        Label lblAPP_NO = (Label)grdUploadedMendatoryDocs.Rows[i].FindControl("lblAPP_NO");

        if (!string.IsNullOrEmpty(lnk.CommandArgument.ToString()))
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '../writereaddata/AppForm/" + lnk.CommandArgument.Trim() + "', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '../TransactionForms/ImageFile.aspx?APPMap=" + lblAPP_NO.Text + "' , null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

        }
    }

    protected void lnkSystemDesign_FILENM_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow row = (GridViewRow)lnk.Parent.Parent;
        int i = row.RowIndex;
        Label lblAPP_NO = (Label)grdUploadedMendatoryDocs.Rows[i].FindControl("lblAPP_NO");

        if (!string.IsNullOrEmpty(lnk.CommandArgument.ToString()))
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '../writereaddata/SystemDesign/" + lnk.CommandArgument.Trim() + "', null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( '../TransactionForms/ImageFile.aspx?SystemDisMap=" + lblAPP_NO.Text + "' , null, 'height=700,width=760,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        }
    }

    public static string strLandRecord = "";
    public static string strLandMap = "";
    public static string strSoilTest = "";
    public static string strWaterTest = "";
    public static string strApplFrm = "";
    public static string strSystemDesign = "";
    protected void lnkSelect_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        LinkButton lnkSelect = (LinkButton)sender;
        GridViewRow grdRow = (GridViewRow)lnkSelect.Parent.Parent;
        Label lblVendorCode = (Label)grdRow.FindControl("lblVendorCode");
        Label lblDistributorCode = (Label)grdRow.FindControl("lblDistributorCode");
        Label lblAPP_NO = (Label)grdRow.FindControl("lblAPP_NO");
        Label lblFName = (Label)grdRow.FindControl("lblFName");
        Label lblAddrs = (Label)grdRow.FindControl("lblAddress");

        LinkButton lnkLAND_REC_FILENM = (LinkButton)grdRow.FindControl("lnkLAND_REC_FILENM");
        LinkButton lnkLAND_MAP_FILENM = (LinkButton)grdRow.FindControl("lnkLAND_MAP_FILENM");
        LinkButton lnkSOIL_TST_FILENM = (LinkButton)grdRow.FindControl("lnkSOIL_TST_FILENM");
        LinkButton lnkWATER_TST_FILENM = (LinkButton)grdRow.FindControl("lnkWATER_TST_FILENM");
        LinkButton lnkAPP_FRM_FILENM = (LinkButton)grdRow.FindControl("lnkAPP_FRM_FILENM");
        LinkButton lnkSystemDesign_FILENM = (LinkButton)grdRow.FindControl("lnkSystemDesign_FILENM");

        lblAppNo.Text = lblAPP_NO.Text.Trim();
        lblFarmerName.Text = lblFName.Text.Trim();
        lblAddress.Text = lblAddrs.Text.Trim();
        ddlVendor.SelectedValue = lblVendorCode.Text.Trim();
        if (ddlVendor.SelectedIndex > 0)
        {
            cc.FillDDLFrom2(ref ddlDistributor, "---Select---", "Distb_NAME", "Distb_CODE", "Master.Distributor", "V_Code", ddlVendor.SelectedValue.Trim());
            ddlDistributor.SelectedValue = lblDistributorCode.Text.Trim();
        }
        ddlDistributor.SelectedValue = lblDistributorCode.Text.Trim();
        strLandRecord = lnkLAND_REC_FILENM.CommandArgument.Trim();
        strLandMap = lnkLAND_MAP_FILENM.CommandArgument.Trim();
        strSoilTest = lnkSOIL_TST_FILENM.CommandArgument.Trim();
        strWaterTest = lnkWATER_TST_FILENM.CommandArgument.Trim();
        strApplFrm = lnkAPP_FRM_FILENM.CommandArgument.Trim();
        strSystemDesign = lnkSystemDesign_FILENM.CommandArgument.Trim();
        btnSave.Text = "Update";
        //fulLandRec.ResolveUrl("");
        //fulSoilTestRpt.ResolveUrl("");
        //fulWaterTestRpt.ResolveUrl("");
        //fuApplFilledManually.ResolveUrl("");
    }
    protected void btnRemoveLM_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        string strLocation = Server.MapPath("../writereaddata/LandMap");
        string filePath = Path.Combine(strLocation, strLandMap);
        if (File.Exists(filePath))
        {
            try
            {
                File.Delete(filePath);
                lblMsg.Text = "Land Map File Removed";
            }
            catch (System.IO.IOException ex)
            {
                lblMsg.Text = ex.Message;
                return;
            }
        }
        else
            lblMsg.Text = "Land Map File Not Found";
    }
    protected void btnRsearch_Click(object sender, EventArgs e)
    {
        BindSearchgrdgrdUploadedMendatoryDocs();

    }

    private void BindSearchgrdgrdUploadedMendatoryDocs()
    {
        string str = "";
        DataTable dt = new DataTable();
        string str1 = "";
        //APP_NO
        if (txtrappno.Text.Trim() != "")
        {
            str1 = "and APP_NO like '%" + txtrappno.Text.Trim() + "%'";
        }
        if (txtrfarmer.Text.Trim() != "")
        {
            str1 += "and NAME like '%" + txtrfarmer.Text.Trim() + "%'";
        }


        if (Session["Location"].ToString() == "State")
        {
            str = "SELECT * FROM V_MendatoryDocs WHERE VendorCode='" + ddlVendor.SelectedValue.Trim() + "' " + str1 + " order by distb_name ";
            dt = cc.EQ(str);
        }
        if (Session["UserType"].ToString() == "3" || Session["UserType"].ToString() == "4")
        {
            if (ddlVendor.SelectedIndex > 0)
                str = "SELECT * FROM V_MendatoryDocs WHERE D_CODE='" + Session["Location"].ToString() + "' and VendorCode='" + ddlVendor.SelectedValue.Trim() + "' " + str1 + " order by distb_name ";
            else
                str = "SELECT * FROM V_MendatoryDocs WHERE D_CODE='" + Session["Location"].ToString() + "' " + str1 + " order by distb_name ";
            dt = cc.EQ(str);
        }


        if (dt.Rows.Count > 0)
        {
            grdUploadedMendatoryDocs.DataSource = dt;
            grdUploadedMendatoryDocs.DataBind();
            ViewState["dt"] = dt;
        }
        else
        {
            grdUploadedMendatoryDocs.DataSource = null;
            grdUploadedMendatoryDocs.DataBind();
        }
    }
    protected void grdApplForMendatoryDocs_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            e.Row.Attributes.Add("onmouseover",
             "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='yellow'; this.style.color='black';");

            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");


        }
    }
    protected void grdUploadedMendatoryDocs_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            e.Row.Attributes.Add("onmouseover",
             "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='yellow'; this.style.color='black';");

            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");


        }
    }
    protected void btnRemoveSD_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        string strLocation = Server.MapPath("../writereaddata/SystemDesign");
        string filePath = Path.Combine(strLocation, strSystemDesign);
        if (File.Exists(filePath))
        {
            try
            {
                File.Delete(filePath);
                lblMsg.Text = "System Design File Removed";
            }
            catch (System.IO.IOException ex)
            {
                lblMsg.Text = ex.Message;
                return;
            }
        }
        else
            lblMsg.Text = "System Design File Not Found";
    }
    
}