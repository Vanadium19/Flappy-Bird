using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private int _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidBody;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.velocity = Vector2.zero;

        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);

        _startPosition = transform.position;
    }

    public void MoveUp()
    {
        _rigidBody.velocity = Vector2.right * _speed;
        transform.rotation = _maxRotation;
        _rigidBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
    }

    public void RotateDown()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void ResetPosition()
    {
        _rigidBody.velocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = _startPosition;
    }
}
