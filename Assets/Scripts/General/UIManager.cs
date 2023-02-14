using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region UI Variables

    [SerializeField] private GameObject successPanel, failPanel;

    [SerializeField] private Button quitButton;
    [SerializeField] private TMP_Text counterText;
    private float counter = 15;

    #endregion

    #region MonoBehaviour

    private void Update()
    {
        CountDown();
    }

    #endregion

    #region Quit

    public void Quit()
    {
        //Application.Quit();
    }

    #endregion

    #region CountDown

    private void CountDown()
    {
        if(counter<=0)
            return;
        counterText.text = counter.ToString("0");
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            counterText.gameObject.SetActive(false);
            quitButton.gameObject.SetActive(true);
        }
    }

    #endregion
    
    #region Fail/Success

    public void ActivateFail()
    {
        failPanel.SetActive(true);
    }

    public void ActivateSuccess()
    {
        successPanel.SetActive(true);
    }

    #endregion
}
