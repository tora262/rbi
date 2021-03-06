﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
namespace RBI.DAL
{
    class ExcelConnect
    {

        public string ConnectionString { set; get; }
        public OleDbConnection connectionExcel(String filePath)
        {
            String connStr = null;
            if (filePath.Trim().EndsWith(".xlsx"))
            {
                connStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", filePath);
                ConnectionString = connStr;
            }
            else
            {
                connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";" +
                          @"Extended Properties='Excel 8.0;HDR=Yes;'";
                ConnectionString = connStr;
            }
            OleDbConnection conn = new OleDbConnection(connStr);
            return conn;
            
        }
        public string getStringConnect()
        {
            return ConnectionString;
        }
    }
}
