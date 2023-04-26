using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Cubik1 : MonoBehaviour
{
    [SerializeField] GameObject _Canvas;
    [SerializeField] GameObject _wordSupport;
    [SerializeField] GameObject _doorBox;

    [Header("GameIvent")]
    public GameObject _Cube;
    public GameObject _TextMesh;
    public GameObject _WinMain;
    public GameObject _WinNpc;

    [Header("Cars")]
    [SerializeField] GameObject _MainCar;
    [SerializeField] GameObject _NpcCar;

    [Header("Player")]
    [SerializeField] GameObject _Player;
    [SerializeField] GameObject _LeftArm;
    [SerializeField] GameObject _RightArm;

    [Header ("Camera")]
    [SerializeField] GameObject _MainCamera;
    [SerializeField] GameObject _Camera;


    TMP_Text _text;
    TMP_Text _textSupport;

    int _Round;
    bool _flag;

    Animator _animNPC;
    Animator _animPlayer;

    AudioSource _soundCar;
    AudioSource _step;

    SoundDrive _scriptOnDrive;
    CarController _scriptCar;

    arms _scriptArm;
    arms _scriptArm2;

    walk _sciptPlayerEnabled1;
    playerGun _sciptPlayerEnabled2;


    private void Start()
    {
        _text = _TextMesh.GetComponent<TMP_Text>();
        _textSupport = _wordSupport.GetComponent<TMP_Text>();

        _animNPC = _NpcCar.GetComponent<Animator>();
        _animPlayer = _Player.GetComponent<Animator>();

        _scriptCar = _MainCar.GetComponent<CarController>();
        _scriptOnDrive = _MainCar.GetComponent<SoundDrive>();

        _sciptPlayerEnabled1 = _Player.GetComponent<walk>();
        _sciptPlayerEnabled2 = _Player.GetComponent<playerGun>();

        _scriptArm = _LeftArm.GetComponent<arms>();
        _scriptArm2 = _RightArm.GetComponent<arms>();

        _soundCar = _MainCar.GetComponent<AudioSource>();
        _step = _Player.GetComponent<AudioSource>();

        _Round = 1;
        _flag = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Car" && _Round == 2 && !_flag)
        {
            _WinMain.SetActive(true);
            _Round--;
            Invoke("GamepPlayOn", 4f);
            /* отключить аниматор 
             * поставить машинку NPC на начало
             * отключить камеру
             * включить скрпиты ирока
             * включить камеру игрока*/

        }

        else if (other.tag == "Car" && _Round == 2 && _flag)
        {
            _Round--;
            gameObject.SetActive(false);
            Invoke("GamepPlayOn", 4f) ;
            /* отключить аниматор 
             * поставить машинку NPC на начало
             * отключить камеру
             * включить скрпиты ирока
             * включить камеру игрока*/
        }

        else if(other.tag == "NPC_Car" && _Round == 2)
        {
            _WinNpc.SetActive(true);
            _flag = true;
            // включить победную реплику NPC
        }

        if (other.tag == "Car")
        {
            _Round++;
            gameObject.SetActive(false);
            _Cube.SetActive(true);
            Debug.Log(_text.text);
            _text.text = "Круг " + _Round.ToString() + "/2";
        }
    }

    void GamepPlayOn()
    {

        _Canvas.SetActive(false);
        _wordSupport.SetActive(true);

        _soundCar.enabled = false;
        _step.enabled = true;

        Debug.Log(_flag);
        if (_flag)
        {
            _WinNpc.SetActive(false);
            _textSupport.text = " не переживай. В следущюий раз, я уверен, ты меня обыграешь!";
        }
        else
        {
            _WinMain.SetActive(false);
            _textSupport.text = "Вы: не переживай. В следущюий раз, я уверен, ты меня обыграешь!";
        }

        _animNPC.enabled = false;
        _animPlayer.enabled = true;

        _scriptCar.enabled = false;
        _scriptOnDrive.enabled = false;
        _sciptPlayerEnabled1.enabled = true;
        _sciptPlayerEnabled2.enabled = true;
        _scriptArm.enabled = true;
        _scriptArm2.enabled = true;

        _Camera.SetActive(false);
        _MainCamera.SetActive(true);

        _MainCar.transform.position = new Vector3(-138.2792f, 1.4257f, 9.2735f);
        _MainCar.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        _NpcCar.transform.position = new Vector3(-137.926f, 1.4257f, 9.2735f);
        _NpcCar.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        _doorBox.SetActive(true);

    }
}
