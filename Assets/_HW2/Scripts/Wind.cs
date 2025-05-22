using System.Collections;
using TMPro;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private const float TimeToIndicateAboutChanging = 3f;

    [SerializeField] private float _timeToChange;
    [SerializeField] private float _changeSpeed;
    [SerializeField] private TMP_Text _windIndicator;

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
            StartIndicateWindChanging();
        }            
    }   

    private void StartIndicateWindChanging() 
        => StartCoroutine(IndicateWindChanging());        

    private IEnumerator IndicateWindChanging()
    {
        _windIndicator.gameObject.SetActive(true);        

        yield return new WaitForSeconds(TimeToIndicateAboutChanging);

        _windIndicator.gameObject.SetActive(false);
    }

    private void ChangeRotation()
    {
        float randomPosition = Random.Range(-180, 180);

        Vector3 newPosition = new Vector3(0, randomPosition, 0);

        _targetRotation = Quaternion.Euler(newPosition);            
    }

    private void DoRotation()
    {
        float step = _changeSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, step);        
    }
}