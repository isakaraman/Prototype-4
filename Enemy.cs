using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody enemyRigid;
    private Rigidbody playerRigid;
    [SerializeField] private float speed;
    private Text scoreText;
    void Start()
    {
        playerRigid = GameObject.Find("Player").GetComponent<Rigidbody>();

        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    void Update()
    {
        Vector3 lookDirection = (playerRigid.transform.position - enemyRigid.transform.position).normalized;
        enemyRigid.AddForce(lookDirection * speed);

        if (transform.position.y<-10)
        {
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 1);
            int score = PlayerPrefs.GetInt("score");
            scoreText.text="SCORE: " + score;
            Destroy(gameObject);
        }
    }
}
