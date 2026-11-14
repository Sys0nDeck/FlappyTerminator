using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;

    private Vector3 _startPosition;
    private Rigidbody2D _rigitbody2D;

    private void Awake()
    {
        _rigitbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _startPosition = transform.position;
    }

    public void Jump()
    {
        _rigitbody2D.velocity = new Vector2(_speed, _tapForce);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        _rigitbody2D.velocity = Vector2.zero;
    }
}
