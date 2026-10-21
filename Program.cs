using LeetCodeStudy.Timus;
using LeetCodeStudy.Timus.AdventureMode;

public static class Program
{
    public static void Main(string[] args)
    {
        var ti = new DataStruct();

        var result = ti.TimeRequiredToBuy([5, 1, 1, 1], 0);
        Console.WriteLine(result);
    }
}
