using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Qazi.Common.GUI.CommonDialogBoxes
{
    public class XMLDataTableLoaderDialogBox
    {
        public event XMLDataLoadedHandler XMLDataTableLoaded;
        private XMLDataTableLoaderWnd xmldlg;
        public string TableName;
        public string FileName;
        public DataTable DataTableSelected;
        public void ShowDialog()
        {
            xmldlg = new XMLDataTableLoaderWnd();
            xmldlg.XMLDataLoaded += new XMLDataLoadedHandler(xmldlg_XMLDataLoaded);
            xmldlg.ShowDialog();
        }

        private void xmldlg_XMLDataLoaded()
        {
            DataTableSelected = xmldlg.DataTableSelected;
            TableName = DataTableSelected.TableName;
            FileName = xmldlg.FileName;
            if(XMLDataTableLoaded != null)   
                XMLDataTableLoaded();
        }
    }
}
