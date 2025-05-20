using UnityEngine;

public class Shaker : MonoBehaviour
{
    [SerializeField] private float _amplitude;
    [SerializeField] private float _frequency;    
    [SerializeField] private float _angle;

    private float _time;
    
    //private void Update()
    //{
    //    _time += Time.deltaTime;
    //    _time *= _direction;

    //    float rotation = (_amplitude * Mathf.Sin(_time * _frequency));       

    //    rotation = Mathf.Clamp(rotation, -_angle, _angle);

    //    Vector3 currentEuler = transform.localEulerAngles;

    //    float currentY = currentEuler.y > 180 ? currentEuler.y - 360 : currentEuler.y;
    //    float currentZ = currentEuler.z > 180 ? currentEuler.z - 360 : currentEuler.z;

    //    transform.localEulerAngles = new Vector3(rotation, currentY, currentZ);
    //}

    private void FixedUpdate()
    {        
        _time += Time.fixedDeltaTime;        

        float rotation = (_amplitude * Mathf.Sin(_time * _frequency));

        rotation = Mathf.Clamp(rotation, -_angle, _angle);

        Vector3 currentEuler = transform.localEulerAngles;

        float currentY = currentEuler.y > 180 ? currentEuler.y - 360 : currentEuler.y;
        float currentZ = currentEuler.z > 180 ? currentEuler.z - 360 : currentEuler.z;

        transform.localEulerAngles = new Vector3(rotation, currentY, currentZ);    
    }
}
