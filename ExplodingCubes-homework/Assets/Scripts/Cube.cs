using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Explosion—ontroller _explosion—ontroller;

    private void OnMouseDown()
    {
        _explosion—ontroller.SpawnNewCubes(gameObject);
        _explosion—ontroller.Explode();
        Destroy(gameObject);
    }
}
