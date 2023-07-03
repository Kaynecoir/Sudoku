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
	public SudokuObject(SudokuObject sudObj)
	{
		value = sudObj.value;
	}
	public void SetValue(int x, int y, int val)
	{
		value[x, y] = val;
	}
	private bool SwapVerticalLine(int indexLine1, int indexLine2, int multipleLine)
	{
		if (indexLine1 > 2 || indexLine1 < 0 || indexLine2 > 2 || indexLine2 < 0 || multipleLine > 2 || multipleLine < 0 || indexLine1 == indexLine2) return false;
		for(int j = 0; j < 9; j++)
		{
			value[indexLine1 + multipleLine * 3, j] = value[indexLine1 + multipleLine * 3, j] + value[indexLine2 + multipleLine * 3, j];
			value[indexLine2 + multipleLine * 3, j] = value[indexLine1 + multipleLine * 3, j] - value[indexLine2 + multipleLine * 3, j];
			value[indexLine1 + multipleLine * 3, j] = value[indexLine1 + multipleLine * 3, j] - value[indexLine2 + multipleLine * 3, j];
		}
		return true;
	}
	private bool SwapVerticalLines(int indexLines1, int indexLines2)
	{
		if (indexLines1 > 2 || indexLines1 < 0 || indexLines2 > 2 || indexLines2 < 0 || indexLines1 == indexLines2) return false;
		for (int j = 0; j < 9; j++)
		{
			for(int k = 0; k < 3; k++)
			{
				value[indexLines1 * 3 + k, j] = value[indexLines1 * 3 + k, j] + value[indexLines2 * 3 + k, j];
				value[indexLines2 * 3 + k, j] = value[indexLines1 * 3 + k, j] - value[indexLines2 * 3 + k, j];
				value[indexLines1 * 3 + k, j] = value[indexLines1 * 3 + k, j] - value[indexLines2 * 3 + k, j];
			}
		}
		return true;
	}
	private bool SwapHorizontalLine(int indexLine1, int indexLine2, int multipleLine)
	{
		if (indexLine1 > 2 || indexLine1 < 0 || indexLine2 > 2 || indexLine2 < 0 || multipleLine > 2 || multipleLine < 0 || indexLine1 == indexLine2) return false;
		for (int i = 0; i < 9; i++)
		{
			value[i, indexLine1 + multipleLine * 3] = value[i, indexLine1 + multipleLine * 3] + value[i, indexLine2 + multipleLine * 3];
			value[i, indexLine2 + multipleLine * 3] = value[i, indexLine1 + multipleLine * 3] - value[i, indexLine2 + multipleLine * 3];
			value[i, indexLine1 + multipleLine * 3] = value[i, indexLine1 + multipleLine * 3] - value[i, indexLine2 + multipleLine * 3];
		}
		return true;
	}
	private bool SwapHorizontalLines(int indexLines1, int indexLines2)
	{
		if (indexLines1 > 2 || indexLines1 < 0 || indexLines2 > 2 || indexLines2 < 0 || indexLines1 == indexLines2) return false;
		for (int i = 0; i < 9; i++)
		{
			for (int k = 0; k < 3; k++)
			{
				value[i, indexLines1 * 3 + k] = value[i, indexLines1 * 3 + k] + value[i, indexLines2 * 3 + k];
				value[i, indexLines2 * 3 + k] = value[i, indexLines1 * 3 + k] - value[i, indexLines2 * 3 + k];
				value[i, indexLines1 * 3 + k] = value[i, indexLines1 * 3 + k] - value[i, indexLines2 * 3 + k];
			}
		}
		return true;
	}
	public void RandomSelf(int cycle = 0)
	{
		Debug.Log(this.ToString());
		int ch = -1, old_ch;
		for (int i = 0; i < cycle;)
		{
			old_ch = ch;
			ch = (int)Random.Range(0, 4);
			if (ch == old_ch) continue;
			int l1 = (int)Random.Range(0, 2);
			int l2 = (int)Random.Range(0, 2);
			int ex = (int)Random.Range(0, 2);
			if (l1 == l2) continue;
			Debug.Log(i.ToString() + " " + ch.ToString() + " " + l1.ToString() + " " + l2.ToString());
			switch (ch)
			{
				case 0:
					if(SwapVerticalLine(l1, l2, ex)) i++;
					break;
				case 1:
					if(SwapVerticalLines(l1, l2)) i++;
					break;
				case 2:
					if(SwapHorizontalLine(l1, l2, ex)) i++;
					break;
				case 3:
					if(SwapHorizontalLines(l1, l2)) i++;
					break;
			}
			Debug.Log(this.ToString());
		}
	}
	public static SudokuObject operator *(SudokuObject a, SudokuObject b)
	{
		SudokuObject t = new SudokuObject();
		for(int i = 0; i < 9; i++)
		{
			for(int j = 0; j < 9; j++)
			{
				t.value[i, j] = a.value[i, j] * b.value[i, j];
			}
		}
		return t;
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
		for(int j = 0; j < 9; j++)
		{
			for(int i = 0; i < 9; i++)
			{
				ret = ret + value[i, j] + " ";
				if ((i + 1) % 3 == 0) ret = ret + "| ";
			}
			ret = ret + "\n";
			if ((j + 1) % 3 == 0) ret = ret + "-----+-----+-----\n";
		}
		return ret;
	}
}
