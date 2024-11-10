using Godot;
using System;

// add signal for death screen
public partial class PlayerCamera : Camera2D
{ 
	private CanvasLayer Interface;

	private PlayerCameraStack Stack;

	int ShakeFrame = 0;
	bool Shaking = false;


	[ExportGroup("Camera Shake")]
	
	[Export]
	float Amplitude = 1.0f;
	
	[Export]
	float PeriodMultiplier = 40.0f;

	[Export]
	float Duration = 1.0f;


	float CurrentDuration;


	Vector2 DefaultOffset;

	public PlayerCamera()
	{
		DefaultOffset = Offset;
	}

	public override void _Ready()
	{
		Interface = GetNode<CanvasLayer>("Interface");

		// Use the Character Global class instead!
		Stack = HUDFactory.PlayerCameraStack(this);
		Interface.AddChild(Stack);


        PlayerGlobal.ConnectPlayerSignal(Controller.SignalName.PlayerHealthChange, Callable.From<int>(Stack.OnPlayerHealthChange));
        PlayerGlobal.ConnectPlayerSignal(Controller.SignalName.PlayerHealthChange, Callable.From<int>(Stack.HUD.OnPlayerHealthChange));
		PlayerGlobal.ConnectPlayerSignal(Controller.SignalName.PlayerDeath, Callable.From(Stack.OnPlayerDeath));
        PlayerGlobal.ConnectPlayerSignal(Controller.SignalName.KaChing, Callable.From(Stack.HUD.OnKaChing));
        PlayerGlobal.ConnectPlayerSignal(Controller.SignalName.ShutUpAndTakeMyMoney, Callable.From(Stack.HUD.OpenShop));
        PlayerGlobal.ConnectPlayerSignal(Controller.SignalName.PlayerMaxHealthChange, Callable.From<int>(Stack.HUD.OnPlayerMaxHealthChange));

		PlayerGlobal.Money = 1000;
		Stack.HUD.OpenShop();
	}

	public override void _Process(double delta)
	{
		if (Shaking)
		{
			ShakeFrame += 1;
			CurrentDuration += (float)delta;

			float theta = ShakeFrame * MathF.PI / 180.0f;

			// GD.Print(theta);

			Vector2 vec = new Vector2(0, MathF.Sin(theta * PeriodMultiplier) * Amplitude / CurrentDuration);
		   
			// GD.Print(vec);
			Offset = vec;

			
			if (CurrentDuration >= Duration && (Offset.Y < 0.2 || Offset.Y > -0.2))
			{
				Shaking = false;
			}
		}
		else
		{
			Offset = new Vector2(0.0f, 0.0f);
		}
	}

	public void ShakeCamera()
	{
		if (!Shaking)
		{
			Shaking = true;
			CurrentDuration = 0.0f;
		}

		Input.VibrateHandheld(500);
	}
}   
