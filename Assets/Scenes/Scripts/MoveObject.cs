using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private float _speed;

    private void Awake()
    {
        _speed = 5;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(-1,0,0), _speed * Time.deltaTime);
    }
}
