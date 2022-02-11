using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UiText : UiTextDefault
{
    [SerializeField] private Text _text;

    private void Awake() { if (!_text) _text = GetComponent<Text>(); }
    public override void SetText(string value)
    {
        base.SetText(value);
        _text.text = Text;
    }
}
