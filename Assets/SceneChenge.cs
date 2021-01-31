using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChenge : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Timer;
    [SerializeField] GameObject gameOverCanvas;

    private bool gameCheck;

    void Start()
    {
        gameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gameCheck = Timer.GetComponent<TimarSystem>().gameOver;
        if (gameCheck == true)
        {
            gameOverCanvas.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Scene loadScen = SceneManager.GetActiveScene();
                SceneManager.LoadScene(loadScen.name);
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Title");
            }
        }
    }
}
