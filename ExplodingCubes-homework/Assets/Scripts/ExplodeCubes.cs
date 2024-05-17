using System.Collections.Generic;
using UnityEngine;

public class ExplodeCubes : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private SpawnCubes _spawner;

    public void Explode(Cube cube)
    {
        List<Rigidbody> cubes = _spawner.GetRigidbody;

        foreach (Rigidbody explodableObject in cubes)
            explodableObject.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
    }
}
