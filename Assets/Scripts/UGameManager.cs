using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGameManager : MonoBehaviour
{
	public Cell currentCell, oldCurrentCell;
	public GameObject goTable;
	public Sprite[] numbersSprite = new Sprite[10];

	private int[,] table =
	{
		{1, 4, 7, 9, 3, 6, 8, 2, 5 },
		{2, 5, 8, 1, 4, 7, 9, 3, 6 },
		{3, 6, 9, 2, 5, 8, 1, 4, 7 },
		{4, 7, 1, 3, 6, 9, 2, 5, 8 },
		{5, 8, 2, 4, 7, 1, 3, 6, 9 },
		{6, 9, 3, 5, 8, 2, 4, 7, 1 },
		{7, 1, 4, 6, 9, 3, 5, 8, 2 },
		{8, 2, 5, 7, 1, 4, 6, 9, 3 },
		{9, 3, 6, 8, 2, 5, 7, 1, 4 }
	};
	private Cell[,] cellTable;

	private void Start()
	{
		Debug.Log("Start");
		cellTable = new Cell[9, 9];
		for(int j = 0; j < 9; j++)
		{
			for(int i = 0; i < 9; i++)
			{
				Debug.Log("Cell [" + i.ToString() + j.ToString() + "]" + ") -> " + (cellTable[i, j] != null ? "Ok" : "No"));
				cellTable[i, j] = GameObject.Find("Cell [" + i.ToString() + j.ToString() + "]").GetComponent<Cell>();
				cellTable[i, j].SetPosition(i, j);
				cellTable[i, j].SetValue(table[i, j]);
				cellTable[i, j].SetImage(numbersSprite[table[i, j]]);
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
