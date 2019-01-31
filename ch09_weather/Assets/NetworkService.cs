using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NetworkService : MonoBehaviour {
	private const string xmlApi = 
		"https://www.tianqiapi.com/api/?version=v1";
	private const string webImage = 
		"https://ss0.bdstatic.com/94oJfD_bAAcT8t7mm9GUKT-xh_/timg?image&quality=100&size=b4000_4000&sec=1548920168&di=c509119cc2093e0058c8d6ccef325946&src=http://bpic.ooopic.com/16/05/57/16055749-347afdd645b72d145ead7f91075a4c10.jpg";
	private bool IsResponseValid(WWW www){
		if (www.error != null) {
			Debug.Log ("bad connection");
			return false;
		} else if (string.IsNullOrEmpty (www.text)) {
			Debug.Log ("bad data");
			return false;
		} else {
			return true;
		}
	}

	private IEnumerator CallAPI(string url, Action<string> callback){
		WWW www = new WWW (url);
		yield return www;

		if (!IsResponseValid(www)){
			yield break;
		}
		callback (www.text);
			
	}

	public IEnumerator GetWeatherXML(Action<string> callback){
		return CallAPI (xmlApi, callback);
	}

	public IEnumerator DownloadImage(Action<Texture2D> callback){
		WWW www = new WWW (webImage);
		yield return www;
		callback (www.texture);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
