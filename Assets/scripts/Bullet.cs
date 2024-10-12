using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Material bulletMaterial;

    public void Initialize(Material material)
    {
        bulletMaterial = material;
        Renderer bulletRenderer = GetComponent<Renderer>();
        if (bulletRenderer != null)
        {
            bulletRenderer.material = bulletMaterial;
        }
    }

    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Enemy"))
    {
        Renderer enemyRenderer = other.GetComponent<Renderer>();
        if (enemyRenderer != null)
        {
            Color enemyColor = enemyRenderer.material.color;

            // Compare colors instead of materials
            if (bulletMaterial.color == enemyColor)
            {
                Destroy(other.gameObject); // Destroy enemy
            }
            else
            {
                Destroy(gameObject); // Destroy bullet
            }
        }
    }
}

}
