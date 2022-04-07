using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthImage : MonoBehaviour {
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    [SerializeField] Image image;
    [SerializeField] int healthLevel;

    public int HealthLevel => healthLevel;

    private void Start() {
        image = GetComponent<Image>();
        UpdateSprite();
    }

    public void HealthUpdate(int amount) {
        if(healthLevel > amount) {
            healthLevel = amount;
            UpdateSprite();
        }
    }

    private void UpdateSprite() {
        image.sprite = sprites[healthLevel];
    }
}
