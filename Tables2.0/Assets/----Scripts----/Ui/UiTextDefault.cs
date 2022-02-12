using UnityEngine;

public abstract class UiTextDefault : UiCellElementDefault
{
    protected string Text = "";

    public virtual string GetText() { return Text; }
    public virtual void SetText(string value) => Text = value;
}
