using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ClickHandler : MonoBehaviour
{
    public delegate void ClickDelegate(Vector3 mousePosition);

    /// <summary>
    /// ������� ������� �� ��� �������
    /// </summary>
    public static event ClickDelegate IsClicked;

    /// <summary>
    /// ������������ ������� ����� �� ��� �������
    /// </summary>
    public void OnMouseDown()
    {
        IsClicked?.Invoke(Input.mousePosition);
    }
}
