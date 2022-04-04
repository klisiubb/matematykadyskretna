
// Graf, okreslanie rozmiaru

// n = liczba wierzchołków grafu, graf ma byc symetryczna tablica

//Graf wypelnianie macierzy zerami

//Macierz wierzchołków
//Macierz wag


//Podawane prawdopodobienstwa istnienia krawedzi



//szukanie cykli o dlugosci 3


// TODO WYKMINIC TĄ MACIERZ C W SUMIE + POPRAWIC WAGI

using System.Linq;

internal class Cykle
{
    public List<int[]> cykl;
    public Cykle()
    {
        cykl = new List<int[]>();
    }
    public bool czyJest(int i, int j, int k)
    {
        foreach (int[] n in cykl)
        {
            if (n.Contains(i))
            {
                if (n.Contains(j))
                {
                    if (n.Contains(k))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    internal bool czyJest(int i, int j, int k, int l)
    {
        foreach (int[] n in cykl)
        {
            if (n.Contains(i))
            {
                if (n.Contains(j))
                {
                    if (n.Contains(k))
                    {
                        if (n.Contains(l))
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}
