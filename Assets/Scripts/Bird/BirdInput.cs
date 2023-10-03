using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdShooter))]
[RequireComponent(typeof(Animator))]
public class BirdInput : MonoBehaviour
{   
    private BirdMover _mover;
    private BirdShooter _shooter;
    private Animator _animator;

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
        _shooter = GetComponent<BirdShooter>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Move();        

        _mover.RotateDown();

        if (Input.GetKeyDown(KeyCode.RightShift))                    
            _shooter.Shoot(transform.right);                
    }

    private void Move()
    {
        _mover.MoveUp();
        _animator.SetTrigger("Fly");
    }
}
