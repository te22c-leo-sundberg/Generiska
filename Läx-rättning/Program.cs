using System.Runtime.Intrinsics.Arm;

int correctAnswers = 0;

Queue<string> Lärare = new Queue<string>();
Lärare.Enqueue("micke");
Lärare.Enqueue("joel");
Lärare.Enqueue("liv");

Stack<string> Läxor = new Stack<string>();
Läxor.Push("Prog");
Läxor.Push("Prog");
Läxor.Push("Prog");
Läxor.Push("Prog");
Läxor.Push("Matte");
Läxor.Push("Matte");
Läxor.Push("DaoDac");
Läxor.Push("DaoDac");
Läxor.Push("DaoDac");

List<string> Klassrum = ["Programmering", "Matematik", "DaoDac"];


bool game = true;
Console.WriteLine("Det är dags att rätta läxor. Programmeringsläraren Micke ska rätta läxor först,\nsedan Matte läraren Joel och sist Dator och Nätverksteknik läraren Liv.\n");
Console.WriteLine("Det finns totalt 4 prog läxor att rätta, 2 matte läxor och 3 DaoDac läxor.\n");
Console.WriteLine("Ditt jobb som lärarassistent är att se till att rätt lärare \nrättar först, och at de rättar bara sina ämnens läxor.\n");
while (game)
{
    if (Lärare.Count > 0)
    {
        string input = GetStringLärare("Påminn mig, i vilken ordning ska lärarna rätta?");
    }
    else if (Läxor.Count > 0)
    {
        string input = GetStringLäxor("Påminn mig, hur många läxor fanns det för alla ämnen? Tryck [S] för att smygtitta.");
    }
    else if (correctAnswers < 1)
    {
        string input = GetStringKlassrum("Påminn mig, vilket klassrum är Micke alltid i? [Programmering], [Matematik], [Daodac].", 0);
    }
    else if (correctAnswers < 2)
    {
        string input = GetStringKlassrum("Påminn mig, vilket klassrum är Joel alltid i? [Programmering], [Matematik], [Daodac].", 1);
    }
    else if (correctAnswers < 3)
    {
        string input = GetStringKlassrum("Påminn mig, vilket klassrum är Liv alltid i? [Programmering], [Matematik], [Daodac].", 2);
    }
    else
    {
        Console.WriteLine("Nu är du klar! Bra jobbat!");
        game = false;
    }
}

Console.ReadLine();
string GetStringLärare(string text)
{
    Console.WriteLine(text);
    string input = "";
    bool success = false;
    while (!success)
    {
        input = Console.ReadLine().ToLower();
        if (input != "micke" && input != "joel" && input != "liv")
        {
            Console.WriteLine("Nja, denna lärare arbetar inte idag");
            success = false;
        }
        else if (input != Lärare.Peek())
        {
            Console.WriteLine("Nja, denna lärare ska inte rätta just nu.");
            success = false;
        }
        else
        {
            Console.WriteLine("Bra jobbat!");
            Lärare.Dequeue();
            success = true;
        }
    }
    return input;
}
string GetStringLäxor(string text)
{
    Console.WriteLine(text);
    string input = "";
    bool success = false;
    while (!success)
    {
        input = Console.ReadLine().ToUpper();
        if (input == "S" || input == "s")
        {
            Console.WriteLine(Läxor.Peek());
            success = true;
        }
        else if (input != Läxor.Peek().ToUpper())
        {
            Console.WriteLine("Nja, det är inte korrekta läxan.");
            success = false;
        }
        else
        {
            Console.WriteLine("Bra jobbat!");
            Läxor.Pop();
            success = true;
        }
    }
    return input;
}
string GetStringKlassrum(string text, int correctAnswer)
{
    Console.WriteLine(text);
    string input = "";
    bool success = false;
    while (!success)
    {
        input = Console.ReadLine().ToUpper();
        if (input == "S" || input == "s")
        {
            Console.WriteLine(Läxor.Peek());
            success = true;
        }
        else if (input != Klassrum[correctAnswer].ToUpper())
        {
            Console.WriteLine("Nja, det är inte korrekta läxan.");
            success = false;
        }
        else
        {
            Console.WriteLine("Bra jobbat!");
            correctAnswers++;
            success = true;
        }
    }
    return input;
}