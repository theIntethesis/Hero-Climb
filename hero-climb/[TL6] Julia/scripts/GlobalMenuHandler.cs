using Godot;

[GlobalClass]
public partial class GlobalMenuHandler : Node
{
    public Node CurrentScene;

    // the scene thats loaded upon calling GlobalMenuHandler.ReturnToMainMenu()
    private string MainMenu = "res://[TL6] Julia/scenes/MainMenu.tscn";
    
    // the scene thats loaded upon calling GlobalMenuHandler.EnterGame()
    public string InitialGameScene = "res://[TL2] Taran/scenes/Main Level.tscn";

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

    public void EnterGame(Controller.ClassType cType)
    {
        if (CurrentScene != null)
        {
            CurrentScene.QueueFree();
            GetTree().Root.RemoveChild(CurrentScene);
            CurrentScene = null;
        }

        // should actually get InitialGameScene from some sort of level handler
        Node NewScene = ResourceLoader.Load<PackedScene>(InitialGameScene).Instantiate();
        Global.SetCharacterType(cType, NewScene.GetNode("Player") as Controller);
		GetTree().Root.AddChild(NewScene);
		CurrentScene = NewScene;
    }
}
