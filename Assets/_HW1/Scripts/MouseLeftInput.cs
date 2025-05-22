using UnityEngine;

public class MouseLeftInput : IUserInputProcessor
{
    private const int LeftMouseButton = 0;

    public Vector3 GetCurrentCursorPosition() => Input.mousePosition;
    
    public bool IsButtonDown() => Input.GetMouseButtonDown(LeftMouseButton);
    
    public bool IsButtonHold() => Input.GetMouseButton(LeftMouseButton);

    public bool IsButtonUp() => Input.GetMouseButtonUp(LeftMouseButton);    
}
