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

void EscreverTitulo()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(@" _");
    Console.WriteLine(@"( . __|_ _  _ _  _    _| _   |\/| _  _ ._|_ _  _ _  _ _  _  _ _|_ _   |_|´ _| _. _ _ ");
    Console.WriteLine(@"_)|_\ | (/_| | |(_|  (_|(/_  |  |(_)| || | (_)| (_|| | |(/_| | | (_)  | ||(_|| |(_(_)");
    Console.ResetColor();
}

inicio:

bool boiaA = false,
     boiaB = false,
     boiaC = false,
     bomba = false,
     valvula = false,
     erro = false;

EscreverTitulo();

// Leitura do estado das boias
Console.WriteLine("\nInforme o estado das boias (0 para \u001b[91mNÃO ACIONADA\u001b[0m, 1 para \u001b[92mACIONADA\u001b[0m):");

Console.Write("> \u001b[36mBoia A\u001b[0m [Reservatório 1 – Nível 1]: ");
boiaA = int.Parse(Console.ReadLine()) == 1;

Console.Write("> \u001b[36mBoia B\u001b[0m [Reservatório 1 – Nível 2]: ");
boiaB = int.Parse(Console.ReadLine()) == 1;

Console.Write("> \u001b[36mBoia C\u001b[0m [Reservatório 2 – Nível 3]: ");
boiaC = int.Parse(Console.ReadLine()) == 1;

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
    Console.WriteLine("Travando a bomba e a válvula! Chame a manutenção!\u001b[0m");
}
else
{
    Console.WriteLine("\n\u001b[92mSistema operando corretamente.");
    if (bomba)
        Console.WriteLine("\u001b[36mBomba de água: \u001b[92mLIGADA");
    else
        Console.WriteLine("\u001b[36mBomba de água: \u001b[91mDESLIGADA");

    if (valvula)
        Console.WriteLine("\u001b[36mEletroválvula de entrada de água: \u001b[92mABERTA\u001b[0m");
    else
        Console.WriteLine("\u001b[36mEletroválvula de entrada de água: \u001b[91mFECHADA\u001b[0m");
}

Console.Write("\nDeseja fazer um novo teste? (S/N): ");
string novoTeste = Console.ReadLine().ToUpper();
if (novoTeste == "S")
{
    goto inicio;
}
else if (novoTeste == "N")
{
    EscreverTitulo();
    Console.WriteLine("\nSaindo...");
    return;
}