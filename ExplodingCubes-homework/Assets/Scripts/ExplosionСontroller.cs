using System.Collections.Generic;
using UnityEngine;

public class Explosion—ontroller : MonoBehaviour
{
    [SerializeField] private MaterialPool _material;
    [SerializeField] private ProbabilityFission _probabilityFission;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private GameObject _newCube;
    private int _minCountCubes = 2;
    private int _maxCountCubes = 7;
    private float _maxProbability = 100;

    public void SpawnNewCubes(GameObject cube)
    {
        _newCube = cube;
        Vector3 position = _newCube.transform.position;
        float divisorNumber = 2;

        float scaleX = _newCube.transform.localScale.x;
        float scaleY = _newCube.transform.localScale.y;
        float scaleZ = _newCube.transform.localScale.z;

        if (_probabilityFission.CalculatingProbabilityFission(_maxProbability))
        {
            for (int i = 0; i < RandomCount(); i++)
            {
                _newCube.GetComponent<Renderer>().material = _material.GetMaterial();
                _newCube.transform.localScale = new Vector3(scaleX / divisorNumber, scaleY / divisorNumber, scaleZ / divisorNumber);                   

                GameObject cubes = Instantiate(_newCube, position, Quaternion.identity);
                cubes.transform.SetParent(transform);
            }
           
            _maxProbability = _maxProbability / divisorNumber;

            Explode();   
        }
    }

    public void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_explosionForce, _newCube.transform.position, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        List<Rigidbody> cubes = new();

        Collider[] hits = Physics.OverlapSphere(_newCube.transform.position, _explosionRadius);

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }

    private int RandomCount() => Random.Range(_minCountCubes, _maxCountCubes);
}
