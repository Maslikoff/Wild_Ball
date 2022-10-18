using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = System.Random;
using UnityEngine.SceneManagement;

public class BoolController : MonoBehaviour
{
    [Header("Текст для определения, враг это или нет")]
    [SerializeField] private TextMeshProUGUI text;
    
    [Header("Текст для подсчета скольких убили")]
    [SerializeField] private TextMeshProUGUI killText;
    
    [Header("Радиус до врага")]
    [SerializeField] private float Radius ;

    [Header("Сила, с которй бьем")]
    [SerializeField] private float Power;

    [Header("Панель паражения | Панель Победы")] 
    [SerializeField] private GameObject LoysePanel, WinPanel;
    
    [Header("Партиклы удара")] 
    [SerializeField] private GameObject ShotParticle;

    [Header("Место старта | Промежуточная точка")]
    public Transform startPointPosition, savePoint;

    [Header("Подсчет скольких убили")]
    private static int Kill;

    /// <summary>
    /// Касание плохих парней
    /// </summary>
    /// <param name="badGuy"></param>
    private void OnCollisionEnter(Collision badGuy)
    {
        TouchTestBadGuy(badGuy);
    }

    /// <summary>
    /// Проверка на касание плохишей
    /// </summary>
    /// <param name="badGuy">Враг</param>
    private void TouchTestBadGuy(Collision badGuy)
    {
        if (badGuy.gameObject.CompareTag("BadGuy"))
        {
            BadText();
            ShotBadGuy(badGuy);
            Instantiate(ShotParticle, transform.position, Quaternion.identity);
            Kill++;
            killText.text = Kill.ToString();
        }
    }

    /// <summary>
    /// Удар по врагам
    /// </summary>
    /// <param name="badGuy"></param>
    private void ShotBadGuy(Collision badGuy)
    {
        if (Vector3.Distance(transform.position, badGuy.transform.position) < Radius)
        {
            Vector3 derection = badGuy.transform.position - transform.position;
            badGuy.rigidbody.AddForce(
                derection.normalized * 
                Power * 
                (Radius - Vector3.Distance(transform.position, badGuy.transform.position)),
                ForceMode.Impulse);
        }
        Destroy(badGuy.gameObject, 1f);
    }

    /// <summary>
    /// Вывод текста плохих ребят
    /// </summary>
    private void BadText()
    {
        Random _r = new Random();
        string[] random = {"Так его!", "Умница!", "Супер!", "Ба-бах!"};
        text.text = random[_r.Next(0, random.Length)];
    }

    /// <summary>
    /// Касание хороших мальчишек
    /// </summary>
    /// <param name="ball"></param>
    private void OnTriggerEnter(Collider ball)
    {
        LastLevel(ball);
        Finish(ball);
        KillZona(ball);
        PromptText(ball);
    }

    /// <summary>
    /// Условие для открытие двери
    /// </summary>
    /// <param name="ball"></param>
    private void PromptText(Collider ball)
    {
        if (ball.CompareTag("Prompt"))
        {
            if (Kill>=16)
                text.text = "Нажми на кнопочку:)";
            else 
                transform.position = savePoint.position;
        }
        else
        {
            text.text = "Убери кубики!";
        }
    }

    /// <summary>
    /// Смертельная зона
    /// </summary>
    /// <param name="other"></param>
    private void KillZona(Collider other)
    {
        if (other.CompareTag("KillZona"))
        {
            gameObject.SetActive(false);
            LoysePanel.SetActive(true);
            Instantiate(ShotParticle, transform.position, Quaternion.identity);
            
            if (LoysePanel == false)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    /// <summary>
    /// Победа
    /// </summary>
    /// <param name="ball"></param>
    private void Finish(Collider ball)
    {
        if (ball.CompareTag("Finish"))
        {
            WinPanel.SetActive(true);
        }
    }

    /// <summary>
    /// Смена уровня
    /// </summary>
    /// <param name="ball"></param>
    private void LastLevel(Collider ball)
    {
        if (ball.CompareTag("LastLevel"))
        {
            if (Kill >= 16)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Kill = 0;
            }
            else if (Kill >= 9 && Kill < 16)
            {
                transform.position = savePoint.position;
            }
            else
            {
                transform.position = startPointPosition.position;
            }
        }
    }

    /// <summary>
    /// Условие для открытия
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            if (Kill >= 9)
            {
                text.text = "[E]";
                if (Input.GetKey(KeyCode.E))
                { 
                    other.gameObject.SetActive(false);
                }
            }
            else
            {
                transform.position = startPointPosition.position;
                text.text = "Добей всех!";
            }
        }
    }
}
