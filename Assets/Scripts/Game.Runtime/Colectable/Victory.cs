using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Victory : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("2");
    }
}
