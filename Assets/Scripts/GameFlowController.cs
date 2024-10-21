using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameFlowController : MonoBehaviour
{
    private List<Enemy> remainingEnemies;
    void Start()
    {
        remainingEnemies = new List<Enemy>(FindObjectsOfType<Enemy>());
        foreach (Enemy amEnemy in remainingEnemies)
        {
            amEnemy.Initialized(this);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

   public void NotifyEnemyDeath(Enemy killedEnemy)
    {
        remainingEnemies.Remove(killedEnemy);
        if (remainingEnemies.Count == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
