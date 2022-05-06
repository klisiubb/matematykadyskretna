using grafyMD;
while(true)
{
    Functions functions = new Functions();
    Cycles cycle = new Cycles();
    Random rand = new Random();

    // Graf, okreslanie rozmiaru
    Console.WriteLine("Podaj liczbę wierzchołków grafu(|V|): ");
    Console.WriteLine("Np: 10,12,14...");
    // n = liczba wierzchołków grafu, graf ma byc symetryczna tablica
    int n = Convert.ToInt32(Console.ReadLine());

    //Podawane prawdopodobienstwa istnienia krawedzi
    Console.WriteLine("Podaj prawodopodobieństwo p: ");
    Console.WriteLine("Zalecane to 0,2, 0,25, 0,3");
    double p = Convert.ToDouble(Console.ReadLine());
    //Macierz wierzchołków
    int[,] A = new int[n, n];
    //Macierz wag
    double[,] W = new double[n, n];

    //Zapis do pliku
    string datetime = DateTime.Now.ToString("yyyyMMddHHmm");
    using StreamWriter file = new StreamWriter("Raport"+datetime+".txt");
    await file.WriteLineAsync("Ilość wierzchołków grafu: " + n +"\n");
    await file.WriteLineAsync("Prawdopodobieństwo istnienia krawędzi: " + p+"\n");

   

    //Wypełnianie macierzy zerami.
    functions.resetMatrix(A, n);


    //Tworzenie krawędzi i określanie wagi

    await file.WriteLineAsync("Krawędzie grafu:\n");
    await functions.createVertexesAndSetWeight(n, p, rand, A, W,file);

    // Tworzenie macierzy do rysowania grafu.
    await file.WriteLineAsync("\nMacierz grafu:\n");
    await functions.drawGraph(A,file);

    //Szukanie cykli o dlugosci 3
    await file.WriteLineAsync("\nCykle o długości 3:\n");
    await functions.findCycle3(A, n, W, cycle,file);

    //Szukanie cykli o dlugosci 4
    await file.WriteLineAsync("\nCykle o długości 4:\n");
    await functions.FindCycle4(A, n, W, cycle, file);

    await file.WriteLineAsync("\nAutorzy raportu: \nMateusz Kliś \nPaula Kawalec \nEdyta Kos \nAgnieszka Białecka");
    file.Close();

    Console.WriteLine("kontynuowac T/N?");
    string? end =Console.ReadLine();
    if (end=="n" || end =="N")
    {
        break;
    }
}
