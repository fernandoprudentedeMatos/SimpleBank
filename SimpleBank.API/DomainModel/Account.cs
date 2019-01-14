using SimpleBank.API.DomainModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBank.API.DomainModel
{
    public class Account: EntityBase, IAggregateRoot
    {
        public static Account Build(Decimal initialBalance)
        {
            return new Account
            {
                Balance = initialBalance,
                DateCreated = DateTime.Now,
                Id = Guid.NewGuid().ToString()
            };
        }

        public Decimal Balance { get; set; }
        public DateTime DateCreated { get; set; }

        public void SubtractMoney(decimal value)
        {
            if (value <= 0)
                throw new InvalidDomainException("Valor para subtração deve ser positivo.");

            this.Balance -= value;

            if (this.Balance < 0)
                throw new InvalidDomainException("Saldo Insuficiente para concluir a operação.");

        }

        public void AddMoney(decimal value)
        {
            if (value <= 0)
                throw new InvalidDomainException("Valor para adição deve ser positivo.");

            this.Balance += value;
        }
    }
}
