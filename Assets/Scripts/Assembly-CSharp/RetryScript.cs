using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000014 RID: 20
public class RetryScript : MonoBehaviour
{
    // Token: 0x0600006C RID: 108 RVA: 0x0000497B File Offset: 0x00002B7B
    private void Start()
    {

    }

    // Token: 0x0600006D RID: 109 RVA: 0x00004988 File Offset: 0x00002B88
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            this.RestartGame();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioListener.pause = false;
    }
}
