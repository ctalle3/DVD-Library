using DVDLibrary.Models.Data;
using DVDLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace DVDLibrary.Models.Repositories
{
    public class DVDRepositoryADO : IDVDRepository
    {
        private SqlConnection _sqlConnection;

        public DVDRepositoryADO()
        {
            _sqlConnection = new SqlConnection()
            {
                ConnectionString = 
                    "Server=localhost;"
                  + "Database=DVDLibrary;"
                  + "User Id=dotnet2019;"
                  + "Password=godzilla"
            };
        }

        public DVD CreateDVD(DVD dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _sqlConnection.ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateDVD";

                cmd.Parameters.AddWithValue("@title", dvd.Title);
                cmd.Parameters.AddWithValue("@releaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@director", dvd.Director);
                cmd.Parameters.AddWithValue("@rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@notes", dvd.Notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            return dvd;
        }

        public void DeleteDVD(int dvdId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _sqlConnection.ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteDVD";

                cmd.Parameters.AddWithValue("@dvdId", dvdId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DVD ReadDVD(int dvdId)
        {
            DVD dvd = new DVD();

            using(SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _sqlConnection.ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ReadDVD";

                cmd.Parameters.AddWithValue("@dvdId", dvdId);

                conn.Open();
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();

                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = int.Parse(dr["ReleaseYear"].ToString());
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                            currentRow.Notes = dr["Notes"].ToString();

                        currentRow.DVDId = (int)dr["DVDId"];
                        dvd = currentRow;
                    }
                }
            }

            return dvd; 
        }

        public List<DVD> ReadDVDDirector(string director)
        {
            List<DVD> dvdList = new List<DVD>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _sqlConnection.ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ReadDVDDirector";

                cmd.Parameters.AddWithValue("@director", director);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();          

                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = int.Parse(dr["ReleaseYear"].ToString());
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                            currentRow.Notes = dr["Notes"].ToString();

                        currentRow.DVDId = (int)dr["DVDId"];
                        dvdList.Add(currentRow);
                    }
                }
            }

            return dvdList;
        }

        public List<DVD> ReadDVDList()
        {
            List<DVD> dvdList = new List<DVD>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _sqlConnection.ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "ReadDVDList";

                conn.Open();
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();

                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = int.Parse(dr["ReleaseYear"].ToString());
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                            currentRow.Notes = dr["Notes"].ToString();

                        currentRow.DVDId = (int)dr["DVDId"];
                        dvdList.Add(currentRow);
                    }
                }
            }

            return dvdList;
        }

        public List<DVD> ReadDVDRating(string rating)
        {
            List<DVD> dvdList = new List<DVD>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _sqlConnection.ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ReadDVDRating";

                cmd.Parameters.AddWithValue("@rating", rating);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();

                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = int.Parse(dr["ReleaseYear"].ToString());
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                            currentRow.Notes = dr["Notes"].ToString();

                        currentRow.DVDId = (int)dr["DVDId"];
                        dvdList.Add(currentRow);
                    }
                }
            }

            return dvdList;
        }

        public List<DVD> ReadDVDTitle(string title)
        {
            List<DVD> dvdList = new List<DVD>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _sqlConnection.ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ReadDVDTitle";

                cmd.Parameters.AddWithValue("@title", title);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();

                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = int.Parse(dr["ReleaseYear"].ToString());
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                            currentRow.Notes = dr["Notes"].ToString();

                        currentRow.DVDId = (int)dr["DVDId"];
                        dvdList.Add(currentRow);
                    }
                }
            }

            return dvdList;
        }

        public List<DVD> ReadDVDYear(string year)
        {
            List<DVD> dvdList = new List<DVD>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _sqlConnection.ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ReadDVDYear";

                cmd.Parameters.AddWithValue("@year", year);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();

                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = int.Parse(dr["ReleaseYear"].ToString());
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                            currentRow.Notes = dr["Notes"].ToString();

                        currentRow.DVDId = (int)dr["DVDId"];
                        dvdList.Add(currentRow);
                    }
                }
            }

            return dvdList;
        }

        public void UpdateDVD(DVD dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _sqlConnection.ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateDVD";

                cmd.Parameters.AddWithValue("@dvdId", dvd.DVDId);
                cmd.Parameters.AddWithValue("@title", dvd.Title);
                cmd.Parameters.AddWithValue("@releaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@director", dvd.Director);
                cmd.Parameters.AddWithValue("@rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@notes", dvd.Notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}