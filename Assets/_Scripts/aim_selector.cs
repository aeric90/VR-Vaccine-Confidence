using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class aim_selector : MonoBehaviour
{
    public static aim_selector instance;

    public Image progressBar;
    public Image targetDot;

    public float selectionTime;
    public float maxDistance;

    private float currentSelectionTime;
    private GameObject gazedAtObject;

    private bool isSelecting;
    private bool hasClicked = false;

    public TMPro.TextMeshProUGUI countDown;

    private LayerMask UIMask;

    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UIMask = LayerMask.GetMask("UI");
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxDistance, UIMask.value) && hit.transform.CompareTag("Target"))
        {
            if (gazedAtObject != hit.transform.gameObject)
            {
                gazedAtObject?.SendMessage("OnPointerExit");
                gazedAtObject = hit.transform.gameObject;
                gazedAtObject.SendMessage("OnPointerEnter");
                StartSelecting();
            }
        }
        else
        {
            gazedAtObject?.SendMessage("OnPointerExit", SendMessageOptions.DontRequireReceiver);
            gazedAtObject = null;
            StopSelecting();
        }

        if (isSelecting)
        {
            if (!hasClicked)
            {
                currentSelectionTime += Time.unscaledDeltaTime;

                if (currentSelectionTime >= selectionTime)
                {
                    gazedAtObject?.SendMessage("OnPointerClick");
                    currentSelectionTime = 0;
                    hasClicked = true;
                }
            }

            UpdateUI();
        }
        else
        {
            IdleMode();
        }
    }

    public void StartSelecting()
    {
        currentSelectionTime = 0;
        UpdateUI();
        progressBar.enabled = true;
        isSelecting = true;
        countDown.text = "3";
    }

    public void IdleMode()
    {
        currentSelectionTime = selectionTime;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (isSelecting)
        {
            progressBar.fillAmount = Mathf.InverseLerp(0, selectionTime, currentSelectionTime);
            if (currentSelectionTime > 2) { countDown.text = "1"; }
            else if (currentSelectionTime > 1) { countDown.text = "2"; }
        }
    }

    public void StopSelecting()
    {
        progressBar.enabled = false;
        isSelecting = false;
        hasClicked = false;
        countDown.text = "";
    }

    public void ToggleTarget(bool status)
    {
        targetDot.enabled = status;
    }
}
