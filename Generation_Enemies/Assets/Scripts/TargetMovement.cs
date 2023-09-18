using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _endPosition = new Vector2(18f, 0f);
    private Vector2 _startPosition = new Vector2(-7.8f,0f);
    private float _zeroMove = 0;

    private void Update()
    {
        if (transform.position.x > _endPosition.x)
        {
            transform.Translate(_startPosition.x *3, _zeroMove, _zeroMove);
        }
        else
        {
            transform.Translate(_speed * Time.deltaTime, _zeroMove, _zeroMove);
        }
    }
}