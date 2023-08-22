using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject[] powerupPrefabs;

    private float spawnRange = 9f;

    [SerializeField] private int enemyCount;

    [SerializeField] private int enemyWave=1;

    [SerializeField] private GameObject bossbattleText;
    private bool bossBool;
    void Start()
    {
        int randomPowerup = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(),
        powerupPrefabs[randomPowerup].transform.rotation);

        spawnEnemyWave(enemyWave);

        PlayerPrefs.SetInt("score",0);
    }
    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount==0)
        {
            enemyWave++;
            spawnEnemyWave(enemyWave);
            int randomPowerup = Random.Range(0, powerupPrefabs.Length);
            Instantiate(powerupPrefabs[randomPowerup], GenerateSpawnPosition(),
            powerupPrefabs[randomPowerup].transform.rotation);

        }
        if (GameObject.FindObjectsOfType<BossEnemy>().Length>0 && !bossBool)
        {
            bossbattleText.SetActive(true);
            StartCoroutine(BossEnumator());
            bossBool = true;

        }
        else if (GameObject.FindObjectsOfType<BossEnemy>().Length == 0)
        {
            bossBool = false;
        }
    }

    IEnumerator BossEnumator()
    {
        yield return new WaitForSeconds(3);
        bossbattleText.SetActive(false);
    }
    
    void spawnEnemyWave(int spawnRate)
    {
        for (int i = 0; i < spawnRate; i++)
        {
            int randomEnemy = Random.Range(0, 5);
            Instantiate(enemy[randomEnemy], GenerateSpawnPosition(), Quaternion.identity);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnY = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(spawnX, 0, spawnY);

        return spawnPos;
    }
}
