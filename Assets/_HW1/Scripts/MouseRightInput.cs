using UnityEngine;

public class MouseRightInput : IUserInputProcessor
{
    private const int RightMouseButton = 1;

    public Vector3 GetCurrentCursorPosition() => Input.mousePosition;

    public bool IsButtonDown() => Input.GetMouseButtonDown(RightMouseButton);

    public bool IsButtonHold() => Input.GetMouseButton(RightMouseButton);

    public bool IsButtonUp() => Input.GetMouseButtonUp(RightMouseButton);
}
