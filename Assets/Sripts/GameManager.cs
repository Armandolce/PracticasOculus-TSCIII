using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ElapsedTime;
    [SerializeField] private GameObject UIWin, UIFail;
    [SerializeField] private Jugador mainPlayer;
    [SerializeField] private Win Plat;


    public GameObject EnemyPrefab;
    public Transform RespawnPoint;
    
    private float Timer, StartTime, actualTime, cicle = 10.0f;

    private int min, seg, cent;
    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
        UIWin.SetActive(false);
        UIFail.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        actualTime = Time.time - StartTime;

        min = (int)(actualTime / 60f);
        seg = (int)(actualTime - min * 60f);
        cent = (int)((actualTime - (int)actualTime  ) * 100f);

        ElapsedTime.text = string.Format("{0:00}:{1:00}:{2:00}", min, seg, cent);

        if (actualTime >= cicle)
        {
            cicle += 10.0f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < 3)
            {
                GameObject Enemy = Instantiate(EnemyPrefab);
                Enemy.SetActive(true);
            }
            
        }

        if (mainPlayer.status())
        {
            UIFail.SetActive(true);
        }
        if (Plat.ConfirmWin())
        {
            UIWin.SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        cicle = 0.0f;
        Start();
        mainPlayer.reivive();
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach(var enemy in enemies)
        {
            enemy.gameObject.transform.position = RespawnPoint.position;
            enemy.gameObject.transform.rotation = RespawnPoint.rotation;
        }
    }
}
