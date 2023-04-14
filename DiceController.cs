using Godot;
using System;

public class DiceController : Node2D
{
    private AnimatedSprite _sprite = null; 

    private const String CURRENT_ANIM = "";

    private int _value = 1;

    public int Value {
        get {
            return this._value;
        }
        set {
            int NewValue = value;
            if (NewValue < 1) NewValue = 1;
            if (NewValue > 6) NewValue = 6;
            _SetAnimAndFrame(CURRENT_ANIM, NewValue - 1);
            _value = NewValue;
        }
    }

    public bool Locked = false; 

    public override void _Ready() {
        _sprite = (AnimatedSprite) FindNode("DiceSprite");
        Value = 1;
        Unlock();
    }

    private void _SetAnimAndFrame(String anim, int NewFrame) {
        _sprite.Play(anim);
        _sprite.Frame = NewFrame;
    }

    public void Lock() {
        Locked = true;
        _SetAnimAndFrame("Locked", _value - 1);
    }

    public void Unlock() {
        Locked = false;
        _SetAnimAndFrame("Unlocked", _value - 1);
    }

    public void ToggleLock() {
        if (Locked) Unlock();
        else Lock();
    }

    public void Roll() {
        Value = Locked ? Value : ((int)GD.Randi() % 6) + 1;
    }
}
