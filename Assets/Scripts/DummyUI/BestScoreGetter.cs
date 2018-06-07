using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BestScoreGetter : MonoBehaviour {
    Text _scoreText;

	void Awake () {
        _scoreText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        ScoreManager.BestScoreUpdated += OnBestScoreUpdated;
        OnBestScoreUpdated(ScoreManager.BestScore);
    }

    private void OnDisable()
    {
        ScoreManager.BestScoreUpdated -= OnBestScoreUpdated;
    }

    // Update is called once per frame
    void OnBestScoreUpdated(int score) {
        _scoreText.text = $"Best score: {score}";
    }
}
