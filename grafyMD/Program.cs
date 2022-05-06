using grafyMD;
while(true)
{
    // Graf, okreslanie rozmiaru
    Console.WriteLine("Podaj liczbę wierzchołków grafu(|V|): ");
    Console.WriteLine("Np: 10,12,14...");
    // n = liczba wierzchołków grafu, graf ma byc symetryczna tablica
    int n = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Wybraleś: "+n +" wierzchołków\n");

    //Macierz wierzchołków
    int[,] A = new int[n, n];
    //Macierz wag
    double[,] W = new double[n, n];

    Functions functions = new Functions();
    Cycles cycle = new Cycles();
    Random rand = new Random();

    //Podawane prawdopodobienstwa istnienia krawedzi
    Console.WriteLine("Podaj prawodopodobieństwo p: ");
    Console.WriteLine("Zalecane to 0.2, 0.25, 0.3");
    double p = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Wybrałeś prawodopodobieństwo: " +p +"\n");

    //Wypełnianie macierzy zerami.
    functions.resetMatrix(A, n);

    //Tworzenie krawędzi i określanie wagi
    functions.createVertexesAndSetWeight(n, p, rand, A, W);

    //Szukanie cykli o dlugosci 3
    functions.findCycle3(A, n, W, cycle);

    //Szukanie cykli o dlugosci 4
    functions.FindCycle4(A, n, W, cycle);  
   
    // Tworzenie macierzy do rysowania grafu.
    functions.drawGraph(A);

    Console.WriteLine("kontynuowac T/N?");
    string? end =Console.ReadLine();
    if (end=="n" || end =="N")
    {
        break;
    }
}
