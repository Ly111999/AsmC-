using System;
using System.Collections.Generic;
using System.Transactions;
using MySql.Data.MySqlClient;
using static HL_Bank.HL_Transaction;

namespace HL_Bank.Model
{
    public class HL_TransactionModel
    {
        public static HashSet<HL_Transaction> hashList = new HashSet<HL_Transaction>();

        public HashSet<HL_Transaction> TransactionLog(string acountNumber)
        {
            DbConnection.Instance().OpenConnection();
            string checkTransacLog = "SELECT id, fromAccountNumber, amount, content, toAccountNumber, type, createdAt, status FROM transaction WHERE fromAccountNumber = '" + Program.currentLoggedIn.AccountNumber + "'";
            MySqlCommand cmd = new MySqlCommand(checkTransacLog, DbConnection.Instance().Connection);
            string id = "", senderAccountNumber = "", content = "", receiveBankNumber = "";
            decimal amount;
            int type1 = 0;
            int status1 = 0;
            string createdAt = "";
            HL_Transaction transaction = null;
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = reader.GetString("id");
                    senderAccountNumber = reader.GetString("fromAccountNumber");
                    amount = reader.GetDecimal("amount");
                    content = reader.GetString("content");
                    receiveBankNumber = reader.GetString("toAccountNumber");
                    type1 = reader.GetInt32("type");
                    createdAt = reader.GetString("createdAt");
                    status1 = reader.GetInt32("status");

                    // cast int sang enum.
                    TransactionType type = (TransactionType)type1;
                    ActiveStatus status = (ActiveStatus)status1;

                    transaction = new HL_Transaction(id, amount, content, senderAccountNumber, receiveBankNumber, type, createdAt, status);
                    hashList.Add(transaction);
                }
            }

            reader.Close();
            return hashList;
        }


    }
}