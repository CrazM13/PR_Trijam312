using Godot;
using System;

public partial class PlayerControl : Node {

	[Export] private Character player;

	public override void _Ready() {
	}

	public override void _Process(double delta) {

		if (Input.IsActionJustPressed("ui_up")) {
			player.PlayEmote("up");
		}

		if (Input.IsActionJustPressed("ui_down")) {
			player.PlayEmote("down");
		}

		if (Input.IsActionJustPressed("ui_left")) {
			player.PlayEmote("left");
		}

		if (Input.IsActionJustPressed("ui_right")) {
			player.PlayEmote("right");
		}

	}
}
