using Godot;

public class DiceArea2D : Area2D
{
    public override void _InputEvent(Godot.Object viewport, InputEvent @event, int shapeIdx)
    {
        if (@event is InputEventMouseButton eventButton) {
            if (eventButton.ButtonIndex == 1 && eventButton.IsPressed()) {
                DiceController owner = GetOwner<DiceController>();
                if (owner != null) owner.ToggleLock();
            }
        }
    }
}
