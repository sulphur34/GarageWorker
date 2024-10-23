using DG.Tweening;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _duration;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        var endValue = _transform.position + new Vector3(0f, _distance, 0f);
        _transform.DOMove(endValue, _duration);
    }
}