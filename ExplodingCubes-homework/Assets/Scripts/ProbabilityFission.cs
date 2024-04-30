using UnityEngine;

public class ProbabilityFission : MonoBehaviour
{
    private float minCount = 0;
    private float maxCount = 100;
    private bool isFission;

    public bool CalculatingProbabilityFission(float value)
    {
        isFission = Random.Range(minCount, maxCount) <= value ? true : false;        
        return isFission;
    }
}
