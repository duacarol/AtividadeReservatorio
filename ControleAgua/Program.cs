// false = não acionado, true = acionado
bool boiaA,
     boiaB,
     boiaC,
     bomba,
     valvulaS2,
     erro = false;

int nivelAgua = 0;

Console.Write("Informe o nível de água do reservatório: ");
nivelAgua = int.Parse(Console.ReadLine());
switch (nivelAgua)
{
    case 0:
        bomba = false; // A bomba de água não pode funcionar com o reservatório vazio.
        break;
}