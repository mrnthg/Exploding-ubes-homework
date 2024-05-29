using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _chanceFission;
    private float _startChanceFission = 100;
    private float _explosionRadius = 20;
    private float _explosionForce = 700;
    private float _maxPercentage = 100;
    private float _percentageIncrease = 20;


    public float ChanceFission => _chanceFission;
    public float ExplosionRadius => _explosionRadius;
    public float ExplosionForce => _explosionForce;

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

    public void UpExplosionRadius()
    {
        _explosionRadius += (_explosionRadius / _maxPercentage) * _percentageIncrease;
    }

    public void UpExplosionForce()
    {
        _explosionForce += (_explosionForce / _maxPercentage) * _percentageIncrease;
    }
}
