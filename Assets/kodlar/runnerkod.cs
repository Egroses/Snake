using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class runnerkod : MonoBehaviour
{
	public Material material;
	public float playerSpeed=30f;
	public List<Transform> target;
	public float speed=60f;
	public float yatayHareket=0f;
	public float ileriHareket=0f;
	public UnityEngine.UI.Text yemek;
	public int yenecek=100;
	public bool lose=false;

	public Button tekrar;
	public Button DurumButon;
	public Text DurumText;
	public List<Button> yonTuslari;
	public Material bittiMat;
	public UnityEngine.UI.Text seviyeText;
	public Vector3 startPoint;
	private void Awake() {
		startPoint = transform.position;
        tekrar.gameObject.SetActive(false);
		DurumButon.gameObject.SetActive(false);

	}
    private void Update() {
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			solaGit();
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			sagaGit();
		}
		if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
			yatayDur();
		}
		if (Input.GetKeyUp(KeyCode.RightArrow))
		{
			yatayDur();
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			ileriGit();
		}
		if (Input.GetKeyUp(KeyCode.UpArrow))
		{
			ileriDur();
		}
		if (yenecek==0){
			DurumText.text="<b>Kazandın</b>";
			tekrar.gameObject.SetActive(true);
			DurumButon.gameObject.SetActive(true);
			for(int i=0;i<yonTuslari.Count;i++){
				yonTuslari[i].interactable=false;
			}
		}
		else if(lose){
			DurumText.text="<b>Kaybettin</b>";
			tekrar.gameObject.SetActive(true);
			DurumButon.gameObject.SetActive(true);
			for(int i=0;i<yonTuslari.Count;i++){
				yonTuslari[i].interactable=false;
			}
		}
		else{
			yemek.text=yenecek+"";
			if(transform.position.x>9)
				transform.position=new Vector3(9,transform.position.y,transform.position.z);
			if(transform.position.x<-8.8)
				transform.position=new Vector3(-8.8f,transform.position.y,transform.position.z);
			transform.position=new Vector3(transform.position.x+yatayHareket*playerSpeed*Time.deltaTime,transform.position.y,transform.position.z+ileriHareket*playerSpeed*Time.deltaTime);

			for(int i=0;i<target.Count;i++){
				Vector3 mesafe= transform.position-target[i].transform.position;
				Vector3 velocity=mesafe.normalized*speed;
				if(mesafe.magnitude>(i+0.1f)+1.5f){
				target[i].transform.Translate(velocity*(Time.deltaTime));
			}
			
			}
		}
		if(transform.position.y <= -5)
        {
			lose = true;
		}
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag=="yem"){
			if(target.Count<5){
				
				target.Add(other.gameObject.transform);
				other.gameObject.transform.position=transform.position;	
				other.gameObject.GetComponent<MeshRenderer>().material=	material;
				other.gameObject.tag="kuyruk";
				seviyeText.text=target.Count+"";
				
				if(target.Count==5){
					seviyeText.text="MAX";
					playerSpeed=42f;
				}
			}
			else{
				yenecek--;
				Destroy(other.gameObject);
			}
			
		}
		if(other.gameObject.tag=="auch"){
			playerSpeed=30f;
			Destroy(other.gameObject);
			if(target.Count!=0){
				Destroy(target[target.Count-1].gameObject);
				target.RemoveAt(target.Count-1);
				seviyeText.text=target.Count+"";
			}
			else{
				lose=true;
			}
		//	reference.Child("users").Child(UserConfigs.userID).Child("score").SetValueAsync(target.Count);
		}
		
	}


	public void solaGit(){
		while(yatayHareket>=-1f){
			yatayHareket=yatayHareket-0.1f ;
					}
	}
	public void sagaGit(){
		while(yatayHareket<=1f){
			yatayHareket=yatayHareket+0.1f ;
		}
	}
	public void yatayDur(){
		yatayHareket=0f;
	}

	public void ileriGit(){
		while(ileriHareket<=1f){
			ileriHareket=ileriHareket+0.2f ;
		}
	}
	public void ileriDur(){
		ileriHareket=0f;
	}
	public void TekrarOyna(){
		SceneManager.LoadScene("Oyun");
	}

}
