using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class testscript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private HeroManager heroManager;
    private GameManager gameManager;


    void Start()
    {
        gameManager = GameManager.instance; 
        // heroManager = gameManager.heroManager;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnMouseOver()
    {
        Debug.Log("Mouse is over the GameObject.");
        // tooltip.SetActive(true);
    }

    void FixedUpdate()
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("pointe!");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
