using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolvingSudoku
{
	public List<SudokuObject> results = new List<SudokuObject>();
	public SolvingSudoku()
	{

	}
	public SudokuObject Solve(SudokuObject sudObj)
	{
		SudokuObject thisSudObj = new SudokuObject(sudObj.value);

		for (int j = 0; j < 9; j++)
		{
			for (int i = 0; i < 9; i++)
			{
				if (thisSudObj.value[i, j] == 0)
				{
					int n;
					for (n = 1; n < 10; n++)
					{
						thisSudObj.SetValue(i, j, n);
						if (CheckFull(i, j, thisSudObj))
						{
							thisSudObj = Solve(thisSudObj);
						}
					}
					if (n == 10)
					{
						thisSudObj.value[i, j] = 0;
						return thisSudObj;
					}
				}
			}
		}
		Debug.Log("!!! FINAL !!!");
		Debug.Log(thisSudObj);
		results.Add(thisSudObj);
		return sudObj;
	}
	public bool CheckFull(int x, int y, SudokuObject sudObj)
	{
		return CheckOnVertical(x, sudObj) && CheckOnHorizontal(y, sudObj) && CheckOnSquare(x / 3, y / 3, sudObj);
	}
	public bool CheckOnVertical(int x, SudokuObject sudObj)
	{
		for (int i = 0; i < 8; i++)
		{
			if (sudObj.value[x, i] == 0) continue;
			for (int j = i + 1; j < 9; j++)
			{
				if (sudObj.value[x, i] == sudObj.value[x, j]) return false;
			}
		}
		return true;
	}
	public bool CheckOnHorizontal(int y, SudokuObject sudObj)
	{
		for (int i = 0; i < 8; i++)
		{
			if (sudObj.value[i, y] == 0) continue;
			for (int j = i + 1; j < 9; j++)
			{
				if (sudObj.value[i, y] == sudObj.value[j, y]) return false;
			}
		}
		return true;
	}
	public bool CheckOnSquare(int sx, int sy, SudokuObject sudObj)
	{
		for (int j = 0; j < 3; j++)
		{
			for (int i = 0; i < 3; i++)
			{
				if (sudObj.value[sx * 3 + i, sy * 3 + j] == 0) continue;
				for (int k = 0; k < 3; k++)
				{
					for (int l = 0; l < 3; l++)
					{
						if (sudObj.value[sx * 3 + i, sy * 3 + j] == sudObj.value[sx * 3 + k, sy * 3 + l] && (i != k || j != l)) return false;
					}
				}
			}
		}
		return true;
	}
}
