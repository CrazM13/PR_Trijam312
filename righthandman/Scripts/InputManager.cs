using Godot;
using System;
using System.Collections.Generic;

public partial class InputManager : Control {

	#region Singleton
	public InputManager Instance { get; private set; }

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

	public float Progress { get; private set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {

		rng = new RandomNumberGenerator();

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {

		if (currentInputNode != null) {
			Progress += (float) delta * inputSpeed;

			currentInputNode.GlobalPosition = new Vector2(Mathf.Lerp(this.GlobalPosition.X, -this.GlobalPosition.X, Progress), this.GlobalPosition.Y);
		}

	}

	public void SpawnInput() {

		if (currentInputNode != null) {
			currentInputNode.QueueFree();
		}

		Progress = 0;
		PackedScene selected;

		selected = rng.RandiRange(0, 3) switch {
			0 => upInputIndicator,
			1 => downInputIndicator,
			2 => leftInputIndicator,
			3 => rightInputIndicator,
			_ => null
		};

		currentInputNode = selected.Instantiate<Control>();

		AddChild(currentInputNode);
		currentInputNode.GlobalPosition = this.GlobalPosition;
	}



}
