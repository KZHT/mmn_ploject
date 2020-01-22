using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolScript : MonoBehaviour {
    public static ObjectPoolScript current;

    //-------------------------------------------------------------------------------
    //    生成させる数
    //-------------------------------------------------------------------------------	

    [System.Serializable]
    public class Amount
    {
        public int shotamount;

    }

    //-------------------------------------------------------------------------------
    //    生成させる親オブジェクト
    //-------------------------------------------------------------------------------

    [SerializeField]
    public GameObject shotOyaObj;


    //-------------------------------------------------------------------------------
    //    生成させる子オブジェクト
    //-------------------------------------------------------------------------------
    [System.Serializable]
    public class Object
    {
        public GameObject shotObj;
       
    }

    //-------------------------------------------------------------------------------
    //   生成させるオブジェクトのリスト
    //-------------------------------------------------------------------------------
    [System.Serializable]
    public class List
    {
        public List<GameObject> listshotobj;
    }

    //-------------------------------------------------------------------------------

    //Amount-------------------------------------------------------------------------
    [SerializeField]
    Amount amount;

    //Obj----------------------------------------------------------------------------
    [SerializeField]
    Object Obj;

    //List---------------------------------------------------------------------------
    [SerializeField]
    List list;


    void Awake()
    {
        current = this;
        Instantiate(shotOyaObj);

    }
    // Use this for initialization
    void Start () {
        shotOyaObj = GameObject.FindGameObjectWithTag("OYA/shot");

        list.listshotobj = new List<GameObject>();

        for (int i = 0; i < amount.shotamount; i++)
        {
            GameObject obj = (GameObject)Instantiate(Obj.shotObj);

            obj.transform.SetParent(shotOyaObj.transform, true);

            obj.SetActive(false);
            list.listshotobj.Add(obj);
        }

     
    }
	
	public GameObject shotObjPooledObject()
    {
        for (int i = 0; i < list.listshotobj.Count; i++)
        {
            if(!list.listshotobj[i].activeInHierarchy)
            {
                return list.listshotobj[i];
            }

        }
        return null;
    }

   
}
