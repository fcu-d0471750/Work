//文字漸層效果(上下)
using UnityEngine;
using System.Collections;
using UnityEngine.UI;   //使用UI
using System;            //系統時間

[AddComponentMenu( "UI/Effects/Gradient" )]
public class TextGradient : BaseMeshEffect {

	//宣告變數
	public Color32 topColor = Color.white;
	public Color32 bottomColor = Color.black;

	/*public Byte TR;
	public Byte TG;
	public Byte TB;
	public Byte TA;

	public Byte BR;
	public Byte BG;
	public Byte BB;
	public Byte BA;*/

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//topColor = new Color32 (TR,TG,TB,TA);
		//bottomColor = new Color32 (BR,BG,BB,BA);
	}

	//文字漸層效果***********************************************************************************
	public  override void ModifyMesh( VertexHelper vh )
	{
		
		float bottomY = -1;
		float topY = -1;

		for ( int i = 0; i < vh.currentVertCount; i++ )
		{
			UIVertex v = new UIVertex();
			vh.PopulateUIVertex( ref v, i );

			if ( bottomY == -1 ) 
				bottomY = v.position.y;
			if ( topY == -1 ) 
				topY = v.position.y;

			if ( v.position.y > topY ) 
				topY = v.position.y;
			else if ( v.position.y < bottomY ) 
				bottomY = v.position.y;
		}


		float uiElementHeight = topY - bottomY;

		for ( int i = 0; i < vh.currentVertCount; i++ )
		{
			UIVertex v = new UIVertex();
			vh.PopulateUIVertex( ref v, i );

			v.color = Color32.Lerp( bottomColor, topColor, (v.position.y - bottomY) / uiElementHeight );
			vh.SetUIVertex( v, i );
		}
	}//文字漸層效果結束***********************************************************************************

}
