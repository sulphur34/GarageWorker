using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 12f;

    private CharacterController _controller;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = _transform.right * horizontal + _transform.forward * vertical;

        _controller.Move(movement * _moveSpeed * Time.deltaTime);
    }
}