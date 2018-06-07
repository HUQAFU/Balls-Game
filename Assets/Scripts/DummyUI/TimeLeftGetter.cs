using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimeLeftGetter : MonoBehaviour {
    Text _text;

	void Awake () {
        _text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        GameTimeManager.GameTimer.TimeLeftUpdated += OnTimeLeftUpdated;
        OnTimeLeftUpdated(GameTimeManager.GameTimer.CurrentTime);
    }

    private void OnDisable()
    {
        GameTimeManager.GameTimer.TimeLeftUpdated -= OnTimeLeftUpdated;
    }

    // Update is called once per frame
    void OnTimeLeftUpdated(float time) {
        string minSec = string.Format("{0}:{1:00}", (int)time / 60, (int)time % 60);
        _text.text = $"Time left: {minSec}";
    }
}
