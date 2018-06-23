using System;
using System.Collections.Generic;
using HL_Bank.Model;

namespace HL_Bank.Controller
{
    public class TransactionController
    {
        private static HL_TransactionModel _transactionModel = new HL_TransactionModel();
        //amount = String.Format("{0:C}", 

        public void GetTransaction(int countTranLog)
        {
            HashSet<HL_Transaction> hashList = _transactionModel.TransactionLog(Program.currentLoggedIn.AccountNumber);
            Console.WriteLine("+--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+");
            Console.WriteLine("|\t  TRANSACTION ID  \t|\t   SENDERACCOUNTNUMBER     \t|\t    AMOUNT     \t |\t          CONTENT         \t|\t       RECEIVERACCOUNTNUMBER       \t|\t   TYPE    \t|\t       CREATEDAT       \t|\t   STATUS  \t|");
            Console.WriteLine("+--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+");
            if (hashList.Count != 0)
            {
                foreach (var transaction in hashList)
                {

                    Console.WriteLine("|     " + transaction.Id +
                                 "      |\t     " + transaction.SenderAccountNumber +
                                 "\t        |   " + transaction.Amount + " VND" +
                                 "   |     " + transaction.Content +
                                 "\t| " + transaction.ReceiverAccountNumber +
                                 " |  " + transaction.Type +
                                 " |  " + transaction.CreatedAt +
                                 "  |  " + transaction.Status +
                                 "  |");


                }
            }
            else
            {
                Console.WriteLine("|                                                 YOU HAVE NOT MADE ANY TRANSACTIONS YET  !                                                 |");
            }
            Console.WriteLine("+----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------+\n");
        }


    }
}