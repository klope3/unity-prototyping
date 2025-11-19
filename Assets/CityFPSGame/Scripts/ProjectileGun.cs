using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : MonoBehaviour
{
    [SerializeField] private ProjectileTemp pf;

    [Sirenix.OdinInspector.Button]
    public void Launch()
    {
        ProjectileTemp spawnedProj = Instantiate(pf);
        spawnedProj.transform.position = transform.position;
        spawnedProj.Launch(transform.forward);
    }
}
