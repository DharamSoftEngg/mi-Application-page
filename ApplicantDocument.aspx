<%@ Page  Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="ApplicantDocument.aspx.cs" Inherits="TransactionForms_ApplicantDocument" Title="Upload Mandatory Documents" Theme="Basic" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 <script type="text/javascript" language="JavaScript">        
        function Validator() {
            if (document.getElementById('<%=lblAppNo.ClientID%>').innerText.trim() == "") {
                alert("Please Select Application No.");
                document.getElementById('<%=lblAppNo.ClientID%>').focus();
                return false;
            }
            if (document.getElementById('<%=ddlVendor.ClientID%>').selectedIndex == 0) {
                alert("Please Select Vendor");
                document.getElementById('<%=ddlVendor.ClientID%>').focus();
                return false;
            }
            if (document.getElementById('<%=ddlDistributor.ClientID%>').selectedIndex == 0) {
                alert("Please Select Distributor");
                document.getElementById('<%=ddlDistributor.ClientID%>').focus();
                return false;
            }
            if (!document.getElementById('<%=fulLandRec.ClientID%>').value) {
                alert("Please Upload Land Record File");
                document.getElementById('<%=fulLandRec.ClientID%>').focus();
                return false;
            }
            if (!document.getElementById('<%=fulSoilTestRpt.ClientID%>').value) {
                alert("Please Upload Soil Test Report");
                document.getElementById('<%=fulSoilTestRpt.ClientID%>').focus();
                return false;
            }
            if (!document.getElementById('<%=fulWaterTestRpt.ClientID%>').value) {
                alert("Please Upload Water Test Report");
                document.getElementById('<%=fulWaterTestRpt.ClientID%>').focus();
                return false;
            }
            if (!document.getElementById('<%=fuApplFilledManually.ClientID%>').value) {
                alert("Please Upload Application Filled Manually");
                document.getElementById('<%=fuApplFilledManually.ClientID%>').focus();
                return false;
            }
             if (!document.getElementById('<%=fupsystemD.ClientID%>').value) {
                alert("Please Upload Application Filled Manually");
                document.getElementById('<%=fuApplFilledManually.ClientID%>').focus();
                return false;
            }
        }
-->
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <table width="100%" class="dashboardtable">
        <tr align="center" class="lableheading">
            <td colspan="9">
              MANDATORY
                DOCUMENTS
            </td>
        </tr>
        <tr>
            <td style="padding-right: 5px" colspan="2">
                <cc1:AutoCompleteExtender ID="aceApplNo" runat="server" CompletionSetCount="10" MinimumPrefixLength="1"
                    ServiceMethod="GetApplForMendatoryDocs" ServicePath="~/WebService.asmx" TargetControlID="txtApplNo">
                </cc1:AutoCompleteExtender>
            </td>
            <td style="padding-right: 5px" colspan="2">
                <cc1:AutoCompleteExtender ID="aceFarmerName" runat="server" MinimumPrefixLength="1"
                    ServiceMethod="GetFarmerForMendatoryDocs" ServicePath="~/WebService.asmx" TargetControlID="txtFarmerName">
                </cc1:AutoCompleteExtender>
            </td>
            <td style="padding-right: 5px" colspan="2">
                <cc1:AutoCompleteExtender ID="aceDistrict" runat="server" CompletionSetCount="10"
                    MinimumPrefixLength="1" ServiceMethod="GetDistForMendatoryDocs" ServicePath="~/WebService.asmx"
                    TargetControlID="txtDistrict">
                </cc1:AutoCompleteExtender>
            </td>
            <td style="padding-right: 5px" colspan="2">
                <cc1:AutoCompleteExtender ID="aceBlock" runat="server" CompletionSetCount="10" MinimumPrefixLength="1"
                    ServiceMethod="GetBlockForMendatoryDocs" ServicePath="~/WebService.asmx" TargetControlID="txtBlock">
                </cc1:AutoCompleteExtender>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding-right: 5px">
                Application No.
            </td>
            <td align="left">
                <asp:TextBox ID="txtApplNo" runat="server" Width="180px" ToolTip="Enter correct application number"></asp:TextBox>
            </td>
            <td style="padding-right: 5px">
                Farmer Name
            </td>
            <td align="left">
                <asp:TextBox ID="txtFarmerName" runat="server" Width="100px" ToolTip="Enter farmer name"></asp:TextBox>
            </td>
            <td style="padding-right: 5px">
                District
            </td>
            <td align="left">
                <asp:TextBox ID="txtDistrict" runat="server" Width="100px" ToolTip="Enter district name"></asp:TextBox>
            </td>
            <td style="padding-right: 5px">
                Block
            </td>
            <td align="left">
                <asp:TextBox ID="txtBlock" runat="server" Width="100px" ToolTip="Enter block name"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                    CssClass="cmdbutton" ToolTip="Click to search record" />
            </td>
        </tr>
    </table>
    <table width="100%" class="dashboardtable">
        <tr>
            <td>
                <asp:GridView ID="grdApplForMendatoryDocs" runat="server" AutoGenerateColumns="False"
                    AllowPaging="True" Width="100%" PageSize="5" SkinID="GridView" EmptyDataText="No Application Found For Uploading Mendatory Documents "
                    OnPageIndexChanging="grdApplForMendatoryDocs_PageIndexChanging" 
                    onrowdatabound="grdApplForMendatoryDocs_RowDataBound">
                    <EmptyDataRowStyle ForeColor="#FF5050" HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="Application No." HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkAppNo" runat="server" Text='<%# bind("APP_NO") %>' CausesValidation="false"
                                    Visible="true" OnClick="lnkAppNo_Click" ToolTip="Click to select application" CommandName="Select"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Farmer Name" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblFName" runat="server" Text='<%# bind("NAME") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="District" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblDist" runat="server" Text='<%# bind("District") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Block" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblBlock" runat="server" Text='<%# bind("Block") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Village" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblVillage" runat="server" Text='<%# bind("V_NAME") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table width="100%" class="dashboardtable"
        align="center">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblMsg" runat="server" EnableViewState="false" ForeColor="#FF5050"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 10px">
                Application No.
            </td>
            <td>
                <asp:Label ID="lblAppNo" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 10px">
                Name of farmer
            </td>
            <td>
                <asp:Label ID="lblFarmerName" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 10px">
                Address
            </td>
            <td>
                <asp:Label ID="lblAddress" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 10px">
                Ownership Type
            </td>
            <td>
                <asp:Label ID="lblOwnerShipType" runat="server" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 10px">
                Vendor
            </td>
            <td>
                <asp:DropDownList ID="ddlVendor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged"
                    ToolTip="Click to select vendor name">
                </asp:DropDownList>
                &nbsp;
            </td>
        </tr>
         <tr>
            <td align="right" style="padding-right: 10px">
                Distributor
            </td>
            <td>
                <asp:DropDownList ID="ddlDistributor" runat="server"
                    ToolTip="Click to Select Distributor Name">
                </asp:DropDownList>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <b>Enclosures :</b>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" style="padding-right: 10px">
                Land Record With Khasra No
            </td>
            <td>
                <asp:FileUpload ID="fulLandRec" runat="server" TabIndex="29" ToolTip="Click to browse and upload land record with khasra number" />                 
                &nbsp; <asp:Button ID="btnRemoveLR" runat="server" OnClick="btnRemoveLR_Click" Text="Remove"
                    CssClass="cmdbutton" Visible="false" ToolTip="Click to remove land record" />
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" style="padding-right: 10px">
                Map Of Land With Khasra No&nbsp;
            </td>
            <td>
                <asp:FileUpload ID="fulLandMap" runat="server" TabIndex="29" ToolTip="Click to browse and upload map of land with khasra number" />                 
                &nbsp;&nbsp;<asp:Button ID="btnRemoveLM" runat="server" Text="Remove"
                    CssClass="cmdbutton" Visible="false" ToolTip="Click to remove land map" 
                    onclick="btnRemoveLM_Click" />
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" style="padding-right: 10px">
                System Design</td>
            <td>
                <asp:FileUpload ID="fupsystemD" runat="server" TabIndex="29" 
                    ToolTip="Click to browse and upload system design" />                 
                &nbsp;
                <asp:Button ID="btnRemoveSD" runat="server" Text="Remove"
                    CssClass="cmdbutton" Visible="false" ToolTip="Click to remove land map" 
                    onclick="btnRemoveSD_Click" />
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" style="padding-right: 10px">
                Soil Testing Report
            </td>
            <td>
                <asp:FileUpload ID="fulSoilTestRpt" runat="server" TabIndex="30" ToolTip="Click to browse and upload soil testing report" />
                &nbsp;
                <asp:Button ID="btnRemoveST" runat="server" OnClick="btnRemoveST_Click" Text="Remove"
                    CssClass="cmdbutton" Visible="false" ToolTip="Click to remove soil testing report" />
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" style="padding-right: 10px">
                Water Testing Report
            </td>
            <td>
                <asp:FileUpload ID="fulWaterTestRpt" runat="server" TabIndex="30" ToolTip="Click to browse and upload water testing report" />
                &nbsp;
                <asp:Button ID="btnRemoveWT" runat="server" OnClick="btnRemoveWT_Click" Text="Remove"
                    CssClass="cmdbutton" Visible="false" ToolTip="Click to remove water testing report" />
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" style="padding-right: 10px">
                Application Form-1 Filled manually
            </td>
            <td>
                <asp:FileUpload ID="fuApplFilledManually" runat="server" TabIndex="31" ToolTip="Click to browse and upload application form-1" />
                &nbsp;
                <asp:Button ID="btnRemoveAM" runat="server" OnClick="btnRemoveAM_Click" Text="Remove"
                    CssClass="cmdbutton" Visible="false" ToolTip="Click to remove application form-1" />
            </td>
        </tr>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>
                <tr>
                    <td align="right" width="50%" style="padding-right: 10px">
                        <asp:Button ID="btnSave" runat="server" CssClass="cmdbutton" OnClick="btnSave_Click"
                            Text="Save" ToolTip="Click to save record" OnClientClick="return Validator()" />
                    </td>
                    <td>
                        <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" CssClass="cmdbutton"
                            Text="Reset" ToolTip="Click to clear values" />
                    </td>
                </tr>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSave" />
                <asp:PostBackTrigger ControlID="btnReset" />
            </Triggers>
        </asp:UpdatePanel>
        
         <tr>
            <td style="padding-right: 5px" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="padding-right: 5px">
                Application No.
                <asp:TextBox ID="txtrappno" runat="server" Width="180px" ToolTip="Enter correct application number"></asp:TextBox>
                <%--<asp:Label ID="lblLAND_REC_FILENM" runat="server" Text='<%# bind("LAND_REC_FILENM") %>'></asp:Label>--%>
            </td>
            <td align="left">
                Farmer Name
                <asp:TextBox ID="txtrfarmer" runat="server" Width="100px" ToolTip="Enter farmer name"></asp:TextBox>
                <%--<asp:Label ID="lblLAND_REC_FILENM" runat="server" Text='<%# bind("LAND_REC_FILENM") %>'></asp:Label>--%>
                <asp:Button ID="btnRsearch" runat="server" Text="Search" 
                    CssClass="cmdbutton" ToolTip="Click to search record" 
                    onclick="btnRsearch_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" width="100%" colspan="2">
                <asp:GridView ID="grdUploadedMendatoryDocs" runat="server" SkinID="GridView" AutoGenerateColumns="False"
                    EmptyDataText="No Application Found" AllowPaging="True" OnPageIndexChanging="grdUploadedMendatoryDocs_PageIndexChanging"
                    PageSize="15" Width="100%" 
                    onrowdatabound="grdUploadedMendatoryDocs_RowDataBound">
                    <EmptyDataRowStyle ForeColor="#FF5050" HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No." HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblSNo" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Vendor" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label ID="lblVendorCode" runat="server" Text='<%# bind("VendorCode") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblVendor" runat="server" Text='<%# bind("V_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Distributor" HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label ID="lblDistributorCode" runat="server" Text='<%# bind("Distb_Code") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblDistributor" runat="server" Text='<%# bind("Distb_NAME") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Application No." HeaderStyle-HorizontalAlign="Center">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblAPP_NO" runat="server" Text='<%# bind("APP_NO") %>' Width="180px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Farmer Name" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblFName" runat="server" Text='<%# bind("NAME") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Farmer Address" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" runat="server" Text='<%# bind("Address") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="LAND" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%--<asp:Label ID="lblLAND_REC_FILENM" runat="server" Text='<%# bind("LAND_REC_FILENM") %>'></asp:Label>--%>
                                <asp:LinkButton ID="lnkLAND_REC_FILENM" runat="server" OnClick="lnkLAND_REC_FILENM_Click"
                                    CommandArgument='<%# bind("LAND_REC_FILENM") %>' ToolTip="Click to view land record">view</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="LAND MAP" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%--<asp:Label ID="lblLAND_REC_FILENM" runat="server" Text='<%# bind("LAND_REC_FILENM") %>'></asp:Label>--%>
                                <asp:LinkButton ID="lnkLAND_MAP_FILENM" runat="server" OnClick="lnkLAND_MAP_FILENM_Click"
                                    CommandArgument='<%# bind("LAND_MAP_FILENM") %>' ToolTip="Click to view land map">view</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="System Design" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%--<asp:Label ID="lblLAND_REC_FILENM" runat="server" Text='<%# bind("LAND_REC_FILENM") %>'></asp:Label>--%>
                                <asp:LinkButton ID="lnkSystemDesign_FILENM" runat="server" OnClick="lnkSystemDesign_FILENM_Click"
                                    CommandArgument='<%# bind("SystemDesign_FILENM") %>' 
                                    ToolTip="Click to view land map">view</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="SOIL" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%--<asp:Label ID="lblSOIL_TST_FILENM" runat="server" Text='<%# bind("SOIL_TST_FILENM") %>'></asp:Label>--%>
                                <asp:LinkButton ID="lnkSOIL_TST_FILENM" runat="server" OnClick="lnkSOIL_TST_FILENM_Click"
                                    CommandArgument='<%# bind("SOIL_TST_FILENM") %>' ToolTip="Click to view soil test report">view</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WATER" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%--<asp:Label ID="lblWATER_TST_FILENM" runat="server" Text='<%# bind("WATER_TST_FILENM") %>'></asp:Label>--%>
                                <asp:LinkButton ID="lnkWATER_TST_FILENM" runat="server" OnClick="lnkWATER_TST_FILENM_Click"
                                    CommandArgument='<%# bind("WATER_TST_FILENM") %>' ToolTip="Click to view water test report">view</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="APPL" HeaderStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%--<asp:Label ID="lblAPP_FRM_FILENM" runat="server" Text='<%# bind("APP_FRM_FILENM") %>'></asp:Label>--%>
                                <asp:LinkButton ID="lnkAPP_FRM_FILENM" runat="server" OnClick="lnkAPP_FRM_FILENM_Click"
                                    CommandArgument='<%# bind("APP_FRM_FILENM") %>' ToolTip="Click to view application form">view</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSelect" runat="server" OnClick="lnkSelect_Click" ToolTip="Click to select values" CommandName="Select">Select</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

