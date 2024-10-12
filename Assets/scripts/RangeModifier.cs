using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RangeModifier : MonoBehaviour
{
    public float rangeRadius;
    public GameObject gameOverUI;

    private Collider[] enemyColliders;

    void Update()
    {
        enemyColliders = Physics.OverlapSphere(transform.position, rangeRadius);

        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider enemyCollider in enemyColliders)
        {
            if (enemyCollider.CompareTag("Enemy"))
            {
                float distance = Vector3.Distance(transform.position, enemyCollider.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemyCollider.transform;
                }
            }
        }

        if (closestEnemy != null)
        {
            transform.LookAt(closestEnemy.position);

            if (closestDistance <= 0.5f)
            {
                gameOverUI.SetActive(true);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, rangeRadius);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }
}