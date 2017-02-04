using UnityEngine;
using System.Collections;

public class DataLoader : MonoBehaviour {
    public string[] parames;
	// Use this for initialization
	IEnumerator Start() {
        WWW paramData = new WWW("http://localhost:8080/ATFlow/params.php");
        yield return paramData;
        string paramDatastring = paramData.text;
        if (paramDatastring.Length > 0)
        {
            print(paramDatastring);
            parames = paramDatastring.Split(';');
            print(GetDataValue(parames[0], "Name:"));
        }
	}

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if(value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
}
