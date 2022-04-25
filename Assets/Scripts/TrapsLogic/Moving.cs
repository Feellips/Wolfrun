using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private bool _rightMove;
    [SerializeField] private Transform _moveableObject;
    [SerializeField] private ButtonController _buttonController;

    private void Start()
    {
        _buttonController.OnMouseDown += Move;
    }

    private void Move()
    {
        StartCoroutine(nameof(PerformMove));
    }

    private IEnumerator PerformMove()
    {
        for (int i = 0; i < 20; i++)
        {
            _moveableObject.Translate((_rightMove ? Vector3.right : Vector3.left) * 0.1f);
            yield return null;
        }
    }
}
