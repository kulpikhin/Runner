using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cherri : MonoBehaviour
{
    private Vector2 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = _startPosition;
        gameObject.SetActive(false);
    }
}
