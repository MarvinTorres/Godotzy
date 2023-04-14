using Godot;
using System;
using Godot.Collections;

public class Main : Node2D
{
    private ScoreController _score = null; 

    public override void _Ready()
    {
        GD.Randomize();
        _score = GetNode<ScoreController>("../Main/Score");
    }

    public void _on_Button_Roll() {
        Godot.Collections.Array Dice = GetTree().GetNodesInGroup("Dice");
        int Score = 0;
        int[] Values = new int[Dice.Count];
        int i = 0;

        foreach (DiceController Die in Dice) {
            Die.Roll();
            Score += Die.Value;
            Values[i++] = Die.Value;
        }

        _score.UpdateScore(FindPattern(Values), Score);
    }

    public String FindPattern(int[] Values) {
        String Result = "";

        Dictionary<int, int> Matches = new Dictionary<int, int>();

        foreach (int Value in Values) {
            if (!Matches.ContainsKey(Value)) {
                Matches[Value] = 1;
            } else {
                Matches[Value] += 1;
            }
        }

        int[] MatchLengthsArr = new int[Matches.Values.Count];
        int i = 0;

        foreach (int value in Matches.Values) {
            MatchLengthsArr[i++] = value;
        }

        System.Array.Sort(MatchLengthsArr);

        int highestMatchLength = MatchLengthsArr[MatchLengthsArr.Length-1];

        bool IsGodotzy = highestMatchLength == 5;
        bool IsFullHouse = highestMatchLength == 3 && MatchLengthsArr.Length == 2;
        bool IsFourOfAKind = highestMatchLength == 4;
        bool IsThreeOfAKind = highestMatchLength == 3;
        bool IsTwoOfAKind = highestMatchLength == 2;


        if (IsGodotzy) Result = "GODOTZY!";
        else if (IsFullHouse) Result = "Full House";
        else if (IsFourOfAKind) Result = "Four of a Kind";
        else if (IsThreeOfAKind) Result = "Three of a Kind";
        else if (IsTwoOfAKind) Result = "Two of a Kind";

        int[] Keys = new int[Matches.Keys.Count];
        int j = 0;

        foreach (int Key in Matches.Keys) {
            Keys[j++] = Key;
        }

        System.Array.Sort(Keys);

        bool IsSmallStraight = Keys.Length == 5 && Keys[0] == 1 && Keys[1] == 2 && Keys[2] == 3 && Keys[3] == 4 && Keys[4] == 5;
        bool IsLargeStraight = Keys.Length == 5 && Keys[0] == 2 && Keys[1] == 3 && Keys[2] == 4 && Keys[3] == 5 && Keys[4] == 6;

        if (IsSmallStraight) Result = "Small Straight";
        else if (IsLargeStraight) Result = "Large Straight";

        return Result;
    }
}
