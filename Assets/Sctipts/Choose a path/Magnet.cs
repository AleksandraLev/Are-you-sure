using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private DragAndDrop dragAndDrop;
    public bool wordExist = false;

    // ���� ����� ����������, ����� ������ ������ � 2D-����������� ������ � �������
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("������� �����������!");  // ��� ��������� �������� � ������� ��� ����������� ��������

        // ���������, ��� ������ ������ �� �������� ����� �����
        if (other.gameObject != gameObject)
        {
            dragAndDrop = other.GetComponent<DragAndDrop>();
            // ���������� ������ ������ �� ������� �������� ������� (� ������ z ���������� ��� 2D)
            other.transform.position = new Vector3(transform.position.x, transform.position.y, other.transform.position.z);

            // ���� � ������� ������� ���� Rigidbody2D, ������������� ��� ��������
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero; // ������������� ��������
                rb.bodyType = RigidbodyType2D.Static; // ������ ������ �����������, ����� �� ������ �� ��������
            }
            // �������� ������� ��������, ��� ������ �����������
            dragAndDrop.isMagnetized = true;
            wordExist = true;
        }
    }

    // ���� ����� ����������, ����� ������ ������ ������� �� ��������
    private void OnTriggerExit2D(Collider2D other)
    {
        DragAndDrop dragAndDrop = other.GetComponent<DragAndDrop>();

        if (dragAndDrop != null)
        {
            // ��������, ��� ������ ������ �� �����������
            dragAndDrop.isMagnetized = false;
            wordExist = false;
        }
    }
}
