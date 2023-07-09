using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAP_shop : MonoBehaviour
{
    // Start is called before the first frame update
    private string unlockLevel = "com.brainbug.ColorCluster.UnlockLevels";
    public GameObject IAPButton;
    public Text unlockText;
    private void Start()
    {
        if(PlayerPrefs.GetInt("IAP_key")==1)
        {
            IAPButton.SetActive(false);
            unlockText.text = "ALL LEVELS ARE UNLOCKED";
        }

    }
    public void OnPurchaseComplete(Product product)
    {
        Debug.Log("Unlock all levels");
        PlayerPrefs.SetInt("IAP_key", 1);
    }

    public void OnPurchaseFail(Product product , PurchaseFailureReason reason)
    {
        Debug.Log("Purschase fail because: " + reason);
    }
    
}
