using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneGameManager : MonoBehaviour
{
    public Text text; // ���������� ��� �������� ������ �� �����
    private int count = 0; // ������� �������

    // ���� ����� ����� ���������� ��� ������� �� �����������
    public void OnImageClick()
    {
        count++; // ����������� �������
        text.text = "�������������: " + count.ToString(); // ��������� �����
    }
}
