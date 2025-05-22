using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private Example _example;

    private void Awake()
    {
        _example.Initialize(new MouseLeftInput(), new MouseRightInput());
    }
}