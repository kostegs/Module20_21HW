using UnityEngine;

public interface IInputProcessor
{
    bool IsButtonDown();

    bool IsButtonHold();

    bool IsButtonUp();

    Vector3 GetCurrentCursorPosition();
}
