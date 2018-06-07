using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CurrentScoreGetter : MonoBehaviour {
    Text _scoreText;

	void Awake () {
        _scoreText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        ScoreManager.ScoreUpdated += OnScoreUpdated;
        OnScoreUpdated(ScoreManager.CurrentScore);
    }

    private void OnDisable()
    {
        ScoreManager.ScoreUpdated -= OnScoreUpdated;
    }

    // Update is called once per frame
    void OnScoreUpdated (int score) {
        _scoreText.text = $"Score: {score}";
    }
}
