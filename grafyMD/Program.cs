
// Graf, okreslanie rozmiaru

Console.WriteLine("Podaj liczbę wierzchołków grafu(|V|): ");
Console.WriteLine("Np: 10,12,14...");
// n = liczba wierzchołków grafu, graf ma byc symetryczna tablica
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Wybraleś: "+n +" wierzchołków\n");

//Macierz wierzchołków
int[,]A = new int[n, n];
//Macierz wag
double[,]W = new double[n, n];



//Podawane prawdopodobienstwa istnienia krawedzi
Console.WriteLine("Podaj prawodopodobieństwo p: ");
Console.WriteLine("Zalecane to 0.2, 0.25, 0.3");
double p = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Wybrałeś prawodopodobieństwo: " +p +"\n");

Random rand = new Random(); 
while(true)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            A[i, j] = 0;
        }
    }
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = i + 1; j < n; j++)
        {
            double a = rand.NextDouble();

            //Tworzenie krawedzi oraz nadanie jej wagi jesli losowa liczba jest mniejsza niz prawdopodobieństwo podane przez użytkownika
            if (a < p)
            {
                double losowaLiczba = rand.NextDouble();

                //symetrycznośc macierzy 1 = istnieje krawędź
                A[i, j] = 1;
                A[j, i] = 1;
                Console.WriteLine("Wierzchołek w: (" + (i + 1) + "," + (j + 1) + ")");

                //Określanie wagi 
                int mnoznik = 100;
                W[i, j] = Math.Floor(10 + mnoznik * (losowaLiczba));
                W[j, i] = W[i, j];
            }
        }
    }

    //szukanie cykli o dlugosci 3

    int licznik_cykli3 = 0;
    Cykle C = new Cykle();

    for (int i = 0; i < n - 1; i++)
    {
        for (int j = i + 1; j < n; j++)
        {
            if (A[i, j] == 1)
            {
                for (int k = 1; k < n; k++)
                {
                    if (A[i, k] == 1 && A[j, k] == 1 && !C.czyJest(i, j, k))
                    {
                        licznik_cykli3++;
                        double waga = W[i, j] + W[i, k] + W[j, k];
                        int[] temp = new int[] { i, j, k, (int)waga };
                        C.cykl.Add(temp);
                        Console.WriteLine("waga:" + waga);
                        Console.WriteLine($"cykl: {i + 1} {j + 1} {k + 1}");
                    }
                }
            }
        }
    }

    //szukanie cykli o dlugosci 4

    int licznik_cykli4 = 0;
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = i + 1; j < n; j++)
        {
            if (A[i, j] == 1)
            {
                for (int k = i+1; k < n; k++)
                {
                    if (j != k)
                    {
                        for (int l = i + 1; l < n; l++)
                        {
                            if (l != k && l != j)
                            {
                                if (A[i, k] == 1 && A[j, l] == 1 && A[k, l] == 1 && !C.czyJest(i, j, k, l))
                                {
                                    licznik_cykli4++;
                                    double waga = W[i, j] + W[i, k] + W[j, l] + W[k, l];
                                    int[] temp = new int[] { i, j, k, l, (int)waga };
                                    C.cykl.Add(temp);
                                    Console.WriteLine("waga:" + waga);
                                    Console.WriteLine($"cykl: {i + 1} {j + 1} {k + 1} {l + 1}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }


    //KOD TESTOWY TYLKO DO RYSOWANIA GRAFU NA https://graphonline.ru/en/

    int z = 1;
    foreach (int e in A)
    {
        Console.Write(z % Math.Sqrt(A.Length) == 0 ? $"{e}\n" : e);
        z += 1;
    }
    Console.WriteLine("kontynuowac T/N?");
    string end = Console.ReadLine();
    if (end.ToLower()=="n")
    {
        break;
    }
}
