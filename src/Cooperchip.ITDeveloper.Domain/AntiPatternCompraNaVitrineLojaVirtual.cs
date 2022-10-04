using System;
using System.Diagnostics;

namespace Cooperchip.ITDeveloper.Domain
{
    /// <summary>
    /// Todo: Exemplo de Code Smell
    /// 
    /// Entender o que é Code Smell é fundamental para ter um código rodando em perfeitas condições. Smell, em sua tradução, é cheiro. Isso quer dizer que algo não “cheira bem” no seu código. Enfim, é o mesmo que usar um computador lento.Dá para usar, mas você sabe que hora ou outra, ele irá travar e precisar de conserto.E com o código não se brinca.Afinal, o que não está “cheirando bem” pode virar um bug. 
    /// </summary>
    public class AntiPatternCompraNaVitrineLojaVirtual
    {
        public AntiPatternCompraNaVitrineLojaVirtual()
        {
            var compra = new CompraAntiPattern(1, DateTime.Now, 130.00M);
        }
    }

    public class CompraAntiPattern
    {
        public int Id { get; private set; }
        public DateTime DataDaCompra { get; private set; }
        public decimal ValorDaCompra { get; private set; }
        public CompraAntiPattern(int id, DateTime dataDaCompra, decimal valorDaCompra)
        {
            var cliente = new ClienteAntiPattern(1, "Cliente 01", "Endereço do Cliente 01");
            Id = id;
            DataDaCompra = dataDaCompra;
            ValorDaCompra = valorDaCompra;
        }

        public void Compra(ProdutoAntiPattern produto, ClienteAntiPattern cliente)
        {
            if (TemNoEstoque(produto, 3))
            {
                EfetuarVenda(produto, 3, cliente, 1);
                produto.DecrementaPorVenda(3);
            }
            else
            {
                produto.IncrementarPorCompra(produto, 3);
            }
        }

        private void EfetuarVenda(ProdutoAntiPattern produto, int v, ClienteAntiPattern cliente, int id)
        {
            //..
            //..
            ExpedicaoAntiPattern.Expedir(produto, v, cliente, id);
        }

        public bool TemNoEstoque(ProdutoAntiPattern produto, int Quantidade)
        {
            var estoque = new Estoque();

            if (estoque.VerificarSeTemQuantidadeEmEstoque(produto))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    public static class ExpedicaoAntiPattern
    {
        public static void Expedir(ProdutoAntiPattern produto, int v, ClienteAntiPattern cliente, int id)
        {
            produto.DecrementaPorVenda(v);
            Debug.WriteLine("Venda Finalizada e Expedida.");
        }
    }

    public class ClienteAntiPattern
    {
        public ClienteAntiPattern(int id, string nome, string endereco)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
    }

    public class ProdutoAntiPattern
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public ProdutoAntiPattern(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Quantidade = 10;
        }

        public void ComprarParaEstoque(ProdutoAntiPattern produto, int quantidadeComprada)
        {
            IncrementarPorCompra(produto, quantidadeComprada);
        }

        public void ExtornarParaEstoque(int quantidadeVendida)
        {
            Quantidade += quantidadeVendida;
        }

        public void IncrementarPorCompra(ProdutoAntiPattern produto, int quantidadeComprada)
        {
            produto.Quantidade += quantidadeComprada;
        }


        public void DecrementaPorVenda(int quantidadeVendida)
        {
            if ((Quantidade - quantidadeVendida) >= 0)
            {
                Quantidade -= 1;
            }
        }

    }

    public class Estoque
    {
        public int Id { get; set; }
        public int EstoqueMinimo { get; set; }
        public bool EstoqueRegular { get; set; }
        public int EstoqueRegulado { get; set; }
        public int EstoquePrePromocao { get; set; }
        public Estoque() { }

        public void RegularEstoque(int quantidadeRequerida)
        {
            if (quantidadeRequerida + this.EstoqueMinimo >= this.EstoqueRegulado - 10 || quantidadeRequerida + this.EstoqueMinimo <= this.EstoqueRegulado + 10)
            {
                this.EstoqueRegular = true;
            }
            else
            {
                this.EstoqueRegular = false;
            }
        }

        public void RegularEstoqueParaPromocao()
        {
            this.EstoquePrePromocao *= 10;
        }

        public bool EstoqueEstaRegulado()
        {
            return this.EstoqueRegular;
        }

        public bool VerificarSeTemQuantidadeEmEstoque(ProdutoAntiPattern produto)
        {
            if (produto.Quantidade > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}
