using System;
using System.Collections;
using System.Collections.Generic;
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

    private List<Cell> _cells = new List<Cell>();
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
        int columnsCount = _datasContainer.Datas.CellsDatas.Count / _datasContainer.Datas.ColumnsInPageCount.x;
        int[] columnsDifferences = new int[columnsCount];
        for (int i = 0; i < columnsDifferences.Length; i++) columnsDifferences[i] = -1;

        for (int i = 0; i < columnsCount; i++)
        {
            for (int i0 = 0; i0 < _datasContainer.Datas.ColumnsInPageCount.x; i0++)
            {
                columnsDifferences[i] = Math.Max(columnsDifferences[i], _datasContainer.Datas.CellsDatas[i + i0].Texts[0].IndexOf(value));
            }
        }

        for (int i = 0; i < columnsDifferences.Length; i++)
        {
            Debug.Log(columnsDifferences[i]);
        }
    }

    private void Start()
    {
        Initialize();
    }

    private async void Initialize()
    {
        _datasContainer.Datas = await _datasLoader.Get();

        UpdatingContent();
        CreateCells(_datasContainer.Datas.ColumnsInPageCount.x * _datasContainer.Datas.ColumnsInPageCount.y);

        UpdatingPage(0);

        _pagesCount = _datasContainer.Datas.CellsDatas.Count > _cells.Count ?
            (int)Math.Ceiling((float)_datasContainer.Datas.CellsDatas.Count / _cells.Count) : 1;
    }

    private void UpdatingContent()
    {
        _content.constraintCount = _datasContainer.Datas.ColumnsInPageCount.x;
        _content.cellSize = new Vector2(_contentWidth / _datasContainer.Datas.ColumnsInPageCount.x, _content.cellSize.y);
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
        UpdatingCells(startCellIndex, Mathf.Min(_cells.Count, _datasContainer.Datas.CellsDatas.Count - startCellIndex));
    }
    private void UpdatingCells(int startIndex, int count)
    {
        for (int i = 0; i < count; i++) _cells[i].Updating(_datasContainer.Datas.CellsDatas[i + startIndex]);
        ActiveCells(count);
    }
}
