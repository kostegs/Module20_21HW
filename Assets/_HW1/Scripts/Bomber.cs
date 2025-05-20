using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private LayerMask _layerMask;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            Bomb();
    }

    public void Bomb()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

        Vector3 explosionPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMask))
        {
            Collider[] targets = Physics.OverlapSphere(hit.point, _radius);

            foreach (Collider target in targets)
            {
                Rigidbody rigidbody = target.GetComponent<Rigidbody>();

                if (rigidbody != null)
                {
                    // Применяем силу взрыва
                    rigidbody.AddExplosionForce(_explosionForce, explosionPoint, _radius, 1f, ForceMode.Impulse);
                }
            }
        }
    }
}
