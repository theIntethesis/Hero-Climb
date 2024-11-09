using Godot;

public partial class DeathScreen : MenuLeaf
{
    public DeathScreen() : base()
    {

    }

    public override void _Ready()
    {

        GetNode<Button>("GridContainer/Restart").Pressed += () => 
        {
            Parent().Push(new CharacterCreator());
        };

        GetNode<Button>("GridContainer/Quit").Pressed += () => 
        {
            GameHandler.Instance().StopGame();
            GameHandler.Instance().LoadMainMenu();
        };
    }

    public override void OnPush(MenuComposite parent)
    {
        base.OnPush(parent);

        GetNode<Label>("Label").Text = $"Score: {PlayerGlobal.Score}";
    }
}
