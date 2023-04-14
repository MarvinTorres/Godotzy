using Godot;

public class RollButtonController : Button
{
    [Signal]
    public delegate void Roll();

    public void _on_Button_pressed() {
        EmitSignal("Roll");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
