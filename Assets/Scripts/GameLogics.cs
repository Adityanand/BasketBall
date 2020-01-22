using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogics : MonoBehaviour
{
    [Header("BasketBall")]
    public GameObject Basketball;
    public GameObject BasketBallPerfab;
    public Transform SpawnPosition;
    public int i;
    public int Retries;
    [Header("UI")]
    public int score;
    public Canvas GameOver;
    public Text ScoreText;
    public Image[] BasketballUI;
    public Text GameOverScoreText;
    [Header("Scene")]
    public string RestartScene;
    public string NextLevel;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        Retries = 3;
        ScoreText.text = "00";
        StartCoroutine(SpawnBasketball());
    }

    // Update is called once per frame

    IEnumerator SpawnBasketball()
    {
        Basketball = GameObject.FindGameObjectWithTag("Basketball");
        yield return new WaitForSeconds(.5f);

       if (Retries != 0 && Basketball == null)
        {
            BasketballUI[i].enabled = false;
            i++;
            Retries--;
            Instantiate(BasketBallPerfab, SpawnPosition.position, Quaternion.identity);
            yield return new WaitForSeconds(.5f);

        }
        else if (Retries == 0 && Basketball == null)
        {
            GameOver.enabled = true;
            GameOverScoreText.text = score.ToString();
        }
        StartCoroutine(SpawnBasketball());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Basketball")
        {
            score = score + 5;
            if (score > 10)
                ScoreText.text = ("0" + score);
            else
                ScoreText.text = (score.ToString());
        }
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }
    public void OnClickRestart()
    {
        SceneManager.LoadScene(RestartScene);
    }
    public void OnClickNextLevel()
    {
        SceneManager.LoadScene(NextLevel);
    }
}

