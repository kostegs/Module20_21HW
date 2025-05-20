using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private UserInputVariants _userInputVariant;    
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private List<Transform> _transforms;

    private KeyCode _rotateLeft;
    private KeyCode _rotateRight;
        
    private void Awake() => DetectInputButtons();

    private void Update()
    {
        int horizontalInput = DetectInput();

        DoRotation(horizontalInput);
    }

    private int DetectInput()
    {
        if (Input.GetKey(_rotateLeft))
            return -1;
        else if (Input.GetKey(_rotateRight))
            return 1;

        return 0;
    }

    private void DetectInputButtons()
    {
        switch (_userInputVariant)
        {
            case UserInputVariants.WS:
                _rotateLeft = KeyCode.W;
                _rotateRight = KeyCode.S;
                break;
            case UserInputVariants.AD:
                _rotateLeft = KeyCode.A;
                _rotateRight = KeyCode.D;
                break;
            default:
                Debug.LogError("Неизвестное сочетание клавиш для поворота");
                break;
        }
    }

    private void DoRotation(int horizontalInput)
    {
        if (horizontalInput == 0)
            return;

        float rotation = horizontalInput * _rotationSpeed * Time.deltaTime;

        foreach (Transform objectTransform in _transforms)
        {
            Vector3 currentEuler = objectTransform.localEulerAngles;

            float _currentYAngle = currentEuler.y > 180 ? currentEuler.y - 360 : currentEuler.y;

            float newY = Mathf.Clamp(_currentYAngle + rotation, -_maxAngle, _maxAngle);

            objectTransform.localEulerAngles = new Vector3(currentEuler.x, newY, currentEuler.z);
        }
    }
}
