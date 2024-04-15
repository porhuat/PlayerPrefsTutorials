using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    //玩家儲存點位置
    [SerializeField] Transform _savePointPosition = null;

    //玩家初始位置
    [SerializeField] Transform _playerInitialPosition = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerPrefs.SetString("playerSavePoint", _savePointPosition.position.ToString());
            Debug.Log("savePoint:" + _savePointPosition.position.ToString());
        }
    }
}
