using TMPro;
using UnityEngine;

public class UIScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _scoreCounter.ScoreCountChanged += UpdateScore;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreCountChanged += UpdateScore;
    }

    private void UpdateScore(int value)
    {
        _text.text = value.ToString();
    }
}
