using MyApp.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace MyOwnResearch
{
    public class BAL_Dashboard
    {
        private string ConnectionStrings = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        public int AddReserach(EntityAddResearch entity)
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            SqlCommand comm = new SqlCommand("SP_AddResearch", conn);
            comm.CommandType = CommandType.StoredProcedure;
            if (entity.strFirstName == "")
            {
                entity.strFirstName = "";
            }
            comm.Parameters.AddWithValue("@firstName", entity.strFirstName);
            comm.Parameters.AddWithValue("@Status", entity.status = "1");
            comm.Parameters.AddWithValue("@shareStatus", entity.shareStatus="0");
            if (entity.strLastName == "")
            {
                entity.strLastName = "";
            }
            comm.Parameters.AddWithValue("@lastName", entity.strLastName);
            if (entity.strTitleEmail == "")
            {
                entity.strTitleEmail = "";
            }
            comm.Parameters.AddWithValue("@titleEmail", entity.strTitleEmail);
            if (entity.strPersonlkdnURL == "")
            {
                entity.strPersonlkdnURL = "";
            }
            comm.Parameters.AddWithValue("@personlkdnURL", entity.strPersonlkdnURL);
            if (entity.strCompanyWebsite == "")
            {
                entity.strCompanyWebsite = "";
            }
            comm.Parameters.AddWithValue("@companyWebsite", entity.strCompanyWebsite);
            if (entity.strCorporatePn == "")
            {
                entity.strCorporatePn = "";
            }
            comm.Parameters.AddWithValue("@corporatePhone", entity.strCorporatePn);
            if (entity.strEmployee == "")
            {
                entity.strEmployee = "";
            }
            comm.Parameters.AddWithValue("@employee", entity.strEmployee);
            comm.Parameters.AddWithValue("@industry", entity.strIndustry);
            if (entity.intCountryId == 0)
            {
                entity.intCountryId = 0;
            }
            comm.Parameters.AddWithValue("@countryId", entity.intCountryId);
            if (entity.intStateId == 0)
            {
                entity.intStateId = 0;
            }
            comm.Parameters.AddWithValue("@stateId", entity.intStateId);
            if (entity.intCityId == 0)
            {
                entity.intCityId = 0;
            }
            comm.Parameters.AddWithValue("@cityId", entity.intCityId);
            comm.Parameters.AddWithValue("@companyAddress", entity.strCompanyAddress);
            comm.Parameters.AddWithValue("@companyURL", entity.strCompanyURL);
            comm.Parameters.AddWithValue("@privateNote", entity.strPrivateNote);
            if (entity.fileUpload == null)
            {
                entity.fileUpload = "";
            }
            comm.Parameters.AddWithValue("@fileUpload", entity.fileUpload);
            conn.Open();
            int result = 0;
            result = comm.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        public int invite(EntityInvite entity)
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            SqlCommand comm = new SqlCommand("SP_AddInvite", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@title", entity.strTitle);
                comm.Parameters.AddWithValue("@researchType", entity.strRsrchType);
                comm.Parameters.AddWithValue("@researchURL", entity.strURL);
                comm.Parameters.AddWithValue("@lkdnUrl", entity.strLkdnURL);
                comm.Parameters.AddWithValue("@privateNotes", entity.strPrivateNotes);
                comm.Parameters.AddWithValue("@publicNotes", entity.strPublicNotes);
                comm.Parameters.AddWithValue("@fileUpload1", entity.fileUpload1);
                comm.Parameters.AddWithValue("@fileUpload2", entity.fileUpload2);
                conn.Open();
                int result = 0;
                result = comm.ExecuteNonQuery();
                conn.Close();
                return result;
        }
        
        public int delete(int strresid)
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            int i;
                conn.Open();
                SqlCommand com = new SqlCommand("SP_DeleteResearch", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@resId", strresid);
                i = com.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        public int updateRecords(EntityAddResearch entity)
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            int i = 0;
            SqlCommand comm = new SqlCommand("SP_UpdateResearch", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@resId", entity.strResId);
            comm.Parameters.AddWithValue("@firstName", entity.strFirstName);
            comm.Parameters.AddWithValue("@lastName", entity.strLastName);
            comm.Parameters.AddWithValue("@titleEmail", entity.strTitleEmail);
            comm.Parameters.AddWithValue("@personlkdnURL", entity.strPersonlkdnURL);
            comm.Parameters.AddWithValue("@companyWebsite", entity.strCompanyWebsite);
            comm.Parameters.AddWithValue("@corporatePhone", entity.strCorporatePn);
            comm.Parameters.AddWithValue("@employee", entity.strEmployee);
            comm.Parameters.AddWithValue("@industry", entity.strIndustry);
            comm.Parameters.AddWithValue("@countryId", entity.intCountryId);
            comm.Parameters.AddWithValue("@stateId", entity.intStateId);
            comm.Parameters.AddWithValue("@cityId", entity.intCityId);
            comm.Parameters.AddWithValue("@companyAddress", entity.strCompanyAddress);
            comm.Parameters.AddWithValue("@companyURL", entity.strCompanyURL);
            comm.Parameters.AddWithValue("@privateNote", entity.strPrivateNote);
            comm.Parameters.AddWithValue("@fileUpload", entity.fileUpload);
            conn.Open();
            i = comm.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        //public List<EntityAddResearch> ListAll()
        //{
        //    List<EntityAddResearch> lst = new List<EntityAddResearch>();

        //    conn.Open();
        //    SqlCommand com = new SqlCommand("SelectEmployee", conn);
        //    com.CommandType = CommandType.StoredProcedure;
        //    SqlDataReader tv = com.ExecuteReader();
        //    while (tv.Read())
        //    {
        //        lst.Add(new EntityAddResearch
        //        {
        //            strFirstName = Convert.ToString(tv["firstName"]),
        //            strLastName = Convert.ToString(tv["lastName"]),
        //            strTitleEmail = Convert.ToString(tv["titleEmail"]),
        //            strPersonlkdnURL = Convert.ToString(tv["personlkdnURL"]),
        //            strCompanyAddress = Convert.ToString(tv["companyAddress"]),
        //            strCompanyWebsite = Convert.ToString(tv["companyWebsite"]),
        //            strCorporatePn = Convert.ToString(tv["corporatePhone"]),
        //            strEmployee = Convert.ToString(tv["employee"]),
        //            strIndustry = Convert.ToString(tv["industry"]),
        //            strCompanyURL = Convert.ToString(tv["companyURL"]),
        //            strPrivateNote = Convert.ToString(tv["privateNote"]),
        //            showDate = Convert.ToDateTime(tv["createdDate"])
        //        });
        //    }
        //    return lst;

        //    SqlDataAdapter Ad = new SqlDataAdapter(com);
        //    DataTable dr = new DataTable();
        //    Ad.Fill(dr);
        //    List<EntityAddResearch> lstres = new List<EntityAddResearch>();
        //    if (dr.Rows.Count > 0)
        //    {
        //        foreach (DataRow tv in dr.Rows)
        //        {
        //            lstres.Add(new EntityAddResearch
        //            {
        //                strFirstName = Convert.ToString(tv["firstName"]),
        //                strLastName = Convert.ToString(tv["lastName"]),
        //                strTitleEmail = Convert.ToString(tv["titleEmail"]),
        //                strPersonlkdnURL = Convert.ToString(tv["personlkdnURL"]),
        //                strCompanyAddress = Convert.ToString(tv["companyAddress"]),
        //                strCompanyWebsite = Convert.ToString(tv["companyWebsite"]),
        //                strCorporatePn = Convert.ToString(tv["corporatePhone"]),
        //                strEmployee = Convert.ToString(tv["employee"]),
        //                strIndustry = Convert.ToString(tv["industry"]),
        //                strCompanyURL = Convert.ToString(tv["companyURL"]),
        //                strPrivateNote = Convert.ToString(tv["privateNote"]),
        //                showDate = Convert.ToDateTime(tv["createdDate"])
        //            });
        //        }
        //    }

        //    return lstres;
        //}
        public void getElementById(int id)
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            EntityAddResearch entity = new EntityAddResearch();
            SqlCommand comm = new SqlCommand("SP_GetDataByIdResearch", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@resId", id);
            conn.Open();
            SqlDataAdapter Ad = new SqlDataAdapter(comm);
            DataTable dr = new DataTable();
            Ad.Fill(dr);
            if (dr != null && dr.Rows.Count > 0)
            {
                foreach (DataRow tv in dr.Rows)
                {
                    entity.strFirstName = Convert.ToString(tv["firstName"]);
                    entity.strLastName = Convert.ToString(tv["lastName"]);
                    entity.strTitleEmail = Convert.ToString(tv["titleEmail"]);
                    entity.strPersonlkdnURL = Convert.ToString(tv["personlkdnURL"]);
                    entity.strCompanyAddress = Convert.ToString(tv["companyAddress"]);
                    entity.strCompanyWebsite = Convert.ToString(tv["companyWebsite"]);
                    entity.strCorporatePn = Convert.ToString(tv["corporatePhone"]);
                    entity.strEmployee = Convert.ToString(tv["employee"]);
                    entity.strIndustry = Convert.ToString(tv["industry"]);
                    entity.intCountryId = Convert.ToInt32(tv["countryId"].ToString());
                    entity.intStateId = Convert.ToInt32(tv["stateId"].ToString());
                    entity.intCityId = Convert.ToInt32(tv["cityId"].ToString());
                    entity.strCountryName = Convert.ToString(tv["CountryName"]);
                    entity.strStateName = Convert.ToString(tv["stateName"]);
                    entity.strCityName = Convert.ToString(tv["CityName"]);
                    entity.strCompanyURL = Convert.ToString(tv["companyURL"]);
                    entity.strPrivateNote = Convert.ToString(tv["privateNote"]);
                    entity.showDate = Convert.ToDateTime(tv["createdDate"].ToString());
                }
            }
        }
        public int shareStatus(int id)
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            SqlCommand comm = new SqlCommand("Sp_ShareStatus", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@resId", id);
            conn.Open();
            int result = comm.ExecuteNonQuery();
            conn.Close();
            if (result > 0)
            {
                Console.WriteLine("Share Status Updated");
            }
            else
            {
                Console.WriteLine("Something went Wrong");

            }
            return result;
        }
    }
}
