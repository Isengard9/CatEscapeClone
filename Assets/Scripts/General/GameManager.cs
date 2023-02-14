using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    #region Variables

    public bool isGameEnded = false;
    
    [SerializeField] private UIManager uıManager;

    #endregion
    
    public void EndGame(bool state)
    {
        if(state)
            GameSuccess();
        else 
            GameFailed();

        #if UNITY_IOS
            Application.OpenURL("https://apps.apple.com/us/app/cat-escape/id1536578421");
        
        #elif UNITY_ANDROID
            Application.OpenURL("https://play.google.com/store/apps/details?id=gg.sunday.catescape&hl=en&gl=US");
            
        #endif

        isGameEnded = true;

    }
    
    private void GameSuccess()
    {
        uıManager.ActivateSuccess();
    }

    private void GameFailed()
    {
        uıManager.ActivateFail();
    }
}
