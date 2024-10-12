using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material[] materials;
    public Material currentMaterial;
    public BulletSpawner bulletSpawner;

    public void Start()
    {
        ChangeColor();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        Material newMaterial;

        do
        {
            newMaterial = materials[Random.Range(0, materials.Length)];
        } while (newMaterial == currentMaterial);

        foreach (Renderer r in GetComponentsInChildren<Renderer>()) 
{
    r.material = newMaterial; // Ensure this is applying correctly
}


        bulletSpawner.UpdateSpawnerMaterial(newMaterial);

        currentMaterial = newMaterial; 
    }
}