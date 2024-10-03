bool boiaA = false,
     boiaB = false,
     boiaC = false,
     bomba = false,
     valvula = false,
     erro = false;

// Leitura do estado das boias e dispositivos
Console.WriteLine("Insira o estado das boias (0 para não acionada, 1 para acionada):");

Console.Write("Boia A (nível baixo): ");
boiaA = int.Parse(Console.ReadLine()) == 1;

Console.Write("Boia B (nível intermediário): ");
boiaB = int.Parse(Console.ReadLine()) == 1;

Console.Write("Boia C (reservatório 2): ");
boiaC = int.Parse(Console.ReadLine()) == 1;

// Lógica para controle da bomba e da válvula com base no nível das boias
if (!boiaA && !boiaB && !boiaC) // Nível baixo
{
    erro = false;
    bomba = true; // Liga a bomba
    valvula = true; // Abre a válvula    
}
else if (!boiaA && boiaB && !boiaC) // Nível intermediário
{
    erro = false;
    bomba = true; // Continua bombeando
    valvula = false; // Fecha a válvula
}
else if (boiaA && boiaB && boiaC) // Nível máximo
{
    erro = false;
    bomba = false; // Desliga a bomba
    valvula = false; // Fecha a válvula
}
else // Inconsistência detectada
{
    erro = true; // Sinaliza erro
    bomba = false; // Desliga a bomba
    valvula = false; // Fecha a válvula
}

// Exibindo o status do sistema
if (erro)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\n|| ERRO: Inconsistência detectada! ||");
    Console.WriteLine("|| Travando a bomba e a válvula! Chame a manutenção! ||");
}
else
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nSistema operando corretamente.");

    if (bomba)
        Console.WriteLine("Bomba de água: LIGADA");
    else
        Console.WriteLine("Bomba de água: DESLIGADA");

    if (valvula)
        Console.WriteLine("Eletroválvula de entrada de água: ABERTA");
    else
        Console.WriteLine("Eletroválvula de entrada de água: FECHADA");
}
Console.ResetColor();