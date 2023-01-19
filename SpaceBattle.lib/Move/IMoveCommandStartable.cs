using System.Numerics;
namespace SpaceBattle.lib;

    public interface IMoveCommandStartable {
        IUObject uObject { 
            get; 
        }
        Vector2 velocity { 
            get; 
        }
        Queue<ICommand> queue { 
            get;
        }
    }