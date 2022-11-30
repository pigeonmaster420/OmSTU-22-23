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
        e.b = c.b * d.b;
        e.a = (c.a * d.b) + (d.a * c.b);
        return e;
    }
}