using System.Collections.Generic;
using UnityEngine;

public class ExplodeCubes : MonoBehaviour
{
    [SerializeField] private MaterialPool _material;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private int _minCountCubes = 2;
    private int _maxCountCubes = 7;
    private float _currentChanceFission = 100;

    public void SpawnNewCubes(GameObject cube)
    {        
        Vector3 position = cube.transform.position;
        int countCubes = GetCountCubes();
        float divisorNumber = 2;

        float scaleX = cube.transform.localScale.x;
        float scaleY = cube.transform.localScale.y;
        float scaleZ = cube.transform.localScale.z;

        _currentChanceFission = cube.GetComponent<Cube>().GetChanceFission();

        if (IsFissionPossible())
        {
            _currentChanceFission /= divisorNumber;

            for (int i = 0; i < countCubes; i++)
            {
                cube.GetComponent<Renderer>().material = _material.GetMaterial();
                cube.transform.localScale = new Vector3(scaleX / divisorNumber, scaleY / divisorNumber, scaleZ / divisorNumber);
                
                GameObject newCube = Instantiate(cube, position, Quaternion.identity);
                newCube.transform.SetParent(transform);               
            }

            Explode(cube);   
        }   
    }
    public float GetCurrentChanceFission()
    {
        return _currentChanceFission;
    }

    private void Explode(GameObject cube)
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects(cube))
            explodableObject.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects(GameObject cube)
    {
        List<Rigidbody> cubes = new();
        Collider[] hits = Physics.OverlapSphere(cube.transform.position, _explosionRadius);

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }

    public bool IsFissionPossible()
    {
        float minCount = 0;
        float maxCount = 100;

        return Random.Range(minCount, maxCount) <= _currentChanceFission;
    }

    private int GetCountCubes() => Random.Range(_minCountCubes, _maxCountCubes);
}
