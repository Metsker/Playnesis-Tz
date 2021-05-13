using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using InteractableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI playerHp;
    [SerializeField] private TextMeshProUGUI playerExp;
    [SerializeField] private Image gameOverImage;
    [SerializeField] private Button restartButton;
    private CharacterStats _character;
    private readonly GameObject[] _portals = new GameObject[2];
    private int _level;
    public static bool GameOver { get; private set; }

    private void Start()
    {
        _level = 0;
        GameOver = false;
        Portal.LoadLevel = false;
        _character = FindObjectOfType<CharacterStats>();
        _character.health = 10;
        _character.exp = 0;
    }

    private void OnEnable()
    {
        TextView.StartDescriptionTimer += StartDescriptionTimer;
        CharacterStats.GameOver += OnGameOver;
        CharacterStats.UpdateHpUI += UpdateHpUI;
        CharacterStats.UpdateExpUI += UpdateExpUI;
        Portal.BuildPortals += BuildPortals;
        Portal.Teleport += Teleport;
    }
    
    private void OnDisable()
    {
        TextView.StartDescriptionTimer -= StartDescriptionTimer;
        CharacterStats.GameOver -= OnGameOver;
        CharacterStats.UpdateHpUI -= UpdateHpUI;
        CharacterStats.UpdateExpUI -= UpdateExpUI;
        Portal.BuildPortals -= BuildPortals;
        Portal.Teleport -= Teleport;
    }
    
    private void StartDescriptionTimer(string text)
    {
        StartCoroutine(DescriptionTimer(text));
    }

    private void OnGameOver()
    {
        GameOver = true;
        gameOverImage.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    private void UpdateHpUI(int value)
    {
        playerHp.text = "Hp: " + value;
    }

    private void UpdateExpUI(int value)
    {
        playerExp.text = "Exp: " + value;
    }

    private void BuildPortals()
    {
        _portals[0] = GameObject.FindWithTag("Portal1");
        _portals[1] = GameObject.FindWithTag("Portal2");
    }

    private void Teleport()
    {
        switch (_level)
        {
            case 0 :
                _level = 1;
                _character.GetComponent<NavMeshAgent>().Warp(_portals[_level].transform.position+ Vector3.back);
                break;
            case 1 :
                _level = 0;
                _character.GetComponent<NavMeshAgent>().Warp(_portals[_level].transform.position + Vector3.back);
                break;
        }
    }
    
    private IEnumerator DescriptionTimer(string text)
    {
        description.text = text;
        description.gameObject.SetActive(true);
        while (TextView.ViewTime > 0)
        {
            TextView.ViewTime -= Time.deltaTime;
            yield return null;
        }
        yield return new WaitUntil(() => TextView.ViewTime <= 0);
        description.gameObject.SetActive(false);
    }
}
