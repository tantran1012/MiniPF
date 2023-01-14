using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour
{
    public GameObject GameSettingUI;

    public void onShow() {
        GameSettingUI.SetActive(true);
    }
    
    public void onClose() {
        GameSettingUI.SetActive(false);
    }
}
