using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const float spawnRadius = 50f;
    public GameObject player;
    public GameObject[] obstacles;
    public GameObject powerUp;
    public GameObject gameOverScreen;
    public Text scoreText;
    public Text GameOverText;
    public Text highScoreText;
    public Text GameOverHiText;
    public int noOfObstacles=0;
    public int noOfBGElements=0;
    public int selectedGun;
    int score;
    public float nextPowerup;
    public bool spawnPowerup;
    public Color[] colors;
    // Start is called before the first frame update
    void Start()
    {
        nextPowerup = 0;
        spawnPowerup = true;
        gameOverScreen.SetActive(false);
        score = 0;
        scoreText.text = "0";
        highScoreText.text=highScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(noOfObstacles<0)
        {
            noOfObstacles = 0;
        }
        if(noOfObstacles<5)
        {
            spawnObstacle();
        }
        if (spawnPowerup&&Time.time>nextPowerup)
        {
            spawnPowerUp();
            spawnPowerup = false;
        }
       
    }

    private void spawnPowerUp()
    {
            Vector3 point = (Random.insideUnitSphere * spawnRadius) + player.transform.position;
            point.z = 0f;
            GameObject obstacle = Instantiate(powerUp, point, Quaternion.identity);
            PowerUp p = obstacle.GetComponent<PowerUp>();
            p.player = player;
            p.gameManager = this;
            int gun;
            do
            {
                gun = Random.Range(0, 3);
            } while (gun == selectedGun);
            p.gunNo = gun;
            p.GetComponent<SpriteRenderer>().color = colors[gun];
    }

    private void spawnObstacle()
    {
        Vector3 point = (Random.insideUnitSphere * spawnRadius) + player.transform.position;
        point.z = 0f;
        GameObject obstacle = Instantiate(obstacles[0], point,Quaternion.identity);
        Enemy e = obstacle.GetComponent<Enemy>();
        e.player = player;
        e.speed = 3f;
        e.gameManager = this;
        noOfObstacles++;
    }
    public void AddScore(int points)
    {
        score+=points;
        scoreText.text = score.ToString();
        highScoreText.text = highScore().ToString();
    }
    public string GetScore()
    {
        return score==0?"Better Luck Next Time":"You Scored:"+score.ToString();
    }
    public string GetHighScore()
    {
        string message="";
        if(highScore()==score)
        {
            message="New!!!";
        }
        return message+"High Score:"+highScore().ToString();
    }
    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0.5f;
        GameOverText.text = GetScore();
        GameOverHiText.text = GetHighScore();
    }
    public int highScore()
    {
        int highScore = PlayerPrefs.GetInt("highScore",0);
        if(highScore<score)
        {
            PlayerPrefs.SetInt("highScore",score);
            highScore=score;
        }
        return highScore;
    }
}
