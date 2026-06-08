using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _countText;
    [SerializeField] private int _pointsPerKill;
    [SerializeField] private int _pointsToWin;
    [SerializeField] private Gun _gun;
    [SerializeField] private GameObject _winPanel;


    private int _count;

    public static Action action;

    public int Count { get => _count; set => _count = value; }

    private void Start()
    {
        Time.timeScale = 1;
        _winPanel.SetActive(false);
        action += AddPoints;
        _countText.text = $"0/{_pointsToWin}";
    }

    private void AddPoints()
    {
        _count += _pointsPerKill;
        _countText.text = $"{_count}/{_pointsToWin}";

        if (_count >= _pointsToWin)
        {
            Win();
        }
    }

    private void Win()
    {
        _winPanel.SetActive(true);
        _gun.enabled = false;
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
 