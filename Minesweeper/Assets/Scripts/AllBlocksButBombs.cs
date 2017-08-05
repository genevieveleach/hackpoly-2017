using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBlocksButBombs : MonoBehaviour {

	public int row;
	public int column;
	public bool isBomb = false;
	public bool isBelow = false;
	public bool isFlag = false;
	public bool isBlank = false;
	public bool flaggedForDeletion = false;
	public Minesweeper ground;

	// Use this for initialization
	void Start () {
		ground = GameObject.Find ("Ground").GetComponent<Minesweeper> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown (1)) {
			if (!isBelow) {
				if (!isFlag) {
					Destroy (this.gameObject);
					GameObject flag = Instantiate (GameObject.Find ("BlankFlag"), new Vector3 (row * 4, 6, column * 4), Quaternion.Euler (-90, 0, 0));
					flag.GetComponent<AllBlocksButBombs> ().isFlag = true;
					flag.GetComponent<AllBlocksButBombs> ().row = row;
					flag.GetComponent<AllBlocksButBombs> ().column = column;
				} else {
					Destroy (this.gameObject);
					GameObject temp = Instantiate (GameObject.Find ("BlankBlock"), new Vector3 (row * 4, 6, column * 4), Quaternion.Euler (0, 0, 0));
					temp.GetComponent<AllBlocksButBombs> ().row = row;
					temp.GetComponent<AllBlocksButBombs> ().column = column;
					temp.GetComponent<AllBlocksButBombs> ().isBlank = true;
				}
			}
		}
	}
		

	void OnMouseDown() {
		if (!isFlag) {
			GameObject blockBelow = ground.blockMatrix [row, column];
			if (this.gameObject.GetComponent<AllBlocksButBombs> ().isBelow) {
				//Debug.Log ("Is below");
			} else {
			
				if (blockBelow.GetComponent<AllBlocksButBombs> ().isBomb) {
					ground.endGame (row, column);
					//Debug.Log ("Game is Over");
				}
				Debug.Log (blockBelow.GetComponent<AllBlocksButBombs> ().isBomb);
				if (!blockBelow.GetComponent<AllBlocksButBombs> ().isBomb) {
				
				}
				Destroy (this.gameObject);
				DeleteAround ();
			}
		}
	}
	void DeleteAround(){
		if (ground.blockMatrix[row,column].GetComponent<AllBlocksButBombs>().isBlank) {
			flaggedForDeletion = true;
			for (int i = row - 1; i <= row + 1; i++) 
			{
				for (int j = column - 1; j <= column + 1; j++) 
				{
					//if inbounds and value at adj spot is a bomb
					if (i < ground.rowSize && j < ground.colSize && i >= 0 && j >= 0 && !(i == row && j == column) && ground.blankMatrix[i,j] != null)
					{
						if (ground.blockMatrix [i, j].GetComponent<AllBlocksButBombs> ().isBlank && !ground.blankMatrix [i, j].GetComponent<AllBlocksButBombs> ().flaggedForDeletion) {

							ground.blankMatrix [i, j].GetComponent<AllBlocksButBombs> ().DeleteAround ();
						}
						Destroy (ground.blankMatrix [i, j]);
					}
				}
			}
		}
	}
}
