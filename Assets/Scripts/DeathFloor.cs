using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathFloor : MonoBehaviour
{
    [SerializeField] private CanvasGroup _winCanvas;
    [SerializeField] private CanvasGroup _loseCanvas;
    [SerializeField] private GameObject _player;

    [SerializeField] private float _fadeDuration;
    [SerializeField] private float _endGameDuration;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(nameof(EndGame), false);
    }

    private IEnumerator EndGame(bool won)
    {
        _player?.SetActive(false);

        var time = 0f;
        var canvas = _loseCanvas;

        if (won) canvas = _winCanvas;

        while (time < _fadeDuration + _endGameDuration)
        {
            time += Time.deltaTime;
            var currentAlpha = time / _fadeDuration;
            canvas.alpha = currentAlpha;

            yield return null;
        }

        yield return new WaitForSeconds(_endGameDuration);

        SceneManager.LoadScene(0);
    }
}
