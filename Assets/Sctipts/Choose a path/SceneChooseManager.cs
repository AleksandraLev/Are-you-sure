using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCooseManager : MonoBehaviour
{
    public Magnet magnet1;
    public Magnet magnet2;
    public void Start_to_play()
    {
        if (magnet1.wordExist && magnet2.wordExist)
            SceneManager.LoadScene(2);
    }
}
