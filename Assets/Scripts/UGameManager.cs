using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGameManager : MonoBehaviour
{
	public Cell currentCell, oldCurrentCell;
	public GameObject goTable;
	public Sprite[] numbersSprite = new Sprite[10];

	private SudokuObject solveTable, notSolveTable;
	private Cell[,] cellTable;

	private void Start()
	{
		Debug.Log("Start");
		solveTable = new SudokuObject();
		InitializeTable(solveTable);
	}

	public void InitializeTable(SudokuObject sudObj)
	{
		cellTable = new Cell[9, 9];
		for(int j = 0; j < 9; j++)
		{
			for(int i = 0; i < 9; i++)
			{
				Debug.Log("Cell [" + i.ToString() + j.ToString() + "]" + ") -> " + (cellTable[i, j] != null ? "Ok" : "No"));
				cellTable[i, j] = GameObject.Find("Cell [" + i.ToString() + j.ToString() + "]").GetComponent<Cell>();
				cellTable[i, j].SetPosition(i, j);
				cellTable[i, j].SetValue(sudObj.value[i, j]);
				cellTable[i, j].SetImage(numbersSprite[sudObj.value[i, j]]);
			}
		}
	}

	public void ChangeCurrentCell(Cell c)
	{
		if(currentCell != null) currentCell.image.color = Color.black;
		ViewAlsoCell(Color.black);
		
		currentCell = c;
		currentCell.image.color = Color.yellow;
		ViewAlsoCell(Color.cyan);
	}
	public void ViewAlsoCell(Color clr)
	{
		if (currentCell == null || currentCell.number == 0) return;

		for (int j = 0; j < 9; j++)
		{
			for (int i = 0; i < 9; i++)
			{
				if (currentCell.number == cellTable[i, j].number && currentCell.position != cellTable[i, j].position) cellTable[i, j].image.color = clr;
			}
		}
	}
}
