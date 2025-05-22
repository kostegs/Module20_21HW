using UnityEngine;

public class DragService
{
    private const float GroundYCoordinate = 0.5f;    
    private const float CameraReverseDistanceCoefficiency = -1;
    
    private float _heightAdjustmentCoefficiency;
    private IGrabble _catchedObject;
    private IInputProcessor _input;

    public DragService(IInputProcessor input)
    {
        _input = input;
    }

    public void TryCatchObject()
    {
        Vector3 currentCursorPosition = GetCurrentCursorPosition();
        Ray cameraRay = Camera.main.ScreenPointToRay(currentCursorPosition);
            
        if (Physics.Raycast(cameraRay, out RaycastHit hitInfo)) 
        {
            if (hitInfo.transform.TryGetComponent<IGrabble>(out IGrabble movable))
            {
                _catchedObject = movable;
                _catchedObject.OnGrab();
            }                
        }        
    }

    public void DragNDropObject()
    {
        if (IsObjectCatched() == false)
            return;

        Vector3 currentCursorPosition = GetCurrentCursorPosition();
        currentCursorPosition = new Vector3(currentCursorPosition.x, currentCursorPosition.y, Camera.main.transform.position.z * CameraReverseDistanceCoefficiency);
        
        Vector3 pointOnScene = Camera.main.ScreenToWorldPoint(currentCursorPosition);

        Vector3 currentObjectPosition = _catchedObject.GetPosition();
        Vector3 newPosition = new Vector3(pointOnScene.x, pointOnScene.y - _heightAdjustmentCoefficiency, currentObjectPosition.z);

        if (newPosition.y <= GroundYCoordinate)
            newPosition = new Vector3(currentObjectPosition.x, GroundYCoordinate, currentObjectPosition.z);

        _catchedObject.SetPosition(newPosition);        
    }

    public void TryReleaseObject()
    {
        if (IsObjectCatched() == false)
            return;
        
        _catchedObject.OnRelease();
        _catchedObject = null;                    
    }

    private Vector3 GetCurrentCursorPosition() => _input.GetCurrentCursorPosition();

    private bool IsObjectCatched() => _catchedObject != null;
}
