using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector2 _startPosition;

    private void OnEnable()
    {
        _startPosition = transform.position;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = _startPosition;
        gameObject.SetActive(false);
    }
}
