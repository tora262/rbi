﻿using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.DAL.MSSQL
{
    class REPORT_TEMPLATE_EQUIPMENT_ConnectUtils
    {
        public void add(int EquipmentID, int TemplateID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "GO" +
                        "INSERT INTO [dbo].[REPORT_TEMPLATE_EQUIPMENT]" +
                        "([EquipmentID]" +
                        ",[TemplateID])" +
                        "VALUES" +
                        "('" + EquipmentID + "'" +
                        ",'" + TemplateID + "')" +
                        "GO";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "ADD FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void edit(int EquipmentID, int TemplateID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "GO" +
                        "UPDATE [dbo].[REPORT_TEMPLATE_EQUIPMENT]" +
                        "SET [EquipmentID] = '" + EquipmentID + "'" +
                        ",[TemplateID] = '" + TemplateID + "'" +
                        
                        "WHERE [EquipmentID] = '" + EquipmentID + "'" +
                        "GO";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "EDIT FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void delete(int EquipmentID)
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            String sql = "USE [rbi]" +
                        "GO" +
                        "DELETE FROM [dbo].[REPORT_TEMPLATE_EQUIPMENT]" +
                        "WHERE [EquipmentID]  = '" + EquipmentID + "' " +
                        "GO";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "DELETE FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public List<REPORT_TEMPLATE_EQUIPMENT> getDataSource()
        {
            SqlConnection conn = MSSQLDBUtils.GetDBConnection();
            conn.Open();
            List<REPORT_TEMPLATE_EQUIPMENT> list = new List<REPORT_TEMPLATE_EQUIPMENT>();
            REPORT_TEMPLATE_EQUIPMENT obj = null;
            String sql = " Use [rbi] Select [EquipmentID]" +
                          ",[TemplateID]" +


                          "From [dbo].[REPORT_TEMPLATE_EQUIPMENT] go";
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            obj = new REPORT_TEMPLATE_EQUIPMENT();
                            obj.EquipmentID = reader.GetInt32(0);
                            obj.TemplateID = reader.GetInt32(1);

                            list.Add(obj);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "GET DATA FAIL!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }

    }
}


