using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneGameManager : MonoBehaviour
{
    public Text text; // Переменная для хранения ссылки на текст
    private int count = 0; // Счетчик нажатий

    // Этот метод будет вызываться при нажатии на изображение
    public void OnImageClick()
    {
        count++; // Увеличиваем счетчик
        text.text = "Последователи: " + count.ToString(); // Обновляем текст
    }
}
