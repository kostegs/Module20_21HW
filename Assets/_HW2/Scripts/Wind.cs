using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private float _timeToChange;
    [SerializeField] private float _changeSpeed;

    private float _time;
    private Quaternion _targetRotation;

    private void Update()
    {
        _time += Time.deltaTime;

        DoRotation();
        
        if (_time >= _timeToChange)
        {
            _time = 0;
            ChangeRotation();
        }            
    }

    private void ChangeRotation()
    {
        float randomPosition = Random.Range(-180, 180);

        Vector3 newPosition = new Vector3(0, randomPosition, 0);

        _targetRotation = Quaternion.Euler(newPosition);
        

        //Debug.Log($"New pos: {newPosition}, quat: {lookRotation.eulerAngles}");
    }

    private void DoRotation()
    {
        float step = _changeSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, step);
        
        //Debug.Log($"New pos: {newPosition}, quat: {lookRotation.eulerAngles}");
    }
}