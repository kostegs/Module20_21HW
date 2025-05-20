using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Speedometer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        string text = $"������� ��������: {string.Format("{0:0}", _rigidbody.velocity.magnitude)} ��/�";
        _text.text = text;
    }
}
