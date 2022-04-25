using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    [SerializeField] private ButtonController _buttonController;
    [SerializeField] private Transform _spinnableObject;

    void Start()
    {
        _buttonController.OnMouseDown += Spin;
    }

    private void Spin()
    {
        StartCoroutine(nameof(PerformSpinning));
    }

    private IEnumerator PerformSpinning()
    {
        for (int i = 0; i < 360; i++)
        {
            _spinnableObject.Rotate(Vector3.up, i);
            yield return null;
        }
    }
}
