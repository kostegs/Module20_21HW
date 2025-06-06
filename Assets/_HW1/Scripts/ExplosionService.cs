using UnityEngine;

public class ExplosionService
{
    private const float CameraReverseDistanceCoefficiency = -1;

    private float _radius;
    private float _explosionForce;    
    private float _cameraZDistance;
    private IInputProcessor _input;
    private ParticleSystem _explosionEffect;

    public ExplosionService(float force, float radius, IInputProcessor input, ParticleSystem explosionEffect)
    {
        _cameraZDistance = Camera.main.transform.position.z * CameraReverseDistanceCoefficiency;
        _explosionForce = force;
        _radius = radius;
        _input = input;
        _explosionEffect = explosionEffect;
    }

    public void MakeExplosion()
    {
        Vector3 currentCursorPosition = _input.GetCurrentCursorPosition();
        Vector3 cursorPositionConverted = new Vector3(currentCursorPosition.x, currentCursorPosition.y, _cameraZDistance);
        
        Ray ray = Camera.main.ScreenPointToRay(cursorPositionConverted);
        Vector3 explosionPoint = Camera.main.ScreenToWorldPoint(cursorPositionConverted);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Collider[] targets = Physics.OverlapSphere(hit.point, _radius);

            foreach (Collider target in targets)
            {
                if (target.gameObject.TryGetComponent<IExplosiveable>(out IExplosiveable explosiveable))
                    explosiveable.Explosion(_explosionForce, explosionPoint, _radius);
            }            
        }

        _explosionEffect.transform.position = explosionPoint;
        _explosionEffect.Play();        
    }
}
