using UnityEngine;

public class ConcreteCommands 
{

}

public class MoveLeftCommands: ICommand
{
    public Transform player;
    private float distance;

    public MoveLeftCommands(Transform player, float distance)
    {
        this.player = player;
        this.distance = distance;
    }

    public void Excecute()
    {
        player.Translate(Vector2.left*distance);
    }

    public void Undo()
    {
        player.Translate(Vector2.right*distance);
    }
}

public class MoveRightCommand: ICommand
{
    public Transform player;
    private float distance;


    public MoveRightCommand(Transform player, float distance)
    {
        this.distance = distance;
        this.player = player;
    }

    public void Excecute()
    {
        player.Translate(Vector2.right * distance); 
    }

    public void Undo()
    {
        player.Translate(Vector2.left * distance);
    }
}
