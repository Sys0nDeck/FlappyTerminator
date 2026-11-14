using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private BulletPoolWithScoreEvent _bulletPool;

    private int _score;

    public event Action<int> ScoreCountChanged;

    private void OnEnable()
    {
        _bulletPool.ScoreIncreasing += IncreaseScore;
    }

    private void OnDisable()
    {
        _bulletPool.ScoreIncreasing -= IncreaseScore;
    }

    private void IncreaseScore()
    {
        _score++;
        ScoreCountChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        ScoreCountChanged?.Invoke(_score);
    }
}
