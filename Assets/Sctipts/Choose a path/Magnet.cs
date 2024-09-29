using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private DragAndDrop dragAndDrop;
    public bool wordExist = false;

    // Этот метод вызывается, когда другой объект с 2D-коллайдером входит в триггер
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Объекты пересеклись!");  // Это сообщение появится в консоли при пересечении объектов

        // Проверяем, что другой объект не является самим собой
        if (other.gameObject != gameObject)
        {
            dragAndDrop = other.GetComponent<DragAndDrop>();
            // Перемещаем другой объект на позицию текущего объекта (с учетом z координаты для 2D)
            other.transform.position = new Vector3(transform.position.x, transform.position.y, other.transform.position.z);

            // Если у другого объекта есть Rigidbody2D, останавливаем его движение
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero; // Останавливаем движение
                rb.bodyType = RigidbodyType2D.Static; // Делаем объект статическим, чтобы он больше не двигался
            }
            // Сообщаем скрипту движения, что объект примагничен
            dragAndDrop.isMagnetized = true;
            wordExist = true;
        }
    }

    // Этот метод вызывается, когда другой объект выходит из триггера
    private void OnTriggerExit2D(Collider2D other)
    {
        DragAndDrop dragAndDrop = other.GetComponent<DragAndDrop>();

        if (dragAndDrop != null)
        {
            // Сообщаем, что объект больше не примагничен
            dragAndDrop.isMagnetized = false;
            wordExist = false;
        }
    }
}
