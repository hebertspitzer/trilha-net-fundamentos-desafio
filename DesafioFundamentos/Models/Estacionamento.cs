using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

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
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placaDoVeiculo = Console.ReadLine();
            if(VerificarFormatoDaPlaca(placaDoVeiculo))
            {
                veiculos.Add(placaDoVeiculo);
                Console.WriteLine($"Veículo {placaDoVeiculo} adicionado com sucesso");
            } 
            else
            {
                Console.WriteLine($"O formato da placa esta incorreto, inseria nos seguintes formatos (ABC-1234) ou (ABC1D23)");
            }
            
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + (precoPorHora * horas); 

                veiculos.Remove(placa);

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
                Console.WriteLine($"Existe {veiculos.Count} veiculos estacionados, as placas são:");
                foreach(string veiculo in veiculos){
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
        
        private bool VerificarFormatoDaPlaca(string placa){
            string formatoPlacaAntigo = @"^[a-zA-Z]{3}-\d{4}$";
            string formatoPlacaNova = @"^[a-zA-Z]{3}\d[a-zA-Z]\d{2}$";

            if(Regex.IsMatch(placa, formatoPlacaAntigo) || Regex.IsMatch(placa, formatoPlacaNova))
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
