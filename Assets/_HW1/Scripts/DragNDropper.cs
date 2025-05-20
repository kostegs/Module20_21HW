using UnityEditor.PackageManager;
using UnityEngine;

public class DragNDropper : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    
    [SerializeField] private LayerMask _layerMask;

    private float _coefficiency;
    private Transform _objectTransform;
    private Vector3 _objectScale;

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(cameraRay, out RaycastHit hitInfo, Mathf.Infinity, _layerMask))
            {
                _objectTransform = hitInfo.transform;
                _objectScale = hitInfo.transform.localScale;
                hitInfo.transform.localScale = _objectScale * 1.2f;
            }
                
        }

        if (Input.GetMouseButton(LeftMouseButton))
        {        
            if(_objectTransform != null)
            {
                Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

                if (_coefficiency == 0)
                    _coefficiency = point.y - _objectTransform.position.y;

                _objectTransform.position = new Vector3(point.x, point.y - _coefficiency, _objectTransform.position.z);

                if (_objectTransform.position.y <= 0.5f)
                {
                    _objectTransform.position = new Vector3(_objectTransform.position.x, 0.5f, _objectTransform.position.z); 
                }

                    
            }            
        }

        if (Input.GetMouseButtonUp(LeftMouseButton))
        {
            _coefficiency = 0;
            
            if(_objectTransform != null)
            {
                _objectTransform.localScale = _objectScale;
                _objectTransform = null;
            }            
        }
    }
}
