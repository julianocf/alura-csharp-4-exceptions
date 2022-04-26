using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao ByteBank!");

            UsingTest();

            //TryCatchTest();
            //CustomMadeExceptionTest();
            //InnerExceptionTest();

            Console.WriteLine("Execução finalizada. Tecle ENTER para sair");
            Console.ReadLine();

        }
        private static void UsingTest()
        {
            using (FileReader reader = new FileReader("contas.txt"))
            {
                reader.ReadNextLine();
                reader.ReadNextLine();
                reader.ReadNextLine();
            }
        }
        private void TryCatchTest()
        {
            try
            {
                CheckingAccount account = new CheckingAccount(0, 0);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.ParamName);
            }

            try
            {
                TestMethod();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("não é possível divisão por 0!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        private void CustomMadeExceptionTest()
        {
            try
            {
                CheckingAccount account = new CheckingAccount(456, 4578420);
                CheckingAccount account2 = new CheckingAccount(485, 456478);

                account.Deposit(100);
                account2.Deposit(100);

                account2.Transferir(-10, account);

                account.Deposit(50);
                Console.WriteLine(account.Balance);
                account.Withdraw(-500);
                Console.WriteLine(account.Balance);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argumento com problema: " + ex.ParamName);
                Console.WriteLine("Ocorreu uma exceção do tipo ArgumentException");
                Console.WriteLine(ex.Message);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exceção do tipo InsufficientFundsException");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void InnerExceptionTest()
        {
            try
            {
                CheckingAccount account1 = new CheckingAccount(456, 4578420);
                CheckingAccount account2 = new CheckingAccount(485, 456478);

                account1.Transferir(10000, account1);
                //account.Withdraw(10000);
            }
            catch (FinancialTransactionException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                Console.WriteLine("Informações da INNER EXCEPTION (exceção interna):");

                Console.WriteLine(e.InnerException.Message);
                Console.WriteLine(e.InnerException.StackTrace);
            }
        }
        static void TestMethod()
        {
            TestaDivisao(0);
        }
        static void TestaDivisao(int divisor)
        {
            Dividir(10, divisor);
        }
        static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;
            }
            catch (Exception)
            {
                Console.WriteLine("Exceção com numero=" + numero + " e divisor=" + divisor);
                throw;
            }
        }
    }
}
