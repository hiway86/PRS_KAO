﻿#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\PTWebServiceReference.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74BAE42B7443F5941424F0869BE34937E6A54AFF"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\PTWebServiceReference.cs"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// PTWebServiceReference 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
// [System.Web.Script.Services.ScriptService]
public class PTWebServiceReference : System.Web.Services.WebService {

    public PTWebServiceReference () {

        //如果使用設計的元件，請取消註解下行程式碼 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    
}



#line default
#line hidden
