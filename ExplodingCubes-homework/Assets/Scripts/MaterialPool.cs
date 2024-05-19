using System.Collections.Generic;
using UnityEngine;

public class MaterialPool : MonoBehaviour
{
    [SerializeField] private List<Material> _materials = new List<Material>();

    public Material GetMaterial() => _materials[GetRandomNumber()];

    private int GetRandomNumber() => Random.Range(0, _materials.Count);
}
