using Godot;

[GlobalClass]
public partial class GlobalMenuHandler : Node
{
    public Node CurrentScene;
    private string MainMenu = "res://[TL6] Julia/scenes/MainMenu.tscn";
    private string InitialGameScene = "res://[TL6] Julia/scenes/TestScene.tscn";

    public void ReturnToMainMenu()
    {
		Node NewScene = ResourceLoader.Load<PackedScene>(MainMenu).Instantiate();
		GetTree().Root.AddChild(NewScene);

        if (CurrentScene != null)
        {
            CurrentScene.QueueFree();
            GetTree().Root.RemoveChild(CurrentScene);
            CurrentScene = null;
        }
    }

    public void EnterGame()
    {
        if (CurrentScene != null)
        {
            CurrentScene.QueueFree();
            GetTree().Root.RemoveChild(CurrentScene);
            CurrentScene = null;
        }

        // should actually get InitialGameScene from some sort of level handler
        Node NewScene = ResourceLoader.Load<PackedScene>(InitialGameScene).Instantiate();
		GetTree().Root.AddChild(NewScene);
		CurrentScene = NewScene;

    }
}
