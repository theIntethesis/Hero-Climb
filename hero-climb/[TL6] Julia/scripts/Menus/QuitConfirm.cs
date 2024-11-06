using Godot;

public partial class QuitConfirm : MenuLeaf
{
    public const string NAME = "QuitConfirm";

    public QuitConfirm() : base()
    {
        Name = NAME;
        SetTreeScene("res://[TL6] Julia/scenes/Menus/QuitConfirm.tscn");
        TreeNode.GetNode<Button>("GridContainer/Back").Pressed += () => 
        {
            Parent().Pop();
        };
        TreeNode.GetNode<Button>("GridContainer/Quit").Pressed += () => 
        {
            GetTree().Quit();
        };
    }
}