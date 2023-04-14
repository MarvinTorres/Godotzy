using Godot;
using System;

public class Dice : AnimatedSprite
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
 	private AnimatedSprite _animatedSprite;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite>("../DiceSprite");
		_animatedSprite.Play("Unlocked");
		GD.Print("hi");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	  
  }
}
