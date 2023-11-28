using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private MovementPlayer _movementPlayer;

    private void Awake()
    {
        _movementPlayer = GetComponent<MovementPlayer>();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _movementPlayer.Move(1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _movementPlayer.Move(-1);
        }
    }
}
