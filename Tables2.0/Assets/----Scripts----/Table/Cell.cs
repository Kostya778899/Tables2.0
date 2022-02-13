using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private CellSettings _settings;
    [SerializeField] private List<UiTextDefault> _texts;

    public void Updating(string[] texts)
    {
        if (texts.Length > _texts.Count) CreateTexts(texts.Length - _texts.Count);
        ActiveTexts(texts.Length);

        for (int i = 0; i < texts.Length; i++)
        {
            if (i >= texts.Length)
            {
                _texts.Add(Instantiate(_settings.TextPrefab, transform));
            }
            _texts[i].SetText(texts[i]);
        }
    }

    private void CreateTexts(int count) { for (int i = 0; i < count; i++) _texts.Add(Instantiate(_settings.TextPrefab, transform)); }
    private void ActiveTexts(int count) { for (int i = 0; i < _texts.Count; i++) _texts[i].gameObject.SetActive(i < count); }
}
