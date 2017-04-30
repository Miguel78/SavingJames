using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TileManager : MonoBehaviour {
	public GameObject[] tilePrefabs;
	public float tileLength;
	public int amnTilesOnScreen;
	public float spawnDistanceFromPlayer;

	//Variables
	private float spawnZ = 0;
	private Transform playerTransform;
	private int lastPrefabIndex = 0;
	
	private List<GameObject> activeTiles; 
	
	// Inicializacion
	private void Start () {
		activeTiles = new List<GameObject>();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		
		for (int i = 0; i < amnTilesOnScreen; i++) 
		{
			if (i < 2)
				SpawnTile (0);
			else
				SpawnTile();
		}
		
	}
	
	// Update is called once per frame
	private void Update () {
		if (playerTransform.position.z > spawnZ - (amnTilesOnScreen - 1) * tileLength) {
			SpawnTile ();
			DeleteTile();
		}
	}
	//Activar Tiles
	private void SpawnTile(int prefabIndex = -1)
	{
		GameObject go;
		if(prefabIndex == -1)
			go = Instantiate (tilePrefabs [RandomPrefabIndex()]) as GameObject;
		else
			go = Instantiate (tilePrefabs [prefabIndex]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
		activeTiles.Add (go);
	}
	//Eliminar Tiles
	private void DeleteTile()
	{
		Destroy (activeTiles [0]);
		activeTiles.RemoveAt (0);
	}
	
	//Tiles Random
	
	private int  RandomPrefabIndex()
	{
		if (tilePrefabs.Length <= 1)
			return 0;
		int randomIndex = lastPrefabIndex;
		while (randomIndex == lastPrefabIndex) 
		{
			randomIndex = Random.Range(0,tilePrefabs.Length);
		}
		lastPrefabIndex = randomIndex;
		return randomIndex;
	}
}	