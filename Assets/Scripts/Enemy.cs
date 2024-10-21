using UnityEngine;
using System.Collections;
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _destroyImpactMagnitude = 3f;
    [SerializeField] private float killY;
    private GameFlowController gameFlowController;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Initialized(GameFlowController _gameFlowController)
    {
        gameFlowController = _gameFlowController;
    }
    void Update()
    {
        if (transform.position.y < killY)
        {
            StartCoroutine(WaitKill());
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Cat>())
        {
            StartCoroutine(WaitKill());
        }
        if (collision.relativeVelocity.magnitude >= _destroyImpactMagnitude)
        {
            StartCoroutine(WaitKill());
        }
    }


    IEnumerator WaitKill()
    {
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        gameFlowController.NotifyEnemyDeath(this);
    }
}
