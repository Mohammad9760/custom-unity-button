# custom-unity-button

here's the video demonstration: http://youtu.be/3Zcdc33xbFQ

using this script on your UI gameobjects you can detect clicks and double clicks using conditionals.
create a variable of type Btn and use it in an if statement.
eg:

Btn fireBtn;

void Start(){
  fireBtn = GameObject.Find("Fire Button").GetComponent<Btn>();
}

void Update(){
  
    if(fireBtn.Clicked)
      Debug.Log("bang")
      
    if(fireBtn.DoubleClicked)
      Debug.Log("bang bang")

}
