using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System; 
public class GlobalConfig : MonoBehaviour
{
    public static GlobalConfig Instance;

    [Serializable]
    public struct ColorsToLines {
      public string color;
	  public Line line;
	  public int encodedValue;
    }

    public List<ColorsToLines> colorsToLines;

	void Start ()
    {
	    if (Instance != null)
	    {
	        Destroy(gameObject);
	    }

	    Instance = this;
    }
		
	public Line Line(int encodedValue){
		return colorsToLines.Find(colorToLine => colorToLine.encodedValue == encodedValue).line;
	}
	public Line Line(string color){
    	return colorsToLines.Find(colorToLine => colorToLine.color == color).line;
  	}

  public Line RandomLine(){
		return colorsToLines.Select(colorToLine => colorToLine.line).ToList()[UnityEngine.Random.Range(0, colorsToLines.Count)];
  }
}
