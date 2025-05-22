using UnityEngine;

public interface IGrabble
{
    void OnGrab();

    void OnRelease();

    Vector3 GetPosition();

    void SetPosition(Vector3 position);
}
