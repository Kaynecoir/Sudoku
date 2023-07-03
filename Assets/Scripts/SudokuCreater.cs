using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuCreater
{
	public SudokuObject origin;
	public int hard;
	public SolvingSudoku solvSud;
    public SudokuCreater(SudokuObject sudObj, int userHard)
	{
		origin = new SudokuObject(sudObj);
		hard = userHard;
	}

	public SudokuObject Create()
	{
		SudokuObject pastSud = new SudokuObject(origin);
		for (int h = 0; h < hard; h++)
		{
			int rx = (int)Random.Range(0, 9), ry = (int)Random.Range(0, 9);
			if (pastSud.value[rx, ry] == 0)
			{
				h--;
				continue;
			}
			pastSud.SetValue(rx, ry, 0);
			solvSud = new SolvingSudoku();

			solvSud.Solve(pastSud);
			if (solvSud.results.Count == 1)
			{
				origin.value = pastSud.value;
			}
			else
			{
				pastSud.value = origin.value;
				h--;
			}
		}


		return pastSud;
	}


}
