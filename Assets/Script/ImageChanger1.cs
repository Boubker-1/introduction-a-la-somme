using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger1 : MonoBehaviour
{

	public static int SpriteNumber;
    private Image img;
    private Sprite rod1, rod2, rod3, rod4, rod5;

    public void Start()
    {
        img = this.GetComponent<Image>();
        SpriteNumber = GameControl.slot1;
        rod1 = Resources.Load<Sprite>("1-Rod-Place");
        rod2 = Resources.Load<Sprite>("2-Rod-Place");
        rod3 = Resources.Load<Sprite>("3-Rod-Place");
        rod4 = Resources.Load<Sprite>("4-Rod-Place");
        rod5 = Resources.Load<Sprite>("5-Rod-Place");
        if (SpriteNumber == 1) img.sprite = rod1;
        if (SpriteNumber == 2) img.sprite = rod2;
        if (SpriteNumber == 3) img.sprite = rod3;
        if (SpriteNumber == 4) img.sprite = rod4;
        if (SpriteNumber == 5) img.sprite = rod5;
    }
}
