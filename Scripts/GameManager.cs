using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float respawnDelay = 2f;
    private bool isGameEnding = false; //Basic hali de false zaten.
    private int score = 0;
    public Text scoreText;
    public Text winText;
    public GameObject WinnerUI;
    public AudioSource coinSound;


    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void RespawnPlayer()
    {
        if (isGameEnding == false)
        {
            isGameEnding = true;
            StartCoroutine("RespawnCoroutine");
        }
    }

    public IEnumerator RespawnCoroutine()
    {
        playerController.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //playerController.transform.position = playerController.respawnPoint;
        //playerController.gameObject.SetActive(true);
        isGameEnding = false;
    }

    public void AddScore(int numberOfScore)
    {
        score += numberOfScore;
        coinSound.Play();
        scoreText.text = "Puan: " + score.ToString();
    }

    public void LevelUp()
    {
        WinnerUI.SetActive(true);
        winText.text = "Seviye Tamamlandi Toplam Puan = " + score;
        Invoke("NextLevel", respawnDelay);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
