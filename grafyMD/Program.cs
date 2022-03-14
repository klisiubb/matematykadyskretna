
// Graf, okreslanie rozmiaru

Console.WriteLine("Podaj liczbę wierzchołków grafu(|V|): ");
Console.WriteLine("Np: 10,12,14...");
// n = liczba wierzchołków grafu, graf ma byc symetryczna tablica
int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Wybraleś: "+n +" wierzchołków");

//Graf wypelnianie macierzy zerami

//Macierz wierzchołków
int[,]A = new int[n, n];
//Macierz wag
int[,]W = new int[n, n];

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        A[i, j] = 0;
    }
}

//Podawane prawdopodobienstwa istnienia krawedzi
Console.WriteLine("Podaj prawodopodobieństwo p: ");
Console.WriteLine("Zalecane to 0.2, 0.25, 0.3");
double p = Convert.ToDouble(Console.ReadLine());

Random rand = new Random(2); 

for (int i = 1; i < n-1; i++)
{
    for (int j = i+1; j < n; j++)
    {
        double a = rand.NextDouble();
        
        //Tworzenie krawedzi oraz nadanie jej wagi jesli losowa liczba jest mniejsza niz prawdopodobieństwo podane przez użytkownika
        if(a < p)
        {
            int losowaLiczba = Convert.ToInt32(rand.NextDouble());
            
            //symetrycznośc macierzy 1 = istnieje krawędź
            A[i, j] = 1;
            A[j, i] = 1;

            //Określanie wagi 
            W[i,j] = 10 + 50*(losowaLiczba);
            W[j, i] = W[i, j];

        }
    }
}