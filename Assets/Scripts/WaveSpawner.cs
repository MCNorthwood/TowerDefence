using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPreFab;

    public Transform spawnPoint;

    public float countdownTimer = 5f;
    private float countdown = 2f;

    public Text countdownText;

    private int waveIndex = 0;

    void Update()
    {
        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = countdownTimer;
        }

        countdown -= Time.deltaTime;

        countdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPreFab, spawnPoint.position, spawnPoint.rotation);
    }
}
