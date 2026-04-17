using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public float meters = 0f;
    public float metersPerSecond = 5f;
    public int bestScore;
    private bool isCounting = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (isCounting)
        {
            meters += metersPerSecond * Time.deltaTime;
        }
    }

    public void StartCounting()
    {
        isCounting = true;
    }

    public void StopCounting()
    {
        isCounting = false;
    }

    public int GetMeters()
    {
        return Mathf.FloorToInt(meters);
    }

    public void ResetScore()
    {
        meters = 0f;
    }

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    public void CheckNewRecord()
    {
        int current = GetMeters();

        if (current > bestScore)
        {
            bestScore = current;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }
}