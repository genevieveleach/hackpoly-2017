﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class newScript : MonoBehaviour {
	private const int rowSize = 10;
	private const int colSize = 10;
	private const int numBombs = (rowSize * colSize)/2;

	private int[,] matrix = new int[rowSize,colSize];
	private GameObject[,] objs = new GameObject[rowSize,colSize];

	// Use this for initialization
	void Start () 
	{
		makeMatrix ();


		for (int r = 0; r < rowSize; r++) 
		{
			for (int c = 0; c < colSize; c++) {

				int x = 4*r;
				int y = 2;
				int z = 4*c;
				//0 <= matrix [r, c] <= 10
				int value = matrix [r, c];
				Quaternion quat = new Quaternion ();
				switch (value) {
				case(0):
					objs [r, c] = Instantiate (GameObject.Find("BlankBlock"), new Vector3 (x, y, z),quat);
					break;
				case(1):
					objs [r, c] = Instantiate (GameObject.Find("Block1"), new Vector3 (x, y, z),quat);
					break;
				case(2):
					objs [r, c] = Instantiate (GameObject.Find("Block2"), new Vector3 (x, y, z),quat);
					break;
				case(3):
					objs [r, c] = Instantiate (GameObject.Find("Block3"), new Vector3 (x, y, z),quat);
					break;
				case(4):
					objs [r, c] = Instantiate (GameObject.Find("Block4"), new Vector3 (x, y, z),quat);
					break;
				case(5):
					objs [r, c] = Instantiate (GameObject.Find("Block5"), new Vector3 (x, y, z),quat);
					break;
				case(6):
					objs [r, c] = Instantiate (GameObject.Find("Block6"), new Vector3 (x, y, z),quat);
					break;
				case(7):
					objs [r, c] = Instantiate (GameObject.Find("Block7"), new Vector3 (x, y, z),quat);
					break;
				case(8):
					objs [r, c] = Instantiate (GameObject.Find("Block8"), new Vector3 (x, y, z),quat);
					break;
				case(10):
					objs [r, c] = Instantiate (GameObject.Find("Bomb"), new Vector3 (x, y, z),quat);
					break;
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		//nothing so far
	}


	//private functions

	//make matrix
	void makeMatrix()
	{
		//attempt at making bombs
		bombs();
		//put the numbers
		numberfy();
	}

	//puts bombs randomly in matrix
	void bombs()
	{
		int r, c;
		for (int i = 0; i < numBombs; i++)
		{
			//get a random row and col
			// 0 <= r <= rowSize - 1
			r = (int)(Random.Range (0, rowSize - 1));
			// 0 <= c <= colSize - 1
			c = (int)(Random.Range (0, colSize - 1));

			int temp = matrix [r, c];
			if (temp != 10)
				matrix [r, c] = 10;
			else
				i--;
		}
	}

	void numberfy()
	{
		for (int r = 0; r < rowSize; r++) 
		{
			for (int c = 0; c < colSize; c++) 
			{
				//if not a bomb
				if (matrix [r, c] != 10) 
				{
					matrix [r, c] = countAdjBombs(r,c);
				}
			}
		}
	}

	int countAdjBombs(int r, int c)
	{
		int val = 0;
		for (int i = r - 1; i <= r + 1; i++) 
		{
			for (int j = c - 1; j <= c + 1; j++) 
			{
				//if inbounds and value at adj spot is a bomb
				if (i < rowSize && i >= 0 && j < colSize && j >= 0 && matrix[i,j] == 10) 
				{
					val++;
				}
			}
		}
		return val;
	}
}