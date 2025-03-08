using Godot;
using System;
using System.Collections.Generic;

public partial class InputManager : Control {

	#region Singleton
	public static InputManager Instance { get; private set; }

	public override void _EnterTree() {
		base._EnterTree();
		Instance = this;
	}
	#endregion

	[Export] private PackedScene upInputIndicator;
	[Export] private PackedScene downInputIndicator;
	[Export] private PackedScene leftInputIndicator;
	[Export] private PackedScene rightInputIndicator;

	[Export] private float inputSpeed;

	private Control currentInputNode;
	private RandomNumberGenerator rng;

	public float minAcceptableRange = 0.7f;
	public float maxAcceptableRange = 0.9f;

	public string action = "";

	public float Progress { get; private set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {

		rng = new RandomNumberGenerator();

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

		if (currentInputNode != null) {
			Progress += (float) delta * inputSpeed;

			currentInputNode.GlobalPosition = new Vector2(Mathf.Lerp(this.GlobalPosition.X, 0, Progress), this.GlobalPosition.Y);
		}

	}

	public void SpawnInput() {

		if (currentInputNode != null) {
			currentInputNode.QueueFree();
		}

		Progress = 0;
		PackedScene selected;
		int selectedIndex = rng.RandiRange(0, 3);

		selected = selectedIndex switch {
			0 => upInputIndicator,
			1 => downInputIndicator,
			2 => leftInputIndicator,
			3 => rightInputIndicator,
			_ => null
		};

		action = selectedIndex switch {
			0 => "up",
			1 => "down",
			2 => "left",
			3 => "right",
			_ => ""
		};

		currentInputNode = selected.Instantiate<Control>();

		AddChild(currentInputNode);
		currentInputNode.GlobalPosition = this.GlobalPosition;
	}

	public bool IsInRange(string action) {

		if (this.action != action) return false;

		return IsInRange();
	}

	public bool IsInRange() {
		return minAcceptableRange < Progress && Progress < maxAcceptableRange;
	}

	public string GetCurrentAction() {
		return this.action;
	}

}
