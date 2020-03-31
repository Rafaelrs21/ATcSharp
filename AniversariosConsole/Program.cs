using Negocios.Service.Factory;
using System;
using System.Globalization;
using Negocios.Model.Interfaces.Services;
using Negocios.Model.Entities;

namespace AniversariosConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

            int respostaMenu;

            IAmigosService services = AmigosServicesFactory.Create();

            do
            {
                var aniversariantesDia = services.GetAniversariantesDia();
                Console.Clear();

                Console.WriteLine("Aniversariantes do dia:");
                Console.WriteLine("");
                if (aniversariantesDia.Count > 0)
                {
                    var index = 1;
                    foreach (var item in aniversariantesDia)
                    {
                        Console.WriteLine($"{index + "-" + item.NomeAmigo + " " + item.SobrenomeAmigo}");
                        index++;
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum dos amigos fazem aniversario hoje!");
                }
                Console.WriteLine("");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("");

                Console.WriteLine("Selecione uma das opções abaixo:");
                Console.WriteLine("1 - Pesquisar Amigos");
                Console.WriteLine("2 - Adicionar Amigos");
                Console.WriteLine("3 - Sair");

                respostaMenu = int.Parse(Console.ReadLine());

                if (respostaMenu == 1)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Digite parte ou nome completo da pessoa: ");
                    Console.WriteLine("");
                    var filtroAmigos = Console.ReadLine();

                    var pessoasEncontradas = services.SearchAmigo(filtroAmigos);

                    if (pessoasEncontradas.Count > 0)
                    {
                        for (int i = 0; i < pessoasEncontradas.Count; i++)
                        {
                            Console.WriteLine($"{i} - {pessoasEncontradas[i].NomeAmigo + " " + pessoasEncontradas[i].SobrenomeAmigo}");

                        }

                        Console.WriteLine("");
                        Console.WriteLine("Selecione um amigo da lista:");
                        int InputAmigoUsuario = int.Parse(Console.ReadLine());

                        if (InputAmigoUsuario > pessoasEncontradas.Count || InputAmigoUsuario < 0)
                        {
                            Console.WriteLine("Opção invalida");
                            break;
                        }

                        var amigoEscolhido = pessoasEncontradas[InputAmigoUsuario];
                        var calculoAniversario = services.CalcularDiasParaAniversario(amigoEscolhido);

                        Console.WriteLine("");
                        Console.WriteLine("Exibindo dados do amigo:");
                        Console.WriteLine($"Nome: {amigoEscolhido.NomeAmigo}");
                        Console.WriteLine($"Sobrenome:{amigoEscolhido.SobrenomeAmigo}");
                        Console.WriteLine($"Data de nascimento: {amigoEscolhido.DataNascimentoAmigo.ToString("d")}");
                        Console.WriteLine($"Dias Faltantes para aniversario: {calculoAniversario}");
                        Console.WriteLine("1- Editar Usuario");
                        Console.WriteLine("2- Excluir Usuario");
                        Console.WriteLine("3- Retornar ao menu");

                        var escolhaAcaoAmigos = int.Parse(Console.ReadLine());
                        switch (escolhaAcaoAmigos)
                        {
                            case 1:
                                Console.WriteLine("");
                                Console.WriteLine("Edite os dados do amigo:");

                                Console.WriteLine("Nome:");
                                var nomeAmigoAtualizado = Console.ReadLine();

                                Console.WriteLine("Sobrenome:");
                                var sobrenomeAmigoAtualizado = Console.ReadLine();

                                Console.WriteLine("Data de nascimento:");
                                var dataNascimentoAmigoAtualizado = DateTime.Parse(Console.ReadLine());
                                
                                Console.WriteLine("");
                                Console.WriteLine("Confirmar atualização dos dados?");
                                Console.WriteLine("1- Sim");
                                Console.WriteLine("2- Não");

                                var confirmarAtualizacao = int.Parse(Console.ReadLine());
                                switch (confirmarAtualizacao)
                                {
                                    case 1:
                                        var idAtual = amigoEscolhido.IdAmigo;
                                        var pessoaAtualizada = new Amigos(idAtual, nomeAmigoAtualizado, 
                                            sobrenomeAmigoAtualizado, dataNascimentoAmigoAtualizado);

                                        services.UpdateAmigo(pessoaAtualizada);
                                        Console.WriteLine("Amigo Atualizado com sucesso!");
                                        break;
                                    case 2:
                                        break;
                                    default:
                                        break;
                                }

                                break;

                            case 2:
                                Console.WriteLine("");
                                Console.WriteLine("Deseja confirmar a exclusão do usuario?");
                                Console.WriteLine($"1- Sim");
                                Console.WriteLine($"2- Não");

                                var confirmarExclusão = int.Parse(Console.ReadLine());

                                switch (confirmarExclusão)
                                {
                                    case 1:
                                        services.DeleteAmigo(amigoEscolhido);
                                        Console.WriteLine("Amigo Exluido com sucesso!");
                                        break;
                                    default:
                                        break;
                                }
                                break;

                            case 3:
                                break;

                            default:
                                Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal");
                                Console.ReadKey();
                                break;

                        }

                    }
                    else
                    {
                        Console.WriteLine("Não foi encontrado ninguem com esse termo de busca!");
                    }

                }
                else if (respostaMenu == 2)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Digite o primeiro nome do amigo que deseja adicionar: ");
                    var nomeAmigo = Console.ReadLine();

                    Console.WriteLine("Digite o sobrenome do amigo que deseja adicionar: ");
                    var sobrenomeAmigo = Console.ReadLine();

                    Console.WriteLine("Informe a data de nascimento do amigo: ");
                    var dataNascimentoAmigo = Console.ReadLine();

                    var dataNascimentoAmigoTipada = DateTime.Parse(dataNascimentoAmigo);
                    
                    Console.WriteLine("");
                    Console.WriteLine("Os dados estão corretos?");
                    Console.WriteLine($"Nome: {nomeAmigo + " " + sobrenomeAmigo}");
                    Console.WriteLine($"Data de nascimento: {dataNascimentoAmigoTipada.ToString("d")}");
                    Console.WriteLine("1 - Sim");
                    Console.WriteLine("2 - Não");

                    var respostaConfirmacaoAddAmigo = int.Parse(Console.ReadLine());

                    if (respostaConfirmacaoAddAmigo == 1)
                    {
                        var proximoId = services.RetornarId();
                        var amigo = new Amigos(proximoId, nomeAmigo, sobrenomeAmigo, dataNascimentoAmigoTipada);

                        services.AddAmigo(amigo);
                        
                        Console.WriteLine("");
                        Console.WriteLine("Amigo adicionado!");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal");
                        Console.ReadKey();
                    }
                    else if (respostaConfirmacaoAddAmigo == 2)
                    {
                        Console.WriteLine("Pressione qualquer tecla para reiniciar a operação");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Opção Invalida");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal");
                        Console.ReadKey();
                    }
                }

            } while (respostaMenu != 3);
        }
    }
}
