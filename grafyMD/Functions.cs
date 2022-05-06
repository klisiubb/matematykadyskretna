using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafyMD
{
    public class Functions
    {

        public void resetMatrix(int[,] A, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = 0;
                }
            }
        }

        public async Task createVertexesAndSetWeight(int n, double p, Random rand, int[,]A, double[,]W, StreamWriter file)
        {
            int multiplier = 100;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double a = rand.NextDouble();

                    //Tworzenie krawedzi oraz nadanie jej wagi jesli losowa liczba jest mniejsza niz prawdopodobieństwo podane przez użytkownika
                    if (a < p)
                    {
                        double random = rand.NextDouble();

                        //symetrycznośc macierzy 1 = istnieje krawędź
                        A[i, j] = 1;
                        A[j, i] = 1;
                        await file.WriteLineAsync("Krawędź w (" + (i + 1) + "," + (j + 1) + ")");

                        //Określanie wagi 
                        W[i, j] = Math.Floor(10 + multiplier * (random));
                        W[j, i] = W[i, j];
                    }
                }
            }
        }

        public async Task drawGraph(int[,] A, StreamWriter file)
        {
            int z = 1;
            foreach (int e in A)
            {
               await file.WriteAsync(Convert.ToString(z % Math.Sqrt(A.Length) == 0 ? $"{e}\n" : e));
                z += 1;
            }
        }

        public async Task findCycle3(int[,] A, int n, double[,] W, Cycles C, StreamWriter file)
        {
            int cycle_Counter = 0;
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
                                cycle_Counter++;
                                double weight = W[i, j] + W[i, k] + W[j, k];
                                int[] temp = new int[] { i, j, k, (int)weight };
                                C.cykl.Add(temp);
                                await file.WriteLineAsync($"Cykl: {i + 1} {j + 1} {k + 1}");
                                await file.WriteLineAsync("Waga cyklu: " + weight + "\n");
                            }
                        }
                    }
                }
            }
        }

        public async Task FindCycle4(int[,] A, int n, double[,] W, Cycles C,StreamWriter file)
        {
            int cycle_counter = 0;
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
                                            cycle_counter++;
                                            double weight = W[i, j] + W[i, k] + W[j, l] + W[k, l];
                                            int[] temp = new int[] { i, j, k, l, (int)weight };
                                            C.cykl.Add(temp);
                                            await file.WriteLineAsync($"Cykl: {i + 1} {j + 1} {k + 1} {l + 1}");
                                            await file.WriteLineAsync("Waga cyklu: " + weight + "\n");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
