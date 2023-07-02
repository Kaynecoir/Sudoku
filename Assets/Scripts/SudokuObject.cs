using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuObject
{
	public int[,] value =
	{
		{1, 4, 7, 9, 3, 6, 8, 2, 5 },		//	1 2 3 4 5 6 7 8 9
		{2, 5, 8, 1, 4, 7, 9, 3, 6 },		//	4 5 6 7 8 9 1 2 3	//	{			//	
		{3, 6, 9, 2, 5, 8, 1, 4, 7 },		//	7 8 9 1 2 3 4 5 6	//	  {1 . .}	//	1 2 3	//
		{4, 7, 1, 3, 6, 9, 2, 5, 8 },		//	9 1 2 3 4 5 6 7 8	//	  {2 . .}	//	. . .	//	value[0-3, 0]
		{5, 8, 2, 4, 7, 1, 3, 6, 9 },		//	3 4 5 6 7 8 9 1 2	//	  {3 . .}	//	. . .	//	value[x  , y]
		{6, 9, 3, 5, 8, 2, 4, 7, 1 },		//	6 7 8 9 1 2 3 4 5	//	}			//			//		  i	   j
		{7, 1, 4, 6, 9, 3, 5, 8, 2 },		//	8 9 1 2 3 4 5 6 7
		{8, 2, 5, 7, 1, 4, 6, 9, 3 },		//	2 3 4 5 6 7 8 9 1
		{9, 3, 6, 8, 2, 5, 7, 1, 4 }		//	5 6 7 8 9 1 2 3 4
	};
	public SudokuObject()
	{ 
	
	}
	public SudokuObject(int[,] array)
	{
		value = array;
	}
	private void SwapVerticalLine(int indexLine1, int indexLine2)
	{
		if (indexLine1 > 2 || indexLine1 < 0 || indexLine2 > 2 || indexLine2 < 0) return;
		for(int j = 0; j < 9; j++)
		{
			value[indexLine1, j] = value[indexLine1, j] + value[indexLine2, j];
			value[indexLine2, j] = value[indexLine1, j] - value[indexLine2, j];
			value[indexLine1, j] = value[indexLine1, j] - value[indexLine2, j];
		}
	}
	private void SwapVerticalLines(int indexLines1, int indexLines2)
	{
		if (indexLines1 > 2 || indexLines1 < 0 || indexLines2 > 2 || indexLines2 < 0) return;
		for (int j = 0; j < 9; j++)
		{
			for(int k = 0; k < 3; k++)
			{
				value[indexLines1 + k, j] = value[indexLines1 + k, j] + value[indexLines2 + k, j];
				value[indexLines2 + k, j] = value[indexLines1 + k, j] - value[indexLines2 + k, j];
				value[indexLines1 + k, j] = value[indexLines1 + k, j] - value[indexLines2 + k, j];
			}
		}
	}
	private void SwapHorizontalLine(int indexLine1, int indexLine2)
	{
		if (indexLine1 > 2 || indexLine1 < 0 || indexLine2 > 2 || indexLine2 < 0) return;
		for (int i = 0; i < 9; i++)
		{
			value[i, indexLine1] = value[i, indexLine1] + value[i, indexLine2];
			value[i, indexLine2] = value[i, indexLine1] - value[i, indexLine2];
			value[i, indexLine1] = value[i, indexLine1] - value[i, indexLine2];
		}
	}
	private void SwapHorizontalLines(int indexLines1, int indexLines2)
	{
		if (indexLines1 > 2 || indexLines1 < 0 || indexLines2 > 2 || indexLines2 < 0) return;
		for (int i = 0; i < 9; i++)
		{
			for (int k = 0; k < 3; k++)
			{
				value[i, indexLines1 + k] = value[i, indexLines1 + k] + value[i, indexLines2 + k];
				value[i, indexLines2 + k] = value[i, indexLines1 + k] - value[i, indexLines2 + k];
				value[i, indexLines1 + k] = value[i, indexLines1 + k] - value[i, indexLines2 + k];
			}
		}
	}
	public void RandomSelf(int cycle = 0)
	{
		for (int i = 0; i < cycle; i++)
		{
			int ch = (int)Random.Range(0, 4);
			int l1 = (int)Random.Range(0, 2);
			int l2 = (int)Random.Range(0, 2);
			Debug.Log(ch.ToString() + " " + l1.ToString() + " " + l2.ToString());
			switch (ch)
			{
				case 0:
					SwapVerticalLine(l1, l2);
					break;
				case 1:
					SwapVerticalLines(l1, l2);
					break;
				case 2:
					SwapHorizontalLine(l1, l2);
					break;
				case 3:
					SwapHorizontalLines(l1, l2);
					break;
			}
		}

	}
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
	public override string ToString()
	{
		string ret = "";
		for(int i = 0; i < 9; i++)
		{
			for(int j = 0; j < 9; j++)
			{
				ret = ret + value[i, j] + " ";
			}
			ret = ret + "\n";
		}
		return ret;
	}
}
