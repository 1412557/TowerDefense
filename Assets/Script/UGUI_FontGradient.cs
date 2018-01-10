using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// code changed from Unity3D gradient effect for Unity3D 5.2
/// REF : http://pastebin.com/dJabCfWn
/// </summary>
[AddComponentMenu ("UI/Effects/Gradient")]
public class UGUI_FontGradient : UnityEngine.UI.BaseMeshEffect
{
	[SerializeField]
	private Color32 topColor = Color.white;
	[SerializeField]
	private Color32 bottomColor = Color.black;

	public override void ModifyMesh( VertexHelper vh )
	{
		if( !IsActive() ) { return; }

		List < UIVertex > stream = new List<UIVertex>();
		vh.GetUIVertexStream( stream );

		//UIVertex tv; vh.PopulateUIVertex( ref tv, 0 );

		float bottomY = stream[0].position.y;
		float topY = stream[0].position.y;

		for( int i = 1; i < vh.currentVertCount; i++ )
		{
			float y = stream[i].position.y;
			if( y > topY )
			{
				topY = y;
			}
			else if( y < bottomY )
			{
				bottomY = y;
			}
		}

		float uiElementHeight = topY - bottomY;
		UIVertex uiv = new UIVertex();
		for( int i = 0; i < vh.currentVertCount; i++ )
		{
			vh.PopulateUIVertex( ref uiv, i );
			uiv.color = Color32.Lerp( bottomColor, topColor, (uiv.position.y - bottomY) / uiElementHeight );
			vh.SetUIVertex( uiv, i );
		}
	}
}