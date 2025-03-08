using Godot;
using System;

public partial class Character : AnimatedSprite2D {

	[Signal] public delegate void FailInputEventHandler(Node node);

	[Export] private float emoteDuration = 10;

	[ExportGroup("Prefabs")]
	[Export] private PackedScene upEmote;
	[Export] private PackedScene downEmote;
	[Export] private PackedScene leftEmote;
	[Export] private PackedScene rightEmote;

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

		PackedScene selected = (emote) switch {
			"up" => upEmote,
			"down" => downEmote,
			"left" => leftEmote,
			"right" => rightEmote,
			_ => null
		};

		if (selected != null) {
			Node2D node = selected.Instantiate<Node2D>();

			AddChild(node);
			node.GlobalPosition = this.GlobalPosition;
		}
	}

	public void SendFailure() {
		EmitSignal(SignalName.FailInput, this);
	}

}
