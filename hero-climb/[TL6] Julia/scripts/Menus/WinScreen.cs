using Godot;

public partial class WinScreen : MenuLeaf
{
    public const string NAME = "WinScreen";

    override public bool Poppable { get { return false; }}

    public WinScreen() : base()
    {
        Name = NAME;
        SetTreeScene("res://[TL6] Julia/scenes/Menus/WinScreen.tscn");
        TreeNode.GetNode<Button>("GridContainer/Restart").Pressed += () => 
        {
            Parent().Push(new CharacterCreator());
        };
        TreeNode.GetNode<Button>("GridContainer/Quit").Pressed += () => 
        {
            GameHandler.Instance().StopGame();
            GameHandler.Instance().LoadMainMenu();
        };
    }
}

