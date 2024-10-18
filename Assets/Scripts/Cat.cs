using System.Runtime.CompilerServices;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [SerializeField]
    private float _lauchpower = 5f;
    [SerializeField]
    private float _maxDragDistance = 2f;
    private Rigidbody2D _rb;
    private  Vector3 _startPosition;
    private LineRenderer _dragLineRenderer;

    private bool _launched;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>(); 
        _dragLineRenderer = GetComponent<LineRenderer>();
        
    }
    void Start()
    {
        _startPosition = transform.position;
        _dragLineRenderer.SetPosition(0, transform.position);
        _dragLineRenderer.enabled = false;
    }


    private void OnMouseDrag()
    {
        Vector3 destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        destination.z = 0;
        if (Vector2.Distance(_startPosition, destination) > _maxDragDistance)
        {
            destination = Vector3.MoveTowards(_startPosition, destination, _maxDragDistance);
        }
        transform.position = destination;
        _rb.velocity = Vector2.zero;

        _dragLineRenderer.SetPosition(1, transform.position);
        _dragLineRenderer.enabled = true;
    }

    private void OnMouseUp()
    {
        if (_launched)
            return;

        _launched = true;
        Vector3 LauchVector = _startPosition - transform.position;
        _rb.AddForce(LauchVector * _lauchpower, ForceMode2D.Impulse);
        _rb.gravityScale = 1.0f;
        _dragLineRenderer.enabled = false;
    }
}
