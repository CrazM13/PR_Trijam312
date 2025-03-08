using Godot;
using System;

public partial class Emote : Node2D {

	private float timeRemaining = 10f;



	public override void _Ready() {
	}

	public override void _Process(double delta) {

		timeRemaining -= (float) delta;

		if (timeRemaining <= 0) {
			QueueFree();
		} else {
			this.GlobalPosition += Vector2.Up * (float) delta * 400f;
		}

	}
}
