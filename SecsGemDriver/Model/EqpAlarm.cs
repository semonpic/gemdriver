﻿/*
 * C# class for entity table eqp_alarm 
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
 * Entity bean for table "eqp_alarm"
 * 
 * @author Telosys Tools Generator
 *
 */
namespace SecsGemDriver
{
    public class EqpAlarm
    {
        //Declare an instance for log4net
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int ea_id { get; set; }

        public int eqp_id { get; set; }
        public string ea_uuid { get; set; }
        public string ea_name { get; set; }
        public string ea_alcd { get; set; }
        public string ea_altext { get; set; }
        public int sts { get; set; }

        public EqpAlarm()
        {
        }

        /*
         * CRUD functions
         */
        public static List<EqpAlarm> load()
        {
            return load("");
        }
        public static List<EqpAlarm> load(string query)
        {
            List<EqpAlarm> list = new List<EqpAlarm>();
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
                    query = "select * from eqp_alarm";
                }
                Log.Info("Query: " + query);
                MySqlCommand cmd = new MySqlCommand(query, conn);

                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    EqpAlarm obj = new EqpAlarm();
                    obj.ea_id = Convert.ToInt32(rd["ea_id"].ToString());   // Primary
                    obj.eqp_id = Convert.ToInt32(rd["eqp_id"].ToString());
                    obj.ea_uuid = rd["ea_uuid"].ToString();
                    obj.ea_name = rd["ea_name"].ToString();
                    obj.ea_alcd = rd["ea_alcd"].ToString();
                    obj.ea_altext = rd["ea_altext"].ToString();
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

        public static EqpAlarm load(int ea_id)
        {
            MySqlDataReader rd = null;
            try
            {
                MySqlConnection conn = Main.getConnection();
                if (conn == null)
                {
                    return null;
                }
                string query = "select * from eqp_alarm where ea_id='" + ea_id + "'";
                Log.Info("Query: " + query);
                MySqlCommand cmd = new MySqlCommand(query, conn);

                rd = cmd.ExecuteReader();
                EqpAlarm obj = new EqpAlarm();

                while (rd.Read())
                {
                    obj.ea_id = Convert.ToInt32(rd["ea_id"].ToString());   // Primary
                    obj.eqp_id = Convert.ToInt32(rd["eqp_id"].ToString());
                    obj.ea_uuid = rd["ea_uuid"].ToString();
                    obj.ea_name = rd["ea_name"].ToString();
                    obj.ea_alcd = rd["ea_alcd"].ToString();
                    obj.ea_altext = rd["ea_altext"].ToString();
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


        public static EqpAlarm loadUUID(string uuid)
        {
            MySqlDataReader rd = null;
            try
            {
                MySqlConnection conn = Main.getConnection();
                if (conn == null)
                {
                    return null;
                }
                string query = "select * from eqp_alarm where ea_uuid='" + uuid + "'";
                Log.Info("Query: " + query);
                MySqlCommand cmd = new MySqlCommand(query, conn);

                rd = cmd.ExecuteReader();
                EqpAlarm obj = new EqpAlarm();

                while (rd.Read())
                {
                    obj.ea_id = Convert.ToInt32(rd["ea_id"].ToString());   // Primary
                    obj.eqp_id = Convert.ToInt32(rd["eqp_id"].ToString());
                    obj.ea_uuid = rd["ea_uuid"].ToString();
                    obj.ea_name = rd["ea_name"].ToString();
                    obj.ea_alcd = rd["ea_alcd"].ToString();
                    obj.ea_altext = rd["ea_altext"].ToString();
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
            String strData = "eqp_alarm "
                    + " ea_id = " + ea_id + "; eqp_id = " + eqp_id
                    + "; ea_uuid = " + ea_uuid
                    + "; ea_name = " + ea_name
                    + "; ea_alcd = " + ea_alcd
                    + "; ea_altext = " + ea_altext
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
                string query = "insert into eqp_alarm(" +
                                    "eqp_id," +
                                    "ea_uuid," +
                                    "ea_name," +
                                    "ea_alcd," +
                                    "ea_altext," +
                                    "sts" +
" )values (" +
                                    "'" + eqp_id + "'," +
                                    "'" + ea_uuid + "'," +
                                    "'" + ea_name + "'," +
                                    "'" + ea_alcd + "'," +
                                    "'" + ea_altext + "'," +
                                    "'" + sts + "'" +
" )";
                Log.Info("INSERT: " + query);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                this.ea_id = (int)cmd.LastInsertedId;
                // Log file
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                string log_text = "Create new eqp_alarm. ID=" + this.ea_id;
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
                string query = "update eqp_alarm set " +
                                "eqp_id='" + eqp_id + "' ," +
                                "ea_uuid='" + ea_uuid + "' ," +
                                "ea_name='" + ea_name + "' ," +
                                "ea_alcd='" + ea_alcd + "' ," +
                                "ea_altext='" + ea_altext + "' ," +
                                "sts='" + sts + "' " +

" where " +
"ea_id='" + ea_id + "'";
                Log.Info("UPDATE: " + query);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                // Log file
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                string log_text = "Update value eqp_alarm. ID=" + this.ea_id;
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
                string query = "update eqp_alarm set STS=3 " +
" where " +
"ea_id='" + ea_id + "'";
                Console.WriteLine("DELETE: " + query);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                // Log file
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                string log_text = "Update value eqp_alarm. ID=" + this.ea_id;
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
                string query = "delete from eqp_alarm " +
" where " +
"ea_id='" + ea_id + "'";
                Log.Info("DELETE: " + query);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                // Log file
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                string log_text = "Delete row eqp_alarm. ID=" + this.ea_id;
                string queryLog = "insert into action_log(log_text, log_time, user_id) values('" + log_text + "','" + unixTimestamp + "','" + Main.getUserId() + "')";
                MySqlCommand cmdLog = new MySqlCommand(queryLog, conn);
                cmdLog.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Log.Error("Error: " + e.Message);
            }
        }

        public EqpAlarm(System.Windows.Forms.DataGridViewRow row)
        {
            getFromRow(row);
        }

        public void getFromRow(System.Windows.Forms.DataGridViewRow row)
        {
            ea_id = Convert.ToInt32(row.Cells["ea_id"].Value.ToString());

            eqp_id = Convert.ToInt32(row.Cells["eqp_id"].Value.ToString());
            ea_uuid = row.Cells["ea_uuid"].Value.ToString();
            ea_name = row.Cells["ea_name"].Value.ToString();
            ea_alcd = row.Cells["ea_alcd"].Value.ToString();
            ea_altext = row.Cells["ea_altext"].Value.ToString();
            sts = Convert.ToInt32(row.Cells["sts"].Value.ToString());
        }

        public static DataTable loadDt(string query)
        {
            List<EqpAlarm> list = load(query);
            return ListToDataTable(list);
        }

        public static DataTable loadDt()
        {
            List<EqpAlarm> list = load("");
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