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
	  public Color realColor;
    }

    public List<ColorsToLines> colorsToLines;

    public float Distance { get; set; }

	void Awake ()
	{
	    if (Instance != null)
	    {
	        Instance.Distance = 0;
	        Destroy(gameObject);
	    }

	    Instance = this;
        DontDestroyOnLoad(this);
    }

	private List<Line> Lines(){
		return colorsToLines.Select (colorToLine => colorToLine.line).ToList();
	}

	private List<string> Colors(){
		return colorsToLines.Select (colorToLine => colorToLine.color).ToList();
	}
		
	public ColorsToLines Line(int encodedValue){
		return colorsToLines.Find(colorToLine => colorToLine.encodedValue == encodedValue);
	}
	public Line Line(string color){
    	return colorsToLines.Find(colorToLine => colorToLine.color == color).line;
  	}
	public ColorsToLines ColorToLines(string color){
		return colorsToLines.Find (colorToLine => colorToLine.color == color);
	}

  public Line RandomLine(){
		return Lines()[UnityEngine.Random.Range(0, colorsToLines.Count)];
  }

	public ColorsToLines RandomColorToLine(){
		return colorsToLines [UnityEngine.Random.Range (0, colorsToLines.Count)];
	}

	public ColorsToLines RandomColorToNon3DLine(){
		var plainColorToLines = colorsToLines.Where (colorToLine => colorToLine.line.z == 0).ToList ();
		return plainColorToLines[UnityEngine.Random.Range (0, plainColorToLines.Count)];
	}
}
