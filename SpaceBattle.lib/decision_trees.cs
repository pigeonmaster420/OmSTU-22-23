namespace SpaceBattle.lib;
using Hwdtech;
public class decision_trees : ICommand
{

    public string file;
    public decision_trees(string a)
    {
       file = a;
    }
    public void Execute()
    {
        var tree = IoC.Resolve<Dictionary<int, object>>("Game.Tree.Build");
        IEnumerable<string> data;
        try
        {
            data = File.ReadLines (file);
        }
        catch (FileNotFoundException ex)
        {   
            throw new FileNotFoundException (ex.ToString());
        }
        var list = data.Select(i => i.Split("; ").Select(int.Parse) .ToList()) .ToList();
        foreach (var i in list)
        {
            var temp = tree;
            foreach (var j in i)
            {
                temp.TryAdd(j, new Dictionary<int, object>());
                temp = (Dictionary<int, object>) temp[j];
            }
        }
    }
}