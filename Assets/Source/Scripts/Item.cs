using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour, IItemStatus
{
    private Rigidbody _rigidbody;

    public event Action<IItemStatus> Picked;
    public event Action<IItemStatus> Dropped;

    public bool IsPicked { get; private set; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetPicked()
    {
        SetStatus(true);
        Picked?.Invoke(this);
    }

    public void SetDropped()
    {
        SetStatus(false);
        Dropped?.Invoke(this);
    }

    private void SetStatus(bool isPicked)
    {
        _rigidbody.useGravity = !isPicked;
        _rigidbody.isKinematic = isPicked;
        IsPicked = isPicked;
    }
}