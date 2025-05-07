using System.ComponentModel;
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

// Inclusa de pessoas
Pessoa p1 = new Pessoa(nome: "Adriano", sobrenome: "Lima");
Pessoa p2 = new Pessoa(nome: "Thalita", sobrenome: "Pinheiro");
Pessoa p3 = new Pessoa(nome: "Thalia", sobrenome: "Pinheiro");
Pessoa p4 = new Pessoa(nome: "Eduardo", sobrenome: "Lima");
Pessoa p5 = new Pessoa(nome: "Ary", sobrenome: "Lima");
Pessoa p6 = new Pessoa(nome: "Thomas", sobrenome: "Pinheiro");
Pessoa p7 = new Pessoa(nome: "Eleonora", sobrenome: "Pinheiro");
Pessoa p8 = new Pessoa(nome: "Ana", sobrenome: "Lima");

// Add pessoas na lista
hospedes.Add(p1);
hospedes.Add(p2);
hospedes.Add(p3);
hospedes.Add(p4);
hospedes.Add(p5);
hospedes.Add(p6);
hospedes.Add(p7);
hospedes.Add(p8);


// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 10);

// Cria suite de acordo com a quantidade de hospedes

Suite suiteBasic = new Suite(tipoSuite: "Basic", capacidade: 2, valorDiaria: 300);
Suite suitePremium = new Suite(tipoSuite: "Premium", capacidade: 4, valorDiaria: 800);
Suite suitePresident = new Suite(tipoSuite: "President", capacidade: 8, valorDiaria: 2000);

// Escolhe a suíte correta baseado na quantidade de hóspedes
Suite suiteEscolhida;
int quantidadeHospedes = hospedes.Count;

if(quantidadeHospedes <= 2)
{
    suiteEscolhida = suiteBasic;
} 
else if (quantidadeHospedes <= 4)
{
    suiteEscolhida = suitePremium;
} 
else
{
    suiteEscolhida = suitePresident;
}


// Cadastra suíte e hóspedes na reserva
reserva.CadastrarSuite(suiteEscolhida);
reserva.CadastrarHospedes(hospedes);

// Exibe detalhamento de todas as informacoes do Hotel
Console.WriteLine("Seja bem-vindo ao Hotel California 🦅\n");

Console.WriteLine($"Seu quarto e do tipo 🌟{suiteEscolhida.TipoSuite}🌟\n");

Console.WriteLine($"Quantidade de Hóspedes: {reserva.ObterQuantidadeHospedes()}");

for(int contador = 0; contador < hospedes.Count; contador++)
{
    Console.WriteLine($"{contador+1}º Hóspede - {hospedes[contador].NomeCompleto}");
}
Console.WriteLine();

if (reserva.DiasReservados >= 10)
{
    decimal desconto = reserva.DiasReservados * (suiteEscolhida.ValorDiaria * 0.1M);
    Console.WriteLine($"Voce teve uma economia de 10% no valor total de sua hospedagem {desconto:C} 💵");
}

Console.WriteLine();
Console.WriteLine($"Valor total da estadia: {reserva.CalcularValorDiaria():C}");
Console.WriteLine($"Valor da diária: {(reserva.CalcularValorDiaria()/reserva.DiasReservados):C}\n");
Console.WriteLine("Aproveite sua estadia 🦅");