using System.Linq;
public class Cycles
{
    public List<int[]> cykl;
    public Cycles()
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
