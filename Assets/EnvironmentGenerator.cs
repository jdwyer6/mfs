using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    public GameObject[] npcs;
    public GameObject[] plants;

    public float extremum = 99;

    public int numOfNPCsToGenerate = 500;
    public int numOfPlants = 500;

    // Start is called before the first frame update
    void Start()
    {
        GenerateNPCs();
        GeneratePlants();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateNPCs() {
        for(int i = 0; i < numOfNPCsToGenerate; i++) {
            float randomX = UnityEngine.Random.Range(-extremum, extremum);
            float randomZ = UnityEngine.Random.Range(-extremum, extremum);
            var newNPC = Instantiate(npcs[UnityEngine.Random.Range(0, npcs.Length)], new Vector3(randomX, 0, randomZ), Quaternion.identity);
        }
    }

    private void GeneratePlants() {
        for(int i = 0; i < numOfPlants; i++) {
            float randomX = UnityEngine.Random.Range(-extremum, extremum);
            float randomZ = UnityEngine.Random.Range(-extremum, extremum);
            var newNPC = Instantiate(plants[UnityEngine.Random.Range(0, npcs.Length)], new Vector3(randomX, 0, randomZ), Quaternion.identity);
        }
    }
}
