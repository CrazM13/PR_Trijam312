using Godot;
using System;

public partial class GroupNode : Node2D {


	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		SortChildren();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	}

	public void SortChildren() {
		for (int i = 0; i < 5; i++) {
			Node2D character = this.GetChild<Node2D>(i);

			character.Position = (i - 2) * new Vector2(-200, 0);
		}
	}

	public void Derank(Node node) {
		this.RemoveChild(node);
		this.AddChild(node);

		SortChildren();
	}

}
