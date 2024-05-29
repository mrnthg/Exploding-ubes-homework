using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    [SerializeField] private MaterialPool _material; 
    [SerializeField] private ExplodeCubes _explodeCube;

    private int _minCountCubes = 2;
    private int _maxCountCubes = 7;

    private void OnEnable()
    {
        EventManager.cubeDestroyed += SpawnNewCubes;
    }

    private void OnDisable()
    {
        EventManager.cubeDestroyed -= SpawnNewCubes;
    }

    public void SpawnNewCubes(Cube cube)
    {
        Vector3 position = cube.transform.position;
        int countCubes = GetCountCubes();
        float divisorNumber = 2;
        float _currentChanceFission;

        float scaleX = cube.transform.localScale.x;
        float scaleY = cube.transform.localScale.y;
        float scaleZ = cube.transform.localScale.z;

        _currentChanceFission = cube.ChanceFission;

        Vector3 newScale = new Vector3(scaleX / divisorNumber, scaleY / divisorNumber, scaleZ / divisorNumber);

        if (IsFissionPossible(_currentChanceFission))
        {
            _currentChanceFission /= divisorNumber;

            for (int i = 0; i < countCubes; i++)
            {
                if (cube.TryGetComponent(out Renderer material))
                {
                    material.material = _material.GetMaterial();
                }

                cube.transform.localScale = newScale;

                Cube newCube = Instantiate(cube, position, Quaternion.identity);
                newCube.transform.SetParent(transform);
                newCube.SetChanceFission(_currentChanceFission);
                newCube.UpExplosionForce();
                newCube.UpExplosionRadius();

                _explodeCube.Explode(newCube);
            }
        }
        else
        {
            EventManager.OnDisappeared(cube);
        }
    }

    private bool IsFissionPossible(float chanceFission)
    {
        float minCount = 0;
        float maxCount = 100;

        return Random.Range(minCount, maxCount) <= chanceFission;
    }

    private int GetCountCubes() => Random.Range(_minCountCubes, _maxCountCubes);
}
