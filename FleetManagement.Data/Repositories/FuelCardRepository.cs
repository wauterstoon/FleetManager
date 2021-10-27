﻿using System;
using System.Collections.Generic;
using FleetManagement.Business.Entities;
using FleetManagement.Business.Interfaces;
using System.Data.SqlClient;
using System.Data;

namespace FleetManagement.Data.Repositories
{
    public class FuelCardRepository : IFuelCardRepository
    {

        private string connectionString = $"Data Source=fleetmanagserver.database.windows.net;Persist Security Info=True;User ID=fleetadmin;Password=***********";
        private SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }


        // SELECT

        public FuelCard GetFuelCard(int fuelCardId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<FuelCard> GetAllFuelCards()
        {
            SqlConnection connection = getConnection();
            List<FuelCard> fuelCards = new List<FuelCard>();

            string query = "SELECT * FROM dbo.FuelCard";

            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public FuelCard SearchFuelCard(int? fuelCardId, string cardNr, FuelType fuelType)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<FuelCard> SearchFuelCards(int? fuelCardId, string cardNr, FuelType fuelType)
        {
            throw new NotImplementedException();
        }

        // INSERT UPDATE DELETE
        public void AddFuelCard(FuelCard fuelCard)
        {
            SqlConnection connection = getConnection();

            string query = "INSERT INTO dbo.Fuelcard (cardNumber, validityDate, pin, fuelType, isEnabled)" +
                           "VALUES (@fuelCardId, @cardNumber, @validityDate, @pin, @fuelType, @isEnabled)";

            using(SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    //command.Parameters.Add(new SqlParameter("@fuelCardId", SqlDbType.Int));       zonder id
                    command.Parameters.Add(new SqlParameter("@cardNumber", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@validityDate", SqlDbType.DateTime));
                    command.Parameters.Add(new SqlParameter("@pin", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@fuelType", SqlDbType.NVarChar));
                    //command.Parameters.Add(new SqlParameter("@driverId", SqlDbType.Int));         zonder driverId
                    command.Parameters.Add(new SqlParameter("@isEnabled", SqlDbType.Bit));

                    //command.Parameters["@fuelCardId"].Value = fuelCard.FuelCardId;                zonder id
                    command.Parameters["@cardNumber"].Value = fuelCard.CardNumber;
                    command.Parameters["@validityDate"].Value = fuelCard.ValidityDate;
                    command.Parameters["@pin"].Value = fuelCard.Pin;
                    command.Parameters["@fuelType"].Value = fuelCard.FuelType;
                    //command.Parameters["@driverId"].Value = fuelCard.Driver.DriverID;                      zonder driverId
                    command.Parameters["@isEnabled"].Value = fuelCard.IsEnabled;

                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void UpdateFuelCard(FuelCard fuelCard)
        {
            SqlConnection connection = getConnection();

            string query = "UPDATE dbo.Fuelcard" +
                           "SET cardNumber=@cardNumber, validityDate=@validityDate, pin=@pin, fuelType=@fuelType, driverId=@driverId, isEnabled=@isEnabled" +
                           "WHERE fuelCardId=@fuelCardId";

            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    command.Parameters.Add(new SqlParameter("@cardNumber", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@validityDate", SqlDbType.DateTime));
                    command.Parameters.Add(new SqlParameter("@pin", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@fuelType", SqlDbType.NVarChar));
                    command.Parameters.Add(new SqlParameter("@driverId", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@isEnabled", SqlDbType.Bit));

                    command.Parameters["@cardNumber"].Value = fuelCard.CardNumber;
                    command.Parameters["@validityDate"].Value = fuelCard.ValidityDate;
                    command.Parameters["@pin"].Value = fuelCard.Pin;
                    command.Parameters["@fuelType"].Value = fuelCard.FuelType;
                    command.Parameters["@driverId"].Value = fuelCard.Driver.DriverID;
                    command.Parameters["@isEnabled"].Value = fuelCard.IsEnabled;

                    command.CommandText = query;
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void DeleteFuelCard(FuelCard fuelCard)
        {
            SqlConnection connection = getConnection();

            string query = "DELETE FROM dbo.Fuelcard WHERE (@fuelCardId=fuelCardId)";
            
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    command.Parameters.Add(new SqlParameter("@fuelCardId", SqlDbType.Int));
                    command.Parameters["@fuelCardId"].Value = fuelCard.FuelCardId;
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        // EXISTS
        public bool FuelCardExists(FuelCard fuelCard)
        {
            SqlConnection connection = getConnection();
            string query = "SELECT count(*) FROM dbo.FuelCard WHERE fuelCardId=@fuelCardId OR cardNumber=@cardNumber";
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    command.Parameters.Add(new SqlParameter("@fuelCardId", SqlDbType.Int));
                    command.Parameters.Add(new SqlParameter("@cardNumber", SqlDbType.NVarChar));

                    command.Parameters["@fuelCardId"].Value = fuelCard.FuelCardId;
                    command.Parameters["@cardNumber"].Value = fuelCard.CardNumber;

                    command.CommandText = query;
                    int n = (int)command.ExecuteScalar();
                    if (n > 0) return true; else return false;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }



        //END OF REPOSITORY
    }
}
