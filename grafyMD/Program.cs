
// Graf, okreslanie rozmiaru

Console.WriteLine("Podaj liczbę wierzchołków grafu(|V|): ");
Console.WriteLine("Np: 10,12,14...");
// n = liczba wierzchołków grafu, graf ma byc symetryczna tablica
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Wybraleś: "+n +" wierzchołków");

//Graf wypelnianie macierzy zerami

int[,]A = new int[n, n];

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        A[i, j]=0;
    }
}

//Podawane prawdopodobienstwa istnienia krawedzi
Console.WriteLine("Podaj prawodopodobieństwo p: ");
Console.WriteLine("Zalecane to 0.2, 0.25, 0.3");
double p = Convert.ToDouble(Console.ReadLine());