using System.Runtime.Intrinsics.Arm;

int correctAnswers = 0;

Queue<string> Lärare = new Queue<string>(); //Skapar en queue av strings och addar alla lärare. I en queue kan du bara ta ut det längst fram och stoppa in saker längst bak.
Lärare.Enqueue("micke");
Lärare.Enqueue("joel");
Lärare.Enqueue("liv");

Stack<string> Läxor = new Stack<string>(); //Skapar en stack av strings och addar hur många läxor av alla ämne som finns. I en stack kan du bara ta ut och lägga till längst fram.
Läxor.Push("Prog");
Läxor.Push("Prog");
Läxor.Push("Prog");
Läxor.Push("Prog");
Läxor.Push("Matte");
Läxor.Push("Matte");
Läxor.Push("DaoDac");
Läxor.Push("DaoDac");
Läxor.Push("DaoDac");

List<string> Klassrum = ["Programmering", "Matematik", "DaoDac"]; //Skapar en lista av strings för olika klassrum.


bool game = true;
Console.WriteLine("Det är dags att rätta läxor. Programmeringsläraren Micke ska rätta läxor först,\nsedan Matte läraren Joel och sist Dator och Nätverksteknik läraren Liv.\n");
Console.WriteLine("Det finns totalt 4 prog läxor att rätta, 2 matte läxor och 3 DaoDac läxor.\n");
Console.WriteLine("Ditt jobb som lärarassistent är att se till att rätt lärare \nrättar först, och at de rättar bara sina ämnens läxor.\n");
while (game)
{
    if (Lärare.Count > 0) //Kollar så att det fortfarande finns lärare i min queue innan denna kod under runnas.
    {
        string input = GetStringLärare("Påminn mig, i vilken ordning ska lärarna rätta?");
    }
    else if (Läxor.Count > 0) //Kollar så att det fortfarande finns läxor i min stack innan denna kod under runnas.
    {
        string input = GetStringLäxor("Påminn mig, hur många läxor fanns det för alla ämnen? Tryck [S] för att smygtitta.");
    }
    else if (correctAnswers < 1) //Körs ifall spelaren inte har något korrekt svar ännu.
    {
        string input = GetStringKlassrum("Påminn mig, vilket klassrum är Micke alltid i? [Programmering], [Matematik], [Daodac].", 0);
    }
    else if (correctAnswers < 2) //Körs ifall spelaren bara har ett korrekt svar.
    {
        string input = GetStringKlassrum("Påminn mig, vilket klassrum är Joel alltid i? [Programmering], [Matematik], [Daodac].", 1);
    }
    else if (correctAnswers < 3) //Körs ifall spelaren har 2 korrekta svar.
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

string GetStringLärare(string text) //Ska samla in en string. Ifall stringen inte är det korrekta svaret kommer while loopen fortsätta tills du skriver in rätt svar.
{
    Console.WriteLine(text);
    string input = "";
    bool success = false;
    while (!success)
    {
        input = Console.ReadLine().ToLower();
        if (input != "micke" && input != "joel" && input != "liv") //Kollar ifall svaret är någon av lärarna
        {
            Console.WriteLine("Nja, denna lärare arbetar inte idag");
            success = false;
        }
        else if (input != Lärare.Peek())
        {
            Console.WriteLine("Nja, denna lärare ska inte rätta just nu."); //kollar ifall svaret är den korrekta läraren
            success = false;
        }
        else //När du skriver rätt svar blir success sann vilket leder till att denna while loop slutar och du rör dig vidare. Samtidigt tömmer jag stringen längst fram i min queue.
        // Detta leder till att rätta svar automatiskt är Joel nästa gång. Gången efter det är det Liv etc.
        {
            Console.WriteLine("Bra jobbat!");
            Lärare.Dequeue();
            success = true;
        }
    }
    return input;
}
string GetStringLäxor(string text) //Ska samla in en string. Ifall stringen inte är det korrekta svaret kommer while loopen fortsätta tills du skriver in rätt svar.
{
    Console.WriteLine(text);
    string input = "";
    bool success = false;
    while (!success)
    {
        input = Console.ReadLine().ToUpper();
        if (input == "S" || input == "s")
        {
            Console.WriteLine(Läxor.Peek());//Visar spelaren läxan högst upp så att de inte fasnar
            success = true;
        }
        else if (input != Läxor.Peek().ToUpper()) //Kollar och säger till spelaren att den hade fel.
        {
            Console.WriteLine("Nja, det är inte korrekta läxan.");
            success = false;
        }
        else
        {
            Console.WriteLine("Bra jobbat!"); //Kollar och säger till att spelaren hade rätt svar, och använder pop för att ta bort stringen som ligger högst upp i stacken. Sedan blir success true och loopen slutar denna gång.
            Läxor.Pop();
            success = true;
        }
    }
    return input;
}
string GetStringKlassrum(string text, int correctAnswer) //Ska samla in en string. Ifall stringen inte är det korrekta svaret kommer while loopen fortsätta tills du skriver in rätt svar.
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