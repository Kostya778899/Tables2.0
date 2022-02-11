using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class UiTMP_Text : UiTextDefault
{
    [SerializeField] private TMP_Text _text;

    private void Awake() { if (!_text) _text = GetComponent<TMP_Text>(); }
    public override void SetText(string value)
    {
        base.SetText(value);
        _text.text = Text;
    }
}
