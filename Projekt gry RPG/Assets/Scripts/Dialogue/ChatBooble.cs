using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class ChatBooble : MonoBehaviour{
    // Start is called before the first frame update
public static void Create(Transform parent, Vector3 localPosition, string text){

Transform chatBoobleTransform = Instantiate(GameAssets.i.pfChatBooble, parent);
chatBoobleTransform.localPosition = localPosition;

chatBoobleTransform.GetComponent<ChatBooble>().Setup(text);

Destroy(chatBoobleTransform.gameObject, 4f);
}


private SpriteRenderer backgroundSpriteRenderer;
private SpriteRenderer iconSpriteRenderer;
private TextMeshPro textMeshPro;

private void Awake() {

backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
}

private void Setup (string text) {
textMeshPro.SetText(text);
textMeshPro.transform.Rotate(0f, 0f, 0f);
textMeshPro.ForceMeshUpdate();
textMeshPro.transform.localPosition = new Vector3(0.0f, -4.5f, 0f);

Vector2 textSize = textMeshPro.GetRenderedValues (false);

//wielkość black boxa
Vector2 padding=new Vector2(7f, 2f);
backgroundSpriteRenderer.size = textSize + padding;
// padding blackboxa
Vector3 offset = new Vector3(-3f,-3.5f);
backgroundSpriteRenderer.transform.localPosition = new Vector3(backgroundSpriteRenderer.size.x / 2f,0f) + offset;


}



}
