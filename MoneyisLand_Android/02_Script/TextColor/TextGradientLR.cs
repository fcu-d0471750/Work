//文字漸層效果(左右)
using UnityEngine;
using System.Collections;
using  UnityEngine.UI;   //使用UI
using System;            //系統時間

[AddComponentMenu( "UI/Effects/Gradient" )]
public class TextGradientLR : BaseMeshEffect {

	//宣告變數
	public Color32 leftColor = Color.black;
	public Color32 rightColor = Color.white;

	/*public Byte TR;
	public Byte TG;
	public Byte TB;
	public Byte TA = 255;

	public Byte BR;
	public Byte BG;
	public Byte BB;
	public Byte BA = 255;

	bool updown = true;*/

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		/*if (updown) {
			if (TR < 255)
				TR++;
			if (TG < 0)
				TG++;
			if (TB < 248)
				TB++;
			if (TR == 255 && TG == 0 && TB == 248)
				updown = false;
		} else {
			if (TR > 0)
				TR--;
			if (TG > 0)
				TG--;
			if (TB > 0)
				TB--;
			if (TR == 0 && TG == 0 && TB == 0)
				updown = true;
		}

		leftColor.r = TR;
		leftColor.g = TG;
		leftColor.b = TB;*/
		//rightColor = new Color32 (TR,TG,TB,TA);
		//leftColor = new Color32(TR,TG,TB,TA);

	}

	//文字漸層效果***********************************************************************************
	public  override void ModifyMesh( VertexHelper vh )
	{

		float leftX = -1;
		float rightX = -1;

		for ( int i = 0; i < vh.currentVertCount; i++ )
		{
			UIVertex v = new UIVertex();
			vh.PopulateUIVertex( ref v , i );

			if ( leftX == -1 ) 
				leftX = v.position.x;
			if ( rightX == -1 ) 
				rightX = v.position.x;

			if ( v.position.x > rightX ) 
				rightX = v.position.x;
			else if ( v.position.x < leftX ) 
				leftX = v.position.x;
		}


		float uiElementHeight = rightX - leftX;

		for ( int i = 0; i < vh.currentVertCount; i++ )
		{
			UIVertex v = new UIVertex();
			vh.PopulateUIVertex( ref v , i );

			v.color = Color32.Lerp( leftColor, rightColor, (v.position.x - leftX) / uiElementHeight );
			vh.SetUIVertex( v, i );

		}
	}//文字漸層效果結束***********************************************************************************

}
