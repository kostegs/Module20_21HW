using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    [SerializeField] private float _amplitude;
    [SerializeField] private float _frequency;    
    [SerializeField] private float _angle;

    private float _time;
    private float _direction = 1f;

    private void Update()
    {
        _time += Time.deltaTime;
        _time *= _direction;

        float rotation = (_amplitude * Mathf.Sin(_time * _frequency));

        if (rotation >= _angle || rotation <= -_angle)
        {
            _time = 0f; 
            _direction *= -1;
        }
            

        transform.rotation = Quaternion.Euler(new Vector3(rotation, transform.rotation.y, transform.rotation.z));
        //transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
    }
}
