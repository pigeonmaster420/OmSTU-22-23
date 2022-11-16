namespace SpaceBattle.lib;

public class rational
{
    public int a;
    public int b;
    public rational()
    {
        a = 0;
        b = 1;
    }
    public rational(int c)
    {
        a = c;
        b = 1;
    }
    public rational(int c, int d)
    {
        if (d != 0)
        {
        a = c;
        b = d;
        }
        else
        {
            throw new Exception();
        }
    }
    public static rational operator +(rational c, rational d)
    {
        rational e = new rational();
        if (c.b == d.b)
        {
            e.a = c.a + d.a;
            e.b = c.b;
        }
        else
        {
            e.b = c.b * d.b;
            e.a = (c.a * d.b) + (d.a * c.b);
        }
        int m = e.a;
        int n = e.b;
        while(m != n)
            {
                if(m > n)
                {
                    m = m - n;
                }
                else
                {
                    n = n - m;
                }
            }
        int nod = n;
        e.a = e.a / nod;
        e.b = e.b / nod;
        return e;
    }
}