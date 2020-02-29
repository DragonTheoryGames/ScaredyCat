using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {
    
    [SerializeField] GameObject Cat;
 
    // Update is called once per frame
    void Update() {
        SetPosition();
        UpdateValue();
    }

    void SetPosition(){
        float CatPosX = Cat.GetComponent<Transform>().position.x;
        float CatPosY = Cat.GetComponent<Transform>().position.y + 2;
        GetComponent<Transform>().position = new Vector2(CatPosX, CatPosY);
    }

    void UpdateValue(){
        this.GetComponent<Slider>().value = Cat.GetComponent<Talisman>().GetEnergy(); 
    }
}
