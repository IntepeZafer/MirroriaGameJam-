using UnityEngine;

public class MyGameManager : MonoBehaviour
{
    public NormalCharacter normalCharacter;
    public InvertedCharacter invertedCharacter;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            normalCharacter.Jump();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            invertedCharacter.Jump();
        }
    }
}
