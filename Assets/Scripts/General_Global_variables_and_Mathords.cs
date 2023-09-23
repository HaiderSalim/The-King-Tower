using UnityEngine;
using UnityEngine.UI;

public class General_Global_variables_and_Mathords : MonoBehaviour
{
    [Header("Global variables")]
    public int TotalMoney= 10;

    [SerializeField] private GameObject CoinObject;
    [SerializeField] private Text MoneyText;
    private Animator CoinAnimator;

    private void Start()
    {
        MoneyText.text = TotalMoney.ToString();
        CoinAnimator  = CoinObject.GetComponent<Animator>();
    }

    public void MoneyAnimationPlayerAndMoneyUpdater(bool flag,int value)
    {
        if (CoinAnimator != null && MoneyText != null)
        {
            if (flag)
            {
                CoinAnimator.SetBool("Isplaying", flag);

                TotalMoney += value;
                MoneyText.text = TotalMoney.ToString();
            }
            else
            {
                CoinAnimator.SetBool("Isplaying", flag);
            }
        }
    }
}
