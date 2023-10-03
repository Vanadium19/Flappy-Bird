using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _maxHigh;
    [SerializeField] private float _minHigh;
    [SerializeField] private float _speed;

    private float _targetPositionY;
    private Coroutine _mover;

    private void OnEnable()
    {        
        _targetPositionY = _minHigh;
        StartMove();
    }

    private void Update()
    {
        if (transform.position.y == _targetPositionY)
        {            
            SetTargetPosition();
            StopMove();
            StartMove();
        }
    }

    private void SetTargetPosition()
    {
        _targetPositionY = transform.position.y == _maxHigh ? _minHigh : _maxHigh;
    }

    private void StartMove()
    {
        _mover = StartCoroutine(Move());
    }

    private void StopMove()
    {
        if (_mover != null)
            StopCoroutine(_mover);
    }

    private IEnumerator Move()
    {
        while (transform.position.y != _targetPositionY)
        {            
            var targetPosition = new Vector3(transform.position.x, _targetPositionY, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
            yield return null;
        }

        transform.position = new Vector3(transform.position.x, _targetPositionY, transform.position.z);
    }
}
