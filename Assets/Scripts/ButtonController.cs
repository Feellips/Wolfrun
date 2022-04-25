using System.Collections;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Transform _button;

    private Vector3 _translationVector = Vector3.down * 0.005f;
    private bool _pressed = false;

    public event MouseDown OnMouseDown;

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Click();
    }

    private void Click()
    {
        if (_pressed == false)
        {
            _pressed = true;
            OnMouseDown?.Invoke();
            StartCoroutine(nameof(AnimateClick));
        }


    }

    private IEnumerator AnimateClick()
    {
        for (int i = 0; i < 10; i++)
        {
            _button.Translate(_translationVector);
            yield return null;
        }
    }
}

public delegate void MouseDown();
