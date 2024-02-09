using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UImanager : MonoBehaviour
{
    public Text PlayerScoreText;

    public GameObject Player;

    public GameObject[] NPC;
    public GameObject NPCContent;
    public GameObject NPCScore;

    private float nextActionTime = 0.0f;
    public float period = 0.5f;

    public Animator kuva;

    // Start is called before the first frame update
    void Start()
    {
        GameObject k = kuva.gameObject;

        float width = Screen.width / 2 - (k.GetComponent<RectTransform>().rect.width / 2);
        float height = Screen.height / 2; // - (k.GetComponent<RectTransform>().rect.height / 2);

        k.transform.DOMoveX(width, 2).SetEase(Ease.OutExpo);
        k.transform.DOMoveY(height, 2).SetEase(Ease.OutExpo);
        
        Debug.Log("Aloita DoTween");
        //kuva.SetBool("toista", true);
        NPC = GameObject.FindGameObjectsWithTag("npc");

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            int score = Player.GetComponent<PlayerControl>().score;
            PlayerScoreText.text = $"Score: {score}";

            foreach (Transform n in NPCContent.transform)
                Destroy(n.gameObject);
            

            foreach (GameObject n in NPC)
            {
                GameObject t = Instantiate(NPCScore, NPCContent.transform);

                string name = n.GetComponent<NPCControl>().NpcName;
                int npcscore = n.GetComponent<NPCControl>().score;
                t.GetComponent<Text>().text = $"{name}: {npcscore}";

            }
        }

        if(Input.GetKeyDown(KeyCode.P))
            kuva.SetBool("toista", true);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void SpesiaWWW()
    {
        Application.OpenURL("www.spesia.fi");
    }
}
