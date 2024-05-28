using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _chanceFission;
    private float _startChanceFission = 100;

    public float ChanceFission => _chanceFission;

    private void Awake()
    {
        _chanceFission = _startChanceFission;
    }

    private void OnMouseDown()
    {
        EventManager.OnDestroyed(this);
        Destroy(gameObject);
    }

    public void SetChanceFission(float value)
    {
        _chanceFission = value;
    }
}
