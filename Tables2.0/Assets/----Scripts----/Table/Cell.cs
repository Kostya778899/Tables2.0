using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private CellSettings _settings;
    [SerializeField] private List<UiTextDefault> _texts;

    [System.Serializable]
    public struct Datas
    {
        public List<string> Texts;
    }

    public void Updating(Datas datas)
    {
        if (datas.Texts.Count > _texts.Count) CreateTexts(datas.Texts.Count - _texts.Count);
        ActiveTexts(datas.Texts.Count);

        for (int i = 0; i < datas.Texts.Count; i++)
        {
            if (i >= datas.Texts.Count)
            {
                _texts.Add(Instantiate(_settings.TextPrefab, transform));
            }
            _texts[i].SetText(datas.Texts[i]);
        }
    }
    private void CreateTexts(int count) { for (int i = 0; i < count; i++) _texts.Add(Instantiate(_settings.TextPrefab, transform)); }
    private void ActiveTexts(int count) { for (int i = 0; i < _texts.Count; i++) _texts[i].gameObject.SetActive(i < count); }
}
