using UnityEngine;

public class DragNDropper : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    private const float GroundYCoordinate = 0.5f;
    private const float IncreaseScaleOnCatch = 1.2f;
    
    [SerializeField] private LayerMask _layerMask;

    private float _heightAdjustmentCoefficiency;
    private Transform _objectTransform;
    private Vector3 _savedObjectScale;

    private void Update()
    {
        TryCatchObject();
        DragNDropObject();
        TryReleaseObject();
    }

    private void TryCatchObject()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(cameraRay, out RaycastHit hitInfo, Mathf.Infinity, _layerMask))
            {
                _objectTransform = hitInfo.transform;
                _savedObjectScale = hitInfo.transform.localScale;
                hitInfo.transform.localScale = _savedObjectScale * IncreaseScaleOnCatch;
            }
        }
    }

    private void DragNDropObject()
    {
        if (Input.GetMouseButton(LeftMouseButton) && IsObjectCatched())
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

            _objectTransform.position = new Vector3(point.x, point.y - _heightAdjustmentCoefficiency, _objectTransform.position.z);

            if (_objectTransform.position.y <= GroundYCoordinate)
                _objectTransform.position = new Vector3(_objectTransform.position.x, GroundYCoordinate, _objectTransform.position.z);            
        }
    }

    private void TryReleaseObject()
    {
        if(Input.GetMouseButtonUp(LeftMouseButton) && IsObjectCatched())
        {
            _objectTransform.localScale = _savedObjectScale;
            _objectTransform = null;            
        }
    }

    private bool IsObjectCatched() => _objectTransform != null;
}
