#pragma strict

public var speed : float = 10f;


function Update ()
{
	var axis = new Vector3(0,1,0);
    transform.Rotate(axis, speed * Time.deltaTime);
}