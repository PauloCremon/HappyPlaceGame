using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialHud : MonoBehaviour
{
   public void Close()
    {
        Destroy(this.gameObject);
    }
    public void Restart()
    {
        SceneManager.LoadScene("SceneWorld");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
