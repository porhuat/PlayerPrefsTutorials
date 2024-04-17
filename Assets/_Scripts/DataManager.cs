using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Enum to represent different button actions(表示不同按鈕的操作)
public enum UIButtonAction
{
    DELETE = 0
}

public class DataManager : Singleton<DataManager>
{
    //Save Points (儲存點)
    public Transform savePointPosition;

    //Player Initial Position (玩家初始位置)
    [SerializeField] Transform _playerInitialPosition;

    //Player Current Position (玩家當前位置)
    [SerializeField] Transform _playerCurrentPosition;

    //Delete Save Record Button (刪除記錄按鍵)
    [SerializeField] Button _btnDelectSaveRecord = null;

    void Start()
    {
        //檢查PlayerPrefs 是否有“playerSavePoint” 值
        if (PlayerPrefs.HasKey("playerSavePoint"))
        {
            Debug.Log("PlayerPrefs: have player position key");

            //將savePointPosition的值，賦予給_playerCurrentPosition
            _playerCurrentPosition.transform.position = savePointPosition.position;
        }
        else
        {
            Debug.Log("PlayerPrefs: No saved player position found");

            //找不到PlayerPrefs内有任何儲存玩家的坐標值，所以將玩家初始坐標，賦值給 _playerCurrentPosition
            _playerCurrentPosition.transform.position = _playerInitialPosition.position;
        }

        //Add a listener for the Delete button click (在刪除記錄按鍵添加監聽器)
        _btnDelectSaveRecord.onClick.AddListener(() => ButtonAction((int)UIButtonAction.DELETE));
    }

    private void ButtonAction(int index)
    {
        //Handle button action based on the provided enum value(根據提供的Enum value 去處理按鈕操作)
        switch (index)
        {
            case (int)UIButtonAction.DELETE:
                Debug.LogWarning("Delete Save Record");

                //Removes all keys and values from the preferences
                //删除PlayerPrefs内所有值
                PlayerPrefs.DeleteAll();

                //Removes the given key from the PlayerPrefs. If the key does not exist, DeleteKey has no impact.
                //从 PlayerPrefs 中删除给定的值。如果值不存在，DeleteKey 不會產生任何影响。
                PlayerPrefs.DeleteKey("playerSavePoint");
                break;

            default:
                break;
        }
    }
}
