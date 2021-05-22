using System;

namespace Trabalho_Prático_do_Grau_A 
{
    class Program {
        static void Main(string[] args) {

            #region VARIAVEIS
            float[] custoPacote = new float[0];
            int contador = 0;
            int[] caminhao = new int[0];
            float[] valoresPacote = new float[0];
            int opcaoMenu;
            int opcaoDois = 0;
            int capacidadeMax = 0;
            int pesoCargaMax = 0;
            int pesoPacote;
            int valorPacote;
            int pesoCaminhaoMax = 0;  
            float precoPacote;
            bool subMenu =  true;
            bool reiniciar = true;
            bool taxaAceita = false;
            bool diaIniciado = false;
            int capacidadeAtualTotal = 0;
            int menorQntPac = 0;
            int maiorQntPac = 0;
            int menorPesoTotal = 0, maiorPesoTotal = 0;
            int maiorPesoExcedente = 0; float maiorTaxaExcedente = 0;

            #endregion

            #region MENU
            while (reiniciar) {

                Console.WriteLine("            MENU            ");
                Console.WriteLine(" ");
                Console.WriteLine(" [1] - INCIAR DIA");
                Console.WriteLine(" [2] - REALIZAR PARADA");
                Console.WriteLine(" [3] - CONSULTAR SITUAÇÃO");
                Console.WriteLine(" [4] - LISTAR PACOTES");
                Console.WriteLine(" [5] - FINALIZAR DIA");
                Console.WriteLine(" [6] - GERAR RELATÓRIO");
                Console.WriteLine(" [7] - SAIR");
                Console.WriteLine(" ");

                Console.Write("Por favor, escolha uma das opções acima digitando seu número correspondente: ");
                opcaoMenu = int.Parse(Console.ReadLine());
                Console.WriteLine(" ");

                #endregion

                #region  1 - INCIAR DIA

                if (opcaoMenu == 1) {

                    if (!diaIniciado) {
                        Console.Clear();
                        diaIniciado = true;
                        Console.WriteLine("Iniciar Dia: ");
                        Console.WriteLine("Insira a capacidade máxima do caminhão em metros cúbicos: ");
                        capacidadeMax = int.Parse(Console.ReadLine());

                        caminhao = new int[capacidadeMax];

                        while (contador < capacidadeMax) {
                            caminhao[contador] = 0;
                            contador++;
                        }

                        Console.WriteLine("Insira o peso máximo de carga total: ");
                        pesoCargaMax = int.Parse(Console.ReadLine());

                        pesoCaminhaoMax = capacidadeMax * 10;

                        valoresPacote = new float[capacidadeMax];
                        custoPacote = new float[capacidadeMax];

                        Console.Clear();

                        Console.WriteLine("Dia iniciado! ");
                        Console.WriteLine(" ");
                        Console.WriteLine("Pressione enter para prosseguir: ");
                        Console.ReadKey();
                        Console.Clear();
                        
                    }else if (diaIniciado) {
                        Console.Clear();
                        Console.WriteLine("O dia ja esta iniciado");
                        Console.WriteLine(" ");
                        Console.WriteLine("Pressione enter para prosseguir: ");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    

                }
                #endregion

                #region 2 - REALIZAR PARADA
                else if (opcaoMenu == 2) {
                    subMenu = true;
                    int contPac = 0;

                    Console.Clear();


                    while (!diaIniciado) {
                        Console.WriteLine("Antes de fazer uma parada, você precisa iniciar o dia");
                        Console.WriteLine(" ");
                        Console.WriteLine("Pressione enter para prosseguir: ");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }

                    while (subMenu && diaIniciado) {


                        Console.Clear();
                        Console.WriteLine("Realizar Parada: ");
                        Console.WriteLine(" [1] - INSERIR PACOTE");
                        Console.WriteLine(" [2] - RETIRAR PACOTE");
                        Console.WriteLine(" [3] - ENCERRAR PARADA");

                        Console.Write("Por favor, escolha uma das opções acima digitando seu número correspondente: ");
                        opcaoDois = int.Parse(Console.ReadLine());
                        #endregion

                        #region INSERIR PACOTE
                        if (opcaoDois == 1) {

                            Console.Clear();
                            Console.WriteLine("Inserir Pacote: ");
                            Console.WriteLine("Insira o peso do pacote a ser inserido(1 a 99kg's): ");
                            pesoPacote = int.Parse(Console.ReadLine());
                            Console.WriteLine("Insira o valor do pacote a ser inserido: ");
                            valorPacote = int.Parse(Console.ReadLine());

                            precoPacote = pesoPacote * 1.5f;

                            Console.WriteLine($"O custo para envio é de: {precoPacote} reais.");
                            Console.WriteLine("Pressione enter para prosseguir: ");
                            Console.ReadKey();

                            for (int i = 0; i < caminhao.Length; i++) {  //Peso total caminhao
                                capacidadeAtualTotal += caminhao[i];
                            }

                            capacidadeAtualTotal += pesoPacote;
                            if (capacidadeAtualTotal > pesoCaminhaoMax) {
                                string escolhaSeguro;
                                float diferenca = precoPacote + ((capacidadeAtualTotal - pesoCaminhaoMax) * 0.8f);
                                Console.WriteLine($"o valor com a taxa é de: {diferenca} Reais");

                                Console.WriteLine("O pacote excedeu a capacidade máxima do caminhão");
                                Console.WriteLine("deseja continuar com a taxa?(s/n)");
                                escolhaSeguro = Console.ReadLine();

                                if (escolhaSeguro == "s") {
                                    if (diferenca >= maiorTaxaExcedente) {
                                        maiorTaxaExcedente = ((capacidadeAtualTotal - pesoCaminhaoMax) * 0.8f);
                                    }
                                    if (pesoPacote >= maiorPesoExcedente) {
                                        maiorPesoExcedente = pesoPacote;
                                    }
                                    taxaAceita = true;
                                    precoPacote = diferenca;
                                    Console.Clear();
                                    Console.WriteLine("O pacote foi inserido com sucesso!");
                                    Console.WriteLine(" ");
                                    Console.WriteLine("Pressione enter para prosseguir: ");
                                    Console.ReadKey();
                                    Console.Clear();
                                }

                            } else {
                                taxaAceita = true;
                                Console.Clear();
                                Console.WriteLine("O pacote foi inserido com sucesso!");
                                Console.WriteLine(" ");
                                Console.WriteLine("Pressione enter para prosseguir: ");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            if (taxaAceita) {
                                contPac++;
                                for (int i = 0; i < caminhao.Length; i++) {
                                    if (caminhao[i] == 0) {
                                        caminhao[i] = pesoPacote;
                                        valoresPacote[i] = valorPacote;
                                        custoPacote[i] = precoPacote;

                                        Console.Clear();

                                        Console.WriteLine("Pacote Inserido! ");
                                        break;
                                    }

                                }
                                if (contPac >= maiorQntPac) {
                                    maiorQntPac = contPac;
                                }
                                if (contPac <= menorQntPac) {
                                    menorQntPac = contPac;
                                }else if (menorQntPac == 0) {
                                    menorQntPac = contPac;
                                }
                                

                            }

                        }
                        #endregion
                        #region RETIRAR PACOTE
                        else if (opcaoDois == 2) {

                            string decisaoRemover;
                            int posicaoUltimo = 0;
                            int ultimoPacote = 0;
                            for (int i = 0; i < caminhao.Length; i++) {
                                if (caminhao[i] == 0) {
                                    ultimoPacote = caminhao[i - 1];
                                    posicaoUltimo = i - 1;
                                    break;
                                }
                            }
                            Console.Clear();
                            Console.WriteLine($"deseja remover o ultimo pacote de peso: {ultimoPacote} ?(s/n)");
                            decisaoRemover = Console.ReadLine();

                            if (decisaoRemover == "s") {
                                caminhao[posicaoUltimo] = 0;
                                valoresPacote[posicaoUltimo] = 0;
                                custoPacote[posicaoUltimo] = 0;

                                Console.Clear();
                                Console.WriteLine("Pacote Retirado! ");
                                Console.WriteLine(" ");
                                Console.WriteLine("Pressione enter para prosseguir: ");
                                Console.ReadKey();
                                Console.Clear();
                            }else if (decisaoRemover == "n") {
                                Console.WriteLine("Pacote não retirado! ");
                                Console.WriteLine(" ");
                                Console.WriteLine("Pressione enter para prosseguir: ");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            #endregion
                        #region ENCERRAR PARADA

                        } else if (opcaoDois == 3) {
                            subMenu = false;
                            int pesoCaminhao= 0;

                            Console.Clear();

                            Console.WriteLine("Parada Encerrada! ");
                            Console.WriteLine(" ");
                            Console.WriteLine("Pressione enter para prosseguir: ");
                            Console.ReadKey();
                            Console.Clear();

                            for (int i = 0; i < caminhao.Length; i++) {
                                pesoCaminhao += caminhao[i];
                            }
                            if (pesoCaminhao <= menorPesoTotal) {
                                menorPesoTotal = pesoCaminhao;
                            } else if (menorPesoTotal == 0) {
                                menorPesoTotal = pesoCaminhao;
                            }
                            if (pesoCaminhao >= maiorPesoTotal) {
                                maiorPesoTotal = pesoCaminhao;
                            }
                            break;


                        }


                    }
                }
                #endregion

                #region 3 - CONSULTAR SITUAÇÃO
                else if (opcaoMenu == 3) {

                    if (diaIniciado) {

                        int pacotesRestantes = 0;
                        int pacotesColocados = 0;

                        Console.Clear();

                        Console.WriteLine(" ");

                        Console.WriteLine($"O peso atual do caminhão é de: {capacidadeAtualTotal}");
                        Console.WriteLine($"O peso restante do caminhão é de: {pesoCaminhaoMax - capacidadeAtualTotal}");
                        Console.WriteLine($"O peso maximo do caminhão é de: {pesoCargaMax}");

                        for (int i = 0; i < caminhao.Length; i++) {
                            if (caminhao[i] != 0) {
                                pacotesColocados++;
                            }
                        }
                        for (int i = 0; i < caminhao.Length; i++) {
                            if (caminhao[i] == 0) {
                                pacotesRestantes++;
                            }
                        }

                        Console.WriteLine($"A quantitade de pacotes carregados é de: {pacotesColocados}");
                        Console.WriteLine($"A quantitade de pacotes restantes é de: {pacotesRestantes}");
                        Console.WriteLine($"A quantitade máxima de pacotes é de: {capacidadeMax}");
                        Console.WriteLine("Pressione enter para prosseguir: ");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    while (!diaIniciado) {
                        Console.Clear();
                        Console.WriteLine("Antes de gerar um relatório, você precisa iniciar o dia");
                        Console.WriteLine(" ");
                        Console.WriteLine("Pressione enter para prosseguir: ");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    

                }


                #endregion

                #region 4 - LISTAR PACOTES

                else if (opcaoMenu == 4) {

                    Console.Clear();

                    Console.WriteLine("  ------");
                    Console.Write(" /   | |");
                    Console.WriteLine(String.Join("| ", caminhao));
                    Console.WriteLine(" ------|--------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("  -()--|                    /()                                                           /()()");
                    Console.WriteLine(" ");
                    Console.WriteLine("Pressione enter para prosseguir: ");
                    Console.ReadKey();
                    Console.Clear();

                }

                #endregion

                #region 5 - FINALIZAR DIA
                else if (opcaoMenu == 5) {
                    Console.Clear();

                    Console.WriteLine("Dia finalizado! ");
                    Console.WriteLine(" ");
                    Console.WriteLine("Pressione enter para prosseguir: ");
                    Console.ReadKey();
                    Console.Clear();

                    diaIniciado = false;
                }
                #endregion

                #region 6 - GERAR RELATÓRIO
                else if (opcaoMenu == 6) {
                    
                    int menorPeso = caminhao[0];
                    int maiorPeso = caminhao[0];

                    for (int i = 0; i < caminhao.Length; i++) {
                        
                        if (caminhao[i] != 0) {
                            if (caminhao[i] <= menorPeso) {
                                menorPeso = caminhao[i];
                            }
                            if (caminhao[i] >= maiorPeso) {
                                maiorPeso = caminhao[i];
                            }
                        } else {
                            break;
                        }
                    }
                    if (!diaIniciado) {
                        Console.Clear();
                        Console.WriteLine($"O Menor peso de pacote individual transportado durante todo o dia foi de: {menorPeso} kg");
                        Console.WriteLine($"O Maior peso de pacote individual transportado durante todo o dia foi de: {maiorPeso} kg");
                        Console.WriteLine($"A Menor quantidade de pacotes embarcados em uma parada; foi de: {menorQntPac} pacotes");
                        Console.WriteLine($"A Maior quantidade de pacotes embarcados em uma parada foi de: {maiorQntPac} pacotes");
                        Console.WriteLine($"A Menor quantidade total de peso no caminhão ao encerrar parada foi de: {menorPesoTotal} kg");
                        Console.WriteLine($"A Maior quantidade total de peso no caminhão ao encerrar parada foi de: {maiorPesoTotal} kg");
                        Console.WriteLine($"O Maior valor excedente durante todo o dia; foi de: {maiorTaxaExcedente} reais");
                        Console.WriteLine($"O Maior peso excedente durante todo o dia foi de: {maiorPesoExcedente} kg");
                        Console.WriteLine("Pressione enter para prosseguir: ");
                        Console.ReadKey();
                        Console.Clear();
                    } else {
                        Console.Clear();
                        Console.WriteLine("Antes de gerar um relatório, você precisa finalizar o dia");
                        Console.WriteLine("Pressione enter para prosseguir: ");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }

                #endregion

                #region 7 - SAIR
                else if (opcaoMenu == 7) {
                    reiniciar = false;
                }
                #endregion
                         
              }

        }
    }
}
