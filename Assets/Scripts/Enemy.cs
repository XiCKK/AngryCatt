using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _destroyImpactMagnitude = 3f;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Cat>())
        {
            anim.SetTrigger("Die");
        }
        if (collision.relativeVelocity.magnitude >= _destroyImpactMagnitude)
        {
            anim.SetTrigger("Die");
        }
    }

    private void HandleKilledAnimationFisnished()
    {
        Destroy(gameObject);
    }
}
