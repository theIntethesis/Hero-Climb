using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class Pickup : Area2D
{
	[Export]
	public int value = 0;
	
	public override void _Ready(){
		
	}
	
	public virtual void PlayerDetected(){
		
	}
}
