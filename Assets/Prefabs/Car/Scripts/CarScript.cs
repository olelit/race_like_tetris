using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarScript : MonoBehaviour
{

    [SerializeField]
    public float Speed = 2f;
    [SerializeField]
    GameObject ScoreText;
    [SerializeField]
    GameObject HealthBar;
    [SerializeField]
    GameObject ModalDie;

    [SerializeField]
    GameObject BtnLeft;
    [SerializeField]
    GameObject BtnRght;

    [SerializeField]
    GameObject Effect;

    private GUIStyle GetGUI;
    private float WayMult;
    private float StartSpeed;
    private int DifficultMod = 7;
    private bool IsInRight = true;
    private SaveManager Manager;
    void Start()
    {
        GetGUI = new GUIStyle();
        GetGUI.fontSize = 100;
        GetGUI.normal.textColor = Color.white;
        GetGUI.alignment = TextAnchor.MiddleCenter;

        StartSpeed = Speed;
        WayMult = transform.position.x*2;

        Time.timeScale = 1;
        ModalDie.GetComponent<RectTransform>().transform.localScale = new Vector3(0, 0, 0);
        GameObject manager = GameObject.FindGameObjectWithTag("save_manager");
        if(manager != null)
        {
            Manager = manager.GetComponent<SaveManager>();
            Manager.Reset();
        }
    
        Button lButton = BtnLeft.GetComponent<Button>(); 
        Button rButton = BtnRght.GetComponent<Button>();

        lButton.onClick.AddListener(() => {
            Left();
        });

        rButton.onClick.AddListener(() => {
            Right();
        });

    }

    // Update is called once per frame
    void Update()
    {
        CheckSpeed();
        transform.position += transform.up * Time.deltaTime * Speed;

    }

    public void Left()
    {
        if (IsInRight)
        {
            IsInRight = false;
            transform.position += transform.right * -WayMult;
        }
    }

    public void Right()
    {
        if (!IsInRight)
        {
            IsInRight = true;
            transform.position += transform.right * WayMult;
        }
    }

    public void CheckSpeed()
    {
        if(Manager != null)
        {
            int speed = Manager.State.Point / DifficultMod;
            Speed = StartSpeed + speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int health = HealthBar.GetComponent<HealthScript>().SubHealth();
        collision.gameObject.GetComponent<EnemyScript>().Die();
        if (health == 0)
        {
            ModalDie.GetComponent<RectTransform>().transform.localScale = new Vector3(1, 1, 1);
            Instantiate(Effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
