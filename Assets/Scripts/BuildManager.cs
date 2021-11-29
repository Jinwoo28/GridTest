using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Craft  // 생성할 건물들을 분류할 클래스
{
    public string craftname; //건물 이름
    public GameObject previewCraft; //미리보기 프리펩
    public GameObject BuildCraft; // 실제 지어질 프리펩
    
}
public class BuildManager : MonoBehaviour
{
    [SerializeField] private Craft[] craft = null;  //직렬화를 통해 인스펙터창에서 관리하기 위한 변수

    [SerializeField] private Camera _camera = null;

//    [SerializeField] private GameObject BuildSlot = null;
    private bool OpenBuildSlot = false;
    [SerializeField] private Text[] ObstacleCount = null;

    //[SerializeField] private GameObject Shop = null;
    //[SerializeField] private GameObject[] ShopInUi = null;

    //[SerializeField] private GameObject Player = null;
    //[SerializeField] private GameObject[] Weapon = null;

    private GameObject PreviewPrefab = null;    //Craft를 담을 변수와 미리보기에 사용할 변수 선언
    private GameObject InsPrefab = null;    //생성할 건물
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
        MousePos = _camera.ScreenToWorldPoint(Input.mousePosition); //마우스의 현재 위치 받기

        if (Input.GetKeyDown(KeyCode.R)) SlotClick(0);
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{

        //    //OpenBuildSlot = false;

        //}


        //================================================================= 1칸씩 움직이기
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

        //================================================================= 2칸씩 움직이기

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

        //// ================================================================= 3칸씩 움직이기
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