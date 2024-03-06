using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using TMPro;
using UnityEngine;
using Oculus.Interaction.Input;

public class reorderTest : MonoBehaviour
{
  public OVRCameraRig ovrCameraRig;
  private Camera ovrCamera;
  public GameObject functionKeys;
  public TextMeshProUGUI logGUI;
  public TextMeshProUGUI initPointGUI;
  public TextMeshProUGUI pointerGUI;
  public TextMeshProUGUI finalPointGUI;
  public TextMeshProUGUI CaretGUI;
  public TextMeshProUGUI textGUI;
  public TextMeshProUGUI caretPositionGUI;

  public Vector3 initCaretPosition;
  public Vector3 finalCaretPosition;

  public int characterIndex;
  public int finalCharIndex;

  private string beforeBold;
  private string boldChars;
  private string afterBold;

  public bool selectedFlag = false;

  bool correctOrder = false;
  // Start is called before the first frame update
  void Start()
  {
    CaretGUI.text = "This is a <mark=#479ff8>call</mark> <mark=#ec6d57>phone</mark>";
    textGUI.text = "This is a call phone";
    ovrCamera = ovrCameraRig.centerEyeAnchor.GetComponent<Camera>();
  }

  public void reorderMove()
  {
    if (!correctOrder)
    {
      CaretGUI.text = "This is a <mark=#479ff8>phone</mark> <mark=#ec6d57>call</mark>";
      textGUI.text = "This is a phone call";
      correctOrder = true;
    }
    else
    {
      CaretGUI.text = "This is a <mark=#479ff8>call</mark> <mark=#ec6d57>phone</mark>";
      textGUI.text = "This is a call phone";
      correctOrder = false;
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
