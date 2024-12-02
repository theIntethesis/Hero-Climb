using Godot;

public partial class QuitConfirm : MenuLeaf
{

    public override void _Ready()
    {
        GetNode<Button>("GridContainer/Back").Pressed += OnBack;
        GetNode<Button>("GridContainer/Quit").Pressed += () => 
        {
            GetTree().Quit();
            GameHandler.Instance().ClickSound();
        };
        
        base._Ready();
    }

    public void OnBack()
    {
        GD.Print(Parent());
        GameHandler.Instance().ClickSound();
        Parent().Pop();
    }
}
