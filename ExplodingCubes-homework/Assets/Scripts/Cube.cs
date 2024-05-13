using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Explosion—ontroller _explosion—ontroller;

    public float _chanceFission;

    private void Awake()
    {
        _chanceFission = _explosion—ontroller.GetCurrentChanceFission();
    }

    private void OnMouseDown()
    {
        _explosion—ontroller.SpawnNewCubes(gameObject);
        Destroy(gameObject);
    }

    public float GetChanceFission()
    {
        return _chanceFission;
    }   
}
