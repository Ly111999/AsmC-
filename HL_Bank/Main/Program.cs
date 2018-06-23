using System;
using System.Collections.Generic;
using HL_Bank.Controller;
using HL_Bank.Error;
using HL_Bank.view;

namespace HL_Bank
{
    class Program
    {
        public static HL_Account currentLoggedIn;
        public static AccountController controller = new AccountController();
        public static TransactionController controller1 = new TransactionController();

        static void Main(string[] args)
        {
            Menu menu = new Menu();

            while (true)
            {
                if (Program.currentLoggedIn != null)
                {
                    menu.GenerateCustomerMenu();
                }
                else
                {
                    menu.GenerateDefaultMenu();
                }
            }
            
        }
}
}