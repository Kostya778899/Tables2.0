using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Table : MonoBehaviour
{
    [SerializeField] private TableDatas _datas;
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private GridLayoutGroup _content;

    [SerializeField] private float _contentWidth = 640f;

    private List<Cell> _cells = new List<Cell>();
    private int _currentPageIndex = 0;
    private int _pagesCount = 1;


    public void SwitchPage(int direction)
    {
        _currentPageIndex += direction;
        _currentPageIndex = Mathf.Clamp(_currentPageIndex, 0, _pagesCount - 1);

        UpdatingPage(_currentPageIndex * _cells.Count);
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        UpdatingContent();
        CreateCells(_datas.ColumnsInPageCount.x * _datas.ColumnsInPageCount.y);

        UpdatingPage(0);

        _pagesCount = _datas.CellsDatas.Count > _cells.Count ? (int)Math.Ceiling((float)_datas.CellsDatas.Count / _cells.Count) : 1;
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
        UpdatingCells(startCellIndex, Mathf.Min(_cells.Count, _datas.CellsDatas.Count - startCellIndex));
    }
    private void UpdatingCells(int startIndex, int count)
    {
        for (int i = 0; i < count; i++) _cells[i].Updating(_datas.CellsDatas[i + startIndex]);
        ActiveCells(count);
    }
}
