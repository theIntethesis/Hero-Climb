using Godot;

public partial class MainMenu : MenuStack
{
    public const string NAME = "MainMenuStack";

    private partial class Leaf : MenuLeaf
    {
        public const string NAME = "MainMenu";

        override public bool Poppable { get { return false; }}

        public override void OnPop()
        {
            Parent().Push(new QuitConfirm());
        }

        public Leaf() : base()
        {
            Name = NAME;
            SetTreeScene("res://[TL6] Julia/scenes/Menus/MainMenu.tscn");
            
            TreeNode.GetNode<Button>("GridContainer/Start").Pressed += () => 
            {
                Parent().Push(new CharacterCreator());
            };
            TreeNode.GetNode<Button>("GridContainer/Settings").Pressed += () => 
            {
                Parent().Push(new SettingsMenu());
            };
            TreeNode.GetNode<Button>("GridContainer/Credits").Pressed += () => 
            {
                Parent().Push(new CreditsMenu());
            };
            TreeNode.GetNode<Button>("GridContainer/Quit").Pressed += () => 
            {
                Parent().Pop();
            };
        }
    }

    public MainMenu() : base()
    {
        Name = NAME;
        SetTreeScene("res://[TL6] Julia/scenes/Backgrounds/HomeBackground.tscn");
        Push(new Leaf());
    }
}