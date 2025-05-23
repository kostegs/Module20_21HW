using UnityEngine;

public class MouseInput : IInputProcessor
{
    protected int MouseKeyButton;

    public Vector3 GetCurrentCursorPosition() => Input.mousePosition;

    public bool IsButtonDown() => Input.GetMouseButtonDown(MouseKeyButton);

    public bool IsButtonHold() => Input.GetMouseButton(MouseKeyButton);

    public bool IsButtonUp() => Input.GetMouseButtonUp(MouseKeyButton);
}
