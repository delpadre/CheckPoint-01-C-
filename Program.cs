using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint1
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== CHECKPOINT 1 - FUNDAMENTOS C# ===");
                Console.WriteLine("Escolha uma opção para testar:");
                Console.WriteLine("1 - Tipos de dados");
                Console.WriteLine("2 - Calculadora");
                Console.WriteLine("3 - Validar idade");
                Console.WriteLine("4 - Converter string");
                Console.WriteLine("5 - Classificar nota");
                Console.WriteLine("6 - Gerar tabuada");
                Console.WriteLine("7 - Jogo da adivinhação");
                Console.WriteLine("8 - Validar senha");
                Console.WriteLine("9 - Analisar notas");
                Console.WriteLine("10 - Processar vendas");
                Console.WriteLine("0 - Sair");
                Console.Write("\nDigite sua opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao)) opcao = -1;

                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine(DemonstrarTiposDados());
                        break;
                    case 2:
                        Console.WriteLine(CalculadoraBasica(10, 5, '+'));
                        break;
                    case 3:
                        Console.WriteLine(ValidarIdade(25));
                        break;
                    case 4:
                        Console.WriteLine(ConverterString("123", "int"));
                        Console.WriteLine(ConverterString("true", "bool"));
                        Console.WriteLine(ConverterString("abc", "double"));
                        break;
                    case 5:
                        Console.WriteLine(ClassificarNota(8.5));
                        break;
                    case 6:
                        Console.WriteLine(GerarTabuada(5));
                        break;
                    case 7:
                        Console.WriteLine(JogoAdivinhacao(50, new int[] { 25, 75, 50 }));
                        break;
                    case 8:
                        Console.Write("Digite uma senha: ");
                        string senha = Console.ReadLine();
                        Console.WriteLine(ValidarSenha(senha));
                        break;
                    case 9:
                        Console.WriteLine(AnalisarNotas(new double[] { 8.5, 7.0, 9.2, 6.5, 10.0 }));
                        break;
                    case 10:
                        Console.WriteLine(ProcessarVendas(
                            new double[] { 1000, 500, 2000 },
                            new string[] { "A", "B", "A" },
                            new double[] { 10, 7, 5 },
                            new string[] { "A", "B", "C" }
                        ));
                        break;
                    case 0:
                        Console.WriteLine("Saindo... até logo!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }

        // =====================================================================
        // QUESTÃO 1 - VARIÁVEIS E TIPOS DE DADOS
        // =====================================================================
        private static string DemonstrarTiposDados()
        {
            int numeroInteiro = 42;
            double numeroDecimal = 3.14;
            bool booleano = true;
            char caractere = 'A';
            var texto = "Olá";

            return $"Inteiro: {numeroInteiro}, Decimal: {numeroDecimal}, Booleano: {booleano}, Caractere: {caractere}, Texto: {texto}";
        }

        // =====================================================================
        // QUESTÃO 2 - OPERADORES ARITMÉTICOS
        // =====================================================================
        private static double CalculadoraBasica(double num1, double num2, char operador)
        {
            switch (operador)
            {
                case '+': return num1 + num2;
                case '-': return num1 - num2;
                case '*': return num1 * num2;
                case '/': return num2 == 0 ? 0 : num1 / num2;
                default: return -1;
            }
        }

        // =====================================================================
        // QUESTÃO 3 - IF/ELSE
        // =====================================================================
        private static string ValidarIdade(int idade)
        {
            if (idade < 0 || idade > 120) return "Idade inválida";
            else if (idade < 12) return "Criança";
            else if (idade < 18) return "Adolescente";
            else if (idade <= 65) return "Adulto";
            else return "Idoso";
        }

        // =====================================================================
        // QUESTÃO 4 - CONVERSÃO
        // =====================================================================
        private static string ConverterString(string valor, string tipoDesejado)
        {
            switch (tipoDesejado)
            {
                case "int":
                    return int.TryParse(valor, out int i) ? $"int: {i}" : "Conversão impossível para int";
                case "double":
                    return double.TryParse(valor, out double d) ? $"double: {d}" : "Conversão impossível para double";
                case "bool":
                    return bool.TryParse(valor, out bool b) ? $"bool: {b}" : "Conversão impossível para bool";
                default:
                    return "Tipo de conversão não suportado";
            }
        }

        // =====================================================================
        // QUESTÃO 5 - SWITCH
        // =====================================================================
        private static string ClassificarNota(double nota) =>
            nota switch
            {
                >= 9.0 and <= 10.0 => "Excelente",
                >= 7.0 and <= 8.9 => "Bom",
                >= 5.0 and <= 6.9 => "Regular",
                >= 0.0 and <= 4.9 => "Insuficiente",
                _ => "Nota inválida"
            };

        // =====================================================================
        // QUESTÃO 6 - FOR
        // =====================================================================
        private static string GerarTabuada(int numero)
        {
            if (numero <= 0) return "Número inválido";
            string resultado = "";
            for (int i = 1; i <= 10; i++)
            {
                resultado += $"{numero} x {i} = {numero * i}\n";
            }
            return resultado;
        }

        // =====================================================================
        // QUESTÃO 7 - WHILE
        // =====================================================================
        private static string JogoAdivinhacao(int numeroSecreto, int[] tentativas)
        {
            string historico = "";
            int i = 0;
            while (i < tentativas.Length)
            {
                int palpite = tentativas[i];
                historico += $"Tentativa {i + 1}: {palpite} - ";
                if (palpite == numeroSecreto)
                {
                    historico += "correto!\n";
                    break;
                }
                else if (palpite < numeroSecreto) historico += "muito baixo\n";
                else historico += "muito alto\n";
                i++;
            }
            return historico;
        }

        // =====================================================================
        // QUESTÃO 8 - DO-WHILE
        // =====================================================================
        private static string ValidarSenha(string senha)
        {
            string erros;
            bool isValida;

            do
            {
                var sb = new StringBuilder();

                if (senha.Length < 8) sb.AppendLine("A senha deve ter pelo menos 8 caracteres.");
                if (!senha.Any(char.IsDigit)) sb.AppendLine("A senha deve conter pelo menos 1 número.");
                if (!senha.Any(char.IsUpper)) sb.AppendLine("A senha deve conter pelo menos 1 letra maiúscula.");
                if (!senha.Any(c => "!@#$%&*".Contains(c))) sb.AppendLine("A senha deve conter pelo menos 1 caractere especial (!@#$%&*).");

                erros = sb.ToString();
                isValida = erros.Length == 0;

                // como não há interação, o laço vai rodar só uma vez
            } while (!isValida);

            return isValida ? "Senha válida" : erros;
        }

        // =====================================================================
        // QUESTÃO 9 - FOREACH
        // =====================================================================
        private static string AnalisarNotas(double[] notas)
        {
            if (notas == null || notas.Length == 0) return "Nenhuma nota para analisar";

            double soma = 0, maior = double.MinValue, menor = double.MaxValue;
            int aprovados = 0, A = 0, B = 0, C = 0, D = 0, F = 0;

            foreach (var n in notas)
            {
                soma += n;
                if (n >= 7) aprovados++;
                if (n > maior) maior = n;
                if (n < menor) menor = n;

                if (n >= 9) A++;
                else if (n >= 8) B++;
                else if (n >= 7) C++;
                else if (n >= 5) D++;
                else F++;
            }

            double media = soma / notas.Length;
            return $"Média: {media:F2}\nAprovados: {aprovados}\nMaior: {maior}\nMenor: {menor}\nA: {A}, B: {B}, C: {C}, D: {D}, F: {F}";
        }

        // =====================================================================
        // QUESTÃO 10 - FOREACH MÚLTIPLO
        // =====================================================================
        private static string ProcessarVendas(double[] vendas, string[] categorias, double[] comissoes, string[] nomesCategorias)
        {
            if (vendas == null || categorias == null || vendas.Length != categorias.Length)
                return "Dados de entrada inválidos.";

            var totalVendas = new Dictionary<string, double>();
            var totalComissoes = new Dictionary<string, double>();
            var comissoesPorCategoria = new Dictionary<string, double>();

            // Associa cada categoria à sua comissão
            int idx = 0;
            foreach (var cat in nomesCategorias)
            {
                totalVendas[cat] = 0;
                totalComissoes[cat] = 0;
                comissoesPorCategoria[cat] = comissoes[idx];
                idx++;
            }

            // Percorre vendas e categorias
            int j = 0;
            foreach (var venda in vendas)
            {
                string categoria = categorias[j];
                totalVendas[categoria] += venda;
                totalComissoes[categoria] += venda * (comissoesPorCategoria[categoria] / 100.0);
                j++;
            }

            // Gera relatório
            var sb = new StringBuilder();
            foreach (var cat in nomesCategorias)
            {
                sb.AppendLine($"Categoria {cat}: Vendas R$ {totalVendas[cat]:F2}, Comissão R$ {totalComissoes[cat]:F2}");
            }

            return sb.ToString();
        }
    }
}
