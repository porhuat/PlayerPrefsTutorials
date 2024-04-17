using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointDetect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Detects if it is a player and saves a record of the coordinates of the Save Points in PlayerPrefs
        //偵測如果是玩家，並將存儲點的坐標記錄保存在PlayerPrefs
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetString("playerSavePoint", DataManager.Instance.savePointPosition.transform.position.ToString());
            Debug.Log("Player position saved");
        }
    }
}
