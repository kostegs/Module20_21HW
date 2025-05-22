using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Barrel : MonoBehaviour, IGrabble, IExplosiveable
{
    [SerializeField] private float _increaseScaleOnCatch = 1.2f;

    private Vector3 _savedLocalScale;
    private Rigidbody _rigidBody;
    
    private void Awake()
    {
        _savedLocalScale = transform.localScale;
        _rigidBody = GetComponent<Rigidbody>();
    }  

    public void OnGrab() => transform.localScale = _savedLocalScale * _increaseScaleOnCatch;

    public void OnRelease() => transform.localScale = _savedLocalScale;

    public Vector3 GetPosition() => transform.position;
    
    public void SetPosition(Vector3 position) => transform.position = position;

    public void Explosion(float force, Vector3 position, float radius)
        => _rigidBody.AddExplosionForce(force, position, radius, 1f, ForceMode.Impulse);    
}
