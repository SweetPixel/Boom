#pragma strict

function Start () {

}

function Update () {
if (Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Moved || Input.GetKey(KeyCode.Mouse0)) {
    var touchDelta : Vector2 = Input.GetTouch(0).deltaPosition;
    transform.Translate (-touchDelta.x, 0, 0);
}
}