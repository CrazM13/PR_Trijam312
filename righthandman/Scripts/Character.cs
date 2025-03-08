using Godot;
using System;

public partial class Character : AnimatedSprite2D {

	[Export] private float emoteDuration = 10;

	private float emoteTime = 0;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

		emoteTime += (float) delta;

		if (emoteTime >= emoteDuration) {
			this.Play("idle");
		}

	}

	public void PlayEmote(string emote) {
		emoteTime = 0;
		this.Play(emote);
	}

}
