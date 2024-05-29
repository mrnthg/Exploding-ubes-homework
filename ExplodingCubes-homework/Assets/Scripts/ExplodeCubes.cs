using UnityEngine;
using System.Collections.Generic;

public class ExplodeCubes : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private void OnEnable()
    {
        EventManager.cubeDisappeared += MassiveExplosion;
    }

    public void Explode(Cube cube)
    {   
        cube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
    }

    public void MassiveExplosion(Cube cube)
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(cube.ExplosionForce, cube.transform.position, cube.ExplosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);
        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;   
    }
}
