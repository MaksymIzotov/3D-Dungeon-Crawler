using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public float sensitivity;
    public float aimMult;

    [HideInInspector] public KeyCode Forward;
    [HideInInspector] public KeyCode Backward;
    [HideInInspector] public KeyCode Left;
    [HideInInspector] public KeyCode Right;

    [HideInInspector] public KeyCode Jump;
    [HideInInspector] public KeyCode Crouch;
    [HideInInspector] public KeyCode Run;

    [HideInInspector] public KeyCode Spell01;
    [HideInInspector] public KeyCode Spell02;
    [HideInInspector] public KeyCode Spell03;
    [HideInInspector] public KeyCode Spell04;

    [HideInInspector] public KeyCode Shoot;
    [HideInInspector] public KeyCode Aim;
    [HideInInspector] public KeyCode Reload;

    [HideInInspector] public KeyCode Pickup;
    [HideInInspector] public KeyCode Drop;

    public GameObject[] buttons;

    private bool isChanging = false;
    private GameObject lastButton;
    private KeyCode nullKey = KeyCode.None;
    private void Awake()
    {
        Instance = this;

        AssignDefaults();
    }

    private void Start()
    {
        //TODO Load From Save File

        //UpdateButtonsText();
    }

    public void AssignDefaults()
    {
        Forward = KeyCode.W;
        Backward = KeyCode.S;
        Left = KeyCode.A;
        Right = KeyCode.D;

        Jump = KeyCode.Space;
        Crouch = KeyCode.LeftControl;
        Run = KeyCode.LeftShift;

        Spell01 = KeyCode.Mouse0;
        Spell02 = KeyCode.Mouse1;
        Spell03 = KeyCode.E;
        Spell04 = KeyCode.Q;

        //Shoot = KeyCode.Mouse0;
        //Aim = KeyCode.Mouse1;
        Reload = KeyCode.R;

        Pickup = KeyCode.F;
        Drop = KeyCode.G;

        sensitivity = 5f;
        aimMult = 1f;
    }


    public void SetKeyCode(GameObject button)
    {
        lastButton = button;

        isChanging = true;
        ///lastButton.GetComponent<SettingsButtonUpdater>().UpdateButton(KeyCode.None);
    }

    void OnGUI()
    {
        if (!isChanging) { return; }

        Event e = Event.current;
        if (e.isKey)
        {
            FindKey(lastButton.name) = e.keyCode;
            //lastButton.GetComponent<SettingsButtonUpdater>().UpdateButton(FindKey(lastButton.name));

            CheckSimilar();

            isChanging = false;
        }
    }

    private void CheckSimilar()
    {
        foreach (GameObject n in buttons)
        {
            if (n == lastButton) { continue; }

            //if (n.GetComponentInChildren<TMP_Text>().text == lastButton.GetComponentInChildren<TMP_Text>().text)
            //{
            //    n.GetComponentInChildren<SettingsButtonUpdater>().UpdateButton(KeyCode.None);
            //    FindKey(n.GetComponentInChildren<TMP_Text>().text) = nullKey;
            //}
        }
    }

    private void UpdateButtonsText()
    {
        //foreach (GameObject n in buttons)
        //{
        //    n.GetComponentInChildren<SettingsButtonUpdater>().UpdateButton(FindKey(n.name));
        //}

        //multSlider.value = aimMult;
        //sensSlider.value = sensitivity;
        UpdateSensText();
    }

    public void UpdateSliders()
    {
        //sensitivity = sensSlider.value;
        //aimMult = multSlider.value;

        UpdateSensText();
    }

    private void UpdateSensText()
    {
        //sensText.text = sensitivity.ToString("F2");
        //multText.text = aimMult.ToString("F2");
    }

    private ref KeyCode FindKey(string keyName)
    {
        switch (keyName)
        {
            case "Forward":
                return ref Forward;
            case "Backward":
                return ref Backward;
            case "Left":
                return ref Left;
            case "Right":
                return ref Right;
            case "Jump":
                return ref Jump;
            case "Crouch":
                return ref Crouch;
            case "Walk":
                return ref Run;
            case "Reload":
                return ref Reload;
            case "Drop":
                return ref Drop;
            case "Pickup":
                return ref Pickup;
            case "Shoot":
                return ref Shoot;
            case "Aim":
                return ref Aim;

            default:
                return ref nullKey;

        }
    }
}