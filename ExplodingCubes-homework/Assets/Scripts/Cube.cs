using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private ExplodeCubes _explodeCubes;
    [SerializeField] private SpawnCubes _spawnCubes;

    private Cube cube;
    private float _chanceFission;

    public float ChanceFission => _chanceFission;

    private void Awake()
    {            
        cube = GetComponent<Cube>();
        _spawnCubes.SetCurrentChanceFission(cube);
    }

    private void OnMouseDown()
    {
        _spawnCubes.SpawnNewCubes(cube);
        _explodeCubes.Explode(cube);
        Destroy(gameObject);
    }

    public void SetChanceFission(float value)
    {
        _chanceFission = value;
    }
}
