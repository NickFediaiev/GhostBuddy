using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [Header("InputScreen")]
    [SerializeField] private GameObject _inputPanel;
    [SerializeField] private GameObject _congratulationsRibbon;
    [SerializeField] private Button _startButton;
    [SerializeField] private TMP_InputField _inputField;
    
    
    [Header("TimerScreen")]
    [SerializeField] private GameObject _timerPanel;
    [SerializeField] private TMP_Text _timerText;

    private void Awake()
    {
        SetInitialState();
        
        _startButton.onClick.AddListener(StartTimer);
    }

    private void SetInitialState()
    {
        _inputPanel.SetActive(true);
        _congratulationsRibbon.SetActive(false);
        _startButton.interactable = true;
        _inputField.interactable = true;
        
        _timerPanel.SetActive(false);
        _timerText.text = "00 min";
    }
    
    private void StartTimer()
    {
        if (!int.TryParse(_inputField.text, out int _))
            return;
        
        _inputPanel.SetActive(false);
        _timerPanel.SetActive(true);
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        var timerMinutes = int.Parse(_inputField.text);

        while (timerMinutes > 0)
        {
            _timerText.text = $"{timerMinutes.ToString()} min";
            yield return new WaitForSeconds(60);
            timerMinutes--;
        }
        EndTimer();
    }
    
    private void EndTimer()
    {
        _congratulationsRibbon.SetActive(true);
        _inputPanel.SetActive(true);
        _timerPanel.SetActive(false);
    }
}
