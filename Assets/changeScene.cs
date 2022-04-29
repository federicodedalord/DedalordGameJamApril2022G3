using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class changeScene : MonoBehaviour
{
    public void OnButtonClick()
    {
        SceneManager.LoadScene("Stage1");
    }
}
