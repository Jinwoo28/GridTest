using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Craft  // ������ �ǹ����� �з��� Ŭ����
{
    public string craftname; //�ǹ� �̸�
    public GameObject previewCraft; //�̸����� ������
    public GameObject BuildCraft; // ���� ������ ������
    
}
public class BuildManager : MonoBehaviour
{
    [SerializeField] private Craft[] craft = null;  //����ȭ�� ���� �ν�����â���� �����ϱ� ���� ����

    [SerializeField] private Camera _camera = null;

//    [SerializeField] private GameObject BuildSlot = null;
    private bool OpenBuildSlot = false;
    [SerializeField] private Text[] ObstacleCount = null;

    //[SerializeField] private GameObject Shop = null;
    //[SerializeField] private GameObject[] ShopInUi = null;

    //[SerializeField] private GameObject Player = null;
    //[SerializeField] private GameObject[] Weapon = null;

    private GameObject PreviewPrefab = null;    //Craft�� ���� ������ �̸����⿡ ����� ���� ����
    private GameObject InsPrefab = null;    //������ �ǹ�
    //private int BuildNum = 0;

    private bool isActivatePreview = false;
   private Vector3 MousePos;
    //
    private RaycastHit hitinfo;
    private Vector3 _location;

    private void Awake()
    {
        
        
    }
    private void Update()
    {
        MousePos = _camera.ScreenToWorldPoint(Input.mousePosition); //���콺�� ���� ��ġ �ޱ�

        if (Input.GetKeyDown(KeyCode.R)) SlotClick(0);
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{

        //    //OpenBuildSlot = false;

        //}


        //================================================================= 1ĭ�� �����̱�
        //if (isActivatePreview)
        //{
        //    if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hitinfo))
        //    {
        //        if (hitinfo.transform != null)
        //        {
        //            _location = hitinfo.point;
        //            Debug.Log(hitinfo.point);
        //            _location.y = 0.5f;
        //            PreviewPrefab.transform.position = new Vector3((int)_location.x, 0.5f, (int)_location.z);
        //        }
        //    }
        //}

        //================================================================= 2ĭ�� �����̱�

        int X;
        int Z;

        if (isActivatePreview)
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hitinfo))
            {
                if (hitinfo.transform != null)
                {
                    _location = hitinfo.point;
                    _location.y = 0.5f;


                    if ((int)_location.x % 2 == 0) X = (int)_location.x;
                    else X = (int)(_location.x) - 1;


                    if ((int)_location.z % 2 == 0) Z = (int)_location.z;
                    else Z = (int)(_location.z) - 1;

                    Debug.Log(X + " : " + Z);
                    PreviewPrefab.transform.position = new Vector3(X, 0.5f, Z);
                }
            }
        }

        //// ================================================================= 3ĭ�� �����̱�
        //int X;
        //int Z;

        //if (isActivatePreview)
        //{
        //    if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hitinfo))
        //    {
        //        if (hitinfo.transform != null)
        //        {
        //            _location = hitinfo.point;
        //            _location.y = 0.5f;


        //            if ((int)_location.x % 3 == 0) X = (int)_location.x;
        //            else if((int)_location.x % 3 == 1) X = (int)(_location.x) - 1;
        //            else X = (int)(_location.x) - 2;



        //            if ((int)_location.z % 3 == 0) Z = (int)_location.z;
        //            else if ((int)_location.z % 3 == 1) Z = (int)(_location.z) - 1;
        //            else Z = (int)(_location.z) - 2;

        //            Debug.Log(X + " : " + Z);
        //            PreviewPrefab.transform.position = new Vector3(X, 0.5f, Z);
        //        }
        //    }
        //}


        //if (PreviewPrefab != null && PreviewPrefab.GetComponent<Preview>().isBuildable())
        //{
        //    if (Input.GetKeyDown(KeyCode.R))
        //    {
        //        Instantiate(InsPrefab, _location, Quaternion.identity);
        //        Destroy(PreviewPrefab);
        //        isActivatePreview = false;
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Escape) && PreviewPrefab != null)
        {
            Destroy(PreviewPrefab);
            isActivatePreview = false;
           
        }


    }

   

    

    public void SlotClick(int _SlotNumber)
    {
        
        PreviewPrefab = Instantiate(craft[_SlotNumber].previewCraft, MousePos, Quaternion.identity);
        InsPrefab = craft[_SlotNumber].BuildCraft;
       
        isActivatePreview = true;
        //BuildNum = _SlotNumber;
    }

    //public void BuildSlotOpen()
    //{
    //    if (OpenBuildSlot)
    //    {
    //        BuildSlot.SetActive(false);
    //        OpenBuildSlot = false;
    //    }
    //    else if (!OpenBuildSlot)
    //    {
    //        BuildSlot.SetActive(true);
    //        OpenBuildSlot = true;
    //    }
    //}

  

    



}