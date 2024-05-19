using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private ExplodeCubes _explodeCubes;
    [SerializeField] private SpawnCubes _spawnCubes;

    private Cube cube;
    public float _chanceFission;
    private float _startChanceFission = 100;

    public float ChanceFission => _chanceFission;

    private void Awake()
    {            
        cube = GetComponent<Cube>();
        _chanceFission = _startChanceFission;
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
