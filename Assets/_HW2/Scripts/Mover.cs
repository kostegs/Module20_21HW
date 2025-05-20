using UnityEngine;

public class Mover : MonoBehaviour
{
    private Vector3 _rayHeight = new Vector3(0, 10, 0);
    private int _rayLengthCoefficiency = 100;

    [SerializeField] private Wind _wind;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _windCoefficiency;
    [SerializeField] private Transform _sail;
    [SerializeField] private float _maxSpeed;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position + _rayHeight, _wind.transform.forward * _rayLengthCoefficiency);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + _rayHeight, transform.forward * _rayLengthCoefficiency);
    }    

    private void FixedUpdate()
    {
        float windPower = Vector3.Dot(_sail.forward, _wind.transform.forward);
        windPower = Mathf.Clamp(windPower, 0, windPower);

        if(_rigidbody.velocity.magnitude < _maxSpeed)
            _rigidbody.AddForce(transform.forward * windPower * _windCoefficiency, ForceMode.Acceleration);        
    }
}
