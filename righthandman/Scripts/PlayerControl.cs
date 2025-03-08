using Godot;
using System;

public partial class PlayerControl : Node {

	[Export] private Character player;

	public override void _Process(double delta) {

		if (Input.IsActionJustPressed("ui_up")) {
			player.PlayEmote("up");

			if (!InputManager.Instance.IsInRange("up")) {
				player.SendFailure();
			}
		}

		if (Input.IsActionJustPressed("ui_down")) {
			player.PlayEmote("down");

			if (!InputManager.Instance.IsInRange("down")) {
				player.SendFailure();
			}
		}

		if (Input.IsActionJustPressed("ui_left")) {
			player.PlayEmote("left");

			if (!InputManager.Instance.IsInRange("left")) {
				player.SendFailure();
			}
		}

		if (Input.IsActionJustPressed("ui_right")) {
			player.PlayEmote("right");

			if (!InputManager.Instance.IsInRange("right")) {
				player.SendFailure();
			}
		}

	}
}
