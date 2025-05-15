using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private const float WIND_POWER_TRANSLATE_COEFFICIENCY = 1000;

    [SerializeField] private Wind _wind;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _windCoefficiency;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, _wind.transform.forward * 100);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 100);
    }    

    private void FixedUpdate()
    {
        float windPower = Vector3.Dot(transform.forward, _wind.transform.forward);

        Debug.Log(windPower);

        _rigidbody.AddForce(transform.forward * windPower * _windCoefficiency, ForceMode.Acceleration);

        //Debug.Log(_rigidbody.velocity);
    }
}
