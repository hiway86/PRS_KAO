var pagePermit = {
    enableBrowser : false,
    enableQuery : false,
    enableAdd : false,
    enableEdit : false,
    enableDelete : false,
    enablePrint : false,
    enableEditSave : false,
    enableNewSave : false
}

function setPermit(enableBrowser, enableQuery, enableAdd, enableEdit, enableDelete, enablePrint, enableEditSave, enableNewSave)
{
    pagePermit.enableBrowser = enableBrowser;
    pagePermit.enableQuery = enableQuery;
    pagePermit.enableAdd = enableAdd;
    pagePermit.enableEdit = enableEdit;
    pagePermit.enableDelete = enableDelete;
    pagePermit.enablePrint = enablePrint;
    pagePermit.enableEditSave = enableEditSave;
    pagePermit.enableNewSave = enableNewSave;
}