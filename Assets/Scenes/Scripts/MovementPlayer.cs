using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private float _step;
    private float _speed;
    private Vector2 _targetPosition;
    private Vector2 _lastPosition;
    private int _currentBand;
    private int _maxBand;

    private void Awake()
    {
        _lastPosition = transform.position;
        _targetPosition = _lastPosition;
        _step = 2f;
        _speed = 25;
        _currentBand = 3;
        _maxBand = 5;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, Time.deltaTime * _speed);
    }

    public void Move(int multiplier)
    {
        _currentBand += multiplier;

        if (_currentBand > 0 && _currentBand <= _maxBand)
        {
            _targetPosition = new Vector2(_lastPosition.x, _lastPosition.y + _step * multiplier);
            _lastPosition = _targetPosition;
        }
        else
        {
            _currentBand -= multiplier;
        }       
    }
}
