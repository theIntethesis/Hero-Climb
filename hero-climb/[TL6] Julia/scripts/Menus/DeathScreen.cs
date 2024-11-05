using Godot;

public partial class DeathScreen : MenuStack
{
    public const string NAME = "DeathScreenStack";

    private partial class Leaf : MenuLeaf
    {
        public const string NAME = "DeathScreen";

        override public bool Poppable { get { return false; }}

        public Leaf() : base()
        {
            Name = NAME;
            SetForeground("res://[TL6] Julia/scenes/Menus/DeathScreen.tscn");

            ForegroundNode.GetNode<Button>("GridContainer/Restart").Pressed += () => 
            {
                Parent().Push(new CharacterCreator());
            };

            ForegroundNode.GetNode<Button>("GridContainer/Quit").Pressed += () => 
            {
                GameHandler.Instance().StopGame();
                GameHandler.Instance().LoadMainMenu();
            };
        }
    }

    public DeathScreen() : base()
    {
        Name = NAME;
        SetBackground("res://[TL6] Julia/scenes/Backgrounds/DeathBackground.tscn");
        Push(new Leaf());
    }
}

