using MercadoConsole_POO.Models;

namespace MercadoConsole_POO.Services
{
    public class ProdutoService
    {
        private List<IProduto> produtos = new List<IProduto>();
        private int proximoId = 1;

        public ProdutoService()
        {
            // Inicializa com alguns produtos
            produtos.Add(new Produto { Id = proximoId++, Nome = "Copo", Preco = 20.50m });
            produtos.Add(new ProdutoPerecivel { Id = proximoId++, Nome = "Leite", Preco = 5.00m, DataValidade = DateTime.Today.AddDays(7) });
        }

        public void ListarProdutos()
        {
            Console.WriteLine("\n --- Lista de Produtos ---");
            if (!produtos.Any())
            {
                Console.WriteLine("Nenhum produto cadastrado!");
                return;
            }
            foreach (var produto in produtos)
            {
                Console.WriteLine(produto);
            }
        }

        public void AdcionarProduto()
        {
            Console.WriteLine("\nTipo de produto:");
            Console.WriteLine("1. Comum");
            Console.WriteLine("2. Perecível");
            Console.WriteLine("Escolha");
            string tipo = Console.ReadLine();

            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Preço: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
            {
                Console.WriteLine("Preço inválido!");
                return;
            }
            if (tipo == "1")
            {
                produtos.Add(new Produto { Id = proximoId++, Nome = nome, Preco = preco });
            }
            else if (tipo == "2")
            {
                Console.WriteLine("Data de validade (dd/mm/yyyy): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime validade))
                {
                    Console.WriteLine("Data inválida!");
                    return;
                }
                produtos.Add(new ProdutoPerecivel
                {
                    Id = proximoId++,
                    Nome = nome,
                    Preco = preco,
                    DataValidade = validade
                });
            }
            else
            {
                Console.WriteLine("Tipo de produto inválido!");
            }
        }

        public void AtualizarProduto()
        {
            Console.WriteLine("\nID do Produtp para atualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID Inválido!");
                return;
            }

            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado!");
                return;
            }

            Console.WriteLine("Novo nome: ");
            produto.Nome = Console.ReadLine();

            Console.WriteLine("Novo preço: R$");
            if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
            {
                Console.WriteLine("Preço inválido!");
                return;
            }
            produto.Preco = preco;

            if (produto is ProdutoPerecivel perecivel)
            {
                Console.WriteLine("Nova data de validade (dd/mm/yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime novaValidade))
                {
                    //Console.WriteLine("Data inválida!");
                    //return;
                    perecivel.DataValidade = novaValidade;
                }
                else
                {
                    Console.WriteLine("Data inválida! Mantendo a validade anterior.");
                }
            }
            Console.WriteLine("Produto atualizado!");
        }

        public void ExcluirProduto()
        {
            Console.WriteLine("\nID do Produto para excluir: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID Inválido!");
                return;
            }
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado!");
                return;
            }
            produtos.Remove(produto);
            Console.WriteLine("Produto removido com sucesso!");
        }
    }
}
