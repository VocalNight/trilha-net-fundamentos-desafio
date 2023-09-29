namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string placa = "";

            while (placa == null || placa == "")
            {
                Console.Clear();
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                placa = Console.ReadLine();
            }

            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {
            Console.Clear();
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = "";
            placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.Clear();
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                decimal valorTotal = 0;

                bool isNumeroValido = int.TryParse(Console.ReadLine(), out int horas);

                while (!isNumeroValido)
                {
                    Console.Clear();
                    Console.WriteLine("Quantidade inválida, digite a quantidade de horas que o veículo permaneceu estacionado novamente:");
                    isNumeroValido = int.TryParse(Console.ReadLine(), out int horaValida);
                    horas = horaValida;
                }
                
                valorTotal = precoInicial + (precoPorHora * horas);

                veiculos.RemoveAll(n => n.Equals(placa, StringComparison.OrdinalIgnoreCase));

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                veiculos.ForEach(v => Console.WriteLine(v));
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
