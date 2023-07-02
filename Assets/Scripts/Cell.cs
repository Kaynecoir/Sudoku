using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerClickHandler
{
	public UGameManager GM;
	public Vector2Int position;
	public int number;
	public Image image;
	private void Start()
	{
		image = GetComponent<Image>();
		GM = GameObject.Find("GameManager").GetComponent<UGameManager>();
		//if (image == null) Debug.Log(gameObject.name + "don't find image");
	}

	public void SetPosition(Vector2Int vect) => position = vect;
	public void SetPosition(int x, int y)
	{
		position.x = x;
		position.y = y;
	}

	public void SetValue(int val)
	{
		number = val;
	}
	public void SetImage(Sprite spr)
	{
		image.sprite = spr;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		GM.ChangeCurrentCell(this);
	}
}
