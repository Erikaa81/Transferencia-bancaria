using System;

namespace DIO.Bank
{
	public class Conta
	{
		// Atributos
		private TipoConta TipoConta { get; set; }
		private double Saldo { get; set; }
		private double Limite { get; set; }
		private double SaldoTotal { get; set;}
		private string Nome { get; set; }

		// Métodos
		public Conta(TipoConta tipoConta, double saldo, double limite, double saldototal, string nome)
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Limite= limite;
			this.SaldoTotal = saldo+limite;
			this.Nome = nome;
		}

		public bool Sacar(double valorSaque)
		{
            // Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.SaldoTotal *-SaldoTotal)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            // https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting

            return true;
		}
		public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
		}

		public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
			retorno += "Limite" + this.Limite + "|";
            retorno += "SaldoTotal" + this.SaldoTotal;
			return retorno;
		}
	}
}