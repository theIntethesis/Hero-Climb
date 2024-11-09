using Godot;

public partial class DeathScreen : MenuStack
{
    public const string NAME = "DeathScreenStack";

    private partial class Leaf : MenuLeaf
    {
        public const string NAME = "DeathScreen";

        override public bool Poppable() { return false; }

        public Leaf() : base()
        {
            Name = NAME;
            SetTreeScene("res://[TL6] Julia/scenes/Menus/DeathScreen.tscn");

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

        public override void OnPush(IMenuComposite parent)
        {
            base.OnPush(parent);

            TreeNode.GetNode<Label>("Label").Text = $"Score: {PlayerGlobal.Score}";
        }
    }

    public DeathScreen() : base()
    {
        Name = NAME;
        SetTreeScene("res://[TL6] Julia/scenes/Backgrounds/DeathBackground.tscn");
        Push(new Leaf());
    }
}

