// Tabela Verdade
//
// | A  | B  | C  | S1 | S2 | E  |
// |----|----|----|----|----|----|
// | 0  | 0  | 0  | 0  | 0  | 0  |
// | 0  | 0  | 1  | 0  | 0  | 1  |
// | 0  | 1  | 0  | 0  | 0  | 1  |
// | 0  | 1  | 1  | 0  | 0  | 1  |
// | 1  | 0  | 0  | 1  | 0  | 0  |
// | 1  | 0  | 1  | 0  | 0  | 1  |
// | 1  | 1  | 0  | 1  | 1  | 0  |
// | 1  | 1  | 1  | 0  | 1  | 0  |

class Program
{
    static void Main()
    {
        bool rodarTeste = true, boiaA, boiaB, boiaC, bomba, valvula, erro;
        string escolhaUsuario;

        while (rodarTeste)
        {
            EscreverTitulo();
            // Leitura do estado das boias
            Console.WriteLine("\nInforme o estado das boias (0 para \u001b[91mNÃO ACIONADA\u001b[0m, 1 para \u001b[92mACIONADA\u001b[0m):");

            boiaA = LerEstadoBoia("Boia A [Reservatório 1 – Nível 1]");
            boiaB = LerEstadoBoia("Boia B [Reservatório 1 – Nível 2]");
            boiaC = LerEstadoBoia("Boia C [Reservatório 2 – Nível 3]");

            // Lógica para controle da bomba e da válvula com base no nível das boias
            if (!boiaA && !boiaB && !boiaC) // Reservatórios vazios, tudo off
            {
                erro = false;
                bomba = false;
                valvula = false;
            }
            else if (boiaA && !boiaB && !boiaC)
            {
                erro = false;
                bomba = true; // Liga a bomba
                valvula = false;
            }
            else if (boiaA && boiaB && !boiaC)
            {
                erro = false;
                bomba = true; // Continua bombeando
                valvula = true; // Abre a válvula
            }
            else if (boiaA && boiaB && boiaC)
            {
                erro = false;
                bomba = false; // Desliga a bomba
                valvula = true; // Válvula segue aberta
            }
            else // Inconsistência detectada
            {
                erro = true; // Sinaliza erro
                bomba = false; // Desliga a bomba
                valvula = false; // Fecha a válvula
            }

            EscreverTitulo();
            // Exibindo o status do sistema
            if (erro)
            {
                Console.WriteLine("\n\u001b[91mERRO: Inconsistência detectada!");
                Console.WriteLine("Travando a bomba e a válvula! Chame a manutenção!\u001b[0m\n");
            }
            else
            {
                Console.WriteLine("\n\u001b[92mSistema operando corretamente.");
                Console.WriteLine($"\u001b[36mBomba de água: {(bomba ? "\u001b[92mLIGADA" : "\u001b[91mDESLIGADA")}");
                Console.WriteLine($"\u001b[36mEletroválvula de entrada de água: {(valvula ? "\u001b[92mABERTA" : "\u001b[91mFECHADA")}\u001b[0m\n");
            }

            while (true)
            {
                Console.Write("Deseja fazer um novo teste? (S/N): ");
                escolhaUsuario = Console.ReadLine().ToUpper();
                if (escolhaUsuario == "S" || escolhaUsuario == "N")
                    break;
                else
                    Console.WriteLine("\u001b[91mOpção inválida! Digite S ou N.\u001b[0m");
            }

            if (escolhaUsuario == "N")
            {
                rodarTeste = false;
            }
        }
        EscreverTitulo();
        Console.WriteLine("\nSaindo...");
    }

    static void EscreverTitulo()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(@" _");
        Console.WriteLine(@"( . __|_ _  _ _  _    _| _   |\/| _  _ ._|_ _  _ _  _ _  _  _ _|_ _   |_|´ _| _. _ _ ");
        Console.WriteLine(@"_)|_\ | (/_| | |(_|  (_|(/_  |  |(_)| || | (_)| (_|| | |(/_| | | (_)  | ||(_|| |(_(_)");
        Console.ResetColor();
    }

    static bool LerEstadoBoia(string boia)
    {
        string escolhaUsuario;
        
        while (true)
        {
            Console.Write($"> \u001b[36m{boia}\u001b[0m: ");
            escolhaUsuario = Console.ReadLine().ToUpper();
            if (escolhaUsuario == "0" || escolhaUsuario == "1")
                return escolhaUsuario == "1";
            else
                Console.WriteLine("\u001b[91mEntrada inválida! Digite 0 ou 1.\u001b[0m");
        }
    }
}