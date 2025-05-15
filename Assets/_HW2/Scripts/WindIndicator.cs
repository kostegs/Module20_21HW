using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindIndicator : MonoBehaviour
{
    [SerializeField] private Wind _wind;

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(_wind.transform.forward);
    }
}
