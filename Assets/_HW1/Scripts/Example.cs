using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionEffectPrefab;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private DragService _dragService;
    private ExplosionService _explosionService;
    private IInputProcessor _dragAndDropInput;
    private IInputProcessor _explosionInput;
    private ParticleSystem _explosionEffect;
    private bool _isInitialized;

    public void Initialize(IInputProcessor dragAndDropInput, IInputProcessor explosionInput) 
    {
        _dragAndDropInput = dragAndDropInput;
        _explosionInput = explosionInput;

        _dragService = new DragService(_dragAndDropInput);
        _explosionService = new ExplosionService(_explosionForce, _explosionRadius, _explosionInput);

        _explosionEffect = Instantiate(_explosionEffectPrefab, Vector3.zero, Quaternion.identity);

        _isInitialized = true;
    }

    private void Update()
    {
        if (_isInitialized == false)
            return;

        if (_dragAndDropInput.IsButtonDown())
            _dragService.TryCatchObject();
        else if (_dragAndDropInput.IsButtonUp())
            _dragService.TryReleaseObject();
        else if (_dragAndDropInput.IsButtonHold())
            _dragService.DragNDropObject();

        if (_explosionInput.IsButtonDown())
        {
            Vector3 explosionCoordinates = _explosionService.MakeExplosion();
            _explosionEffect.transform.position = explosionCoordinates;
            _explosionEffect.Play(true);
        }
    }
}
