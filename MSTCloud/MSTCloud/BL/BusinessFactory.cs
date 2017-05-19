using MSTCloud.DAL;
using MSTCloud.Models;
using MSTCloud.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MSTCloud.BL
{
    public class BusinessFactory
    {
        public List<callout> GetCallOuts(string division, string location, DateTime startdate)
        {
            return GetCallOuts(Convert.ToInt32(division), Convert.ToInt32(location), startdate);
        }
        public List<callout> GetCallOuts(int division, int location, DateTime startdate)
        {
            List<callout> list = new List<callout>();

            string sqlquery = string.Format(GlobalVars.SQLGetAuditCallOutByShiftDate
                                                , division, location, startdate.ToShortDateString(), startdate.AddDays(1).ToShortDateString());

            DataTable dt = DataFactory.DBExecuteQueryReturnDT(sqlquery, GlobalVars.ENV, "FASDB");

            list = ConvertDataTableToListForCallOut(dt);

            return list;
        }

        private List<callout> ConvertDataTableToListForCallOut(DataTable dt)
        {
            List<callout> list = new List<callout>();

            //foreach (DataRow row in dt.Rows)
            //{
            //    try
            //    {
            //        callout item = new callout();
            //        item.division = Convert.ToInt32(row["division"].ToString());
            //        item.location = Convert.ToInt32(row["location"].ToString());
            //        item.shiftarea = Convert.ToInt32(row["shiftarea"].ToString());
            //        item.shiftareadesc = row["shiftareadesc"].ToString().Trim();
            //        item.auditdatetime = Convert.ToDateTime(row["auditdatetime"].ToString());
            //        item.assocnbr = Convert.ToInt32(row["assocnbr"].ToString());
            //        item.assocname = row["assocname"].ToString();
            //        item.shiftstart = Convert.ToDateTime(row["shiftstart"].ToString());
            //        item.shiftend = Convert.ToDateTime(row["shiftend"].ToString());
            //        list.Add(item);
            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //}
            try
            {

                list = (from DataRow row in dt.Rows
                        select new callout(
                         Convert.ToInt32(row["division"].ToString()),
                         Convert.ToInt32(row["location"].ToString()),
                         Convert.ToInt32(row["shiftarea"].ToString()),
                         row["shiftareadesc"].ToString(),
                         Convert.ToDateTime(row["auditdatetime"].ToString()),
                         Convert.ToInt32(row["assocnbr"].ToString()),
                         row["assocname"].ToString(),
                         Convert.ToDateTime(row["shiftstart"].ToString()),
                         Convert.ToDateTime(row["shiftend"].ToString())
                        )).ToList();
            }
            catch (Exception ex)
            {
                callout item = new callout();
                item.errorcode = ex.Message;
                list.Add(item);
            }
            return list;
        }
    }
}