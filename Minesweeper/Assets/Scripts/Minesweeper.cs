using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



	// Use this for initialization
public class Minesweeper : MonoBehaviour {
		public int rowSize = 50;
		public int colSize = 50;
	private int numBombs;
	private int[,] matrix;
	public GameObject[,] blockMatrix ;
	public GameObject[,] blankMatrix;
	private static int X_ROT = 0;
	private static int Y_ROT = 90;
	private static int Z_ROT = 0;
	//private GameObject BlankBlock, Block1, Block2, Block3, Block4, Block5, Block6, Block7, Block;

		// Use this for initialization
		void Start () 
		{
			numBombs = (rowSize * colSize)/8;
			matrix = new int[rowSize,colSize];
			blockMatrix = new GameObject[rowSize, colSize];
			blankMatrix = new GameObject[rowSize, colSize];
			makeMatrix ();

			for (int i = 0; i < rowSize; i++) {
				for (int j = 0; j < colSize; j++) {
				//Debug.Log (matrix [i, j]);
					switch (matrix [i, j]) {
				case 0:
					blockMatrix [i, j] = Instantiate (GameObject.Find ("BlankBlock"), new Vector3 (i * 4, 2, j * 4), Quaternion.Euler (X_ROT, Y_ROT, Z_ROT));
					blockMatrix [i, j].GetComponent<AllBlocksButBombs> ().isBlank = true;
						break;
					case 1:
					blockMatrix [i, j] = Instantiate (GameObject.Find("Block1"), new Vector3 (i * 4, 2, j * 4), Quaternion.Euler (X_ROT, Y_ROT, Z_ROT));

						break;
					case 2:
					blockMatrix [i, j] = Instantiate (GameObject.Find("Block2"), new Vector3 (i * 4, 2, j * 4), Quaternion.Euler (X_ROT, Y_ROT, Z_ROT));

						break;
					case 3:
					blockMatrix [i, j] = Instantiate (GameObject.Find("Block3"), new Vector3 (i * 4, 2, j * 4), Quaternion.Euler (X_ROT, Y_ROT, Z_ROT));

						break;
					case 4:
					blockMatrix [i, j] = Instantiate (GameObject.Find("Block4"), new Vector3 (i * 4, 2, j * 4), Quaternion.Euler (X_ROT, Y_ROT, Z_ROT));

						break;
					case 5:
					blockMatrix [i, j] = Instantiate (GameObject.Find("Block5"), new Vector3 (i * 4, 2, j * 4), Quaternion.Euler (X_ROT, Y_ROT, Z_ROT));

						break;
					case 6:
					blockMatrix [i, j] = Instantiate (GameObject.Find("Block6"), new Vector3 (i * 4, 2, j * 4), Quaternion.Euler (X_ROT, Y_ROT, Z_ROT));

						break;
					case 7:
					blockMatrix [i, j] = Instantiate (GameObject.Find("Block7"), new Vector3 (i * 4, 2, j * 4), Quaternion.Euler (X_ROT, Y_ROT, Z_ROT));

						break;
					case 8:
					blockMatrix [i, j] = Instantiate (GameObject.Find("Block8"), new Vector3 (i * 4, 2, j * 4), Quaternion.Euler (X_ROT, Y_ROT, Z_ROT));

						break;
				default:
					blockMatrix [i, j] = Instantiate (GameObject.Find ("BlockBomb"), new Vector3 (i * 4, 2, j * 4), Quaternion.Euler (X_ROT, Y_ROT, Z_ROT));
					blockMatrix [i, j].GetComponent<AllBlocksButBombs> ().isBomb = true;
						break;
					}
				blockMatrix [i, j].GetComponent<AllBlocksButBombs> ().row = i;
				blockMatrix [i, j].GetComponent<AllBlocksButBombs> ().column = j;
				blockMatrix [i, j].GetComponent<AllBlocksButBombs> ().isBelow = true;
				}
			}
			for (int i = 0; i < rowSize; i++) {
				for (int j = 0; j < colSize; j++) {
					blankMatrix[i,j] = Instantiate (GameObject.Find("BlankBlock"), new Vector3 (i * 4, 6, j * 4), Quaternion.Euler (X_ROT, Y_ROT, Z_ROT));
				blankMatrix [i, j].GetComponent<AllBlocksButBombs> ().row = i;
				blankMatrix [i, j].GetComponent<AllBlocksButBombs> ().column = j;
				blankMatrix [i, j].GetComponent<AllBlocksButBombs> ().isBlank = true;
				}
			}
			for (int i = 1; i < 4; i++) {
				for(int j = 0; j < rowSize; j++){
					Instantiate (GameObject.Find("BlockWall"), new Vector3 ( -4, i * 4 + 2, j * 4), Quaternion.Euler (90, 0, Z_ROT));
					Instantiate (GameObject.Find("BlockWall"), new Vector3 ( j * 4, i * 4 + 2, -4), Quaternion.Euler (90, 0, Z_ROT));
					Instantiate (GameObject.Find("BlockWall"), new Vector3 ( rowSize * 4 , i * 4 + 2, j * 4), Quaternion.Euler (90, 0, Z_ROT));
					Instantiate (GameObject.Find("BlockWall"), new Vector3 ( j * 4, i * 4 + 2, rowSize * 4), Quaternion.Euler (90, 0, Z_ROT));
			}
		}
	}


	// Update is called once per frame
	void Update () {
		//nothing so far
		if (Input.GetMouseButtonDown (0)) {
			//Debug.Log ("Button Pressed");
		}
	}


	//private functions

	//make matrix
	void makeMatrix()
	{

		//basic bomb placement
		/*
        for (int r = 0; r < rowSize; r++) 
        {
            for (int c = 0; c < colSize; c++) 
            {
                //0 <= matrix [r, c] <= 10
                matrix [r, c] = (int)(Random.Range(0,10));
            }
        }
        */

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
			while (matrix [r, c] == 10) {
				r = (int)(Random.Range (0, rowSize - 1));
				c = (int)(Random.Range (0, colSize - 1));
			}
			matrix [r, c] = 10;
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

	public void endGame (int row, int col){
		//blankMatrix [row, col].GetComponent<ParticleSystem> ().Play();
		Instantiate (GameObject.Find ("Fat Man"), new Vector3 (4 * row, 6, col * 4), Quaternion.Euler (X_ROT, Y_ROT, Z_ROT));
		Instantiate (GameObject.Find ("Little Boy"), new Vector3 (4 * row, 6, col * 4), Quaternion.Euler (X_ROT, Y_ROT, Z_ROT));
		GameObject a = Instantiate (GameObject.Find ("ExplosionSound"), new Vector3 (4 * row, 6, col * 4), Quaternion.Euler (X_ROT, Y_ROT, Z_ROT));
		a.GetComponent<AudioSource>().Play ();
		Destroy (blankMatrix [row, col]);
		//GameObject.Find ("Canvas").GetComponent<Animator> ().Play("GameOver");
		foreach(GameObject block in blankMatrix){
			if (block != null) {
				Destroy (block);
			}
		}

		
	}
		

}

