using Godot;

public partial class QuitConfirm : MenuLeaf
{
    public const string NAME = "QuitConfirm";

    public QuitConfirm() : base()
    {
        Name = NAME;
        SetForeground("res://[TL6] Julia/scenes/Menus/QuitConfirm.tscn");
        ForegroundNode.GetNode<Button>("GridContainer/Back").Pressed += () => 
        {
            Parent().Pop();
        };
        ForegroundNode.GetNode<Button>("GridContainer/Quit").Pressed += () => 
        {
            GetTree().Quit();
        };
    }
}
