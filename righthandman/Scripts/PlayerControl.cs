using Godot;
using System;

public partial class PlayerControl : Node {

	[Export] private Character player;

	private bool hasActed = false;
	private bool wasInRange = false;

	public override void _Process(double delta) {

		if (Input.IsActionJustPressed("ui_up")) {
			player.PlayEmote("up");

			if (!InputManager.Instance.IsInRange("up")) {
				player.SendFailure();
			}

			hasActed = true;
		}

		if (Input.IsActionJustPressed("ui_down")) {
			player.PlayEmote("down");

			if (!InputManager.Instance.IsInRange("down")) {
				player.SendFailure();
			}

			hasActed = true;
		}

		if (Input.IsActionJustPressed("ui_left")) {
			player.PlayEmote("left");

			if (!InputManager.Instance.IsInRange("left")) {
				player.SendFailure();
			}

			hasActed = true;
		}

		if (Input.IsActionJustPressed("ui_right")) {
			player.PlayEmote("right");

			if (!InputManager.Instance.IsInRange("right")) {
				player.SendFailure();
			}

			hasActed = true;
		}

		bool isInRange = InputManager.Instance.IsInRange();

		if (!isInRange && wasInRange) {
			if (!hasActed) {
				player.SendFailure();
			}

			hasActed = false;
		}

		wasInRange = isInRange;

	}
}
