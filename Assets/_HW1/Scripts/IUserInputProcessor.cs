using UnityEngine;

public interface IUserInputProcessor
{
    bool IsButtonDown();

    bool IsButtonHold();

    bool IsButtonUp();

    Vector3 GetCurrentCursorPosition();
}
