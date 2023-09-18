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
        Vector3 target = _target.GetComponent<Transform>().position;

        if (target.x > transform.position.x)
            _flip.flipX = true;
        else
            _flip.flipX = false;

        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }
}