using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<Cube> cubeDestroyed;
    public static event Action<Cube> cubeDisappeared;

    public static void OnDestroyed(Cube cube)
    {
        cubeDestroyed?.Invoke(cube);
    }

    public static void OnDisappeared(Cube cube)
    {
        cubeDisappeared?.Invoke(cube);
    }
}
