using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuObject
{
	public int[,] value = new int[9, 9];

	public static bool operator ==(SudokuObject a, SudokuObject b)
	{
		for(int i = 0; i < 9; i++)
		{
			for(int j = 0; j < 9; j++)
			{
				if (a.value[i, j] != b.value[i, j]) return false;
			}
		}
		return true;
	}
	public static bool operator !=(SudokuObject a, SudokuObject b)
	{
		return !(a == b);
	}
}
