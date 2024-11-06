using Godot;

public partial class PauseMenu : MenuStack
{
    public const string NAME = "PauseMenuStack";

    private partial class Leaf : MenuLeaf
    {
        public const string NAME = "PauseMenu";

        public Leaf() : base()
        {
            Name = NAME;
            SetTreeScene("res://[TL6] Julia/scenes/Menus/PauseMenu.tscn");

            TreeNode.GetNode<Button>("GridContainer/Resume").Pressed += () => 
            {
                Parent().Pop();
            };
            TreeNode.GetNode<Button>("GridContainer/Restart").Pressed += () => 
            {
                Parent().Push(new CharacterCreator());
            };
            TreeNode.GetNode<Button>("GridContainer/Settings").Pressed += () => 
            {
                Parent().Push(new SettingsMenu());
            };            
            TreeNode.GetNode<Button>("GridContainer/Quit").Pressed += () => 
            {
                // Parent.Pop();
                GameHandler.Instance().StopGame();
                GameHandler.Instance().LoadMainMenu();
            };
        }
    }



    public PauseMenu() : base()
    {
        Name = NAME;
        SetTreeScene("res://[TL6] Julia/scenes/Backgrounds/PauseBackground.tscn");
        Leaf leaf = new Leaf();
        Push(leaf);
    }
}
