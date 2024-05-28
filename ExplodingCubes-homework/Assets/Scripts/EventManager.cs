using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<Cube> cubeDestroyed;

    public static void OnDestroyed(Cube cube)
    {
        cubeDestroyed?.Invoke(cube);
    }
}
