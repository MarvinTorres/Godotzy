using Godot;
using System;

public class ScoreController : Label
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Text = "Click the roll button to play!";
    }

    public void UpdateScore(String pattern, int score) {
        String PatternText = "";
        String ScoreText = "Score:" + score;

        if (!pattern.Empty()) {
            PatternText = pattern + " - ";
        }
        Text = PatternText + ScoreText;
    }
}
