using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CircularMenu : MonoBehaviour
{
    public List<MenuButton> buttons = new List<MenuButton>();
    private Vector2 mousePosition;
    private Vector2 fromVector2M = new Vector2(0.5f,1.0f);
    private Vector2 centerCircle = new Vector2(0.5f,0.5f);
    private Vector2 toVector2M;
    public int menuItems;
    public int currentMenuItem;
    private int oldMenuItem;
    // Use this for initialization
    void Start()
    {
        menuItems=buttons.Count;
        foreach(MenuButton button in buttons)
        {
            button.sceneImage.color = button.normalColor;
        }
        currentMenuItem=0;
        oldMenuItem=0;
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentMenuItem();

    }

    public void GetCurrentMenuItem()
    {
        mousePosition = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        toVector2M = new Vector2(mousePosition.x/Screen.width,mousePosition.y/Screen.height);
        float angle = (Mathf.Atan2(fromVector2M.y-centerCircle.y, fromVector2M.x -centerCircle.x) - Mathf.Atan2(toVector2M.y - centerCircle.y, toVector2M.x - centerCircle.x)) * Mathf.Rad2Deg;
        if(angle < 0)
        {
            angle+=360;
        }
        currentMenuItem = (int) (angle/(360/menuItems));
        if(currentMenuItem != oldMenuItem)
        {
            buttons[oldMenuItem].sceneImage.DOColor(buttons[oldMenuItem].normalColor,0.3f);
            oldMenuItem = currentMenuItem;
            buttons[oldMenuItem].sceneImage.DOColor(buttons[oldMenuItem].highlightedColor, 0.3f);
        }
    }

    IEnumerator ReturnColor()
    {
        yield return new WaitForSeconds(0.1f);
        buttons[currentMenuItem].sceneImage.DOColor(buttons[currentMenuItem].highlightedColor, 0.3f);
    }
}

[System.Serializable]
public class MenuButton
{
    public string name;
    public Image sceneImage;
    public Color normalColor = Color.white;
    public Color highlightedColor = Color.grey;
    public Color pressedColor = Color.gray;
    public string weapon;
}
