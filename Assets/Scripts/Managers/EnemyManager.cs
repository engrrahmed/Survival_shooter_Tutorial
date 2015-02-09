using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
//	int index = 0;

    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
		if(playerHealth.currentHealth <= 0f )//|| index >= 1
		{
			return;
        }
		//index += 1;
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
