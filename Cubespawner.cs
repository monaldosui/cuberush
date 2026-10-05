using UnityEngine;

public class Cubespawner : MonoBehaviour
{
    public GameObject blueCube;
    public GameObject redCube;

    public void SpawnCube()
    {
        float x = Random.Range(-13.0f, 13.0f);
        float y = Random.Range(1f, 1f);
        float z = Random.Range(-8.0f, 8.0f);

        Vector3 spawnPosition = transform.position + new Vector3(x, y, z);

        if (Random.value < 0.5f)
        {
            Instantiate(blueCube, spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(redCube, spawnPosition, Quaternion.identity);
        }

        Debug.Log("A new cube spawned!");
    }
    

    private void Start()
    {
        SpawnCube();
    }
}