using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
    [SerializeField] private TableDatasContainer _datasContainer;
    [SerializeField] private TableDatasLoaderDefault _datasLoader;
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private GridLayoutGroup _content;

    [SerializeField] private float _contentWidth = 640f;
    [SerializeField] private Color _matchedCharsColor = Color.blue;
    [SerializeField] private string _datasJson = "";

    private List<Cell> _cells = new List<Cell>();
    private List<List<string>> _cellsTexts = new List<List<string>>();
    private TableDatas _datas;
    private int _currentPageIndex = 0;
    private int _pagesCount = 1;


    public void SwitchPage(int direction)
    {
        _currentPageIndex += direction;
        _currentPageIndex = Mathf.Clamp(_currentPageIndex, 0, _pagesCount - 1);

        UpdatingPage(_currentPageIndex * _cells.Count);
    }

    public void SortByMatch(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            ResetDatas();
        }
        else
        {
            int[] columnsDifferences = new int[_datasContainer.Datas.Texts.Count];
            for (int i = 0; i < columnsDifferences.Length; i++) columnsDifferences[i] = -1;

            for (int i = 0; i < columnsDifferences.Length; i++)
            {
                columnsDifferences[i] = Math.Max(columnsDifferences[i], _cellsTexts[i].IndexOf(value));
                if (columnsDifferences[i] >= 0)
                {
                    _cellsTexts[i][0] = _cellsTexts[i][0]
                        .Insert(value.Length, ">*")
                        .Insert(columnsDifferences[i], "*<");

                    Debug.Log(_cellsTexts[i]);
                    Debug.Log(columnsDifferences[i]);
                }
            }
        }

        UpdatingPage(0);
    }

    private void Start()
    {
        Initialize();
    }

    private async void Initialize()
    {
        _datasContainer.LoadDatas(_datasJson);
        _datasContainer.Datas = await _datasLoader.Get();
        ResetDatas();

        UpdatingContent();
        CreateCells(_datas.ColumnsInPageCount.x * _datas.ColumnsInPageCount.y);

        UpdatingPage(0);

        _pagesCount = _datas.Texts.Count > _cells.Count ?
            (int)Math.Ceiling((float)_datas.Texts.Count / _cells.Count) : 1;
    }
    private void ResetDatas()
    {
        _datas = _datasContainer.Datas;
        _cellsTexts = new List<List<string>>(_datas.Texts.Count);
        for (int y = 0; y < _datas.Texts.Count; y++)
        {
            _cellsTexts.Add(new List<string>(_datas.Texts[y].Count));
            for (int x = 0; x < _datas.Texts[y].Count; x++)
            {
                _cellsTexts[y].Add(_datas.Texts[y][x]);
            }
        }
    }

    private void UpdatingContent()
    {
        _content.constraintCount = _datas.ColumnsInPageCount.x;
        _content.cellSize = new Vector2(_contentWidth / _datas.ColumnsInPageCount.x, _content.cellSize.y);
    }
    private void CreateCells(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var cell = Instantiate(_cellPrefab, _content.transform).GetComponent<Cell>();
            _cells.Add(cell);
        }
    }
    private void ActiveCells(int count)
    {
        for (int i = 0; i < _cells.Count; i++) _cells[i].gameObject.SetActive(i < count);
    }

    private void UpdatingPage(int startCellIndex)
    {
        UpdatingCells(startCellIndex, Mathf.Min(_cells.Count, _datas.Texts.Count - startCellIndex));
    }
    private void UpdatingCells(int startIndex, int count)
    {
        ActiveCells(count);
        for (int i = 0; i < count; i++)
            _cells[i].Updating(_cellsTexts[i].ToArray());
    }
}
