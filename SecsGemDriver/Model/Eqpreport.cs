﻿/*
 * C# class for entity table eqpreport 
 * Created on 18 Jan 2018 ( Date ISO 2018-01-18 - Time 19:47:35 )
 * Generated by Telosys Tools Generator ( version 2.1.1 )
 * template update by NEO
 */
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Reflection;
using log4net;

/**
 * Entity bean for table "eqpreport"
 * 
 * @author Telosys Tools Generator
 *
 */
namespace SecsGemDriver
{
    public class Eqpreport
    {
        //Declare an instance for log4net
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int er_id { get; set; }

        public int eqp_id { get; set; }
        public string er_uuid { get; set; }
        public string er_reportname { get; set; }
        public int typ { get; set; }
        public int sts { get; set; }

        public Eqpreport()
        {
        }

        /*
         * CRUD functions
         */
        public static List<Eqpreport> load()
        {
            return load("");
        }
        public static List<Eqpreport> load(string query)
        {
            List<Eqpreport> list = new List<Eqpreport>();
            MySqlDataReader rd = null;
            try
            {
                MySqlConnection conn = Main.getConnection();
                if (conn == null)
                {
                    return list;
                }
                if (query == null || query.Length == 0)
                {
                    query = "select * from eqpreport";
                }
                Log.Info("Query: " + query);
                MySqlCommand cmd = new MySqlCommand(query, conn);

                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    Eqpreport obj = new Eqpreport();
                    obj.er_id = Convert.ToInt32(rd["er_id"].ToString());   // Primary
                    obj.eqp_id = Convert.ToInt32(rd["eqp_id"].ToString());
                    obj.er_uuid = rd["er_uuid"].ToString();
                    obj.er_reportname = rd["er_reportname"].ToString();
                    obj.typ = Convert.ToInt32(rd["typ"].ToString());
                    obj.sts = Convert.ToInt32(rd["sts"].ToString());
                    list.Add(obj);
                }
                rd.Close();
            }
            catch (MySqlException e)
            {
                Log.Error("Error: " + e.Message);
            }
            finally
            {
                if (rd != null)
                {
                    rd.Close();
                }
            }
            return list;
        }
        public void query(string query)
        {
            try
            {
                MySqlConnection conn = Main.getConnection();
                if (conn == null)
                {
                    return;
                }
                Log.Info("Query: " + query);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                // Log file
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                string queryLog = "insert into action_log(log_text, log_time, user_id) values('" + query + "','" + unixTimestamp + "','" + Main.getUserId() + "')";
                MySqlCommand cmdLog = new MySqlCommand(queryLog, conn);
                cmdLog.ExecuteNonQuery();
                // End logfile
            }
            catch (MySqlException e)
            {
                Log.Error("Error: " + e.Message);
            }

            return;
        }

        public static Eqpreport load(int er_id)
        {
            MySqlDataReader rd = null;
            try
            {
                MySqlConnection conn = Main.getConnection();
                if (conn == null)
                {
                    return null;
                }
                string query = "select * from eqpreport where er_id='" + er_id + "'";
                Log.Info("Query: " + query);
                MySqlCommand cmd = new MySqlCommand(query, conn);

                rd = cmd.ExecuteReader();
                Eqpreport obj = new Eqpreport();

                while (rd.Read())
                {
                    obj.er_id = Convert.ToInt32(rd["er_id"].ToString());   // Primary
                    obj.eqp_id = Convert.ToInt32(rd["eqp_id"].ToString());
                    obj.er_uuid = rd["er_uuid"].ToString();
                    obj.er_reportname = rd["er_reportname"].ToString();
                    obj.typ = Convert.ToInt32(rd["typ"].ToString());
                    obj.sts = Convert.ToInt32(rd["sts"].ToString());
                    break;
                }
                rd.Close();

                return obj;
            }
            catch (MySqlException e)
            {
                Log.Error("Query: " + e.Message);
            }
            finally
            {
                if (rd != null)
                {
                    rd.Close();
                }
            }
            return null;
        }


        public static Eqpreport loadUUID(string uuid)
        {
            MySqlDataReader rd = null;
            try
            {
                MySqlConnection conn = Main.getConnection();
                if (conn == null)
                {
                    return null;
                }
                string query = "select * from eqpreport where er_uuid='" + uuid + "'";
                Log.Info("Query: " + query);
                MySqlCommand cmd = new MySqlCommand(query, conn);

                rd = cmd.ExecuteReader();
                Eqpreport obj = new Eqpreport();

                while (rd.Read())
                {
                    obj.er_id = Convert.ToInt32(rd["er_id"].ToString());   // Primary
                    obj.eqp_id = Convert.ToInt32(rd["eqp_id"].ToString());
                    obj.er_uuid = rd["er_uuid"].ToString();
                    obj.er_reportname = rd["er_reportname"].ToString();
                    obj.typ = Convert.ToInt32(rd["typ"].ToString());
                    obj.sts = Convert.ToInt32(rd["sts"].ToString());
                    break;
                }
                rd.Close();

                return obj;
            }
            catch (MySqlException e)
            {
                Log.Error("Query: " + e.Message);
            }
            finally
            {
                if (rd != null)
                {
                    rd.Close();
                }
            }

            return null;
        }

        public String toString()
        {
            String strData = "eqpreport "
                    + " er_id = " + er_id + "; eqp_id = " + eqp_id
                    + "; er_uuid = " + er_uuid
                    + "; er_reportname = " + er_reportname
                    + "; typ = " + typ
                    + "; sts = " + sts
                    ;
            return strData;
        }

        public void insert()
        {
            //
            try
            {
                MySqlConnection conn = Main.getConnection();
                if (conn == null)
                {
                    return;
                }
                string query = "insert into eqpreport(" +
                                    "eqp_id," +
                                    "er_uuid," +
                                    "er_reportname," +
                                    "typ," +
                                    "sts" +
" )values (" +
                                    "'" + eqp_id + "'," +
                                    "'" + er_uuid + "'," +
                                    "'" + er_reportname + "'," +
                                    "'" + typ + "'," +
                                    "'" + sts + "'" +
" )";
                Log.Info("INSERT: " + query);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                this.er_id = (int)cmd.LastInsertedId;
                // Log file
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                string log_text = "Create new eqpreport. ID=" + this.er_id;
                string queryLog = "insert into action_log(log_text, log_time, user_id) values('" + log_text + "','" + unixTimestamp + "','" + Main.getUserId() + "')";
                MySqlCommand cmdLog = new MySqlCommand(queryLog, conn);
                cmdLog.ExecuteNonQuery();
                // End logfile
            }
            catch (MySqlException e)
            {
                Log.Error("Error: " + e.Message);
            }
        }

        public void update()
        {
            try
            {
                MySqlConnection conn = Main.getConnection();
                if (conn == null)
                {
                    return;
                }
                string query = "update eqpreport set " +
                                "eqp_id='" + eqp_id + "' ," +
                                "er_uuid='" + er_uuid + "' ," +
                                "er_reportname='" + er_reportname + "' ," +
                                "typ='" + typ + "' ," +
                                "sts='" + sts + "' " +

" where " +
"er_id='" + er_id + "'";
                Log.Info("UPDATE: " + query);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                // Log file
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                string log_text = "Update value eqpreport. ID=" + this.er_id;
                string queryLog = "insert into action_log(log_text, log_time, user_id) values('" + log_text + "','" + unixTimestamp + "','" + Main.getUserId() + "')";
                MySqlCommand cmdLog = new MySqlCommand(queryLog, conn);
                cmdLog.ExecuteNonQuery();
                // End logfile
            }
            catch (MySqlException e)
            {
                Log.Error("Error: " + e.Message);
            }

        }


        public void delete()
        {
            //
            try
            {
                MySqlConnection conn = Main.getConnection();
                if (conn == null)
                {
                    return;
                }
                string query = "update eqpreport set STS=3 " +
" where " +
"er_id='" + er_id + "'";
                Console.WriteLine("DELETE: " + query);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                // Log file
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                string log_text = "Update value eqpreport. ID=" + this.er_id;
                string queryLog = "insert into action_log(log_text, log_time, user_id) values('" + log_text + "','" + unixTimestamp + "','" + Main.getUserId() + "')";
                MySqlCommand cmdLog = new MySqlCommand(queryLog, conn);
                cmdLog.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Log.Error("Error: " + e.Message);
            }
        }

        public void deleteRow()
        {
            //
            try
            {
                MySqlConnection conn = Main.getConnection();
                if (conn == null)
                {
                    return;
                }
                string query = "delete from eqpreport " +
" where " +
"er_id='" + er_id + "'";
                Log.Info("DELETE: " + query);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                // Log file
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                string log_text = "Delete row eqpreport. ID=" + this.er_id;
                string queryLog = "insert into action_log(log_text, log_time, user_id) values('" + log_text + "','" + unixTimestamp + "','" + Main.getUserId() + "')";
                MySqlCommand cmdLog = new MySqlCommand(queryLog, conn);
                cmdLog.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Log.Error("Error: " + e.Message);
            }
        }

        public Eqpreport(System.Windows.Forms.DataGridViewRow row)
        {
            getFromRow(row);
        }

        public void getFromRow(System.Windows.Forms.DataGridViewRow row)
        {
            er_id = Convert.ToInt32(row.Cells["er_id"].Value.ToString());

            eqp_id = Convert.ToInt32(row.Cells["eqp_id"].Value.ToString());
            er_uuid = row.Cells["er_uuid"].Value.ToString();
            er_reportname = row.Cells["er_reportname"].Value.ToString();
            typ = Convert.ToInt32(row.Cells["typ"].Value.ToString());
            sts = Convert.ToInt32(row.Cells["sts"].Value.ToString());
        }

        public static DataTable loadDt(string query)
        {
            List<Eqpreport> list = load(query);
            return ListToDataTable(list);
        }

        public static DataTable loadDt()
        {
            List<Eqpreport> list = load("");
            return ListToDataTable(list);
        }

        public static DataTable ListToDataTable<T>(List<T> items)
        {

            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties

            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)
            {

                //Setting column names as Property names

                dataTable.Columns.Add(prop.Name);

            }

            foreach (T item in items)
            {

                var values = new object[Props.Length];

                for (int i = 0; i < Props.Length; i++)
                {

                    //inserting property values to datatable rows

                    values[i] = Props[i].GetValue(item, null);

                }

                dataTable.Rows.Add(values);

            }

            //put a breakpoint here and check datatable

            return dataTable;

        }

    }
}