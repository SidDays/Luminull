using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerTemp : MonoBehaviour {

    public bool Colliding = false;
    Rigidbody PlayerRB;
    public Slider ControlSlider;
    public GameObject LaserObject;
    public GameObject PlayerSelectedObject;
    public float speed = 2.0f;
    public float speedMin = 1.0f;
    public float speedMax = 20.0f;
    //public float SpeedPowerupLength = 5.0f;
    public static float LaserNormalSpeed = 0.5f;
    public float LaserSpawnSpeed = LaserNormalSpeed;

    public UIManager UIManager;

    private GameStateController GameStateController;

    private int score;
    private float CachedSpeed;
    //private float CurrentSpeedPowerupLength = 0.0f;
    //private float CachedSpeed = 1.0f;

    void Awake()
    {
        GameObject game = GameObject.Find("Game State Controller");
        if (game == null)
            Debug.LogError("PlayerControllerTemp: Can not find Game State Controller.");
        GameStateController = game.GetComponent<GameStateController>();
    }

    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        PlayerSelectedObject = null;
        /*GameObject NewLaser = Instantiate(LaserObject);
        //NewLaser.transform.parent = transform;
        NewLaser.transform.position = transform.position;
        NewLaser.transform.forward = transform.forward;
        Physics.IgnoreCollision(NewLaser.GetComponent<Collider>(), GetComponent<Collider>());
        */
        if (UIManager == null)
            Debug.LogError("PlayerController doesn't have UI! Drag UI prefab to scene and insert it into PlayController.\n");
        UIManager.SetPlayerSpeedText(speed);
        score = 0;
     }

    void Update()
    {
        /*if(CurrentSpeedPowerupLength > 0.0f)
        {
            CurrentSpeedPowerupLength -= Time.deltaTime;
            if(CurrentSpeedPowerupLength<=0)
            {
                speed = CachedSpeed;
                UIManager.SetPlayerSpeedText(speed);
            }
        }*/

        if (PlayerSelectedObject == null && ControlSlider.gameObject.activeSelf)
        {
            ControlSlider.gameObject.SetActive(false);
        }
        LaserSpawnSpeed -= Time.deltaTime;
        if(LaserSpawnSpeed<0.0f)
        {
            GameObject NewLaser = Instantiate(LaserObject);
            //NewLaser.transform.parent = transform;
            NewLaser.transform.position = transform.position;
            NewLaser.transform.forward = transform.forward;
            Physics.IgnoreCollision(NewLaser.GetComponent<Collider>(), GetComponent<Collider>());
            LaserSpawnSpeed = LaserNormalSpeed;
        }
        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        /*var z = speed * Time.deltaTime;
        if (!Colliding)
        {

            //transform.Rotate(0, x, 0);
            //PlayerRB.velocity = transform.forward * speed * Time.fixedDeltaTime;
            //transform.Translate(0, 0, z);
            PlayerRB.AddForce(transform.forward * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

            /*if (Input.GetButtonDown("Fire1"))
            {
                transform.Rotate(0, 90, 0);
            }

            if (Input.GetButtonDown("Fire2"))
            {
                transform.Rotate(0, -90, 0);
            }
        }*/
    }

    private void FixedUpdate()
    {
        PlayerRB.velocity = transform.forward * speed;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin Pick Up"))
        {
            CoinPickUp script = other.GetComponent<CoinPickUp>();
            script.OnPickUp();
            score += script.score;
            UIManager.SetPlayerScoreText(score);
        }
        /*if(other.gameObject.CompareTag("SpeedChange Pick Up"))
        {
            SpeedChangePickUp script = other.GetComponent<SpeedChangePickUp>();
            script.OnPickUp();
            CachedSpeed = speed;
            speed = script.GetNewSpeed(speed);
            CurrentSpeedPowerupLength = SpeedPowerupLength;
            UIManager.SetPlayerSpeedText(speed);
        }*/

        if (other.gameObject.CompareTag("Mirror"))
        {
            if (!other.gameObject.GetComponent<ReflectObject>().MirrorHit)
            {
                Vector3 ReflectionAngle = Vector3.Reflect(transform.forward, other.transform.forward);
                transform.forward = ReflectionAngle;
                other.gameObject.GetComponent<ReflectObject>().MirrorHit = true;
            }
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            GameStateController.OnPlayerLose();
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            GameStateController.OnPlayerWin();
        }
    }

    public void SelectObject(GameObject selected)
    {
        if(PlayerSelectedObject!=null)
        {
            if(PlayerSelectedObject.GetComponent<RotateObject>())
            {
                PlayerSelectedObject.GetComponent<RotateObject>().Deselect();
            }
        }
        PlayerSelectedObject = selected;
        ControlSlider.gameObject.SetActive(true);
    }

    public void DeselectObject()
    {
        if (PlayerSelectedObject.GetComponent<RotateObject>())
        {
            PlayerSelectedObject.GetComponent<RotateObject>().Deselect();
        }
        PlayerSelectedObject = null;
    }

    public void RotateSelectedObjectAroundY()
    {
        // apply rotation
        Vector3 _rotation = new Vector3(0, 0, 0);
        _rotation.y = -(ControlSlider.value - 0.5f) * 100;//-(_mouseOffset.x + _mouseOffset.y) * _sensitivity;

        // rotate
        transform.Rotate(_rotation);
    }

    public void SetControlSlider(Slider mainSlider)
    {
        ControlSlider = mainSlider;
    }

    public Slider GetControlSlider()
    {
        return ControlSlider;
    }

    public void SetSpeedWithDiff(float speedDiff)
    {
        speed = Mathf.Clamp(speed + speedDiff, speedMin, speedMax);
        UIManager.SetPlayerSpeedText(speed);
    }

    public void SetSpeed(float targetSpeed)
    {
        speed = Mathf.Clamp(targetSpeed, speedMin, speedMax);
        UIManager.SetPlayerSpeedText(speed);
    }

    public void OnPause()
    {
        CachedSpeed = speed;
        speed = 0;
    }

    public void OnResume()
    {
        speed = CachedSpeed;
    }
}

