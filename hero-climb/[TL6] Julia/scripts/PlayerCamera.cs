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
	float Amplitude = 10f;
	
	[Export]
	float PeriodMultiplier = 50.0f;

	[Export] 
	float ShakyTime = 1;


	Vector2 DefaultOffset;

	public PlayerCamera()
	{
		DefaultOffset = Offset;

		if (ShakyTime < 0f || Amplitude <= 0f)
		{
			throw new Exception("PlayerCamera is incorrectly configured");
		}
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

		// PlayerGlobal.Money = 1000;
		// Stack.HUD.OpenShop();
	}

	public override void _Process(double delta)
	{
		if (Shaking)
		{
			ShakeFrame += 1;
			float Theta = ShakeFrame * MathF.PI / 180.0f;

			// Trust me. I swear
			// https://www.desmos.com/calculator/now6fy6fvr - Because there isn't a better way to document how this works. It just... Does
			float CurrentAmplitude = (Amplitude + 1) / Mathf.Pow(Amplitude + 1, Theta / ShakyTime) - 1;

			Vector2 vec = new Vector2(0, CurrentAmplitude * MathF.Sin(Theta * PeriodMultiplier));

			Offset = vec;

			
			if (Theta >= ShakyTime)
			{
				Shaking = false;
			}
		}
		else
		{
			Offset = new Vector2(0.0f, 0.0f);
		}

		
		if (Input.IsActionJustPressed("interact"))
		{
			ShakeCamera();
		}
		
	}

	public void ShakeCamera()
	{
		if (!Shaking)
		{
			Shaking = true;
			ShakeFrame = 0;
		}

		Input.VibrateHandheld(500);
	}
}   
