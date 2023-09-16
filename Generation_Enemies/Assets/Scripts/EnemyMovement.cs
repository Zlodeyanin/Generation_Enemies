using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private int _direction;
    private int _directionRignt = 1;
    private float _zeroMove = 0;

    public void Init(int direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        if (_direction == _directionRignt)
        {
            transform.Translate(_speed * Time.deltaTime, _zeroMove, _zeroMove);
        }
        else
        {
            transform.Translate((_speed * Time.deltaTime) * -1, _zeroMove, _zeroMove);
        }
    }
}