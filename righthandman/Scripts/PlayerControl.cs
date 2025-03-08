using Godot;
using System;

public partial class PlayerControl : Node {

	[Export] private Character player;
	[Export] private SceneManager sceneManager;

	private bool hasActed = false;
	private bool wasInRange = false;

	private int remainingLives = 3;

	public override void _Process(double delta) {

		if (Input.IsActionJustPressed("ui_up")) {
			player.PlayEmote("up");

			if (!InputManager.Instance.IsInRange("up")) {
				player.SendFailure();
				remainingLives--;
			}

			hasActed = true;
		}

		if (Input.IsActionJustPressed("ui_down")) {
			player.PlayEmote("down");

			if (!InputManager.Instance.IsInRange("down")) {
				player.SendFailure();
				remainingLives--;
			}

			hasActed = true;
		}

		if (Input.IsActionJustPressed("ui_left")) {
			player.PlayEmote("left");

			if (!InputManager.Instance.IsInRange("left")) {
				player.SendFailure();
				remainingLives--;
			}

			hasActed = true;
		}

		if (Input.IsActionJustPressed("ui_right")) {
			player.PlayEmote("right");

			if (!InputManager.Instance.IsInRange("right")) {
				player.SendFailure();
				remainingLives--;
			}

			hasActed = true;

			if (remainingLives <= 0) {
				sceneManager.LoadScene("res://Scenes/LoseScene.tscn");
			}
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
