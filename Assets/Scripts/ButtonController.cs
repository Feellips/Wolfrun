using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Transform _button;
    [SerializeField] private UIDocument _ui;

    private Vector3 _translationVector = Vector3.down * 0.005f;
    private bool _pressed = false;
    private VisualElement _visualRoot;

    private Button _actionButton;

    public event MouseDown OnMouseDown;

    private void Start()
    {
        _visualRoot = _ui.rootVisualElement;
        _actionButton = _visualRoot.Q<Button>("ActionButton");
        _visualRoot.visible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        _ui.rootVisualElement.visible = true;
        _actionButton.clicked += Click;
    }

    private void OnTriggerExit(Collider other)
    {
        _actionButton.clicked -= Click;
        _ui.rootVisualElement.visible = false;
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
