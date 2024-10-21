using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private Collider2D floorCollider;
    [SerializeField] private float margin = 1;
    private Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            float camLeft = _camera.ViewportToWorldPoint(new Vector2(0f, 0f)).x;
            if (camLeft > floorCollider.bounds.min.x - margin)
            {
                transform.position -= speed * Time.deltaTime * Vector3.right;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            float camRight = _camera.ViewportToWorldPoint(new Vector2(1f, 0f)).x;
            if (camRight < floorCollider.bounds.max.x + margin)
            {
                transform.position += speed * Time.deltaTime * Vector3.right;
            }
        }
    }
}
