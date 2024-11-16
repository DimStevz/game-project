using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI coinText;

    private void OnGUI()
    {
        coinText.text = Levelmanager.main.coin.ToString();
    }

    public void SetSelected(){
        
    }
}