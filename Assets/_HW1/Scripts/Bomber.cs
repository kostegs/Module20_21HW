using UnityEngine;

public class Bomber : MonoBehaviour
{
    private const int RightMouseButton = 1;

    [SerializeField] private float _radius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private ParticleSystem _explosionEffectPrefab;

    private float _cameraZDistance;
    private ParticleSystem _explosionEffect;

    private void Awake()
    {
        _cameraZDistance = -Camera.main.transform.position.z;
        _explosionEffect = Instantiate(_explosionEffectPrefab, Vector3.zero, Quaternion.identity);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(RightMouseButton))
            Bomb();
    }

    public void Bomb()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mousePositionConverted = new Vector3(mousePosition.x, mousePosition.y, _cameraZDistance);
        
        Ray ray = Camera.main.ScreenPointToRay(mousePositionConverted);
        Vector3 explosionPoint = Camera.main.ScreenToWorldPoint(mousePositionConverted);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMask))
        {
            Collider[] targets = Physics.OverlapSphere(hit.point, _radius);

            foreach (Collider target in targets)
            {
                Rigidbody rigidbody = target.GetComponent<Rigidbody>();

                if (rigidbody != null)
                    rigidbody.AddExplosionForce(_explosionForce, explosionPoint, _radius, 1f, ForceMode.Impulse);                                                 
            }

            _explosionEffect.transform.position = explosionPoint;
            _explosionEffect.Play(true);
        }
    }
}
