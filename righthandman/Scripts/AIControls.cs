using Godot;
using System;

public partial class AIControls : Node {

	[Export] private Character character;
	private bool canAct = true;

	private RandomNumberGenerator rng;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {

		rng = new RandomNumberGenerator();

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

		if (InputManager.Instance.IsInRange()) {
			if (canAct) {

				if (rng.RandiRange(0, 10) == 0) {

					string newAction = InputManager.Instance.GetCurrentAction() switch {
						"up" => "down",
						"down" => "left",
						"left" => "right",
						"right" => "up",
						_ => InputManager.Instance.GetCurrentAction()
					};

					character.PlayEmote(newAction);
					character.SendFailure();
				} else {
					character.PlayEmote(InputManager.Instance.GetCurrentAction());
				}

				canAct = false;
			}
		} else {
			canAct = true;
		}

	}
}
