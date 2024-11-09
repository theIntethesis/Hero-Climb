using Godot;

public partial class QuitConfirm : MenuLeaf
{
    public const string NAME = "QuitConfirm";

    public override void _Ready()
    {
        Name = NAME;
        GetNode<Button>("GridContainer/Back").Pressed += OnBack;
        GetNode<Button>("GridContainer/Quit").Pressed += () => 
        {
            GetTree().Quit();
        };
        
        base._Ready();
    }

    public void OnBack()
    {
        GD.Print(Parent());
        Parent().Pop();
    }
}
