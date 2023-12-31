using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private SpriteRenderer _flip;
    private TargetMovement _target;

    public void Init(TargetMovement paw)
    {
        _target = paw;
    }

    private void Start()
    {
        _flip = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        bool isFlip = true && _target.transform.position.x > transform.position.x;
        _flip.flipX = isFlip;
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }
}