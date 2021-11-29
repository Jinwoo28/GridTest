using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour
{
    private List<Collider> colliderList = new List<Collider>(); //충돌검사

    [SerializeField]
    private int layerGround; //그라운드 레이어
    private const int IGNORE_LAYER = 2; //무시할 레이어

    [SerializeField] private Material green;    // 충돌이 없을 때 보여줄 초록색 프리뷰
    [SerializeField] private Material red;  // 충돌 물체가 있을 때 보여줄 빨간색 프리뷰

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        if (colliderList.Count > 0) //충돌 물체가 하나 이상일 때 
        {
            SetColor(red);
        }

        else { SetColor(green); }
    }

    private void SetColor(Material mat)
    {
        foreach (Transform thistransform in transform)
        {
            var newMaterials = new Material[thistransform.GetComponent<Renderer>().materials.Length];
            for (int i = 0; i < newMaterials.Length; i++)
            {
                newMaterials[i] = mat;
            }
            thistransform.GetComponent<Renderer>().materials = newMaterials;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != layerGround && other.gameObject.layer != IGNORE_LAYER)
        {
            colliderList.Add(other);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != layerGround && other.gameObject.layer != IGNORE_LAYER)
        {
            colliderList.Remove(other);
        }
    }

    public bool isBuildable()
    {
        return colliderList.Count == 0;
    }
}