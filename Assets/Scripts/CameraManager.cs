using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Vector3 Offset;
    private Vector3 PositionHero;

    // Start is called before the first frame update
    void Start()
    {
        HeroManager.Created += HeroManager_Created;
        HeroManager.heroMoving += HeroManager_IsMoving;
    }

    /// <summary>
    /// ����� ���������� ������� ����� ���� PositionHero
    /// ����������� ����� ������� ����������� �����
    /// </summary>
    /// <param name="h"></param>
    private void HeroManager_IsMoving(Hero h)
    {
        PositionHero = h.transform.position;
    }

    /// <summary>
    /// ����� ����������� ���������� �� ������ �� �����
    /// ����������� ����� ������� ��������� ���������
    /// </summary>
    /// <param name="h"></param>
    private void HeroManager_Created(Hero h)
    {
        PositionHero = h.transform.position;
        Offset = transform.position - PositionHero;
    }



    // Update is called once per frame
    void Update()
    {
        transform.position = PositionHero + Offset;
    }

}
