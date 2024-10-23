using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetPicked()
    {
        SetStatus(true);
    }

    public void SetDropped()
    {
        SetStatus(false);
    }

    private void SetStatus(bool isPicked)
    {
        _rigidbody.useGravity = !isPicked;
        _rigidbody.isKinematic = isPicked;
    }
}