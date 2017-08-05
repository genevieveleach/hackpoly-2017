using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterBlock : MonoBehaviour {

	public int row;
	public int column;
	public bool isBomb = true;
	public bool isBelow = true;

	BetterBlock(int r, int c) {
		row = r;
		column = c;
	}
}
