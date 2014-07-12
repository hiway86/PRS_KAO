<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // 應用程式啟動時執行的程式碼

        
        Application["App_Mis_Company"] = CommonLib.GetCompany();
        Application["App_Mis_CompanyGroup"] = CommonLib.GetCompanyGroup();
        Application["App_Mis_Equipment"] = CommonLib.GetDevice();
        Application["App_Mis_Region"]=CommonLib.GetRegion();
        Application["App_Mis_Area"] = CommonLib.GetArea();
        Application["App_Mis_DeviceModel"] = CommonLib.GetDeviceModel();
        Application["App_Mis_Contract"] = CommonLib.GetContract();
        Application["App_Report_WarrantyNotify"] = CommonLib.GetWarrantyNotify();
        Application["App_Role"] = CommonLib.GetRole();
        Application["App_Mis_ICSProject"] = CommonLib.GetProject();
        Application["App_Invetory_ICSMaterial"] = CommonLib.GetICSMaterial();
        Application["App_Invetory_MaterialType"] = CommonLib.GetMaterialType();
        
	}
    
    void Application_End(object sender, EventArgs e) 
    {
        //  應用程式關閉時執行的程式碼

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 發生未處理錯誤時執行的程式碼

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 啟動新工作階段時執行的程式碼

    }

    void Session_End(object sender, EventArgs e) 
    {
        // 工作階段結束時執行的程式碼。 
        // 注意: 只有在 Web.config 檔將 sessionstate 模式設定為 InProc 時，
        // 才會引發 Session_End 事件。如果將工作階段模式設定為 StateServer 
        // 或 SQLServer，就不會引發這個事件。

    }
       
</script>
