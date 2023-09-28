using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _endPoint;

    private Vector2 _startPosition;
    private float _zeroMove = 0;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position.x > _endPoint.position.x)
        {
            transform.position = _startPosition;
        }
        else
        {
            transform.Translate(_speed * Time.deltaTime, _zeroMove, _zeroMove);
        }
    }
}