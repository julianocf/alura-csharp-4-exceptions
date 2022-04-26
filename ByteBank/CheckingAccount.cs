using System;

namespace ByteBank
{
    public class CheckingAccount
    {
        private Client _holder;
        private int _branch;
        private int _number;
        private double _balance = 0;

        public static int HandlingFee { get; private set; }
        public static int TotalCreatedAccounts { get; private set; }
        public int WithdrawsNotAllowedCounter { get; private set; }
        public int TransfersNotAllowedCounter { get; private set; }

        public Client Holder { get; set; }
        public int Branch { get; }
        public int Number { get; }
        public double Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _balance = value;
            }
        }

        public CheckingAccount(int branch, int number)
        {
            if (branch <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(branch));
            }

            if (number <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(number));
            }

            Branch = branch;
            Number = number;

            TotalCreatedAccounts++;
            HandlingFee = 30 / TotalCreatedAccounts;
        }

        public void Deposit(double value)
        {
            _balance += value;
        }

        public void Withdraw(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Valor de saque não pode ser negativo.", nameof(value));
            }
            if (_balance < value)
            {
                WithdrawsNotAllowedCounter++;
                throw new InsufficientFundsException(_balance, value);
            }
            _balance -= value;
        }
        public bool Transferir(double value, CheckingAccount destinationAccount)
        {
            if (value < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(value));
            }
            try
            {
                Withdraw(value);
            }
            catch (InsufficientFundsException ex)
            {
                TransfersNotAllowedCounter++;
                throw new FinancialTransactionException("Operação não realizada.", ex);
            }
            destinationAccount.Deposit(value);
            return true;
        }

    }
}