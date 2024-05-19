using UnityEngine;
using System.Collections.Generic;

public class SpawnCubes : MonoBehaviour
{
    [SerializeField] private MaterialPool _material;

    private int _minCountCubes = 2;
    private int _maxCountCubes = 7;
    private float _currentChanceFission;
    private List<Rigidbody> _poolCubes = new List<Rigidbody>();

    public List<Rigidbody> poolCubes => _poolCubes;

    public void SpawnNewCubes(Cube cube)
    {
        Vector3 position = cube.transform.position;
        int countCubes = GetCountCubes();
        float divisorNumber = 2;

        float scaleX = cube.transform.localScale.x;
        float scaleY = cube.transform.localScale.y;
        float scaleZ = cube.transform.localScale.z;

        _poolCubes.Clear();
        _currentChanceFission = cube.ChanceFission;      

        if (IsFissionPossible())
        {
            _currentChanceFission /= divisorNumber;

            for (int i = 0; i < countCubes; i++)
            {
                cube.GetComponent<Renderer>().material = _material.GetMaterial();
                cube.transform.localScale = new Vector3(scaleX / divisorNumber, scaleY / divisorNumber, scaleZ / divisorNumber);

                Cube newCube = Instantiate(cube, position, Quaternion.identity);
                _poolCubes.Add(newCube.GetComponent<Collider>().attachedRigidbody);
                newCube.transform.SetParent(transform);
                newCube.SetChanceFission(_currentChanceFission);
            }
        }
    }

    private bool IsFissionPossible()
    {
        float minCount = 0;
        float maxCount = 100;

        return Random.Range(minCount, maxCount) <= _currentChanceFission;
    }

    private int GetCountCubes() => Random.Range(_minCountCubes, _maxCountCubes);
}
