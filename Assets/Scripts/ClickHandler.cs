using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ClickHandler : MonoBehaviour
{
    public delegate void ClickDelegate(Vector3 mousePosition);

    /// <summary>
    /// Событие нажатия на пол локации
    /// </summary>
    public static event ClickDelegate IsClicked;

    /// <summary>
    /// Обрабатывает нажатие мышью на пол локации
    /// </summary>
    public void OnMouseDown()
    {
        IsClicked?.Invoke(Input.mousePosition);
    }
}
