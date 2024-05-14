using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private ExplodeCubes _explodeCubes;

    private float _chanceFission;

    private void Awake()
    {
        _chanceFission = _explodeCubes.GetCurrentChanceFission();
    }

    private void OnMouseDown()
    {
        _explodeCubes.SpawnNewCubes(gameObject);
        Destroy(gameObject);
    }

    public float GetChanceFission()
    {
        return _chanceFission;
    }   
}
