using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Wind _wind;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _windCoefficiency;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, _wind.transform.forward * 100);
    }

    private void Update()
    {
        float windPower = Vector3.Dot(transform.forward, _wind.transform.forward);
        
        Vector3 move = new Vector3(0, 0, windPower * _windCoefficiency * Time.deltaTime);

        Debug.Log(move);

        _rigidbody.AddForce(transform.forward * windPower * _windCoefficiency * Time.deltaTime, ForceMode.VelocityChange);

        //Debug.Log(_rigidbody.velocity);
    }
}
