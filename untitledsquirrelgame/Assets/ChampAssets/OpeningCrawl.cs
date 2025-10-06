using UnityEngine;

public class OpeningCrawl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float scrollSpeed = 20f;
    public float endY = 1000f;

    private RectTransform rectTransform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        if (rectTransform.anchoredPosition.y >= endY)
        {
            gameObject.SetActive(false);
        }
    }
}

/*
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningCrawl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Crawl Settings")]
    public float scrollSpeed = 20f;
    public float scrollBoost = 40f;
    public float endY = 1000f;
    public string nextSceneName = "MainScene";

    private RectTransform rectTransform;
    private float currentSpeed;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        currentSpeed = scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        ScrollCrawl();
        
        rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        if (rectTransform.anchoredPosition.y >= endY)
        {
            gameObject.SetActive(false);
        }
        
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            LoadNextScene();
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            currentSpeed += scroll * scrollBoost;
            currentSpeed = Mathf.Clamp(currentSpeed, 5f, 200f);
        }
    }

    void ScrollCrawl()
    {
        rectTransform.anchoredPosition += Vector2.up * currentSpeed * Time.deltaTime;

        if (rectTransform.anchoredPosition.y >= endY)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
*/