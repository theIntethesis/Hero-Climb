using Godot;
using System;

public partial class DeathBackground : Control
{
	public ShaderMaterial material;
	public Color FinalTint;
	public float FinalLOD;

	public int FinalCount = 10;
	public int count = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		material = (ShaderMaterial)GetNode<ColorRect>("ColorRect").Material;
		FinalTint = new Color((Color)material.GetShaderParameter("tint"));
		FinalLOD = (float)material.GetShaderParameter("lod");

		material.SetShaderParameter("lod", 0.0f);
		material.SetShaderParameter("tint", new Color(0, 0, 0, 0));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (count < FinalCount)
		{
			count++;
			material.SetShaderParameter("tint", new Color(FinalTint, 0.4f * (float)count/FinalCount));
			material.SetShaderParameter("lod", FinalLOD * (float)count/FinalCount);
		}
	}
}
