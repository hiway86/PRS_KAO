#pragma checksum "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\Entity\MIS\Menu.cs" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B6FA91739EFCEA2063E298817ED27782D84E7067"

#line 1 "D:\Source\DotNet\ParkingRepairSystemKAO\App_Code\Entity\MIS\Menu.cs"
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
/// Menu 的摘要描述
/// </summary>
public class Menu
{
	public Menu()
	{

	}

    private string _systemGroupID;
    public string System_Group_ID
    {
        get { return _systemGroupID; }
        set { _systemGroupID = value; }
    }

    private string _systemGroupName;
    public string System_Group_Name
    {
        get { return _systemGroupName; }
        set { _systemGroupName = value; }
    }

    private string _systemFolderName;
    public string System_Folder_Name
    {
        get { return _systemFolderName; }
        set { _systemFolderName = value; }
    }

    private string _programName;
    public string Program_Name
    {
        get { return _programName; }
        set { _programName = value; }
    }

    private string _programCName;
    public string Program_CName
    {
        get { return _programCName; }
        set { _programCName = value; }
    }

}


#line default
#line hidden
