using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float cellsize;
    public int X;
    public int Y;

    private Grid grid;
    private void Start()
    {
        grid = new Grid(X, Y, cellsize);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(GetMouseWorldPosition(), 56);
           // Debug.Log(GetMouseWorldPosition());
        }
    }

    public Vector3 GetMouse(Vector3 screenPosition,Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        Debug.Log(worldCamera.ScreenToWorldPoint(screenPosition) + "dddd"); //�̰� �Ⱥ���
        return worldPosition;
    }

    public Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouse(Input.mousePosition, Camera.main);
        Debug.Log(Input.mousePosition + "���콺 ��ġ");  //�̻����
        vec.z = 0f;
        return vec;
    }

}
